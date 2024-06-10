using Lightening.Ecommerce.Data.Context;
using Lightening.Ecommerce.Domain.Repositories;
using System.Linq.Expressions;

namespace Lightening.Ecommerce.Data.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected AdventureWorksContext _context;

        public RepositoryBase(AdventureWorksContext context)
        {
            _context = context;
        }

        public IQueryable<T> AsQueryable()
        {
            return _context.Set<T>().AsQueryable();
        }

        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression).AsQueryable();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
