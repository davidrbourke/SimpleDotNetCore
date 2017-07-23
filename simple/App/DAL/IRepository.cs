using System.Threading.Tasks;
using System;
using System.Linq.Expressions;
using MongoDB.Bson;

namespace Simple.DAL
{
    public interface IRepository<TEntity>
    {
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter);
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(string id, TEntity entity);
        Task DeleteAsync(string id);
    }
}