using Microsoft.EntityFrameworkCore.Query;
using PhoneStoreApplication.Models;
using System.Linq.Expressions;

namespace PhoneStoreApplication.Data.Repository
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> GetAsync(
                   Expression<Func<TEntity, bool>> filter = null,
                   Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);

        Task<TEntity> AddAsync(TEntity entity);
    }
}
