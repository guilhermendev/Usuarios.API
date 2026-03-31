using Usuarios.API.DTOs;

namespace Usuarios.API.Service
{
    public interface IUsuarioService
    {
        Task<bool> CriarAsync(UsuarioRequestDto dto);
        Task<IEnumerable<UsuarioResponseDto>> BuscarTodosAsync();
        Task<UsuarioResponseDto> BuscarPorIdAsync(int id);
        Task<bool> AtualizarAsync(int id, UsuarioRequestDto dto);
        Task<bool> DeletarAsync(int id);
    }
}
