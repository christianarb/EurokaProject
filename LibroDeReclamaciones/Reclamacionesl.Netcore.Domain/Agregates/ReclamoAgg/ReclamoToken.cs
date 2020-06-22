using System;
using System.Collections.Generic;
using System.Text;

namespace Netcore.Domain.Agregates.ReclamoAgg
{
    public class ReclamoToken
    {
        public int Id { get; set; }
        public string NroReclamo { get; set; }
        public string IP { get; set; }
        public bool  Procesado { get; set; }
        public List<Reclamo> Reclamo { get; set; }
}
}
