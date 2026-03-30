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


        public bool Criar(UsuarioRequestDto dto)
        {

            var usuario = _mapping.UsuarioRequestDtoToUsuario(dto);
            return _Repository.Criar(usuario);
        }


        public IEnumerable<UsuarioResponseDto> BuscarTodos()
        {
            var usuarios = _Repository.BuscarTodos();
            return usuarios.Select(u => _mapping.UsuarioToUsuarioResponseDto(u));
        }


        public UsuarioResponseDto BuscarPorId(int id)
        {
            var usuario = _Repository.BuscarPorId(id);

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
