using Dapper;
using Usuarios.API.Entidade;
using System.Data;


namespace Usuarios.API.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IDbConnection _connection;

        public UsuarioRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public void Criar(Usuario usuario)
        {
            var sql = "INSERT INTO Usuario (Nome_Completo, Data_Nascimento, Cpf) VALUES (@NomeCompleto, @DataNascimento,@Cpf)";
            _connection.Execute(sql, usuario);
        }
        public IEnumerable<Usuario> BuscarTodos()
        {
            var sql = "SELECT Id, Nome_completo AS NomeCompleto, Data_Nascimento AS DataNascimento, Cpf FROM usuario";
            return _connection.Query<Usuario>(sql);
        }
    }
}
