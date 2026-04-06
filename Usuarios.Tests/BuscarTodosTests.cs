using Xunit;
using Moq;

using Usuarios.API.DTOs;
using Usuarios.API.Entidade;
using Usuarios.API.Mapping;
using Usuarios.API.Repository;
using Usuarios.API.Service;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Usuarios.Tests
{
    public class BuscarTodosTests
    {
        private readonly Mock<IUsuarioRepository> _repositoryMock;
        private readonly UsuarioMapping _mapping;
        private readonly UsuarioService _service;

        public BuscarTodosTests()
        {
            _repositoryMock = new Mock<IUsuarioRepository>();
            _mapping = new UsuarioMapping();

            _service = new UsuarioService(
                _repositoryMock.Object,
                _mapping
            );
        }

        [Fact]
        public async Task BuscarTodosAsyncDeveRetornarListaComDados()
        {
            var usuarios = new List<Usuario>
            {
                new Usuario{Id = 1, NomeCompleto = ""},
                new Usuario{Id = 2, NomeCompleto = ""},
                new Usuario{Id = 3, NomeCompleto = ""}
            };

            _repositoryMock.Setup(r => r.BuscarTodosAsync())
                           .ReturnsAsync(usuarios);

            var resultado = await _service.BuscarTodosAsync();

            Assert.NotEmpty(resultado);
            Assert.All(resultado, u => Assert.False(string.IsNullOrEmpty(u.NomeUsuario)));
            Assert.True(resultado.Count() >= 1);
        }

        [Fact]
        public async Task BuscarTodosAsync_DeveRetornarListaVazia()
        {
            _repositoryMock.Setup(r => r.BuscarTodosAsync())
                           .ReturnsAsync(new List<Usuario>());

            var resultado = await _service.BuscarTodosAsync();

            Assert.Empty(resultado);
            Assert.IsAssignableFrom<IEnumerable<UsuarioResponseDto>>(resultado);
        }
    }
}