using Usuarios.API.DTOs;

namespace Usuarios.API.Service
{
    public interface IUsuarioService
    {
        bool Criar(UsuarioRequestDto dto);
        IEnumerable<UsuarioResponseDto> BuscarTodos();
        UsuarioResponseDto BuscarPorId(int id);
        bool Atualizar(int id, UsuarioRequestDto dto);
        bool Deletar(int id);
    }
}
