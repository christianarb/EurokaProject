using Netcore.Domain.Agregates.ParametroAgg;
using Netcore.Domain.Agregates.ReclamoAgg;
using Netcore.Domain.EntityBase;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace Netcore.Domain.Agregates.PersonaAgg
{
    public class Persona : Entity
    {
        public int IdTipoDocumento { get; set; }
        public ParametroDetalle TipoDocumento { get; set; }
       // public int IdTipoRespuesta { get; set; }
       // public ParametroDetalle TipoRespuesta { get; set; }
        public int IdTipoPersona { get; set; }
        public ParametroDetalle TipoPersona { get; set; }
        public string Nombres { get; set; }        
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string NroDocumento { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }

        public List<Reclamo> Reclamo { get; set; }
        public List<ReclamoApoderado> ReclamoApoderado { get; set; }


    }
}
