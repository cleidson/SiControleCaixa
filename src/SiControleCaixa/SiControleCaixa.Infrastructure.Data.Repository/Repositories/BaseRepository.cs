using Microsoft.EntityFrameworkCore;
using SiControleCaixa.Infrastructure.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiControleCaixa.Infrastructure.Data.Repository.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly DbContext Context;

        public BaseRepository(DbContext context) : base()
        {
            Context = context;
        }

        public bool Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
            return Context.SaveChanges() > 0;
        }

        public async Task<bool> AddAsync(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
            return await Context.SaveChangesAsync() == 1;
        }

        public void Delete(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
            Context.SaveChanges();
        }

        public TEntity GetById(int id) => Context.Set<TEntity>().Find(id);

        public async Task<TEntity> GetByIdAsync(int id) => await Context.Set<TEntity>().FindAsync(id);

        public IQueryable<TEntity> ListAll() =>Context.Set<TEntity>();

        public async Task<List<TEntity>> ListAllAsync() =>await Context.Set<TEntity>().ToListAsync();

        public bool Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            return Context.SaveChanges() == 1;
        }
    }
}
