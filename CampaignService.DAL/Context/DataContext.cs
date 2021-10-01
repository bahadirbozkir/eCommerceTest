using CampaignService.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CampaignService.DAL.Context
{
    public class DataContext : DbContext, IDataContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options){ }

        #region DBSets

        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<DAL.Entity.Action> Actions { get; set; }
        public DbSet<Condition> Conditions { get; set; }        
        public DbSet<ConditionProduct> ConditionProducts { get; set; }

        #endregion
    }
}
