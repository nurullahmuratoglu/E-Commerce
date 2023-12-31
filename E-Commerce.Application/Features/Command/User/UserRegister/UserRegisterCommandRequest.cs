﻿using E_Commerce.Application.Dtos.User;
using E_Commerce.Shared.ResponseDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Features.Command.User.CreateUser
{
    public class UserRegisterCommandRequest : IRequest<ResponseDto<CreateUserViewDto>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public Guid GuestId { get; set; }
    }
}
