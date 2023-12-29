using Birlikte.Domain.Entities;

namespace Birlikte.Persistence;

public class FakeDB
{
    public static List<Cart> Carts = new();
    public static List<Customer> Customers = new();
    public static List<Order> Orders = new();
    public static List<Product> Products = new();
    public static List<ProductShop> ProductShops = new();
    public static List<Shop> Shops = new();

    public static bool IsGenerated = false;

    public static void Generate()
    {
        if (!IsGenerated)
        {
            Shops.Add(new Shop
            {
                Id = 1,
                Name = "Sony"
            });
            Carts.Add(new Cart
            {
                Id = 1
            });
            Customers.Add(new Customer
            {
                Id = 1,
                Name = "Haruncan",
                Surname = "Atali",
                CartId = 1
            });
            Products.Add(new Product
            {
                Id = 1,
                Name = "Pencil",
                Price = 15.50m
            });
            ProductShops.Add(new ProductShop
            {
                Id = 1,
                NumberOfProducts = 50,
                ProductId = 1,
                ShopId = 1
            });

            IsGenerated = true;
        }
    }
}