using FluentValidation;

namespace Clothes.Application.DeleteClothe;

public class DeleteClotheCommandValidator : AbstractValidator<DeleteClotheCommand>
{
    public DeleteClotheCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}