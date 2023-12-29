using Birlikte.Application.Carts.Managers;
using Birlikte.Application.Carts.Models;
using Birlikte.Application.Orders.Models;
using Birlikte.Persistence;

namespace Birlikte.Test;

public class CartServiceTest
{
    [Test]
    public async Task Update_Should_UpdateProductInCart_When_ValidInputs()
    {
        var service = new CartManager();
        var model = new UpdateCartRequestModel
        {
            Order = new OrderForCartRequestModel
            {
                ProductId = 1,
                ShopId = 1,
                CartId = 1,
                Amount = 3
            }
        };

        var result = await service.Update(model);

        // Assert
        Assert.IsTrue(result.Data);
        Assert.That(result.Data, Is.EqualTo(true));
    }

    [Test]
    public async Task Get_Should_ReturnCartDto_When_ValidCustomerId()
    {
        var service = new CartManager();
        var customerId = 1;

        var result = await service.Get(customerId);

        Assert.IsNotNull(result.Data);
    }
}