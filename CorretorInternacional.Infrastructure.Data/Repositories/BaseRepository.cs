using CorretorInternacional.Domain.Interfaces.Repositories;
using CorretorInternacional.Domain.Models;
using CorretorInternacional.Infrastructure.Data.Context;

using Microsoft.EntityFrameworkCore;

using System.Linq.Expressions;

namespace CorretorInternacional.Infrastructure.Data.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly ApplicationDbContext DbContext;
        protected readonly DbSet<TEntity> DbSet;
        protected BaseRepository(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
            DbSet = dbContext.Set<TEntity>();

        }

        public virtual async Task InsertAsync(TEntity entity)
        {
            DbSet.Add(entity);

            await SaveChanges();
        }

        public virtual async Task InsertAsync(IEnumerable<TEntity> entity)
        {
            await DbSet.AddRangeAsync(entity);

            await SaveChanges();
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            DbSet.Update(entity);

            await SaveChanges();
        }

        public virtual async Task UpdateAsync(IEnumerable<TEntity> entity)
        {
            DbSet.UpdateRange(entity);

            await SaveChanges();
        }

        public virtual async Task DeleteAsync(TEntity entity)
        {
            DbSet.Remove(entity);

            await SaveChanges();
        }

        public virtual async Task DeleteAsync(IEnumerable<TEntity> entities)
        {
            DbSet.RemoveRange(entities);

            await SaveChanges();
        }

        public virtual async Task<TEntity> GetById<T>(T id) => await DbSet.FirstOrDefaultAsync(entity => entity.Id == id.ToString());

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return await DbSet
                .AsNoTracking()
                .ToListAsync();
        }

        public virtual async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await DbSet
                .AsNoTracking()
                .FirstOrDefaultAsync(expression);
        }

        public virtual async Task<IEnumerable<TEntity>> WhereAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await DbSet
                .AsNoTracking()
                .Where(expression).ToListAsync();
        }

        public virtual bool Any(Expression<Func<TEntity, bool>> expression)
        {
            return DbSet
                .AsNoTracking()
                .Any(expression);
        }

        public virtual async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await DbSet
                .AsNoTracking()
                .AnyAsync(expression);
        }

        public virtual int Count(Expression<Func<TEntity, bool>> expression)
        {
            return DbSet
                .AsNoTracking()
                .Count(expression);
        }

        public virtual async Task<int> CountAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await DbSet
                .AsNoTracking()
                .CountAsync(expression);
        }

        public virtual async Task<int> SaveChanges()
        {
            try
            {
                return await DbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                return 0;
            }
        }

        public void Dispose()
        {
            DbContext?.Dispose();
        }
    }
}
