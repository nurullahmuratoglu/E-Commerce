using E_Commerce.Shared;
using E_Commerce.Shared.ResponseDtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Features.Command.User.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, ResponseDto<NoContentDto>>
    {
        private readonly E_CommerceDbContext _context;

        public CreateUserCommandHandler(E_CommerceDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseDto<NoContentDto>> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            if (_context.Users.Any(x => x.Email == request.Email))
            {
                return ResponseDto<NoContentDto>.Fail(StatusCodes.Status200OK, "Bu email adresi zaten kullanılmış.");
            }

            var user = new Domain.Model.User(request.Email, request.Password, request.FirstName, request.LastName, request.City);
            _context.Users.Add(user);

            
            await _context.SaveChangesAsync(cancellationToken);
            return ResponseDto<NoContentDto>.Success(StatusCodes.Status200OK);

        }
    }
}
