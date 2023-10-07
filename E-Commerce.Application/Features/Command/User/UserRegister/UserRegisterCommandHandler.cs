using E_Commerce.Application.Dtos.User;
using E_Commerce.Application.Exceptions;
using E_Commerce.Shared;
using E_Commerce.Shared.ResponseDtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Application.Features.Command.User.CreateUser
{
    public class UserRegisterCommandHandler : IRequestHandler<UserRegisterCommandRequest, ResponseDto<CreateUserViewDto>>
    {
        private readonly E_CommerceDbContext _context;

        public UserRegisterCommandHandler(E_CommerceDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseDto<CreateUserViewDto>> Handle(UserRegisterCommandRequest request, CancellationToken cancellationToken)
        {
            if (_context.Users.Any(x => x.Email == request.Email))
            {
                return ResponseDto<CreateUserViewDto>.Fail(StatusCodes.Status200OK, "Bu email adresi zaten kullanılmış.");
            }
            var Guestcart = await _context.Carts.Where(x => x.GuestId == request.GuestId && x.IsActive == true).Include(x => x.Items).FirstOrDefaultAsync();
            if (Guestcart == null) throw new NotFoundException("guestid geçersiz");


            var user = new Domain.Model.User(request.Email, request.Password, request.FirstName, request.LastName, request.City);
            _context.Users.Add(user);

            await _context.SaveChangesAsync();
            Guestcart.AssignUser(user.Id);
            await _context.SaveChangesAsync();
            return ResponseDto<CreateUserViewDto>.Success(StatusCodes.Status200OK,new CreateUserViewDto {UserId=user.Id });

        }
    }
}
