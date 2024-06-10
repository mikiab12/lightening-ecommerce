using Lightening.Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lightening.Ecommerce.Application.DTOs
{
    public class ProductModelDto
    {
        public int ProductModelId { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<ProductModelProductDescriptionCultureDto> ProductModelProductDescriptionCultures { get; set; }
        public ICollection<ProductDetailsDto> Products { get; set; }
    }

    public class ProductDetailsDto
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = null!;
        public string ProductNumber { get; set; } = null!;
        public string? Color { get; set; }
        public decimal StandardCost { get; set; }
        public decimal ListPrice { get; set; }
        public string? Size { get; set; }
        public string? SizeUnitMeasureCode { get; set; }
        public string? WeightUnitMeasureCode { get; set; }
        public decimal? Weight { get; set; }
        public int DaysToManufacture { get; set; }
        /// <summary>
        /// R = Road, M = Mountain, T = Touring, S = Standard
        /// </summary>
        public string? ProductLine { get; set; }
        /// <summary>
        /// H = High, M = Medium, L = Low
        /// </summary>
        public string? Class { get; set; }
        /// <summary>
        /// W = Womens, M = Mens, U = Universal
        /// </summary>
        public string? Style { get; set; }
        public int? ProductSubcategoryId { get; set; }
        public int? ProductModelId { get; set; }
        public DateTime SellStartDate { get; set; }
        public DateTime? SellEndDate { get; set; }
        public DateTime? DiscontinuedDate { get; set; }
        public ProdcutSubcategoryDto ProductSubcategory { get; set; }
        public ICollection<ProductReviewDto> ProductReviews { get; set; }
        public ICollection<ProductProductPhotoDto> ProductProductPhotos { get; set; }
    }

    public class ProductReviewDto
    {
        public int ProductReviewId { get; set; }
        public int ProductId { get; set; }
        public string ReviewerName { get; set; } = null!;
        public DateTime ReviewDate { get; set; }
        public string EmailAddress { get; set; } = null!;
        public int Rating { get; set; }
        public string? Comments { get; set; }
    }

    public class ProductProductPhotoDto
    {
        public int ProductId { get; set; }
        public int ProductPhotoId { get; set; }
        public bool Primary { get; set; }
    }

    public class ProductModelProductDescriptionCultureDto
    {
        public int ProductModelId { get; set; }
        public int ProductDescriptionId { get; set; }
        public string CultureId { get; set; } = null!;
        public virtual ProductDescriptionDto ProductDescription { get; set; } = null!;
    }

    public class ProductDescriptionDto
    {
        public int ProductDescriptionId { get; set; }
        public string Description { get; set; } = null!;
    }
}
