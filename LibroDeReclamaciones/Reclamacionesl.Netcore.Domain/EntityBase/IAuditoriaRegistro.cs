using System;

namespace Netcore.Domain.EntityBase
{
    public interface IAuditoriaRegistro
    {
        public DateTime FechaRegistro { get; set; }

        public string UsuarioRegistro { get; set; }
    }
}
