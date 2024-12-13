using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Clothes.Application.CreateClothe;
using Clothes.Domain.Repositories;
using Clothes.Infra.Context;
using Clothes.Infra.Repositories;

namespace Clothes.API.Configuration;

public static class ConfigurationAPI 
{
    public static IServiceCollection AddConfigurations(this IServiceCollection services)
    {
        // Adds and configures the DbContextClothes (which is your Entity Framework Core context) to use an in-memory database. 
        // This is typically used for testing or development due to the volatile nature of the in-memory database.
        services.AddDbContext<DbContextClothe>(x => x.UseInMemoryDatabase(nameof(DbContextClothe)));

        // Registers the generic repository interface IRepository<> and its implementation Repository<> to the services collection.
        // The AddScoped method means a new instance of the service will be created for each scope, i.e., each web request.
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        // Adds MediatR services (a library for in-process messaging) to the services collection.
        // It scans the assembly containing CreateClotheCommand for any classes that are handling requests (commands/queries).
        services.AddMediatR(x => x.RegisterServicesFromAssemblyContaining(typeof(CreateClotheCommand)));

        // Adds FluentValidation services (a library for building strongly-typed validation rules) to the services collection.
        // It scans the assembly containing CreateClotheCommandValidator for any validation classes.
        services.AddValidatorsFromAssemblyContaining(typeof(CreateClotheCommandValidator));

        return services;
    }
}
