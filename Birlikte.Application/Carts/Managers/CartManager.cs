using Birlikte.Application.Carts.Dtos;
using Birlikte.Application.Carts.Models;
using Birlikte.Application.Carts.Services;
using Birlikte.Application.Common.Models;
using Birlikte.Application.Orders.Dtos;
using Birlikte.Application.Product.Dtos;
using Birlikte.Application.Shops.Dtos;
using Birlikte.Domain.Entities;
using Birlikte.Persistence;

namespace Birlikte.Application.Carts.Managers;

public class CartManager : ICartService
{
    public CartManager()
    {
        FakeDB.Generate();    
    }
    
    public async Task<BaseResponseModel<bool>> Update(UpdateCartRequestModel model)
    {
        var requestOrder = model.Order;

        var product = FakeDB.Products.FirstOrDefault(c => c.Id == requestOrder.ProductId);
        var shop = FakeDB.Shops.FirstOrDefault(c => c.Id == requestOrder.ShopId);
        var cart = FakeDB.Carts.FirstOrDefault(c => c.Id == requestOrder.CartId);

        if (product == null || shop == null || cart == null)
        {
            throw new Exception("Invalid inputs.");
        }
        
        var productShop = FakeDB.ProductShops
            .FirstOrDefault(c => c.ProductId == requestOrder.ProductId && c.ShopId == requestOrder.ShopId);

        if (productShop == null)
        {
            return new BaseResponseModel<bool>(false,
                "The product to be updated could not be found in the relevant store.");
        }

        var amount = requestOrder.Amount;

        if (productShop.NumberOfProducts < amount)
        {
            return new BaseResponseModel<bool>(false,
                "The product is not available in sufficient quantities in the relevant store's stock.");
        }

        var order = FakeDB.Orders.FirstOrDefault(c =>
            (c.ProductId == requestOrder.ProductId) &&
            (c.CartId == requestOrder.CartId) &&
            (c.ShopId == requestOrder.ShopId));

        if (order != null)
        {
            if (requestOrder.Amount > 0)
            {
                order.Amount += requestOrder.Amount;
                productShop.NumberOfProducts -= requestOrder.Amount;
            }
            else
            {
                order.Amount -= (requestOrder.Amount * -1);
                productShop.NumberOfProducts += (requestOrder.Amount * -1);

                if (order.Amount < 1)
                {
                    FakeDB.Orders.Remove(order);
                }
            }
        }
        else
        {
            FakeDB.Orders.Add(new Order
            {
                Id = (new Random()).Next(1,10000),
                CartId = cart.Id,
                ProductId = product.Id,
                ShopId = shop.Id
            });
        }

        return new BaseResponseModel<bool>(true, "The entity has been created successfully.");
    }

    public async Task<BaseResponseModel<CartDto>> Get(long customerId)
    {
        var customer = FakeDB.Customers.FirstOrDefault(c => c.Id == customerId);

        if (customer == null)
        {
            throw new Exception("Customer not found.");
        }

        CartDto response = new();
        decimal total = 0.0m;

        var orders = FakeDB.Orders.Where(c => c.CartId == customer.CartId).ToList();
        
        orders.ForEach(c =>
        {
            var product = FakeDB.Products.FirstOrDefault(x => x.Id == c.ProductId);
            var shop = FakeDB.Shops.FirstOrDefault(x => x.Id == c.ShopId);

            if (product == null || shop == null)
            {
                throw new Exception("Product or Shop not found.");
            }
            
            response.Orders.Add(new OrderDto
            {
                Amount = c.Amount,
                Product = new ProductDto
                {
                    Name = product.Name,
                    Price = product.Price
                },
                Shop = new ShopDto
                {
                    Name = shop.Name
                }
            });

            total += c.Amount * product.Price;
        });

        response.Total = total;

        return new BaseResponseModel<CartDto>(response, "Cart data found.");
    }
}