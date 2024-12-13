using MediatR;
using Clothes.Application.Results;
using Clothes.Domain.Entities;
using Clothes.Domain.Repositories;

namespace Clothes.Application.DeleteClothe;

public class DeleteClotheCommandHandler(IRepository<ClotheEntity> _repository, DeleteClotheCommandValidator _validator) : IRequestHandler<DeleteClotheCommand, Result>
{
    public async Task<Result> Handle(DeleteClotheCommand request, CancellationToken cancellationToken)
    {
        var isValid = await _validator.ValidateAsync(request, cancellationToken);
        if (!isValid.IsValid)
        {
            return new Result(false, "Invalid data", isValid.Errors);
        }
        var Clothe = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (Clothe is null)
        {
            return new Result(false, "Clothe not found");
        }

        _repository.Delete(Clothe);
        await _repository.SaveChangesAsync(cancellationToken);
        return new Result(true, "Clothe deleted successfully", Clothe.Id);
    }
}
