using Netcore.Domain.Agregates.PersonaAgg;
using Netcore.Domain.Agregates.ReclamoAgg;
using Netcore.Domain.EntityBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace Netcore.Domain.Agregates.UbigeoAgg
{
    public class Ubigeo : Entity
    {
        public string Codigo { get; set; }

        public string Nombre { get; set; }

        public string NombreCompuesto { get; set; }

        public int? IdUbigeoPadre { get; set; }

        public List<Ubigeo> UbigeoHijos { get; set; }

        public List<Reclamo> ReclamoDepartamentos { get; set; }

        public List<Reclamo> ReclamoProvincias { get; set; }

        public List<Reclamo> ReclamoDistritos { get; set; }

        public Ubigeo UbigeoPadre { get; set; }


        public List<ReclamoApoderado> ReclamoApoderadoDepartamentos { get; set; }

        public List<ReclamoApoderado> ReclamoApoderadoProvincias { get; set; }

        public List<ReclamoApoderado> ReclamoApoderadoDistritos { get; set; }
    }
}
