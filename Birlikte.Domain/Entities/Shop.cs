namespace Birlikte.Domain.Entities;

public class Shop : BaseEntity
{
    public string Name { get; set; }

    public List<ProductShop> ProductShops { get; set; }
}