using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Domain.Entities;

namespace Domain.Specfication
{
    public interface ISpecifecation<T>  where T:BaseEntity
    {Expression<Func<T,bool>> Criteria{get;}
         List<Expression<Func<T,Object>>> Includes{get;}
         Expression<Func<T,Object>> OrderBy{get;  }
         Expression<Func<T,Object>> OrderByDescending{get; }
          int Take { get; }
          int Skip  { get; }
          bool isPagingEnabled{get;}
    }
}