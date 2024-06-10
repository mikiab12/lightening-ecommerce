using Lightening.Ecommerce.Data.Context;
using Lightening.Ecommerce.Domain.Entities;
using Lightening.Ecommerce.Domain.Repositories;

namespace Lightening.Ecommerce.Data.Repositories
{
    public class ProductListPriceHistoryRepository : RepositoryBase<ProductListPriceHistory>, IProductListPriceHistoryRepository
    {
        public ProductListPriceHistoryRepository(AdventureWorksContext context) : base(context)
        {
        }
    }

}
