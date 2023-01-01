namespace GeekShopping.ProductAPI.Domain.VM
{
    public class ProductVM
    {
        public long Id { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public string Description { get; private set; }
        public string ImageUrl { get; private set; }

        public ProductVM(long id, string name, decimal price, string description, string imageUrl)
        {
            Id = id;
            Name = name;
            Price = price;
            Description = description;
            ImageUrl = imageUrl;
        }
    }
}
