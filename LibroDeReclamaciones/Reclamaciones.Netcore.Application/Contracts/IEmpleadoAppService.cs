using System.Collections.Generic;
using System.Threading.Tasks;
using Netcore.Application.Dtos;


namespace Netcore.Application.Contracts
{
    public interface IEmpleadoAppService
    {
        Task<List<EmpleadoDto>> ObtenerTodos();
        Task<EmpleadoDto> ObtenerPorId(int id);

        Task<EmpleadoDto> Agregar(EmpleadoDto empleado);
    }
}
