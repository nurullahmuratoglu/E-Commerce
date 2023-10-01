﻿using E_Commerce.Shared.ResponseDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Features.Command.User.UserAuthentication
{
    public class UserAuthQueryRequest : IRequest<ResponseDto<NoContentDto>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public int? VisitorCartId { get; set; }

    }
}
