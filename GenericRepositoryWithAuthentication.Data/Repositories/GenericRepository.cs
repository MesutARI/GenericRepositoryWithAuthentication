
using GenericRepositoryWithAuthentication.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GenericRepositoryWithAuthentication.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        #region variables

        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        #endregion

        #region GenericRepository
        public GenericRepository(DbContext context)
        {
            this._context = context;
            this._dbSet = context.Set<T>();
        }

        //protected virtual IDbSet<T> DbSet
        //{
        //    get { return _dbSet ?? (_dbSet = _context.Set<T>()); }
        //}

        #endregion

        #region Methods

        #region GetAllAsync

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
        #endregion

        #region GetByIdAsync
        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }
        #endregion

        #region CountWhereAsync

        public async Task<int> CountWhereAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.CountAsync(predicate);
        }
        #endregion

        #region GetWhereAsync

        public async Task<IEnumerable<T>> GetWhereAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        #endregion

        #region AddAsync

        public async Task AddAsync(T Entry)
        {
            await _dbSet.AddAsync(Entry);
        }

        #endregion

        #region Update
        public void Update(T Entry)
        {
            _dbSet.Attach(Entry);
            _context.Entry(Entry).State = EntityState.Modified;
        }

        #endregion

        #region DeleteAsync

        public async Task DeleteAsync(int id)
        {
            T exist_entity = await GetByIdAsync(id);
            _dbSet.Remove(exist_entity);

            //if (context.Entry(entityToDelete).State == EntityState.Detached)
            //{
            //    dbSet.Attach(entityToDelete);
            //}
            //dbSet.Remove(entityToDelete);
        }

        #endregion

        #endregion

    }
}
