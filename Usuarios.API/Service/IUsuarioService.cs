using Usuarios.API.DTOs;

namespace Usuarios.API.Service
{
    public interface IUsuarioService
    {
        void Criar(UsuarioRequestDto dto);
        IEnumerable<UsuarioResponseDto> BuscarTodos();
        UsuarioResponseDto BuscarPorId(int id);
        void Atualizar(int id, UsuarioRequestDto dto);
        void Deletar(int id);
    }
}
