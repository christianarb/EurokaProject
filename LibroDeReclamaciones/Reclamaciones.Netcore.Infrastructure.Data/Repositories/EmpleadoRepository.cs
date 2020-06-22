using Dapper;
using Netcore.Domain.Agregates.EmpleadoAgg;
using Netcore.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.Data.SqlClient;
using Dapper;
using System.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
namespace Netcore.Infrastructure.Data.Repositories
{
    public class EmpleadoRepository : Repository<Empleado>, IEmpleadoRepository
    {
        readonly AppDbContext _context;
        #region Constructor
        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="unitOfWork">Associated unit of work</param>
        public EmpleadoRepository(AppDbContext dbContext) : base(dbContext)
        {
            _context = dbContext as AppDbContext;
        }

        public async Task<EmpleadoReadModel> ObtenerPorId(int id)
        {
            var param = new DynamicParameters();

            param.Add("@id", id, DbType.Int32);

            var resultado = await _context.Database.GetDbConnection()
                .QueryAsync<EmpleadoReadModel>("Empleados_Seleccionar @id", param);

            return resultado.FirstOrDefault();
        }

        public async Task<List<EmpleadoReadModel>> ObtenerTodos()
        {
           
            var resultado = await _context.Database.GetDbConnection()
                .QueryAsync<EmpleadoReadModel>("Empleados_Listar");

            return resultado.ToList();
        }



        #endregion

        /* public async Task<ClientePorEmailReadModel> ObtenerPorEmail(string email)
         {
             var param = new DynamicParameters();
             param.Add("@email", email, DbType.String);

             var resultado = await _context.Database.GetDbConnection()
                 .QueryAsync<ClientePorEmailReadModel>(StoredProcedures.CLIENTE_OBTENER_POR_EMAIL, param);

             return resultado.FirstOrDefault();
         }*/
    }
}
