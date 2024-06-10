using Lightening.Ecommerce.Data.Context;
using Lightening.Ecommerce.Domain.Entities;
using Lightening.Ecommerce.Domain.Repositories;

namespace Lightening.Ecommerce.Data.Repositories
{
    public class ProductPhotoRepository : RepositoryBase<ProductPhoto>, IProductPhotoRepository
    {
        public ProductPhotoRepository(AdventureWorksContext context) : base(context)
        {
        }
    }

}
