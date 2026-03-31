using Microsoft.AspNetCore.Mvc;
using Usuarios.API.DTOs;
using Usuarios.API.Entidade;
using Usuarios.API.Service;

namespace Usuarios.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _service;
        private readonly ILogger<UsuariosController> _logger;

        public UsuariosController(IUsuarioService service, ILogger<UsuariosController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpPost]

        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public async Task<IActionResult> Criar([FromBody] UsuarioRequestDto dto)
        {
            _logger.LogInformation("Criando novo usuário: {Nome}", dto.Nome);

            await _service.CriarAsync(dto);

            _logger.LogInformation("Usuário criado com sucesso.");

            return Ok("Usuário criado com sucesso!");
        }


        [HttpGet]

        [ProducesResponseType(typeof(IEnumerable<Usuario>), StatusCodes.Status200OK)]
        public async Task<IActionResult> BuscarTodos()
        {
            _logger.LogInformation("Buscando todos os usuários.");

            var usuarios =await _service.BuscarTodosAsync();

            _logger.LogInformation("Total de usuários encontrados: {Total}", usuarios?.Count());

            return Ok(usuarios);
        }


        [HttpGet("{id}")]

        [ProducesResponseType(typeof(Usuario), StatusCodes.Status200OK)]

        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> BuscarPorId(int id)
        {
            _logger.LogInformation("Buscando usuário com ID: {Id}", id);

            var usuario =await _service.BuscarPorIdAsync(id);

            if (usuario == null)
            {
                _logger.LogWarning("Usuário com ID {Id} não encontrado.", id);

                return NotFound("Usuário não encontrado.");
            }
            return Ok(usuario);
        }


        [HttpPut("{id}")]

        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]

        public async Task<IActionResult> Atualizarasync(int id, [FromBody] UsuarioRequestDto dto)
        {
            _logger.LogInformation("Atualizando usuário com ID: {Id}", id);

            await _service.AtualizarAsync(id, dto);

            _logger.LogInformation("Usuário com ID {Id} atualizado com sucesso.", id);

            return Ok("Usuário atualizado com sucesso!");
        }


        [HttpDelete("{id}")]

        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeletarAsync(int id)
        {
            _logger.LogInformation("Deletando usuário com ID: {Id}", id);

            await _service.DeletarAsync(id);

            _logger.LogInformation("Usuário com ID {Id} deletado com sucesso.", id);

            return Ok("Usuário deletado com sucesso!");
        }
    }
}