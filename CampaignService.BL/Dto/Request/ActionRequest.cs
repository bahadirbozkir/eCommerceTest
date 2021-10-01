using CampaignService.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CampaignService.BL.Dto.Request
{
    public class ActionRequest
    {
        public long CampaignId { get; set; }

        public decimal Amount { get; set; }

        public int Quantity { get; set; }

        public AmountType AmountType { get; set; }

        public int MultiplierFactor { get; set; }
    }
}
