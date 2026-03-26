using Usuarios.API.Entidade;


namespace Usuarios.API.Repository
{
    public interface IUsuarioRepository
    {
        void Criar (Usuario usuario);
        IEnumerable<Usuario> BuscarTodos();
        Usuario BuscarPorId(int id);
        void Atualizar( int id, Usuario usuario);
    }
}
