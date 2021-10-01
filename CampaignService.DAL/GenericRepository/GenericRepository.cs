using CampaignService.DAL.Context;
using CampaignService.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CampaignService.DAL.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T: BaseEntity
    {
        protected DataContext _context;

        public GenericRepository(DataContext context)
        {
            _context = context;
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = _context.Set<T>().Where(predicate);
            return query;
        }
    }
}
