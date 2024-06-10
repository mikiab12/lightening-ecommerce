namespace Lightening.Ecommerce.Application.DTOs
{
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
}
