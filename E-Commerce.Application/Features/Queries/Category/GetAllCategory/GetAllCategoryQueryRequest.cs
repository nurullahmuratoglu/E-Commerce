using Aggregate = E_Commerce.Domain.AggregateModels.CategoryAndProductAggregate;
using E_Commerce.Shared.ResponseDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce.Application.Dtos.Category;

namespace E_Commerce.Application.Features.Queries.Category.GetAllCategory
{
    public class GetAllCategoryQueryRequest:IRequest<ResponseDto<CategoryViewDtos>>
    {

    }
}
