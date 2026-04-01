using Xunit;
using Moq;

using Usuarios.API.DTOs;
using Usuarios.API.Entidade;
using Usuarios.API.Mapping;
using Usuarios.API.Repository;
using Usuarios.API.Service;


namespace Usuarios.Tests
{
    public class AtualizarTests
    {
        private readonly Mock<IUsuarioRepository> _repositoryMock;
        private readonly UsuarioMapping _mapping;
        private readonly UsuarioService _service;

        public AtualizarTests()
        {
            _repositoryMock = new Mock<IUsuarioRepository>();
            _mapping = new UsuarioMapping();

            _service = new UsuarioService(
                _repositoryMock.Object,
                _mapping
            );
        }

        [Fact]
        public async Task AtualizarAsync_DeveRetornarTrue_QuandoAtualizadoComSucesso()
        {
            var dto = new UsuarioRequestDto();

            _repositoryMock.Setup(r => r.AtualizarAsync(It.IsAny<int>(), It.IsAny<Usuario>()))
                           .ReturnsAsync(true);

            var resultado = await _service.AtualizarAsync(1, dto);

            Assert.True(resultado);
        }

        [Fact]
        public async Task AtualizarAsync_DeveRetornarFalse_QuandoFalhar()
        {
            var dto = new UsuarioRequestDto();

            _repositoryMock.Setup(r => r.AtualizarAsync(It.IsAny<int>(), It.IsAny<Usuario>()))
                           .ReturnsAsync(false);

            var resultado = await _service.AtualizarAsync(1, dto);

            Assert.False(resultado);
        }
    }
}