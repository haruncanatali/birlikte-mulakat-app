using Birlikte.Application.Carts.Dtos;
using Birlikte.Application.Carts.Models;
using Birlikte.Application.Common.Models;

namespace Birlikte.Application.Carts.Services;

public interface ICartService
{
    public Task<BaseResponseModel<bool>> Update(UpdateCartRequestModel model);
    public Task<BaseResponseModel<CartDto>> Get(long customerId);
}