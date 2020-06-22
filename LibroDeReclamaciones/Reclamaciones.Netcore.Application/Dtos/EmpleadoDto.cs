using System;
using System.ComponentModel.DataAnnotations;
using Netcore.Infrastructure.Crosscutting.Resources;

namespace Netcore.Application.Dtos
{
    public class EmpleadoDto 
    {



        public int Id { get; set; }

        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public DateTime FechaIngreso { get; set; }

        public int IdAfp { get; set; }
       
        public int IdCargo { get; set; }

        public string Afp { get; set; }

        public string Cargo { get; set; }

        public decimal Sueldo { get; set; }
    }
}
