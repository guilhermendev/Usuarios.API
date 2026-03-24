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

        public void Criar (Usuario usuario)
        {
            var sql = "INSERT INTO Usuarios (Nome_Completo, Data_Nascimento, Cpf) VALUES (@NomeCompleto, @DataNascimento,@Cpf)";
            _connection.Execute(sql, usuario);
        }
    }
}
