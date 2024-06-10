using Lightening.Ecommerce.Data.Context;
using Lightening.Ecommerce.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lightening.Ecommerce.Data.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly AdventureWorksContext _context;
        public RepositoryManager(AdventureWorksContext context)
        {
            _context = context;
        }

        public IProductRepository ProductRepository { get; set; }
        public IProductCategoryRepository ProductCategoryRepository { get; set; }
        public IProductModelRepository ProductModelRepository { get; set; }
        public IProductPhotoRepository ProductPhotoRepository { get; set; }
        public IProductListPriceHistoryRepository ProductListPriceHistoryRepository { get; set; }
        public IProductProductPhotoRepository ProductProductPhotoRepository { get; set; }
  

        public IProductCategoryRepository ProductCategory
        {
            get {
                if (ProductCategoryRepository == null)
                    ProductCategoryRepository = new ProductCategoryRepository(_context);
                return ProductCategoryRepository;
            }
        }

        public IProductModelRepository ProductModel
        {
            get {
                if (ProductModelRepository == null)
                    ProductModelRepository = new ProductModelRepository(_context);
                return ProductModelRepository;
            }
        }

        public IProductPhotoRepository ProductPhoto
        {
            get {
                if (ProductPhotoRepository == null)
                    ProductPhotoRepository = new ProductPhotoRepository(_context);
                return ProductPhotoRepository;
            }
        }

        public IProductListPriceHistoryRepository ProductListPriceHistory
        {
            get {
                if (ProductListPriceHistoryRepository == null)
                    ProductListPriceHistoryRepository = new ProductListPriceHistoryRepository(_context);
                return ProductListPriceHistoryRepository;
            }
        }

        public IProductRepository Product
        {
            get
            {
                if (ProductRepository == null)
                    ProductRepository = new ProductRepository(_context);
                return ProductRepository;
            }
        }
    }
}
