using CampaignService.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CampaignService.DAL.GenericRepository
{
    public interface IGenericRepository<T> where T: BaseEntity
    {
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
    }
}
