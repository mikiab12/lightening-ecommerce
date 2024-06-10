using Lightening.Ecommerce.Data.Context;
using Lightening.Ecommerce.Domain.Entities;
using Lightening.Ecommerce.Domain.Repositories;

namespace Lightening.Ecommerce.Data.Repositories
{
    public class ProductModelRepository : RepositoryBase<ProductModel>, IProductModelRepository
    {
        public ProductModelRepository(AdventureWorksContext context) : base(context)
        {
        }
    }

}
