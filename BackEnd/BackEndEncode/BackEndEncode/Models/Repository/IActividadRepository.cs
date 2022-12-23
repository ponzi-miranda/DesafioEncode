using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndEncode.Models.Repository
{
    public interface IActividadRepository
    {
        Task<Actividad> AddActividad(Actividad actividad);
        Task<List<Actividad>> GetListActividades();
    }
}
