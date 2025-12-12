using Xunit;

namespace ejercicio5.Tests
{
    public class ReescribeTikoTests
    {
        [Theory]
        [InlineData("x q", "por qué")]
        [InlineData("holaaa", "hola")]
        [InlineData("jajajaja", "😂")]
        [InlineData("Tengo 2 perros", "Tengo dos perros")]        
        [InlineData("jajajaja x q", "😂 por qué")]
        [InlineData("", "")]
        public void ReescribeTiko_DevuelveCorrecto(string entrada, string esperado)
        {
            Assert.Equal(esperado, Program.ReescribeTiko(entrada));
        }
    }
}