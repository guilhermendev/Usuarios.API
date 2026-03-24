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

        public void Criar(UsuarioRequestDto dto)
        {

            var usuario = _mapping.UsuarioRequestDtoToUsuario(dto);
            _Repository.Criar(usuario);

        }
    }
}
