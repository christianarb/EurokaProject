using Netcore.Domain.Agregates.ParametroAgg;
using Netcore.Domain.Agregates.PersonaAgg;
using Netcore.Domain.Agregates.UbigeoAgg;
using Netcore.Domain.EntityBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace Netcore.Domain.Agregates.ReclamoAgg
{
    public class Reclamo : Entity
    {
        public string NroReclamo { get; set; }
        public DateTime FechaReclamo { get; set; }
       
        public decimal MontoReclamado { get; set; }
        public string Descripcion { get; set; }       
        public bool AceptaCondiciones { get; set; }
        public bool ConformidadCondiciones { get; set; }

        public int? IdConsumidor { get; set; }
        public Persona Consumidor { get; set; }

        public int? IdDepartamento { get; set; }
        public Ubigeo Departamento { get; set; }
        public int? IdProvincia { get; set; }
        public Ubigeo Provincia { get; set; }
        public int? IdDistrito { get; set; }
        public Ubigeo Distrito { get; set; }

        public int? IdTipoRespuesta { get; set; }
        public ParametroDetalle TipoRespuesta { get; set; }
        public string Direccion { get; set; }
        public bool EsMenorEdad { get; set; }

        public int? IdTipoReclamo{ get; set; }
        public ParametroDetalle TipoReclamo { get; set; }

        public int? IdTipoBien { get; set; }
        public ParametroDetalle TipoBien { get; set; }

     
        public List<ReclamoDetalle> ReclamoDetalle { get; set; }
        public ReclamoApoderado ReclamoApoderado { get; set; }


        public int? IdReclamoToken { get; set; }
        public ReclamoToken ReclamoToken { get; set; }
        
    }
}
