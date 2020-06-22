using Netcore.Domain.Agregates.EmpleadoAgg;
using System;
using System.Collections.Generic;
using System.Text;

namespace Netcore.Domain.Agregates.AFPAgg
{
    public class Afp
    {
        public int Id { get; set; }
        public int Nombre { get; set; }

        //public int IdEmpleado { get; set; }
        public List<Empleado> Empleado { get; set; }
    }
}
