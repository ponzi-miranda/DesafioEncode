using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndEncode.Models.Repository
{
    public interface IUsuarioRepository
    {
        Task<List<Usuario>> GetListUsuarios();
        Task<Usuario> GetUsuario(int id);
        Task DeleteUsuario(Usuario usuario);
        Task<Usuario> AddUsuario(Usuario usuario);
        Task UpdateUsuario(Usuario usuario);
    }
}
