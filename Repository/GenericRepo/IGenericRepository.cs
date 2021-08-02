using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.GenericRepo
{
    public interface IGenericRepository<T> where T : class
    {
        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);

        /// <summary>
        /// Gets Collection of objects using no parameters
        /// </summary>
        /// <returns></returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// Gets Collection of objects using delegate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Gets single object using delegate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        T GetOneBy(Expression<Func<T, bool>> predicate);
    }
}
