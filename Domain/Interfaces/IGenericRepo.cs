using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Specfication;

namespace Domain.Interfaces
{
    public interface IGenericRepo<T> where T : BaseEntity
    {  
         Task<T> GetByIdAsync(int id);
         Task<IReadOnlyList<T>> ListAllAsync();
         Task<T> GetBySpec(ISpecifecation<T> spec);
         Task<IReadOnlyList<T>> ListAllBySpec(ISpecifecation<T> spec);
         Task<int> CountAsync(ISpecifecation<T> spec);
        Task<T> AddAsync(T obj);
        Task<T> UpdateAsync(T obj);
        Task<bool> DeleteAsync(int id);



    }
}