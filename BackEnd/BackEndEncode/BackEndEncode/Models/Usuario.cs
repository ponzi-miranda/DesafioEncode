using System;
using System.Collections.Generic;

#nullable disable

namespace BackEndEncode.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Actividades = new HashSet<Actividad>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string CorreoElectronico { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public string PaisResidencia { get; set; }
        public bool InformacionContacto { get; set; }

        public virtual ICollection<Actividad> Actividades { get; set; }
    }
}
