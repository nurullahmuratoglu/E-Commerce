using E_Commerce.Application.Dtos.Product;
using E_Commerce.Shared.ResponseDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Features.Queries.Product.GetProductByCategoryId
{
    public class GetProductByCategoryIdQueryRequest:IRequest<ResponseDto<List<ProductInfoDto>>>
    {
        public int CategoryId { get; set; }
    }
}
