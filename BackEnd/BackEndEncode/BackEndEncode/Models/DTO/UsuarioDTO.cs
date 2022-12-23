using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndEncode.Models.DTO
{
    public class UsuarioDTO : DTOBase
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string CorreoElectronico { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public string PaisResidencia { get; set; }
        public bool InformacionContacto { get; set; }
    }
}
