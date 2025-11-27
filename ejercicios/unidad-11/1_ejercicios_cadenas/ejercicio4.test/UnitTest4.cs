using Xunit;

namespace ejercicio4.Tests
{
    public class TraducirTikoTests
    {
        [Theory]
        [InlineData("holaaa", "hola")]
        [InlineData("Tengo 2 perros", "Tengo dos peros")]
        [InlineData("jajajaja", "😂😂")]
        [InlineData("jejejeje", "😄😄")]
        [InlineData("jijijiji", "😆😆")]
        [InlineData("jojoojo", "🤣jo")]
        [InlineData("por que", "por que")]
        [InlineData("", "")]
        public void TraducirTiko_DevuelveCorrecto(string entrada, string esperado)
        {
            Assert.Equal(esperado, Program.TraducirTiko(entrada));
        }
    }
}