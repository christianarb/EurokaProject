using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Netcore.Domain.Agregates.UbigeoAgg;


namespace Netcore.Infrastructure.Data.Context.Mapping
{
    class UbigeoEntityTypeConfiguration : IEntityTypeConfiguration<Ubigeo>
    {
        public void Configure(EntityTypeBuilder<Ubigeo> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Codigo).IsRequired().HasColumnType("nvarchar(20)");
            builder.Property(x => x.Nombre).IsRequired().HasColumnType("nvarchar(100)");
            builder.Property(x => x.NombreCompuesto).IsRequired().HasColumnType("nvarchar(250)");
            //builder.Property(x => x.Activo).IsRequired();
            builder.Property(x => x.FechaRegistro).IsRequired().HasColumnType("datetime2");
            builder.Property(x => x.UsuarioRegistro).IsRequired().HasColumnType("nvarchar(320)");
            builder.Property(x => x.FechaModificacion).HasColumnType("datetime2");
            builder.Property(x => x.UsuarioModificacion).HasColumnType("nvarchar(320)");
            builder.HasIndex(x => x.NombreCompuesto);

            builder.HasMany(e => e.ReclamoDepartamentos)
                .WithOne(e => e.Departamento)
                .HasForeignKey(e => e.IdDepartamento).OnDelete(DeleteBehavior.NoAction)
            .HasPrincipalKey(t => t.Id);

            builder.HasMany(e => e.ReclamoProvincias)
                .WithOne(e => e.Provincia)
                .HasForeignKey(e => e.IdProvincia).OnDelete(DeleteBehavior.NoAction)
            .HasPrincipalKey(t => t.Id);

            builder.HasMany(e => e.ReclamoDistritos)
                .WithOne(e => e.Distrito)
                .HasForeignKey(e => e.IdDistrito).OnDelete(DeleteBehavior.NoAction)
            .HasPrincipalKey(t => t.Id);



            builder.HasMany(e => e.UbigeoHijos)
                .WithOne(e => e.UbigeoPadre)
                .HasForeignKey(e => e.IdUbigeoPadre).OnDelete(DeleteBehavior.NoAction)
            .HasPrincipalKey(t => t.Id);


            builder.HasMany(e => e.ReclamoApoderadoDepartamentos)
          .WithOne(e => e.Departamento)
          .HasForeignKey(e => e.IdDepartamento).OnDelete(DeleteBehavior.NoAction)
      .HasPrincipalKey(t => t.Id);

            builder.HasMany(e => e.ReclamoApoderadoProvincias)
                .WithOne(e => e.Provincia)
                .HasForeignKey(e => e.IdProvincia).OnDelete(DeleteBehavior.NoAction)
            .HasPrincipalKey(t => t.Id);

            builder.HasMany(e => e.ReclamoApoderadoDistritos)
                .WithOne(e => e.Distrito)
                .HasForeignKey(e => e.IdDistrito).OnDelete(DeleteBehavior.NoAction)
            .HasPrincipalKey(t => t.Id);
        }
    }
}
