using AutoMapper;
using Lightening.Ecommerce.Application.DTOs;
using Lightening.Ecommerce.Domain.Entities;
using Lightening.Ecommerce.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lightening.Ecommerce.Application.Services
{
    public interface IProductService
    {
        Task<PagedResult<ProductModelSummaryDto>> GetProductSummaryListAsync(ProductQueryRequest request);
        Task<byte[]?> GetProductThumbnailAsync(int photoId);
        Task<byte[]?> GetProductLargePhotoAsync(int photoId);
        Task<ProdcutCategoryDto[]> GetAllProductCategoriesAsync();
        Task<ProductModelDto> GetProductDetailsAsync(int productModelId);
    }
    public class ProductService : IProductService
    {

        private IRepositoryManager _repository;
        private IMapper _mapper;
        public ProductService(IRepositoryManager repository, IMapper mapper) 
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PagedResult<ProductModelSummaryDto>> GetProductSummaryListAsync(ProductQueryRequest request)
        {
            var query = _repository.Product.AsQueryable();

            if (request.SubCategoryId.HasValue)
                query = query.Where(m => m.ProductSubcategoryId == request.SubCategoryId.Value);

            if (request.CategoryId.HasValue)
                query = query.Where(m => m.ProductSubcategory != null && m.ProductSubcategory.ProductCategoryId == request.CategoryId.Value);

            var filteredQuery = query
                .Where(m => m.ProductModelId.HasValue)
                .Include(m => m.ProductProductPhotos)
                .GroupBy(m => m.ProductModelId)
                .Select(p => p.OrderBy(m => m.ProductId).FirstOrDefault());

            var totalCount = filteredQuery.AsNoTracking().AsEnumerable().Count();

            if (request.Page.HasValue && request.PageSize.HasValue)
                filteredQuery = filteredQuery.Skip((request.Page.Value - 1) * request.PageSize.Value).Take(request.PageSize.Value);

            var products = await filteredQuery.ToListAsync();

            var productModelids = products.Select(m => m.ProductModelId).Distinct().ToList();
            var productModels = await _repository.ProductModel
                .AsQueryable()
                .Where(m => productModelids.Contains(m.ProductModelId))
                .Include(m => m.ProductModelProductDescriptionCultures)
                .ThenInclude(m => m.ProductDescription)
                .AsNoTracking()
                .ToListAsync();


            var data = products.Select(p => new ProductModelSummaryDto
            {
                ProductModelId = p.ProductModelId.Value,
                Description = ProductModelDescrption(p.ProductModelId.Value),
                Name = FindProductModel(p.ProductModelId.Value).Name,
                ProductThumbnailId = p.ProductProductPhotos?.FirstOrDefault()?.ProductPhotoId,
                ProductListPrice = p.ListPrice
            }).ToArray();

            return new PagedResult<ProductModelSummaryDto>
            {
                Data = data,
                CurrentPage = request.Page.Value,
                PageSize = request.PageSize.Value,
                TotalCount = totalCount
            };

            ProductModel FindProductModel(int productModelId)
                => productModels.FirstOrDefault(m => m.ProductModelId == productModelId);

            string ProductModelDescrption(int productModelId)
                => FindProductModel(productModelId).ProductModelProductDescriptionCultures?.FirstOrDefault()?.ProductDescription?.Description;
        }

        public async Task<byte[]?> GetProductThumbnailAsync(int photoId)
        {
            var productPhoto = await _repository.ProductPhoto.Find(m => m.ProductPhotoId == photoId).FirstOrDefaultAsync();
            return productPhoto?.ThumbNailPhoto;
        }

        public async Task<byte[]?> GetProductLargePhotoAsync(int photoId)
        {
            var productPhoto = await _repository.ProductPhoto.Find(m => m.ProductPhotoId == photoId).FirstOrDefaultAsync();
            return productPhoto?.LargePhoto;
        }

        public async Task<ProdcutCategoryDto[]> GetAllProductCategoriesAsync()
        {
            var categories = await _repository.ProductCategory
                .AsQueryable()
                .Include(m => m.ProductSubcategories)
                .ToListAsync();
            return categories.Select(m => new ProdcutCategoryDto
            {
                Name = m.Name,
                ProductCategoryId = m.ProductCategoryId,
                ProductSubcategories = m.ProductSubcategories.Select(psc => new ProdcutSubcategoryDto
                {
                    Name = psc.Name,
                    ProductCategoryId = psc.ProductCategoryId,
                    ProductSubcategoryId = psc.ProductSubcategoryId,
                }).ToList()
            }).ToArray();
        }

        public async Task<ProductModelDto> GetProductDetailsAsync(int productModelId)
        {
            var productModel = await _repository.ProductModel.Find(m => m.ProductModelId == productModelId)
                .Include(m => m.ProductModelProductDescriptionCultures)
                .ThenInclude(m => m.ProductDescription)
                .FirstOrDefaultAsync();

            if (productModel == null)
                return null;

            var products = await _repository.Product.AsQueryable()
                .Where(m => m.ProductModelId == productModelId)
                .Include(m => m.ProductProductPhotos)
                .Include(m => m.ProductReviews)
                .Include(m => m.ProductSubcategory)
                    .ThenInclude(m => m.ProductCategory)
                .ToListAsync();

            productModel.Products = products;

            return _mapper.Map<ProductModelDto>(productModel);

        }
    }
}
