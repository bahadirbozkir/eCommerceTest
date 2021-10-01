using CampaignService.DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CampaignService.DAL.Entity
{
    public class Condition : BaseEntity
    {
        public long CampaignId { get; set; }

        public ConditionType ConditionType { get; set; }

        public int Quantity { get; set; }

        public decimal Total { get; set; }

        public int MultiplierFactor { get; set; }


        [ForeignKey("ConditionId")]
        public virtual ICollection<ConditionProduct> ConditionProducts { get; set; }
    }
}
