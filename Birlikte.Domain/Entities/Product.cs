namespace Birlikte.Domain.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; }
    public decimal Price { get; set; }

    public List<ProductShop> ProductShops { get; set; }
}