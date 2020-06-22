using Netcore.Domain.EntityBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace Netcore.Domain.Agregates.ParametroAgg
{
    public class Parametro : Entity
    {
        public string Llave { get; set; }
        public string Valor { get; set; }
        public string Tipo { get; set; }
        //public string Estado { get; set; }
        public List<ParametroDetalle> ParametroDetalles { get; set; }
    }
}
