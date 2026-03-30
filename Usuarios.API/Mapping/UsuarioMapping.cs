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
        public UsuarioResponseDto UsuarioToUsuarioResponseDto(Usuario usuario)
        {

            if (usuario == null)
                return null;

            return new UsuarioResponseDto
            {
                CodigoUsuario = usuario.Id,
                NomeUsuario = usuario.NomeCompleto,
                Nascimento = usuario.DataNascimento,
                CodigoPessoaFisica = usuario.Cpf
            };
        }
    }
}