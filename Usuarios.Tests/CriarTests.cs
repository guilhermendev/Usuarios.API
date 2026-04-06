using Xunit;
using Moq;

using Usuarios.API.DTOs;
using Usuarios.API.Service;
using Usuarios.API.Repository;
using Usuarios.API.Mapping;
using Usuarios.API.Entidade;

namespace Usuarios.Tests
{
    public class CriarTests
    {
        private readonly Mock<IUsuarioRepository> _repositoryMock;
        private readonly UsuarioMapping _mapping;
        private readonly UsuarioService _service;

        public CriarTests()
        {
            _repositoryMock = new Mock<IUsuarioRepository>();
            _mapping = new UsuarioMapping();

            _service = new UsuarioService(
                _repositoryMock.Object,
                _mapping
            );
        }

        [Fact]
        public async Task CriarAsync_DeveRetornarTrue_QuandoCriadoComSucesso()
        {
            var dto = new UsuarioRequestDto();

            _repositoryMock.Setup(r => r.CriarAsync(It.IsAny<Usuario>()))
                .ReturnsAsync(true);

            var resultado = await _service.CriarAsync(dto);

            Assert.True(resultado);
        }

        [Fact]
        public async Task CriarAsync_DeveRetornarFalse_QuandoFalhar()
        {
            var dto = new UsuarioRequestDto();

            _repositoryMock.Setup(r => r.CriarAsync(It.IsAny<Usuario>()))
                           .ReturnsAsync(false);

            var resultado = await _service.CriarAsync(dto);

            Assert.False(resultado);
        }
    }
}