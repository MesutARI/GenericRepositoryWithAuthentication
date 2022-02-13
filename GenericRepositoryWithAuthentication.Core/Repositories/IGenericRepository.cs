using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GenericRepositoryWithAuthentication.Core.Repositories
{
    public partial interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id);

        Task<int> CountWhereAsync(Expression<Func<T, bool>> predicate);

        Task<IEnumerable<T>> GetWhereAsync(Expression<Func<T, bool>> predicate);

        Task AddAsync(T Entry);

        void Update(T Entry);

        Task DeleteAsync(int id);

    }
}
