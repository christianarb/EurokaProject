using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Netcore.Domain.Agregates.AFPAgg;
using Netcore.Domain.Agregates.CargoEmpledoAgg;
using Netcore.Domain.Agregates.PersonaAgg;
using Netcore.Domain.Agregates.ReclamoAgg;

namespace Netcore.Infrastructure.Data.Context.Mapping
{
   public class CargoTokenEntityTypeConfiguration : IEntityTypeConfiguration<Cargo>
    {
        public void Configure(EntityTypeBuilder<Cargo> builder)
        {
            builder.HasKey(x => x.Id);       
            
        

            builder.Property(x => x.Nombre)
               .IsRequired().HasColumnType("nvarchar(64)")
               .HasComment("Nombre del cargo");



            builder.HasMany(e => e.Empleado)
        .WithOne(e => e.Cargo)
        .HasForeignKey(e => e.IdCargo).OnDelete(DeleteBehavior.NoAction)
        .HasPrincipalKey(t => t.Id);


            /*builder.HasMany(e => e.Afps)
         .WithOne(e => e.Empleado)
         .HasForeignKey(e => e.IdEmpleado).OnDelete(DeleteBehavior.NoAction)
         .HasPrincipalKey(t => t.Id);*/


            /*builder.HasMany(e => e.Cargos)
          .WithOne(e => e.Empleado)
          .HasForeignKey(e => e.IdEmpleado).OnDelete(DeleteBehavior.NoAction)
          .HasPrincipalKey(t => t.Id);*/



            /**/

        }
    }
    
}
