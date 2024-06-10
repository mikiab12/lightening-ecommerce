using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lightening.Ecommerce.Domain.Repositories
{
    public interface IRepositoryManager
    {
        public IProductRepository Product { get; }
        public IProductCategoryRepository ProductCategory { get; }
        public IProductModelRepository ProductModel { get; }
        public IProductPhotoRepository ProductPhoto { get; }
        public IProductListPriceHistoryRepository ProductListPriceHistoryRepository { get; }
    }
}
