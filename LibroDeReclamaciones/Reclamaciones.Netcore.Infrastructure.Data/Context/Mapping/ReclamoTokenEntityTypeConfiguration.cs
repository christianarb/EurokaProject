using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Netcore.Domain.Agregates.PersonaAgg;
using Netcore.Domain.Agregates.ReclamoAgg;

namespace Netcore.Infrastructure.Data.Context.Mapping
{
   public class ReclamoTokenEntityTypeConfiguration : IEntityTypeConfiguration<ReclamoToken>
    {
        public void Configure(EntityTypeBuilder<ReclamoToken> builder)
        {
            builder.HasKey(x => x.Id);       
            
        

            builder.Property(x => x.IP)
               .IsRequired().HasColumnType("nvarchar(12)")
               .HasComment("Dirección IP de solicitante");

            builder.Property(x => x.NroReclamo)
               .IsRequired().HasColumnType("nvarchar(6)")
               .HasComment("Dirección IP de solicitante");

            builder.Property(x => x.Procesado)
              .IsRequired().HasColumnType("bit")
              .HasComment("Dirección IP de solicitante");



            builder.HasMany(e => e.Reclamo)
                       .WithOne(e => e.ReclamoToken)
                       .HasForeignKey(e => e.IdReclamoToken)
                       .OnDelete(DeleteBehavior.NoAction)
          .HasPrincipalKey(t => t.Id);

            /**/

        }
    }
    
}
