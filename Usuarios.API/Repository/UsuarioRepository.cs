using Dapper;
using Usuarios.API.Entidade;
using System.Data;

namespace Usuarios.API.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IDbConnection _connection;
        private readonly ILogger<UsuarioRepository> _logger;

        public UsuarioRepository(IDbConnection connection, ILogger<UsuarioRepository> logger)
        {
            _connection = connection;
            _logger = logger;
        }
        public void Criar(Usuario usuario)
        {
            try
            {
                _logger.LogInformation("Criando usuário: {NomeCompleto}", usuario.NomeCompleto);
                var sql = "INSERT INTO Usuario (Nome_Completo, Data_Nascimento, Cpf) VALUES (@NomeCompleto, @DataNascimento, @Cpf)";
                _connection.Execute(sql, usuario);
                _logger.LogInformation("Usuário criado com sucesso: {NomeCompleto}", usuario.NomeCompleto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao criar usuário: {NomeCompleto}", usuario.NomeCompleto);
                throw;
            }
        }
        public IEnumerable<Usuario> BuscarTodos()
        {
            try
            {
                _logger.LogInformation("Buscando todos os usuários.");
                var sql = "SELECT Id, Nome_Completo AS NomeCompleto, Data_Nascimento AS DataNascimento, Cpf FROM usuario";
                var usuarios = _connection.Query<Usuario>(sql);
                _logger.LogInformation("Usuários encontrados com sucesso!");
                return usuarios;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao buscar todos os usuários.");
                throw;
            }
        }
        public Usuario BuscarPorId(int id)
        {
            try
            {
                _logger.LogInformation("Buscando usuário com ID: {Id}", id);
                var sql = "SELECT Id, Nome_Completo AS NomeCompleto, Data_Nascimento AS DataNascimento, Cpf FROM usuario WHERE Id = @Id";
                var usuario = _connection.QueryFirstOrDefault<Usuario>(sql, new { Id = id });
                _logger.LogInformation("Usuário com ID: {Id} encontrado com sucesso!", id);
                return usuario;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao buscar usuário com ID: {Id}", id);
                throw;
            }
        }
        public void Atualizar(int id, Usuario usuario)
        {
            try
            {
                _logger.LogInformation("Atualizando usuário com ID: {Id}", id);
                var sql = "UPDATE Usuario SET Nome_Completo = @NomeCompleto, Data_Nascimento = @DataNascimento, Cpf = @Cpf WHERE Id = @Id";
                usuario.Id = id;
                _connection.Execute(sql, usuario);
                _logger.LogInformation("Usuário com ID: {Id} atualizado com sucesso!", id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar usuário com ID: {Id}", id);
                throw;
            }
        }
        public void Deletar(int id)
        {
            try
            {
                _logger.LogInformation("Deletando usuário com ID: {Id}", id);
                var sql = "DELETE FROM usuario WHERE Id = @Id";
                _connection.Execute(sql, new { Id = id });
                _logger.LogInformation("Usuário com ID: {Id} deletado com sucesso!", id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao deletar usuário com ID: {Id}", id);
                throw;
            }
        }
    }
}