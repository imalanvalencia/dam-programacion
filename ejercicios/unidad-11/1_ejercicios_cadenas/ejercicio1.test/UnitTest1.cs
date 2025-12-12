using Xunit;

namespace ejercicio1.Tests
{
    public class PasswordTests
    {
        [Theory]
        [InlineData("123456", "Muy débil")]
        [InlineData("abcdabcd", "Débil")]
        [InlineData("abc12345", "Fuerte")]
        [InlineData("abc12345!", "Muy fuerte")]
        [InlineData("", "Muy débil")]
        public void NivelSeguridad_DevuelveNivelCorrecto(string password, string esperado)
        {
            Assert.Equal(esperado, Program.NivelSeguridad(password));
        }

        [Theory]
        [InlineData("123456", true)]
        [InlineData("abc123", false)]
        public void SoloNumeros_DevuelveCorrecto(string password, bool esperado)
        {
            Assert.Equal(esperado, Program.SoloNumeros(password));
        }

        [Theory]
        [InlineData("abcdefgh", true)]
        [InlineData("abc12345", false)]
        public void SoloLetras_DevuelveCorrecto(string password, bool esperado)
        {
            Assert.Equal(esperado, Program.SoloLetras(password));
        }

        [Theory]
        [InlineData("abc123", true)]
        [InlineData("123456", false)]
        public void ContieneLetras_DevuelveCorrecto(string password, bool esperado)
        {
            Assert.Equal(esperado, Program.ContieneLetras(password));
        }

        [Theory]
        [InlineData("abc123", true)]
        [InlineData("abcdef", false)]
        public void ContieneNumeros_DevuelveCorrecto(string password, bool esperado)
        {
            Assert.Equal(esperado, Program.ContieneNumeros(password));
        }

        [Theory]
        [InlineData("abc123!", true)]
        [InlineData("abc123", false)]
        public void ContieneEspeciales_DevuelveCorrecto(string password, bool esperado)
        {
            Assert.Equal(esperado, Program.ContieneEspeciales(password));
        }
    }
}