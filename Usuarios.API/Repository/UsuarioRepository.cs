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
            var sql = "SELECT Id, Nome_Completo AS NomeCompleto, Data_Nascimento AS DataNascimento, Cpf FROM usuario";
            return _connection.Query<Usuario>(sql);
        }
        public Usuario BuscarPorId(int id)
        {
            var sql = "SELECT Id, Nome_Completo AS NomeCompleto, Data_Nascimento AS DataNascimento, Cpf FROM usuario WHERE Id = @Id";
            return _connection.QueryFirstOrDefault<Usuario>(sql, new { Id = id });
        }

        public void Atualizar(int id, Usuario usuario)
        {
            var sql = "UPDATE Usuario SET Nome_Completo = @NomeCompleto, Data_Nascimento = @DataNascimento, Cpf = @Cpf WHERE Id = @Id";
            usuario.Id = id;
            _connection.Execute(sql, usuario);
        }

        public void Deletar(int id)
        {
            var sql = "DELETE FROM usuario WHERE Id = @Id";
            _connection.Execute(sql, new { Id = id });
        }
    }
}
