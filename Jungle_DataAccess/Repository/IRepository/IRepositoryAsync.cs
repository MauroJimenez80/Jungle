using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Jungle_DataAccess.Repository.IRepository
{
    public interface IRepositoryAsync<T> where T : class

    {

        // Les méthodes devant être implantées dans les repositories

        Task<T> GetAsync(int id);

        Task<IEnumerable<T>> GetAllAsync(

        Expression<Func<T, bool>> filter = null,

        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,

        string includeProperties = null

        );

        // Retourne le 1er seulement

        Task<T> FirstOrDefaultAsync(

        Expression<Func<T, bool>> filter = null,

        string includeProperties = null

        );

        Task AddAsync(T entity);

        void RemoveAsync(T entity);

        void RemoveRangeAsync(IEnumerable<T> entity);

    }

}
