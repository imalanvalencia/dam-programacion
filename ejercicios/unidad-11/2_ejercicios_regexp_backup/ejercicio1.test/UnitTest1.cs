using Xunit;

namespace ejercicio1.Tests
{
    public class ExtraerEtiquetasTests
    {
        [Theory]
        [InlineData("<p>Hola mundo</p><p>¿Qué tal estás?</p>", new[] { "Hola mundo", "¿Qué tal estás?" })]
        [InlineData("<div>Hola <span>mundo</span></div>", new[] { "Hola <span>mundo</span>" })]
        [InlineData("<b>negrita</b>", new[] { "negrita" })]
        [InlineData("", new string[0])]
        public void ExtraerEtiquetas_DevuelveCorrecto(string entrada, string[] esperado)
        {
            var resultado = Program.ExtraerEtiquetas(entrada);
            Assert.Equal(esperado, resultado);
        }
    }
}