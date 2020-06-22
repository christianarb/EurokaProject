using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Linq;
using Netcore.Infrastructure.Data.Context.Mapping;
using Netcore.Domain.Agregates.PersonaAgg;
using Netcore.Domain.Agregates.ParametroAgg;
using Netcore.Domain.Agregates.UbigeoAgg;
using Netcore.Domain.Agregates.ReclamoAgg;
using Netcore.Domain.Agregates.EmpleadoAgg;
using Netcore.Domain.Agregates.AFPAgg;
using Netcore.Domain.Agregates.CargoEmpledoAgg;

namespace Netcore.Infrastructure.Data.Context
{
    public class AppDbContext: DbContext
    {
        public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
        {
            public AppDbContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
                optionsBuilder.UseSqlServer("Server=.;Database=ABCDatabase;User Id=app_user;Password=app_user");

                return new AppDbContext(optionsBuilder.Options);
            }
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        #region IDbSet Members
        /*public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<Parametro> Parametro { get; set; }
        public virtual DbSet<ParametroDetalle> ParametroDetalle { get; set; }

        public virtual DbSet<Ubigeo> Ubigeo { get; set; }
        public virtual DbSet<Reclamo> Reclamo { get; set; }
        public virtual DbSet<ReclamoApoderado> ReclamoApoderado { get; set; }

        public virtual DbSet<ReclamoDetalle> ReclamoDetalle { get; set; }

        public virtual DbSet<ReclamoToken> ReclamoToken { get; set; }*/

        public virtual DbSet<Empleado> Empleado { get; set; }
        public virtual DbSet<Afp> Afp { get; set; }
        public virtual DbSet<Cargo> Cargo { get; set; }
        #region read Models



        #endregion

        #endregion

        #region Model Creating

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            /*modelBuilder.ApplyConfiguration(new PersonaEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ParametroEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ParametroDetalleEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new UbigeoEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ReclamoEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ReclamoDetalleEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ReclamoApoderadoEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new ReclamoTokenEntityTypeConfiguration());*/

            modelBuilder.ApplyConfiguration(new EmpleadoEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AfpTokenEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CargoTokenEntityTypeConfiguration());

            SetNotDeleteCascade(modelBuilder);

            #region read Models

      

            #endregion
        }

        private void SetNotDeleteCascade(ModelBuilder modelBuilder)
        {
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
            .SelectMany(t => t.GetForeignKeys())
            .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;
        }

        #endregion
    }
}
