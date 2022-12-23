using System;
using System.Collections.Generic;

#nullable disable

namespace BackEndEncode.Models
{
    public partial class Actividad
    {
        public int Id { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int IdUsuario { get; set; }
        public string ActividadDescripcion { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
