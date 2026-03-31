using Usuarios.API.DTOs;
using Usuarios.API.Mapping;
using Usuarios.API.Repository;

namespace Usuarios.API.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _Repository;
        private readonly UsuarioMapping _mapping;

        public UsuarioService(IUsuarioRepository repository, UsuarioMapping mapping)
        {
            _Repository = repository;
            _mapping = mapping;
        }


        public async Task<bool> CriarAsync(UsuarioRequestDto dto)
        {

            var usuario = _mapping.UsuarioRequestDtoToUsuario(dto);
            return await _Repository.CriarAsync(usuario);
        }


        public async Task<IEnumerable<UsuarioResponseDto>> BuscarTodosAsync()
        {
            var usuarios = await _Repository.BuscarTodosAsync();
            return usuarios.Select(u => _mapping.UsuarioToUsuarioResponseDto(u));
        }


        public async Task<UsuarioResponseDto> BuscarPorIdAsync(int id)
        {
            var usuario =await _Repository.BuscarPorIdAsync(id);

            if (usuario == null)
                return null;

            return _mapping.UsuarioToUsuarioResponseDto(usuario);
        }


        public bool Atualizar(int id, UsuarioRequestDto dto)
        {
            var usuario = _mapping.UsuarioRequestDtoToUsuario(dto);
            return _Repository.Atualizar(id, usuario);
        } 


        public bool Deletar(int id)
        {
           return _Repository.Deletar(id);
           
        }
     }
}
