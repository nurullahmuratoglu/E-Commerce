using E_Commerce.Application.Dtos.Cart;
using E_Commerce.Application.Exceptions;
using E_Commerce.Shared;
using E_Commerce.Shared.ResponseDtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Aggregate = E_Commerce.Domain.AggregateModels.CartAggregate;

namespace E_Commerce.Application.Features.Command.Cart.CreateCart
{
    public class CreateCartCommandHandler : IRequestHandler<CreateCarttCommandRequest, ResponseDto<CreateCartViewDto>>
    {
        private readonly E_CommerceDbContext _context;

        public CreateCartCommandHandler(E_CommerceDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseDto<CreateCartViewDto>> Handle(CreateCarttCommandRequest request, CancellationToken cancellationToken)
        {

            if (request.UserId != null & !_context.Users.Any(x => x.Id == request.UserId))
            {
                throw new NotFoundException("user bulunamadı");

            }
            if (request.UserId != null & _context.Carts.Any(x => x.UserId == request.UserId && x.IsActive == true))
            {
                throw new NotFoundException("bu userın aktif bir sepeti bulunmakta");

            }

            var product = await _context.Categories
.Where(c => c.Products.Any(p => p.Id == request.ProductId))
.SelectMany(c => c.Products.Where(p => p.Id == request.ProductId && p.IsActive==true))
.FirstOrDefaultAsync();


            if (product == null)
            {

                throw new NotFoundException("product bulunamadı");

            }
            if (product.Stock <= 0)
            {
                throw new NotFoundException("ürünün stock miktarı 0 dan nüyük olmalıdır");

            }
            Aggregate.Cart newCart = new();

            newCart.AddItem(product.Id, product.Name, product.Price, product.Stock, request.Quantity);
            newCart.AssignUser(request.UserId!);

            await _context.Carts.AddAsync(newCart);

            await _context.SaveChangesAsync();


            return ResponseDto<CreateCartViewDto>.Success(StatusCodes.Status200OK, new CreateCartViewDto { CartId = newCart.Id });
        }
    }
}
