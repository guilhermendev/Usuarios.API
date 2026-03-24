using Usuarios.API.DTOs;

namespace Usuarios.API.Service
{
    public interface IUsuarioService
    {
        void Criar(UsuarioRequestDto dto);
    }
}
