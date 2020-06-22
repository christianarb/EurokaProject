using System;
using System.Collections.Generic;
using System.Text;

namespace Netcore.Domain.Agregates.EmpleadoAgg
{
    public class EmpleadoReadModel
    {
        public int Id { get; set; }

        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public DateTime FechaIngreso { get; set; }

        public int IdAfp { get; set; }
        public String Afp { get; set; }
        public int IdCargo { get; set; }
        public String Cargo { get; set; }
    }
}
