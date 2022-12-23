using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndEncode.Models.Repository
{
    public class ActividadRepository : IActividadRepository
    {
        private readonly DESAFIO_ENCODE_GONZALOMIRANDAContext _context;

        public ActividadRepository(DESAFIO_ENCODE_GONZALOMIRANDAContext context)
        {
            _context = context;
        }

        public async Task<Actividad> AddActividad(Actividad actividad)
        {
            _context.Add(actividad);
            await _context.SaveChangesAsync();
            return actividad;
        }

        public async Task<List<Actividad>> GetListActividades()
        {
            return await _context.Actividades.Include(x => x.IdUsuarioNavigation).ToListAsync();
        }
    }
}
