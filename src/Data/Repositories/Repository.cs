using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;
        public Repository(DbContext context)
        {
            this.Context = context;
        }
        public async Task AddAsync(TEntity entity) => await Context.Set<TEntity>().AddAsync(entity);

        public async Task AddRangeAsync(IEnumerable<TEntity> entities) => await Context.Set<TEntity>().AddRangeAsync(entities);

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate) => Context.Set<TEntity>().Where(predicate);

        public async Task<IEnumerable<TEntity>> GetAllAsync() => await Context.Set<TEntity>().ToListAsync();

        public async Task<TEntity> GetByIdAsync(long id) => await Context.Set<TEntity>().FindAsync(id);

        public void Remove(TEntity entity) => Context.Set<TEntity>().Remove(entity);

        public void RemoveRange(IEnumerable<TEntity> entities) =>Context.Set<TEntity>().RemoveRange(entities);

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate) => await Context.Set<TEntity>().SingleOrDefaultAsync(predicate);
        

        public async Task Toogle(long id, bool status)
        {
           TEntity entity = await Context.Set<TEntity>().FindAsync(id);

            PropertyInfo propertyInfo = entity.GetType().GetProperty("Status");
            propertyInfo.SetValue(entity, Convert.ChangeType(status, propertyInfo.PropertyType), null);
        }

      
    }
}