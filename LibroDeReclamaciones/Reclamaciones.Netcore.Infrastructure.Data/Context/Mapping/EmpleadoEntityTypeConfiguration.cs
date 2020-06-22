using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Netcore.Domain.Agregates.EmpleadoAgg;
using Netcore.Domain.Agregates.PersonaAgg;

namespace Netcore.Infrastructure.Data.Context.Mapping
{
   public class EmpleadoEntityTypeConfiguration : IEntityTypeConfiguration<Empleado>
    {
        public void Configure(EntityTypeBuilder<Empleado> builder)
        {
            builder.HasKey(x => x.Id);         
            builder.Property(x => x.Nombres)
                .IsRequired().HasColumnType("nvarchar(64)")
                .HasComment("Nombre de la persona");
            builder.Property(x => x.ApellidoPaterno)
                .IsRequired().HasColumnType("nvarchar(64)")
                .HasComment("Apellido paterno de la persona");
            builder.Property(x => x.ApellidoMaterno)
                .IsRequired().HasColumnType("nvarchar(64)")
                .HasComment("Apellido materno de la persona");

            builder.Property(x => x.Sueldo)
                .IsRequired().HasColumnType("decimal(6,2)")
                .HasComment("Apellido materno de la persona");

        }
    }
    
}
