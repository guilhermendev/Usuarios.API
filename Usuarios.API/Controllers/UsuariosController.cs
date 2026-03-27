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

        public UsuariosController(IUsuarioService service)
        {
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult Criar([FromBody] UsuarioRequestDto dto)
        {
            _service.Criar(dto);
            return Ok("Usuário criado com sucesso!");
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Usuario>), StatusCodes.Status200OK)]
        public IActionResult BuscarTodos()
        {
            var usuarios = _service.BuscarTodos();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Usuario), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult BuscarPorId(int id)
        {
            var usuario = _service.BuscarPorId(id);
            if (usuario == null)
                return NotFound("Usuário não encontrado.");
            return Ok(usuario);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult Atualizar(int id, [FromBody] UsuarioRequestDto dto)
        {
            _service.Atualizar(id, dto);
            return Ok("Usuário atualizado com sucesso!");
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult Deletar(int id)
        {
            _service.Deletar(id);
            return Ok("Ususario deletado com sucesso!");
        }
    }
}
