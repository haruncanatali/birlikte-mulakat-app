using Birlikte.Application.Orders.Models;

namespace Birlikte.Application.Carts.Models;

public class UpdateCartRequestModel
{
    public OrderForCartRequestModel Order { get; set; }
}