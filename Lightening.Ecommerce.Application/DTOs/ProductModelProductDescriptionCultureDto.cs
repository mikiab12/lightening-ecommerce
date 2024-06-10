namespace Lightening.Ecommerce.Application.DTOs
{
    public class ProductModelProductDescriptionCultureDto
    {
        public int ProductModelId { get; set; }
        public int ProductDescriptionId { get; set; }
        public string CultureId { get; set; } = null!;
        public virtual ProductDescriptionDto ProductDescription { get; set; } = null!;
    }
}
