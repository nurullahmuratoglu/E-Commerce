using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace E_Commerce.Application.Validations
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var validationErrors = new List<ValidationFailure>();

            foreach (var validator in _validators)
            {
                var validationResult = await validator.ValidateAsync(request, cancellationToken);
                validationErrors.AddRange(validationResult.Errors);
            }

            if (validationErrors.Any())
            {
                var errorMessages = validationErrors.Select(error => error.ErrorMessage).ToList();


                throw new ValidationException(errorMessages);
            }

            return await next();
        }
    }
}
