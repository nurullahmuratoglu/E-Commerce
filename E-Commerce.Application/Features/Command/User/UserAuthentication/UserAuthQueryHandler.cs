using E_Commerce.Application.Exceptions;
using E_Commerce.Shared;
using E_Commerce.Shared.ResponseDtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Features.Command.User.UserAuthentication
{
    public class UserAuthQueryHandler : IRequestHandler<UserAuthQueryRequest, ResponseDto<NoContentDto>>
    {
        private readonly E_CommerceDbContext _context;

        public UserAuthQueryHandler(E_CommerceDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseDto<NoContentDto>> Handle(UserAuthQueryRequest request, CancellationToken cancellationToken)
        {
            var user = _context.Users.FirstOrDefault(x => x.Email == request.Email);
            if (user == null)
            {
                throw new NotFoundException("Email adresi yanlış");
            }
            if (user.Password != request.Password)
            {
                throw new NotFoundException("Şifre Yanlış");
            }
            if (user.IsActive == false)
            {
                throw new NotFoundException("kullanıcı aktif değil");
            }
            if (request.VisitorCartId == null)
            {
                return ResponseDto<NoContentDto>.Success(StatusCodes.Status200OK);
            }

            var Visitorcart = _context.Carts.Include(x => x.Items).FirstOrDefault(x => x.Id == request.VisitorCartId && x.IsActive == true);

            if (Visitorcart==null)
            {
                throw new NotFoundException("sepet bulunamadı");
            }
            if (Visitorcart.UserId.HasValue)
            {
                throw new NotFoundException("bu sepet bir kullanıcıya ait");
            }
            var userCart = _context.Carts.Include(x => x.Items).FirstOrDefault(x => x.UserId == user.Id);
            if (userCart == null)
            {
                Visitorcart.AssignUser(user.Id);
                await _context.SaveChangesAsync();
                return ResponseDto<NoContentDto>.Success(StatusCodes.Status200OK);
            }
          
            userCart.MergeWith(Visitorcart);
            Visitorcart.SetActive(false);
            await _context.SaveChangesAsync();
            return ResponseDto<NoContentDto>.Success(StatusCodes.Status200OK);
        }
    }
}
