using Microsoft.AspNetCore.Mvc;
using Usuarios.API.DTOs;
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
        public IActionResult Criar([FromBody] UsuarioRequestDto dto)
        {
            _logger.LogInformation("Criando um novo usuário com nome: {Nome}", dto.Nome);
            _service.Criar(dto);
            _logger.LogInformation("Usuário criado com sucesso: {Nome}", dto.Nome);
            return Ok("Usuário criado com sucesso!");
        }

        [HttpGet]
        public IActionResult BuscarTodos()
        {
            _logger.LogInformation("Buscando todos os usuários.");
            var usuarios = _service.BuscarTodos();
            _logger.LogInformation("Usuários encontrados com sucesso!");
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            _logger.LogInformation("Buscando usuário com ID: {Id}", id);
            var usuario = _service.BuscarPorId(id);
            if (usuario == null)
                return NotFound("Usuário não encontrado.");
            {
                _logger.LogWarning("Usuário com Id {id} não encontrado.", id);
                return NotFound("Usuário não encontrado.");
            }
            _logger.LogInformation("Usuário com Id {id} encontrado com sucesso!", id);
            return Ok(usuario);
        }

        [HttpPut("{id}")]

        public IActionResult Atualizar(int id, [FromBody] UsuarioRequestDto dto)
        {
            _logger.LogInformation("Atualizando usuário com ID: {Id}", id);
            _service.Atualizar(id, dto);
            _logger.LogInformation("Usuário com ID: {Id} atualizado com sucesso!", id);
            return Ok("Usuário atualizado com sucesso!");
        }

        [HttpDelete("{id}")]

        public IActionResult Deletar(int id)
        {
            _logger.LogInformation("Deletando usuário com ID: {Id}", id);
            _service.Deletar(id);
            _logger.LogInformation("Usuário com ID: {Id} deletado com sucesso!", id);
            return Ok("Ususario deletado com sucesso!");
        }
    }
}
