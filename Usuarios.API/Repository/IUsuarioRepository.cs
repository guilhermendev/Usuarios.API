using Usuarios.API.Entidade;


namespace Usuarios.API.Repository
{
    public interface IUsuarioRepository
    {
        bool Criar (Usuario usuario);
        IEnumerable<Usuario> BuscarTodos();
        Usuario BuscarPorId(int id);
        bool Atualizar( int id, Usuario usuario);
        bool Deletar(int id);
    }
}
