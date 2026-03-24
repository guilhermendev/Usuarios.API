using Usuarios.API.DTOs;
using Usuarios.API.Entidade;

namespace Usuarios.API.Mapping
{
    public class UsuarioMapping
    {
        public Usuario UsuarioRequestDtoToUsuario(UsuarioRequestDto dto)
        {
            return new Usuario
            {
                NomeCompleto = dto.Nome,
                DataNascimento = dto.DataNascimento,
                Cpf = dto.Cpf
            };
        }
    }
}
