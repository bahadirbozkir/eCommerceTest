using CampaignService.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CampaignService.DAL.Entity
{
    public class Action : BaseEntity
    {
        public long CampaignId { get; set; }

        public decimal Amount { get; set; }

        public int Quantity { get; set; }

        public AmountType AmountType { get; set; }
    }
}
