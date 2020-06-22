using Netcore.Domain.Agregates.PersonaAgg;
using Netcore.Domain.Agregates.ReclamoAgg;
using Netcore.Domain.EntityBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace Netcore.Domain.Agregates.ParametroAgg
{
    public class ParametroDetalle : Entity
    {
        public Parametro Parametro { get; set; }
        public int IdParametro { get; set; }
        public string Llave { get; set; }
        public string Valor { get; set; }
        public int Orden { get; set; }
        //public List<Reclamo> Reclamos { get; set; }
        public List<Persona> PersonaTipoDocumento { get; set; }
        //public List<Persona> PersonaTipoRespuesta { get; set; }
        public List<Persona> PersonaTipoPersona { get; set; }   
        
        public List<Reclamo> ReclamoTipoRespuesta { get; set; }
        public List<Reclamo> ReclamoTipoReclamo { get; set; }
        public List<Reclamo> ReclamoTipoBien { get; set; }


        public List<ReclamoDetalle> ReclamoDetalleTipoReclamo { get; set; }


        public List<ReclamoApoderado> ReclamoApoderadoTipoRespuesta { get; set; }
        


    }
}
