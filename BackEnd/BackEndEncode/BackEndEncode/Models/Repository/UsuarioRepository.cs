using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndEncode.Models.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DESAFIO_ENCODE_GONZALOMIRANDAContext _context;

        public UsuarioRepository(DESAFIO_ENCODE_GONZALOMIRANDAContext context)
        {
            _context = context;
        }

        public async Task<Usuario> AddUsuario(Usuario usuario)
        {
            _context.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task DeleteUsuario(Usuario usuario)
        {
               _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
        }

        public async Task<List<Usuario>> GetListUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuario> GetUsuario(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

        public async Task UpdateUsuario(Usuario usuario)
        {
            var usuarioItem = await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == usuario.Id);

            if (usuarioItem != null)
            {
                usuarioItem.Nombre = usuario.Nombre;
                usuarioItem.Apellido = usuario.Apellido;
                usuarioItem.CorreoElectronico = usuario.CorreoElectronico;
                usuarioItem.FechaNacimiento = usuario.FechaNacimiento;
                usuarioItem.InformacionContacto = usuario.InformacionContacto;
                usuarioItem.PaisResidencia = usuario.PaisResidencia;
                usuarioItem.Telefono = usuario.Telefono;

                await _context.SaveChangesAsync();
            }
        }
    }
}
