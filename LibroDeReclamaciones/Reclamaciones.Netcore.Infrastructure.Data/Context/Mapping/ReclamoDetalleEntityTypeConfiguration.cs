using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Netcore.Domain.Agregates.PersonaAgg;
using Netcore.Domain.Agregates.ReclamoAgg;

namespace Netcore.Infrastructure.Data.Context.Mapping
{
   public class ReclamoDetalleEntityTypeConfiguration : IEntityTypeConfiguration<ReclamoDetalle>
    {
        public void Configure(EntityTypeBuilder<ReclamoDetalle> builder)
        {
            builder.HasKey(x => x.Id);       
            
        

            builder.Property(x => x.Detalle)
               .IsRequired().HasColumnType("nvarchar(512)")
               .HasComment("Dirección de reclamo");


            

            /**/

        }
    }
    
}
