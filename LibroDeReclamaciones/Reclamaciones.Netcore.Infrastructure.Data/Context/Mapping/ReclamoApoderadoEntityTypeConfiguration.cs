using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Netcore.Domain.Agregates.PersonaAgg;
using Netcore.Domain.Agregates.ReclamoAgg;

namespace Netcore.Infrastructure.Data.Context.Mapping
{
   public class ReclamoApoderadoEntityTypeConfiguration : IEntityTypeConfiguration<ReclamoApoderado>
    {
        public void Configure(EntityTypeBuilder<ReclamoApoderado> builder)
        {
            builder.Property(x => x.Id).IsRequired().HasColumnType("int")
               .HasComment("IdReclamo");



            builder.Property(x => x.Direccion)
               .IsRequired().HasColumnType("nvarchar(512)")
               .HasComment("Dirección de reclamo");

          


            /**/

        }
    }
    
}
