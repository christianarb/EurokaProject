using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Netcore.Domain.Agregates.PersonaAgg;

namespace Netcore.Infrastructure.Data.Context.Mapping
{
   public class PersonaEntityTypeConfiguration : IEntityTypeConfiguration<Persona>
    {
        public void Configure(EntityTypeBuilder<Persona> builder)
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
            builder.Property(x => x.NroDocumento)
                .IsRequired().HasColumnType("nvarchar(24)")
                .HasComment("Número de documento de la persona");
            builder.Property(x => x.Telefono)
             .IsRequired().HasColumnType("nvarchar(16)")
             .HasComment("Número de documento de la persona");
            builder.Property(x => x.Correo)
             .IsRequired().HasColumnType("nvarchar(128)")
             .HasComment("Número de documento de la persona");

            builder.HasMany(e => e.Reclamo)
             .WithOne(e => e.Consumidor)
             .HasForeignKey(e => e.IdConsumidor).OnDelete(DeleteBehavior.NoAction)
             .HasPrincipalKey(t => t.Id);


            builder.HasMany(e => e.ReclamoApoderado)
          .WithOne(e => e.Apoderado)
          .HasForeignKey(e => e.IdApoderado).OnDelete(DeleteBehavior.NoAction)
          .HasPrincipalKey(t => t.Id);

        }
    }
    
}
