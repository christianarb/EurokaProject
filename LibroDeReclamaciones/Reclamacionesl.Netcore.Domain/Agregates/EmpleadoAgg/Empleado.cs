using Netcore.Domain.Agregates.AFPAgg;
using Netcore.Domain.Agregates.CargoEmpledoAgg;
using System;
using System.Collections.Generic;
using System.Text;

namespace Netcore.Domain.Agregates.EmpleadoAgg
{
    public class Empleado 
    {
        public int Id { get; set; }
        
        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public DateTime FechaIngreso { get; set; }

        public int IdAfp { get; set; }
        public Afp Afp { get; set; }
        public int IdCargo { get; set; }
        public Cargo Cargo { get; set; }

        public decimal  Sueldo { get; set; }
    }
}
