using Microsoft.EntityFrameworkCore;
using Clothes.Infra.MappingEntities;

namespace Clothes.Infra.Context;

public class DbContextClothe : DbContext
{
    public DbContextClothe(DbContextOptions<DbContextClothe> options) : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new MappingClothe());
    }

}
