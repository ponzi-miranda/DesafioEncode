using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndEncode.Models.DTO
{
    public class ActividadDTO : DTOBase
    {
        public DateTime FechaCreacion { get; set; }
        public int IdUsuario { get; set; }
        public string ActividadDescripcion { get; set; }
        public string Nombre {get; set;}
    }
}
