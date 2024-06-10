using Lightening.Ecommerce.Data.Context;
using Lightening.Ecommerce.Domain.Entities;
using Lightening.Ecommerce.Domain.Repositories;

namespace Lightening.Ecommerce.Data.Repositories
{
    public class ProductCategoryRepository : RepositoryBase<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(AdventureWorksContext context) : base(context)
        {
        }
    }

}
