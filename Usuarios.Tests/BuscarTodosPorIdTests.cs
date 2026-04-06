using Moq;
using Usuarios.API.DTOs;
using Usuarios.API.Entidade;
using Usuarios.API.Mapping;
using Usuarios.API.Repository;
using Usuarios.API.Service;
using Xunit;

namespace Usuarios.Tests
{
    public class BuscarPorIdTests
    {
        private readonly Mock<IUsuarioRepository> _repositoryMock;
        private readonly UsuarioMapping _mapping;
        private readonly UsuarioService _service;

        public BuscarPorIdTests()
        {
            _repositoryMock = new Mock<IUsuarioRepository>();
            _mapping = new UsuarioMapping();

            _service = new UsuarioService(
                _repositoryMock.Object,
                _mapping
            );
        }

        [Fact]
        public async Task BuscarPorIdAsync_DeveRetornarUsuario_QuandoEncontrado()
        {
            var usuario = new Usuario();

            _repositoryMock.Setup(r => r.BuscarPorIdAsync(It.IsAny<int>()))
                           .ReturnsAsync(usuario);

            var resultado = await _service.BuscarPorIdAsync(1);

            Assert.NotNull(resultado);
            Assert.IsType<UsuarioResponseDto>(resultado);
            Assert.Equal(usuario.Id, resultado.CodigoUsuario);
        }
            
        [Fact]
        public async Task BuscarPorIdAsync_DeveRetornarNull_QuandoNaoEncontrado()
        {
            _repositoryMock.Setup(r => r.BuscarPorIdAsync(It.IsAny<int>()))
                           .ReturnsAsync((Usuario)null);

            var resultado = await _service.BuscarPorIdAsync(1);

            Assert.Null(resultado);
        }
    }
}
