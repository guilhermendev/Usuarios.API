using Usuarios.API.DTOs;

namespace Usuarios.API.Service
{
    public interface IUsuarioService
    {
        Task<bool> CriarAsync(UsuarioRequestDto dto);
        Task<IEnumerable<UsuarioResponseDto>> BuscarTodosAsync();
        UsuarioResponseDto BuscarPorId(int id);
        bool Atualizar(int id, UsuarioRequestDto dto);
        bool Deletar(int id);
    }
}
