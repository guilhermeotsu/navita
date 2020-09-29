using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Nativa.Core.Model;
using Nativa.Data.Context;
using Navita.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Nativa.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Base, new()
    {
        protected readonly MainDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;
        public Repository(MainDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public virtual async Task Add(TEntity entity)
        {
            _context.Add(entity);
            await SaveChanges();
        }

        public virtual async Task<bool> Delete(int id)
        {
            _dbSet.Remove(new TEntity { Id = id });
            return await SaveChanges() == 1;
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<TEntity> Update(TEntity entity)
        {
            _dbSet.Update(entity);
            await SaveChanges();

            return entity;
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

        public async Task<bool> IsAny<T>(IEnumerable<T> data)
        {
            return data != null && data.Any();
        }
    }
}
