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

        public UsuariosController(IUsuarioService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Criar([FromBody] UsuarioRequestDto dto)
        {
            _service.Criar(dto);
            return Ok("Usuário criado com sucesso!");
        }

        [HttpGet]
        public IActionResult BuscarTodos()
        {
            var usuarios = _service.BuscarTodos();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            var usuario = _service.BuscarPorId(id);
            if (usuario == null)
                return NotFound("Usuário não encontrado.");
            return Ok(usuario);
        }

        [HttpDelete("{id}")]

        public IActionResult Deletar(int id)
        {
            _service.Deletar(id);
            return Ok("Ususario deletado com sucesso!");
        }
    }
}
