using AutoMapper;
using CampaignService.BL.Dto.Request;
using CampaignService.BL.Dto.Response;
using CampaignService.BL.Interfaces;
using CampaignService.DAL.Entity;
using CampaignService.DAL.Enums;
using CampaignService.DAL.UOW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampaignService.BL.Services
{
    public class CampaignService : ICampaignService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public CampaignService(IUnitOfWork unitOfWork, ILogger logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<CalculateResponse> Calculate(CalculateRequest request)
        {
            var campaignRepository = _unitOfWork.GetRepository<Campaign>();

            var campaigns = await campaignRepository.FindBy(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now)
                .Include(x => x.Conditions).ThenInclude(co => co.ConditionProducts)
                .Include(x => x.Actions).ToListAsync();

            var appliedCampaigns = new List<CalculateResponse>();

            var campaignRequest = _mapper.Map<List<CampaignRequest>>(campaigns);
            var calculateResponse = _mapper.Map<CalculateResponse>(request);

            calculateResponse.AffectedTotal = calculateResponse.SubTotal;

            foreach (var item in calculateResponse.BasketItems)
                item.AffectedTotal = item.Total;

            foreach (var campaign in campaignRequest)
            {
                switch (campaign.DiscountType)
                {
                    case DiscountType.Cart:
                        CartCalculationAction(calculateResponse, campaign);
                        break;
                    case DiscountType.Product:
                        ProductCalculationAction(calculateResponse, campaign);
                        break;
                    default:
                        break;
                }

                appliedCampaigns.Add(calculateResponse);
            }

            appliedCampaigns = appliedCampaigns.OrderBy(x => x.AffectedTotal).ToList();

            return appliedCampaigns.FirstOrDefault();
        }

        private void CartCalculationAction(CalculateResponse response, CampaignRequest campaign)
        {
            var action = campaign.Actions.FirstOrDefault();

            if (action == null)
                return;

            decimal discountTotal = CalculateTotalByAmountType(action.AmountType, response.AffectedTotal, action.Amount);
            decimal itemDiscountTotal = 0M;

            if (discountTotal <= 0M) return;

            var oneUnitDiscount = discountTotal / response.AffectedTotal;

            foreach (var basketItem in response.BasketItems)
            {
                var itemDiscount = Math.Round(oneUnitDiscount * basketItem.AffectedTotal, 2);

                basketItem.AffectedTotal -= itemDiscount;

                basketItem.AppliedCampaigns.Add(new AppliedCampaignResponse
                {
                    CampaignId = campaign.Id,
                    Name = campaign.Name,
                    DiscountType = campaign.DiscountType,
                    DiscountAmount = itemDiscount,
                    DiscountTypeName = campaign.DiscountType.ToString(),
                    AmountType = action.AmountType
                });

                itemDiscountTotal += itemDiscount;
            }

            if (itemDiscountTotal != discountTotal)
            {
                var difference = discountTotal - itemDiscountTotal;

                response.BasketItems.First().AffectedTotal -= difference;
                response.BasketItems.First().AppliedCampaigns.First(c => c.CampaignId == campaign.Id).DiscountAmount -= difference;
                itemDiscountTotal += difference;
            }

            response.AffectedTotal -= itemDiscountTotal;
        }

        private void ProductCalculationAction(CalculateResponse response, CampaignRequest campaign)
        {
            var action = campaign.Actions.FirstOrDefault();
            var condition = campaign.Conditions.FirstOrDefault();
            var basketItems = response.BasketItems;

            var applyingQuantity = condition.MultiplierFactor * action.Quantity;

            basketItems = basketItems.OrderBy(x => x.NewPrice).ToList();

            foreach (var basketItem in basketItems)
            {
                if (applyingQuantity <= 0)
                    continue;

                decimal itemAffectedTotal;
                if (basketItem.Quantity >= applyingQuantity)
                {
                    itemAffectedTotal = basketItem.AffectedTotal / basketItem.Quantity * applyingQuantity;
                    applyingQuantity = 0;
                }
                else
                {
                    itemAffectedTotal = basketItem.AffectedTotal;
                    applyingQuantity -= basketItem.Quantity;
                }

                var itemDiscount = CalculateTotalByAmountType(action.AmountType, itemAffectedTotal,
                    action.Amount);

                basketItem.AppliedCampaigns.Add(new AppliedCampaignResponse
                {
                    CampaignId = campaign.Id,
                    Name = campaign.Name,
                    DiscountType = campaign.DiscountType,
                    DiscountAmount = itemDiscount,
                    DiscountTypeName = campaign.DiscountType.ToString(),
                    AmountType = action.AmountType
                });

                basketItem.AffectedTotal -= itemDiscount;
                response.AffectedTotal -= itemDiscount;
            }
        }

        private static decimal CalculateTotalByAmountType(AmountType amountType, decimal affectedTotal, decimal actionAmount)
        {
            decimal discountTotal = 0M;

            switch (amountType)
            {                
                case AmountType.Percent:
                    discountTotal = affectedTotal * actionAmount / 100;
                    break;
            }

            return Math.Round(discountTotal, 2);
        }
    }
}
