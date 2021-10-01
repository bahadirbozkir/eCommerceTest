using CampaignService.DAL.Enums;
using System;
using System.Collections.Generic;

namespace CampaignService.BL.Dto.Request
{
    public class CampaignRequest
    {
        public long Id { get; set; }

        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DiscountType DiscountType { get; set; }

        public virtual ICollection<ConditionRequest> Conditions { get; set; }

        public virtual ICollection<ActionRequest> Actions { get; set; }
    }
}
