using Usuarios.API.Entidade;


namespace Usuarios.API.Repository
{
    public interface IUsuarioRepository
    {
        Task<bool> CriarAsync(Usuario usuario);
        Task <IEnumerable<Usuario>> BuscarTodosAsync();
        Task<Usuario> BuscarPorIdAsync(int id);
        Task<bool> AtualizarAsync( int id, Usuario usuario);
        bool Deletar(int id);
    }
}
