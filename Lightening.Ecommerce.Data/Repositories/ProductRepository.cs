using Lightening.Ecommerce.Data.Context;
using Lightening.Ecommerce.Domain.Entities;
using Lightening.Ecommerce.Domain.Repositories;

namespace Lightening.Ecommerce.Data.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(AdventureWorksContext context) : base(context)
        {
        }
    }

}
