using Xunit;

namespace ejercicio3.Tests
{
    public class EvaluaExpresionTests
    {
        [Theory]
        [InlineData("2+3*4-1", 13)]
        [InlineData("10/2+5*2", 15)]
        [InlineData("8-3+2", 7)]
        [InlineData("7*2", 14)]
        [InlineData("5+5+5", 15)]
        public void EvaluaExpresion_DevuelveCorrecto(string expresion, int esperado)
        {
            Assert.Equal(esperado, Program.EvaluaExpresion(expresion));
        }
    }
}