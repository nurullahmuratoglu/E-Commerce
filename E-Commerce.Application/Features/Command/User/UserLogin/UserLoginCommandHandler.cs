using E_Commerce.Application.Exceptions;
using E_Commerce.Shared;
using E_Commerce.Shared.ResponseDtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Application.Features.Command.User.UserAuthentication
{
    public class UserLoginCommandHandler : IRequestHandler<UserLoginCommandRequest, ResponseDto<NoContentDto>>
    {
        private readonly E_CommerceDbContext _context;

        public UserLoginCommandHandler(E_CommerceDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseDto<NoContentDto>> Handle(UserLoginCommandRequest request, CancellationToken cancellationToken)
        {
            var user = _context.Users.FirstOrDefault(x => x.Email == request.Email);
            if (user == null) throw new NotFoundException("Email adresi yanlış");
            if (user.Password != request.Password) throw new NotFoundException("Şifre Yanlış");

            if (user.IsActive == false) throw new NotFoundException("kullanıcı aktif değil");

            var Guestcart = await _context.Carts.Where(x => x.GuestId == request.GuestId && x.IsActive == true).Include(x => x.Items).FirstOrDefaultAsync();
            if (Guestcart == null) throw new NotFoundException("guestid geçersiz");

            var userCart = _context.Carts.Include(x => x.Items).FirstOrDefault(x => x.UserId == user.Id);        
            
            userCart.MergeWith(Guestcart);
            Guestcart.SetActive(false);
            await _context.SaveChangesAsync();
            return ResponseDto<NoContentDto>.Success(StatusCodes.Status200OK);
        }
    }
}
