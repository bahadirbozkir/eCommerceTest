using CampaignService.DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CampaignService.DAL.Entity
{
    public class Campaign : BaseEntity
    {
        [Column(TypeName = "varchar(250)")]
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DiscountType DiscountType { get; set; }

        #region Navigation Properties

        [ForeignKey("CampaignId")]
        public virtual ICollection<Condition> Conditions { get; set; }

        [ForeignKey("CampaignId")]
        public virtual ICollection<Action> Actions { get; set; }

        #endregion

        #region Navigation Properties

        [ForeignKey("ConditionId")]
        public virtual ICollection<ConditionProduct> ConditionProducts { get; set; }

        #endregion

    }
}
