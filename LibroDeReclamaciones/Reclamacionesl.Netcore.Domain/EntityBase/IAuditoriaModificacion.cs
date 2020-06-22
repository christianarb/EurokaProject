using System;

namespace Netcore.Domain.EntityBase
{
    public interface IAuditoriaModificacion
    {
        public DateTime? FechaModificacion { get; set; }

        public string UsuarioModificacion { get; set; }
    }
}
