using E_Commerce.Application.Dtos.Guest;
using E_Commerce.Application.Dtos.User;
using E_Commerce.Application.Features.Command.Guest.CreateCart;
using E_Commerce.Application.Features.Command.User.CreateUser;
using E_Commerce.Application.Features.Command.User.UserAuthentication;
using E_Commerce.Shared.ResponseDtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.API.Controllers
{
    [Route("api/accounts")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("register")]
        public async Task<ResponseDto<CreateUserViewDto>> CreateUser([FromBody] UserRegisterCommandRequest request)
        {
            return await _mediator.Send(request);

        }

        [HttpPost("login")]

        public async Task<ResponseDto<NoContentDto>> Login([FromBody] UserLoginCommandRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpPost("create-guestid")]
        public async Task<ResponseDto<CreateCartForGuestViewDto>> CreateCart()
        {
            return await _mediator.Send(new CreateCartAndGuestIdCommandRequest());
        }
    }
}
