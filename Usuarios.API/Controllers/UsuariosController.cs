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
    }
}
