using FluentValidation;

namespace Application.Features.BrandOperations.Command;

public class CreateBrandCommandValidator : AbstractValidator<CreateBrandCommandRequest>
{
     public CreateBrandCommandValidator()
     {
          RuleFor(n => n.Name).NotEmpty();
          RuleFor(n => n.Name).NotNull();
          RuleFor(n => n.Name).MinimumLength(2);
          RuleFor(n => n.Name).MaximumLength(25);
     }
}
