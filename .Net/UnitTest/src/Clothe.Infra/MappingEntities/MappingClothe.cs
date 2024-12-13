using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Clothes.Domain.Entities;

namespace Clothes.Infra.MappingEntities;

public class MappingClothe : MappingBaseEntity<ClotheEntity>
{
    public override void Configure(EntityTypeBuilder<ClotheEntity> builder)
    {
        base.Configure(builder);
        builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
        builder.Property(x => x.Fabric).HasMaxLength(50).IsRequired();
        builder.Property(x => x.Year).IsRequired();
        builder.Property(x => x.Size).HasMaxLength(5).IsRequired();
        builder.Property(x => x.Color).HasMaxLength(15).IsRequired();
        
    }
}
