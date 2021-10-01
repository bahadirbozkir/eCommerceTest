using CampaignService.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CampaignService.BL.Dto.Response
{
    public class AppliedCampaignResponse
    {
        public long CampaignId { get; set; }

        public string Name { get; set; }

        public decimal DiscountAmount { get; set; }

        public DiscountType DiscountType { get; set; }

        public bool IsMergeable { get; set; }

        public AmountType AmountType { get; set; }

        public string DiscountTypeName { get; set; }
    }
}
