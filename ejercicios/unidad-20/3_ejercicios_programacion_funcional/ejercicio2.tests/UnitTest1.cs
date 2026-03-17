using Xunit;
using Ejercicio;
using System.Collections.Generic;

namespace ejercicio2.tests
{
    public class UnitTest1
    {
        private List<double> datosPrueba = new List<double> { 0.5, 1.6, 2.8, 3.9, 4.1, 5.2, 6.3, 7.4, 8.1, 9.2 };

        [Fact]
        public void CuentaParteDecimalMenorA05_CuentaCorrectamente()
        {
            // 2.8(.8), 3.9(.9), 0.5(.5), 4.1(.1 < 0.5), 1.6(.6), 5.2(.2 < 0.5), 6.3(.3 < 0.5), 7.4(.4 < 0.5), 8.1(.1 < 0.5), 9.2(.2 < 0.5)
            // Manual check:
            // 0.5 -> No (<0.5 is false if == 0.5? Code: r < 0.5) .5 is not < .5
            // 1.6 -> .6 No
            // 2.8 -> .8 No
            // 3.9 -> .9 No
            // 4.1 -> .1 Yes
            // 5.2 -> .2 Yes
            // 6.3 -> .3 Yes
            // 7.4 -> .4 Yes
            // 8.1 -> .1 Yes
            // 9.2 -> .2 Yes
            // Total: 6
            var result = Program.CuentaParteDecimalMenorA05(datosPrueba);
            Assert.Equal(6, result);
        }

        [Fact]
        public void SumaElemParteEnteraMultiploDe3_SumaCorrectamente()
        {
            // Enteros: 0, 1, 2, 3, 4, 5, 6, 7, 8, 9
            // Multiplos de 3 (excluyendo 0): 3, 6, 9.
            // Items: 3.9, 6.3, 9.2
            // Suma: 3.9 + 6.3 + 9.2 = 19.4
            var result = Program.SumaElemParteEnteraMultiploDe3(datosPrueba);
            Assert.Equal(19.4, result, 1);
        }

        [Fact]
        public void MaximoCuyaParteDecimalMayorA05_EncuentraMaximo()
        {
            // > 0.5: 1.6, 2.8, 3.9. (0.5 is not > 0.5)
            // Max of 1.6, 2.8, 3.9 is 3.9.
            var result = Program.MaximoCuyaParteDecimalMayorA05(datosPrueba);
            Assert.Equal(3.9, result);
        }

        [Fact]
        public void ElementosParteEnteraEsPrimo_DevuelveListaCorrecta()
        {
            // Enteros: 0, 1, 2, 3, 4, 5, 6, 7, 8, 9
            // Primos: 2, 3, 5, 7.
            // Items: 2.8, 3.9, 5.2, 7.4.
            var result = Program.ElementosParteEnteraEsPrimo(datosPrueba);
            Assert.Equal(4, result.Count);
            Assert.Contains(2.8, result);
            Assert.Contains(3.9, result);
            Assert.Contains(5.2, result);
            Assert.Contains(7.4, result);
        }
    }
}