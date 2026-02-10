using Xunit;

namespace ejercicio1.Tests
{
    public class CalculadoraAvanzadaTests
    {
        [Fact]
        public void Dividir_DivisionNormal_DevuelveResultado()
        {
            Assert.Equal(2, CalculadoraAvanzada.Dividir(10, 5));
        }

        [Fact]
        public void Dividir_DivisionPorCero_LanzaDivideByZeroException()
        {
            Assert.Throws<DivideByZeroException>(() => CalculadoraAvanzada.Dividir(10, 0));
        }

        [Fact]
        public void RaizCuadrada_ValorPositivo_DevuelveRaiz()
        {
            Assert.Equal(3, CalculadoraAvanzada.RaizCuadrada(9));
        }

        [Fact]
        public void RaizCuadrada_Negativo_LanzaArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => CalculadoraAvanzada.RaizCuadrada(-4));
        }

        [Fact]
        public void ObtenerElemento_IndiceValido_DevuelveElemento()
        {
            int[] array = { 1, 2, 3 };
            Assert.Equal(2, CalculadoraAvanzada.ObtenerElemento(array, 1));
        }

        [Fact]
        public void ObtenerElemento_IndiceInvalido_LanzaIndexOutOfRangeException()
        {
            int[] array = { 1, 2, 3 };
            Assert.Throws<IndexOutOfRangeException>(() => CalculadoraAvanzada.ObtenerElemento(array, 5));
        }

        [Fact]
        public void ParsearEntero_Valido_DevuelveEntero()
        {
            Assert.Equal(42, CalculadoraAvanzada.ParsearEntero("42"));
        }

        [Fact]
        public void ParsearEntero_NoValido_LanzaFormatException()
        {
            Assert.Throws<FormatException>(() => CalculadoraAvanzada.ParsearEntero("abc"));
        }
    }
}