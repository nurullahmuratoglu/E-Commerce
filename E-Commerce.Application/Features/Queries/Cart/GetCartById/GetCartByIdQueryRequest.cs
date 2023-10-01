using E_Commerce.Application.Dtos.Cart;
using E_Commerce.Shared.ResponseDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Features.Queries.Cart.GetCartById
{
    public class GetCartByIdQueryRequest:IRequest<ResponseDto<CartViewDto>>
    {
        public int CartId { get; set; }
    }
}
