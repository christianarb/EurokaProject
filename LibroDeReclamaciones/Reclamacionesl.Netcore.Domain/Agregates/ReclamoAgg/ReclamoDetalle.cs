using Netcore.Domain.Agregates.ParametroAgg;
using Netcore.Domain.EntityBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace Netcore.Domain.Agregates.ReclamoAgg
{
    public class ReclamoDetalle : Entity
    {
        public int? IdReclamo { get; set; }
        public Reclamo Reclamo { get; set; }

        public int? IdTipoReclamo { get; set; }
        public ParametroDetalle TipoReclamo { get; set; }

        public string Detalle { get; set; }

        public string Pedido { get; set; }
    }
}
