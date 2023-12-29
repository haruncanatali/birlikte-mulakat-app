namespace Birlikte.Domain.Entities;

public class ProductShop : BaseEntity
{
    public long ProductId { get; set; }
    public long ShopId { get; set; }
    public int NumberOfProducts { get; set; }

    public Product Product { get; set; }
    public Shop Shop { get; set; }
}