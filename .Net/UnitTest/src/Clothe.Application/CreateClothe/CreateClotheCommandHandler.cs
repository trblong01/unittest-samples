using MediatR;
using Clothes.Application.Results;
using Clothes.Domain.Entities;
using Clothes.Domain.Repositories;

namespace Clothes.Application.CreateClothe;

public class CreateClotheCommandHandler(CreateClotheCommandValidator _validator, IRepository<ClotheEntity> _repository) : IRequestHandler<CreateClotheCommand, Result>
{
    
    public async Task<Result> Handle(CreateClotheCommand request, CancellationToken cancellationToken)
    {
        var isValid = await _validator.ValidateAsync(request, cancellationToken);
        if (!isValid.IsValid)
        {
            return new Result(false, "Invalid data", isValid.Errors);
        }

        var Clothe = new ClotheEntity(request.Name, request.Model, request.Year, request.Size, request.Color);
        await _repository.AddAsync(Clothe, cancellationToken);
        await _repository.SaveChangesAsync(cancellationToken);

        return new Result(true, "Clothe created successfully", Clothe.Id);

    }
}
