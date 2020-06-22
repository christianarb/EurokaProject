using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Netcore.Domain.Agregates.ParametroAgg;

namespace Netcore.Infrastructure.Data.Context.Mapping
{
    class ParametroEntityTypeConfiguration : IEntityTypeConfiguration<Parametro>
    {
        public void Configure(EntityTypeBuilder<Parametro> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Llave).IsRequired().HasColumnType("nvarchar(256)").HasComment("llave del parámetro");
            builder.Property(x => x.Valor).IsRequired().HasColumnType("nvarchar(256)").HasComment("Valor del parámetro");
            builder.Property(x => x.FechaRegistro).IsRequired().HasColumnType("datetime2");
            builder.Property(x => x.UsuarioRegistro).IsRequired().HasColumnType("nvarchar(320)");
            builder.Property(x => x.FechaModificacion).HasColumnType("datetime2");
            builder.Property(x => x.UsuarioModificacion).HasColumnType("nvarchar(320)");

            builder.HasMany(e => e.ParametroDetalles)
             .WithOne(e => e.Parametro)
             .HasForeignKey(e => e.IdParametro).OnDelete(DeleteBehavior.NoAction)
            .HasPrincipalKey(t => t.Id);

        }
    }
    
}
