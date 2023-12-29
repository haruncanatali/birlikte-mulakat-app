using Birlikte.Application.Orders.Dtos;

namespace Birlikte.Application.Carts.Dtos;

public class CartDto
{
    public List<OrderDto> Orders { get; set; }
    public decimal Total { get; set; }
}