using Xunit;

namespace ejercicio5.Tests
{
    public class EspaciadaTests
    {
        [Theory]
        [InlineData("BUCLE", "B U C L E")]
        [InlineData("A", "A")]
        [InlineData("", "")]
        [InlineData("PRUEBA", "P R U E B A")]
        public void Espaciada_DevuelveCorrecto(string palabra, string esperado)
        {
            Assert.Equal(esperado, Program.Espaciada(palabra));
        }
    }
}