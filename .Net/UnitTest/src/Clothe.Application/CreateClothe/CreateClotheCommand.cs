using MediatR;
using Clothes.Application.Results;

namespace Clothes.Application.CreateClothe;

public record CreateClotheCommand(string Name, string Model, int Year, string Size, string Color) : IRequest<Result>;