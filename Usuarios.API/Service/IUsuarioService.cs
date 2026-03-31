using Usuarios.API.DTOs;

namespace Usuarios.API.Service
{
    public interface IUsuarioService
    {
        Task<bool> CriarAsync(UsuarioRequestDto dto);
        Task<IEnumerable<UsuarioResponseDto>> BuscarTodosAsync();
        Task<UsuarioResponseDto> BuscarPorIdAsync(int id);
        bool Atualizar(int id, UsuarioRequestDto dto);
        bool Deletar(int id);
    }
}
