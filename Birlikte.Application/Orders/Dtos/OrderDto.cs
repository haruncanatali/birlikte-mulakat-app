using Birlikte.Application.Product.Dtos;
using Birlikte.Application.Shops.Dtos;

namespace Birlikte.Application.Orders.Dtos;

public class OrderDto
{
    public ProductDto Product { get; set; }
    public ShopDto Shop { get; set; }
    public int Amount { get; set; }
}