using Xunit;

namespace ejercicio3.Tests
{
    public class NormalizaTests
    {
        [Theory]
        [InlineData("¡Árboles y pingüinos!", "arbolesypinguinos")]
        [InlineData("Canción", "cancion")]
        [InlineData("MÜSICA", "musica")]
        [InlineData("12345", "")]
        [InlineData("", "")]
        public void Normaliza_DevuelveCorrecto(string entrada, string esperado)
        {
            Assert.Equal(esperado, Program.Normaliza(entrada));
        }
    }
}