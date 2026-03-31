using Usuarios.API.Entidade;


namespace Usuarios.API.Repository
{
    public interface IUsuarioRepository
    {
        Task<bool> CriarAsync(Usuario usuario);
        Task <IEnumerable<Usuario>> BuscarTodosAsync();
        Usuario BuscarPorId(int id);
        bool Atualizar( int id, Usuario usuario);
        bool Deletar(int id);
    }
}
