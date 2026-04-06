using Xunit;
using Moq;

using Usuarios.API.Mapping;
using Usuarios.API.Repository;
using Usuarios.API.Service;


namespace Usuarios.Tests
{
    public class DeletarTests
    {
        private readonly Mock<IUsuarioRepository> _repositoryMock;
        private readonly UsuarioMapping _mapping;
        private readonly UsuarioService _service;

        public DeletarTests()
        {
            _repositoryMock = new Mock<IUsuarioRepository>();
            _mapping = new UsuarioMapping();

            _service = new UsuarioService(
                _repositoryMock.Object,
                _mapping
            );
        }

        [Fact]
        public async Task DeletarAsync_DeveRetornarTrue_QuandoDeletadoComSucesso()
        {
            _repositoryMock.Setup(r => r.DeletarAsync(It.IsAny<int>()))
                           .ReturnsAsync(true);

            var resultado = await _service.DeletarAsync(1);

            Assert.True(resultado);
            _repositoryMock.Verify(r => r.DeletarAsync(1), Times.Once);
        }

        [Fact]
        public async Task DeletarAsync_DeveRetornarFalse_QuandoFalhar()
        {
            _repositoryMock.Setup(r => r.DeletarAsync(It.IsAny<int>()))
                           .ReturnsAsync(false);

            var resultado = await _service.DeletarAsync(1);

            Assert.False(resultado);
        }
    }
}