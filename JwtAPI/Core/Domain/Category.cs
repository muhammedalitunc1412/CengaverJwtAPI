namespace JwtAPI.Core.Domain
{
    public class Category
    {
        public int Id { get; set; }
        public string? Definiton { get; set; }
        public List<Product> Products { get; set; }
        public Category()
        {
            Products=new List<Product>();
        }
    }
}
