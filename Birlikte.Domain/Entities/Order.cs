namespace Birlikte.Domain.Entities;

public class Order : BaseEntity
{
    public long ProductId { get; set; }
    public long CartId { get; set; }
    public long ShopId { get; set; }
    public int Amount { get; set; }

    public Product Product { get; set; }
    public Cart Cart { get; set; }
    public Shop Shop { get; set; }
}