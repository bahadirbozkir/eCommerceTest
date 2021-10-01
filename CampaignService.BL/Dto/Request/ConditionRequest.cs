using CampaignService.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CampaignService.BL.Dto.Request
{
    public class ConditionRequest
    {
        public long CampaignId { get; set; }

        public ConditionType ConditionType { get; set; }

        public int Quantity { get; set; }

        public decimal Total { get; set; }

        public int MultiplierFactor { get; set; }

    }
}
