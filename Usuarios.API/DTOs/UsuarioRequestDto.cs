namespace Usuarios.API.DTOs
{
    public class UsuarioRequestDto
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cpf { get; set; }
    }
}
