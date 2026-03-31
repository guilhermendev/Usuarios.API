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


        public async Task<bool> CriarAsync(Usuario usuario)
        {
            try
            {
                _logger.LogInformation("Criando usuário: {NomeCompleto}", usuario.NomeCompleto);

                var sql = "INSERT INTO Usuario (Nome_Completo, Data_Nascimento, Cpf) VALUES (@NomeCompleto, @DataNascimento, @Cpf)";

                var result =await _connection.ExecuteAsync(sql, usuario);

                if (result == 0)
                {
                    _logger.LogWarning("Nenhum usuário foi inserido: {NomeCompleto}", usuario.NomeCompleto);
                    return false;
                }

                _logger.LogInformation("Usuário criado com sucesso: {NomeCompleto}", usuario.NomeCompleto);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao criar usuário: {NomeCompleto}", usuario.NomeCompleto);
                return false;
            }
        }


        public async Task<IEnumerable<Usuario>> BuscarTodosAsync()
        {
            try
            {
                _logger.LogInformation("Buscando todos os usuários.");

                var sql = "SELECT Id, Nome_Completo AS NomeCompleto, Data_Nascimento AS DataNascimento, Cpf FROM usuario";

                var usuarios = await _connection.QueryAsync<Usuario>(sql);

                _logger.LogInformation("Usuários encontrados com sucesso!");

                return usuarios;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao buscar todos os usuários.");
                throw;
            }
        }


        public async Task<Usuario> BuscarPorIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("Buscando usuário com ID: {Id}", id);

                var sql = "SELECT Id, Nome_Completo AS NomeCompleto, Data_Nascimento AS DataNascimento, Cpf FROM usuario WHERE Id = @Id";

                var usuario =await _connection.QueryFirstOrDefaultAsync<Usuario>(sql, new { Id = id });

                _logger.LogInformation("Usuário com ID: {Id} encontrado com sucesso!", id);

                return usuario;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao buscar usuário com ID: {Id}", id);
                throw;
            }
        }


        public bool Atualizar(int id, Usuario usuario)
        {
            try
            {
                _logger.LogInformation("Atualizando usuário com ID: {Id}", id);

                var sql = "UPDATE Usuario SET Nome_Completo = @NomeCompleto, Data_Nascimento = @DataNascimento, Cpf = @Cpf WHERE Id = @Id";

                usuario.Id = id;

                var result =  _connection.Execute(sql, usuario);

                if (result == 0)
                {
                    _logger.LogWarning("Nenhum usuário foi inserido: {NomeCompleto}", usuario.NomeCompleto);
                    return false;
                }

                _logger.LogInformation("Usuário criado com sucesso: {NomeCompleto}", usuario.NomeCompleto);
                return true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao criar usuário: {NomeCompleto}", usuario.NomeCompleto);
                return false;
            }
        }
            

        public bool Deletar(int id)
        {
            try
            {
                _logger.LogInformation("Deletando usuário com ID: {Id}", id);

                var sql = "DELETE FROM usuario WHERE Id = @Id";

                var result = _connection.Execute(sql, new { Id = id });

                if (result == 0)
                {
                    _logger.LogWarning("Nenhum usuário foi deletado com ID: {Id}", id);
                    return false;
                }
               
                return true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao deletar usuário: {Id}", id);
                throw;
            }
        }
    }
}