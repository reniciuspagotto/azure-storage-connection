namespace AzureStorage.Core.Entities
{
    public class Product
    {
        public Product(string name, decimal price, string imageUrl)
        {
            Name = name;
            Price = price;
            ImageUrl = imageUrl;
        }

        public int Id { get; set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public string ImageUrl { get; private set; }
    }
}
