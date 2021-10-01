using CampaignService.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CampaignService.DAL.Context
{
    public interface IDataContext
    {
        DbSet<Campaign> Campaigns { get; set; }
        DbSet<Condition> Conditions { get; set; }
        DbSet<ConditionProduct> ConditionProducts { get; set; }

    }
}
