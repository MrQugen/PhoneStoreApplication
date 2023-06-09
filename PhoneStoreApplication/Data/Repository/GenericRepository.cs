﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using PhoneStoreApplication.Models;
using System.Linq.Expressions;

namespace PhoneStoreApplication.Data.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly ApplicationContext _context;
    
        public GenericRepository(ApplicationContext context)
        {
            _context = context;
        }
    
        public async Task<IEnumerable<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
    
            if (include != null)
            {
                query = include(query);
            }
    
            if (filter != null)
            {
                query = query.Where(filter);
            }
    
            return await query.ToListAsync();
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);

            int addedRows = await _context.SaveChangesAsync();

            if (addedRows > 0)
            {
                return entity;
            }

            return null;
        }
    }
}
