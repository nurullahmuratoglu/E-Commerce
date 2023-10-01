using E_Commerce.Shared;
using E_Commerce.Shared.ResponseDtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Aggregate = E_Commerce.Domain.AggregateModels.CategoryAndProductAggregate;

namespace E_Commerce.Application.Features.Command.Category.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest, ResponseDto<NoContentDto>>
    {
        private readonly E_CommerceDbContext _context;

        public CreateCategoryCommandHandler(E_CommerceDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseDto<NoContentDto>> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var parentCategory = await _context.Categories.FindAsync(request.ParentCategoryId);
            var category = new Aggregate.Category(request.Name, request.ParentCategoryId);
            if (parentCategory == null)
            {
                return ResponseDto<NoContentDto>.Fail(StatusCodes.Status400BadRequest, "parrentcategoryıd geçerli değil");
            }

            parentCategory.AddSubcategory(category);
            _context.Categories.Add(category);
            _context.SaveChanges();

            return ResponseDto<NoContentDto>.Success(StatusCodes.Status200OK);

        }
    }
}
