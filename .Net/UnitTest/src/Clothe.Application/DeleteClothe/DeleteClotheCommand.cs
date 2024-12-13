using MediatR;
using Clothes.Application.Results;

namespace Clothes.Application.DeleteClothe;

public record DeleteClotheCommand(Guid Id) : IRequest<Result>;
