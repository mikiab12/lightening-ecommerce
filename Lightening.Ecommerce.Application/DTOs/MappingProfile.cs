using AutoMapper;
using Lightening.Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lightening.Ecommerce.Application.DTOs
{
    public class MappingProfile : Profile
    {
       public MappingProfile()
        {
            CreateMap<ProductProductPhoto, ProductProductPhotoDto>();
            CreateMap<ProductReview, ProductReviewDto>();
            CreateMap<Product, ProductDetailsDto>();
            CreateMap<ProductModel, ProductModelDto>();
            CreateMap<ProductCategory, ProdcutCategoryDto>();
            CreateMap<ProductSubcategory, ProdcutSubcategoryDto>();
            CreateMap<ProductModelProductDescriptionCulture, ProductModelProductDescriptionCultureDto>();
            CreateMap<ProductDescription, ProductDescriptionDto>();
        }
    }
}
