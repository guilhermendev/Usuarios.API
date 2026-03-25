using Usuarios.API.DTOs;
using Usuarios.API.Entidade;

namespace Usuarios.API.Service
{
    public interface IUsuarioService
    {
        void Criar(UsuarioRequestDto dto);
        IEnumerable<Usuario> BuscarTodos();
        Usuario BuscarPorId(int id);
    }
}
