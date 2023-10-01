using E_Commerce.Shared.ResponseDtos;
using MediatR;

namespace E_Commerce.Application.Features.Command.Category.CreateCategory
{
    public class CreateCategoryCommandRequest : IRequest<ResponseDto<NoContentDto>>
    {
        public string Name { get; set; }
        public int? ParentCategoryId { get; set; } = 1;


    }
}
