using CampaignService.DAL.Context;
using CampaignService.DAL.Entity;
using CampaignService.DAL.GenericRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CampaignService.DAL.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext context;
        public UnitOfWork(DataContext dbContext)
        {
            context = dbContext;
        }

        public IGenericRepository<T> GetRepository<T>() where T : BaseEntity
        {
            return new GenericRepository<T>(context);
        }

        public int SaveChanges(bool useAudit = false)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChangesAsync(bool useAudit = false)
        {
            throw new NotImplementedException();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed && disposing && context != null)
            {
                context.Dispose();
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
