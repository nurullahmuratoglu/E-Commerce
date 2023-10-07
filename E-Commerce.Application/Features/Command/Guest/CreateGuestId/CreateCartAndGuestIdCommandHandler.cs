using E_Commerce.Application.Dtos.Guest;
using E_Commerce.Application.Exceptions;
using E_Commerce.Shared;
using E_Commerce.Shared.ResponseDtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Aggregate = E_Commerce.Domain.AggregateModels.CartAggregate;

namespace E_Commerce.Application.Features.Command.Guest.CreateCart
{
    public class CreateCartAndGuestIdCommandHandler : IRequestHandler<CreateCartAndGuestIdCommandRequest, ResponseDto<CreateCartForGuestViewDto>>
    {
        private readonly E_CommerceDbContext _context;

        public CreateCartAndGuestIdCommandHandler(E_CommerceDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseDto<CreateCartForGuestViewDto>> Handle(CreateCartAndGuestIdCommandRequest request, CancellationToken cancellationToken)
        {

            Aggregate.Cart guestCart = new(Guid.NewGuid());
            await _context.Carts.AddAsync(guestCart);
            await _context.SaveChangesAsync();

            return ResponseDto<CreateCartForGuestViewDto>.Success(StatusCodes.Status200OK, new CreateCartForGuestViewDto { GuestId = guestCart.GuestId });
        }
    }
}
