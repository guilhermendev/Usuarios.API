namespace Usuarios.API.DTOs
{
    public class UsuarioResponseDto
    {
        public int CodigoUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public DateTime Nascimento { get; set; }
        public string CodigoPessoaFisica { get; set; }
    }
}
