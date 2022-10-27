using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShiftSystem.Infrastructure.Context;
using ShiftSystem002.Application.Generic.Interfaces;
using ShiftSystem002.Domain.Base;

namespace ShiftSystem.Infrastructure.Service
{
    public class BaseCrudService<TEntity> : IBaseCrudService<TEntity> where TEntity : BaseEntity
    {
        protected readonly DbSet<TEntity> _dbSet;
        private readonly IShiftSystemDbContext _dbContext;
        private readonly IMapper _mapper;

        public BaseCrudService(IShiftSystemDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _dbSet = _dbContext.GetDbSet<TEntity>();
        }

        public virtual async Task<TEntity> Create(TEntity entity)
        {
            await _dbSet.AddAsync(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await GetById(id);

            if (entity == null) throw new Exception("Error deleting entity.");

            _dbSet.Remove(entity);

            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<TEntity>> Get(int top = 50)
        {
            return await _dbSet.Take(top).ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            var entity = await Query().FirstOrDefaultAsync(entity => entity.Id == id);

            if (entity == null)
                throw new Exception("Entity not found");

            return entity;
        }

        public IQueryable<TEntity> Query()
        {
            return _dbSet.AsQueryable();
        }


        public async Task<TEntity> Update(TEntity entity)
        {
            _dbSet.Update(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }
        
        public async Task<TEntity> Update(int id, TEntity entity)
        {
            if (id != entity.Id) throw new Exception("Id doesn't match");

            var existingEntity = await GetById(id);

            _mapper.Map(entity, existingEntity);

            _dbSet.Update(existingEntity);

            return existingEntity;
        }
    }
}
