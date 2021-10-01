using CampaignService.BL.Dto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CampaignService.BL.Dto.Request
{
    public class CalculateRequest
    {
        public CalculateRequest()
        {
            BasketItems = new List<BasketItemRequest>();
        }

        public long Id { get; set; }

        public long CustomerId { get; set; }

        public string Email { get; set; }

        public decimal ShippingPrice { get; set; }

        public decimal SubTotal { get; set; }

        public List<BasketItemRequest> BasketItems { get; set; }
    }

    public class BasketItemRequest
    {
        public BasketItemRequest()
        {
            AppliedCampaigns = new List<AppliedCampaignResponse>();
        }

        public long Id { get; set; }

        public long BasketId { get; set; }

        public long ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal NewPrice { get; set; }

        public string ProductName { get; set; }

        public decimal Total => NewPrice * Quantity;

        public decimal AffectedTotal { get; set; }

        public List<AppliedCampaignResponse> AppliedCampaigns { get; set; }

    }
}
