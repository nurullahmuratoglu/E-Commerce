using E_Commerce.Application.Dtos.Guest;
using E_Commerce.Shared.ResponseDtos;
using MediatR;

namespace E_Commerce.Application.Features.Command.Guest.CreateCart
{
    public class CreateCartAndGuestIdCommandRequest : IRequest<ResponseDto<CreateCartForGuestViewDto>>
    {
    }
}
