using System;

namespace Netcore.Domain.EntityBase
{
    public class Entity : IAuditoriaRegistro, IAuditoriaModificacion
    {
        public int Id { get; set; }
       // public bool Activo { get; set; }

        #region Auditoria Registro

        public DateTime FechaRegistro { get; set; }
        public string UsuarioRegistro { get; set; }

        #endregion

        #region Auditoria Modificacion

        public DateTime? FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }

        #endregion
    }
}
