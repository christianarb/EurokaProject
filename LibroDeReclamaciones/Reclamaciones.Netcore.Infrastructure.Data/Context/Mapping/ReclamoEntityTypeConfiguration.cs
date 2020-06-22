using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Netcore.Domain.Agregates.PersonaAgg;
using Netcore.Domain.Agregates.ReclamoAgg;

namespace Netcore.Infrastructure.Data.Context.Mapping
{
   public class ReclamoEntityTypeConfiguration : IEntityTypeConfiguration<Reclamo>
    {
        public void Configure(EntityTypeBuilder<Reclamo> builder)
        {
            //builder.HasKey(x => x.Id);       
            
            builder.Property(x => x.NroReclamo)
                .IsRequired().HasColumnType("nvarchar(6)")
                .HasComment("Número de reclamo");

            builder.Property(x => x.FechaReclamo)
             .IsRequired().HasColumnType("datetime2")
             .HasComment("Fecha de reclamo");

            builder.Property(x => x.MontoReclamado)
             .IsRequired().HasColumnType("decimal(6,2)")
             .HasComment("Monto del reclamo");


            builder.Property(x => x.Descripcion)
                .IsRequired().HasColumnType("nvarchar(max)")
                .HasComment("Descripción de reclamo");

            builder.Property(x => x.AceptaCondiciones)
               .IsRequired().HasColumnType("bit")
               .HasComment("Acepta condiciones");


            builder.Property(x => x.ConformidadCondiciones)
               .IsRequired().HasColumnType("bit")
               .HasComment("Conformidad de condiciones");

            builder.Property(x => x.Direccion)
               .IsRequired().HasColumnType("nvarchar(512)")
               .HasComment("Dirección de reclamo");

            builder.Property(x => x.EsMenorEdad)
              .IsRequired().HasColumnType("bit")
              .HasComment("Es menor de edad");


            builder.HasMany(e => e.ReclamoDetalle)
                         .WithOne(e => e.Reclamo)
                         .HasForeignKey(e => e.IdReclamo)
                         .OnDelete(DeleteBehavior.NoAction)
            .HasPrincipalKey(t => t.Id);

            builder.HasOne(e => e.ReclamoApoderado)
                        .WithOne(e => e.Reclamo)
                        .HasForeignKey<ReclamoApoderado>(b => b.Id);
            // .HasForeignKey(e => e.IdReclamo)
            // .OnDelete(DeleteBehavior.NoAction)
            //.HasPrincipalKey(t => t.);





            /**/

        }
    }
    
}
