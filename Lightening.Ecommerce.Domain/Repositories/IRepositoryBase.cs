using System.Linq.Expressions;

namespace Lightening.Ecommerce.Domain.Repositories
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> Find(Expression<Func<T, bool>> expression);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        IQueryable<T> AsQueryable();
    }
}