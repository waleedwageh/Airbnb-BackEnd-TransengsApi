using System.Linq;
using Domain.Entities;
using Domain.Specfication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.SpecificationEvaluators
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
       

        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputquery,
        ISpecifecation<TEntity> spec)
        {
            var query = inputquery;
           
            if (spec.Criteria != null)
            {
              query =  query.Where(spec.Criteria);
            }

            if (spec.OrderBy != null)
            {
                query = query.OrderBy(spec.OrderBy);
            }

            if (spec.OrderByDescending != null)
            {
                query = query.OrderByDescending(spec.OrderByDescending);
            }
           
           
           
            if (spec.isPagingEnabled)
            {
                query = query.Skip(spec.Skip).Take(spec.Take);
            }

            
            
            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));

            return query;
        }
    }
}