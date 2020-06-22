using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Netcore.Domain.Agregates.ParametroAgg;
using Netcore.Domain.Agregates.PersonaAgg;

namespace Netcore.Infrastructure.Data.Context.Mapping
{
   public class ParametroDetalleEntityTypeConfiguration : IEntityTypeConfiguration<ParametroDetalle>
    {
        public void Configure(EntityTypeBuilder<ParametroDetalle> builder)
        {
            builder.HasKey(x => x.Id);

         
            builder.Property(x => x.Valor).IsRequired().HasColumnType("nvarchar(256)");
            builder.Property(x => x.Llave).IsRequired().HasColumnType("nvarchar(256)");
          
            builder.Property(x => x.FechaRegistro).IsRequired().HasColumnType("datetime2");
            builder.Property(x => x.UsuarioRegistro).IsRequired().HasColumnType("nvarchar(24)");
            builder.Property(x => x.FechaModificacion).HasColumnType("datetime2");
            builder.Property(x => x.UsuarioModificacion).HasColumnType("nvarchar(24)");
            builder.Property(x => x.Orden).HasColumnType("int");


            //Persona
             builder.HasMany(e => e.PersonaTipoDocumento)
            .WithOne(e => e.TipoDocumento)
            .HasForeignKey(e => e.IdTipoDocumento).OnDelete(DeleteBehavior.NoAction)
            .HasPrincipalKey(t => t.Id);

           /*builder.HasMany(e => e.PersonaTipoRespuesta)
             .WithOne(e => e.TipoRespuesta)
             .HasForeignKey(e => e.IdTipoRespuesta).OnDelete(DeleteBehavior.NoAction)
            .HasPrincipalKey(t => t.Id);*/

            builder.HasMany(e => e.PersonaTipoPersona)
             .WithOne(e => e.TipoPersona)
             .HasForeignKey(e => e.IdTipoPersona).OnDelete(DeleteBehavior.NoAction)
            .HasPrincipalKey(t => t.Id);

            //Reclamo

            builder.HasMany(e => e.ReclamoTipoRespuesta)
             .WithOne(e => e.TipoRespuesta)
             .HasForeignKey(e => e.IdTipoRespuesta).OnDelete(DeleteBehavior.NoAction)
            .HasPrincipalKey(t => t.Id);

            builder.HasMany(e => e.ReclamoTipoReclamo)
             .WithOne(e => e.TipoReclamo)
             .HasForeignKey(e => e.IdTipoReclamo).OnDelete(DeleteBehavior.NoAction)
            .HasPrincipalKey(t => t.Id);

            builder.HasMany(e => e.ReclamoTipoBien)
             .WithOne(e => e.TipoBien)
             .HasForeignKey(e => e.IdTipoBien).OnDelete(DeleteBehavior.NoAction)
            .HasPrincipalKey(t => t.Id);


            //Reclamo Detalle

            builder.HasMany(e => e.ReclamoDetalleTipoReclamo)
           .WithOne(e => e.TipoReclamo)
           .HasForeignKey(e => e.IdTipoReclamo).OnDelete(DeleteBehavior.NoAction)
          .HasPrincipalKey(t => t.Id);

            //Reclamo Apoderado

            builder.HasMany(e => e.ReclamoApoderadoTipoRespuesta)
           .WithOne(e => e.TipoRespuesta)
           .HasForeignKey(e => e.IdTipoRespuesta).OnDelete(DeleteBehavior.NoAction)
          .HasPrincipalKey(t => t.Id);
        }
    }
    
}
