using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Netcore.Domain.Agregates.EmpleadoAgg
{
    public interface IEmpleadoRepository : IRepository<Empleado>
    {


        Task<List<EmpleadoReadModel>> ObtenerTodos();
        Task<EmpleadoReadModel> ObtenerPorId(int id);
    }
}
