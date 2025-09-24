

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SGA.Domain.Base;
using SGA.Domain.Repository;
using SGA.Persistence.Context;
using System.Linq.Expressions;

namespace SGA.Persistence.Base
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly SGAContext _context;
        private DbSet<TEntity> _entities;

        public BaseRepository(SGAContext context)
        {
            _context = context;
            _entities = _context.Set<TEntity>();
        }

        public async virtual Task<bool> Exists(Expression<Func<TEntity, bool>> filter)
        {
            return await _entities.AnyAsync(filter);
        }

        public async virtual Task<OperationResult> GetAll()
        {
            OperationResult result = new OperationResult();

            result.Data = await _entities.ToListAsync();

            return result;
        }

        public async virtual Task<OperationResult> GetAll(Expression<Func<TEntity, bool>> filter)
        {
            OperationResult result = new OperationResult();

            result.Data = await _entities.Where(filter).ToListAsync();

            return result;
        }

        public async virtual Task<OperationResult> GetEntityBy(int Id)
        {
            OperationResult result = new OperationResult();

            result.Data = await _entities.FindAsync(Id);

            return result;
        }

        public async virtual Task<OperationResult> Remove(TEntity entity)
        {
            OperationResult result = new OperationResult();

            _entities.Remove(entity);
            await _context.SaveChangesAsync();

            return result;
        }

        public async virtual Task<OperationResult> Save(TEntity entity)
        {
            OperationResult result = new OperationResult();

            _entities.Add(entity);
            await _context.SaveChangesAsync();

            return result;
        }

        public async virtual Task<OperationResult> Update(TEntity entity)
        {
            OperationResult result = new OperationResult();

            _entities.Update(entity);
            await _context.SaveChangesAsync();

            return result;
        }
    }
}
