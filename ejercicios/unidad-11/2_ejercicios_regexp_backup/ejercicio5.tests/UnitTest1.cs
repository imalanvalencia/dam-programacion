using Xunit;

namespace ejercicio5.Tests
{
    public class ConvierteMarkdownTests
    {
        [Theory]
        [InlineData("**negrita**", "<strong>negrita</strong>")]
        [InlineData("*cursiva*", "<em>cursiva</em>")]
        [InlineData("Esto es **importante** y *bonito*", "Esto es <strong>importante</strong> y <em>bonito</em>")]
        [InlineData("sin formato", "sin formato")]
        [InlineData("", "")]
        public void ConvierteMarkdown_DevuelveCorrecto(string entrada, string esperado)
        {
            Assert.Equal(esperado, Program.ConvierteMarkdown(entrada));
        }
    }
}