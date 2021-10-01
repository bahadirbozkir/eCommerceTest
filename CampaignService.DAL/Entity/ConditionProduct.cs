using System;
using System.Collections.Generic;
using System.Text;

namespace CampaignService.DAL.Entity
{
    public class ConditionProduct : BaseEntity
    {
        public long ConditionId { get; set; }

        public long ProductId { get; set; }
    }
}
