namespace JwtAPI.Core.Application.Dto
{
    public class ProductListDto
    {
        public int Id { get; set; }
        public string? Definiton { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
