namespace Birlikte.Application.Orders.Models;

public class OrderForCartRequestModel
{
    public long ProductId { get; set; }
    public long CartId { get; set; }
    public long ShopId { get; set; }
    public int Amount { get; set; }
}