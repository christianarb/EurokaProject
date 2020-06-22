using Netcore.Domain.Agregates.ParametroAgg;
using Netcore.Domain.Agregates.PersonaAgg;
using Netcore.Domain.Agregates.UbigeoAgg;
using Netcore.Domain.EntityBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace Netcore.Domain.Agregates.ReclamoAgg
{
    public class ReclamoApoderado : Entity
    {

       // public int?  IdReclamo { get; set; }
        public Reclamo Reclamo { get; set; }

        public int?  IdApoderado { get; set; }
        public Persona Apoderado { get; set; }

        public int? IdDepartamento { get; set; }
        public Ubigeo Departamento { get; set; }
        public int? IdProvincia { get; set; }
        public Ubigeo Provincia { get; set; }
        public int? IdDistrito { get; set; }
        public Ubigeo Distrito { get; set; }

        public int? IdTipoRespuesta { get; set; }
        public ParametroDetalle TipoRespuesta { get; set; }

        public string Direccion { get; set; }
    }
}
