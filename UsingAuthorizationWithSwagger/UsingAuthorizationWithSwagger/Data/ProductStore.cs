using UsingAuthorizationWithSwagger.Models;

namespace UsingAuthorizationWithSwagger.Data
{
    public static class ProductStore
    {
        private static readonly Product[] Products = {
            new() { Id = 1, Name = "Rubber duck"},
            new() { Id = 2, Name = "Flip flop"},
            new() { Id = 3, Name = "Magic Wand"},
            new() { Id = 4, Name = "Glitter pen"}
        };

        public static IEnumerable<Product> GetProducts()
        {
            return Products;
        }

        public static Product? GetProduct(int id)
        {
            foreach (var product in Products)
            {
                if (product.Id == id)   
                    return product;
            }
            return null;
        }
    }
}
