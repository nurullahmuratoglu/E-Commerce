using E_Commerce.Application.Dtos.Category;
using E_Commerce.Application.Mapping;
using E_Commerce.Shared;
using E_Commerce.Shared.ResponseDtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Aggregate = E_Commerce.Domain.AggregateModels.CategoryAndProductAggregate;

namespace E_Commerce.Application.Features.Queries.Category.GetAllCategory
{

    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQueryRequest, ResponseDto<CategoryViewDtos>>
    {
        private readonly E_CommerceDbContext _context;

        public GetAllCategoryQueryHandler(E_CommerceDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseDto<CategoryViewDtos>> Handle(GetAllCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            
            var baseCategory = _context.Categories.FirstOrDefault(c => c.Id == 1);
            var categoryTree = BuildCategoryTree(baseCategory);

            return ResponseDto<CategoryViewDtos>.Success(StatusCodes.Status200OK, categoryTree);
        }

        private CategoryViewDtos BuildCategoryTree(Aggregate.Category category)
        {
            var categoryDto = ObjectMapper.Mapper.Map<CategoryViewDtos>(category);

            var subcategories = _context.Categories
                .Where(c => c.ParentCategoryID == category.Id)
                .OrderBy(c => c.Name)
                .ToList();

            categoryDto.Subcategories = subcategories.Select(BuildCategoryTree).ToList();

            return categoryDto;
        }
    }
}
