using FluentValidation;

namespace Clothes.Application.CreateClothe;

public class CreateClotheCommandValidator : AbstractValidator<CreateClotheCommand>
{
    public CreateClotheCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
        RuleFor(x => x.Model).NotEmpty().MaximumLength(50);
        RuleFor(x => x.Size).NotEmpty().MaximumLength(5);
        RuleFor(x => x.Color).NotEmpty().MaximumLength(15);
        RuleFor(x=> x.Year).GreaterThanOrEqualTo(2024);
    }
}
