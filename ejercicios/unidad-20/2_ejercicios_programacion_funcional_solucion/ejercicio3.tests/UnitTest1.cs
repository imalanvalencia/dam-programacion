using Xunit;
using Ejercicio3;

namespace ejercicio3.tests
{
    public class UnitTest1
    {
        [Fact]
        public void EsMultiploDe_ConClausura_DeterminaSiEsMultiplo()
        {
            var funcionMultiplo = Principal.EsMultiploDe_ConClausura(10);
            // 10 es multiplo de 2? (10 % 2 == 0) -> True
            Assert.True(funcionMultiplo(2)); 
            // 10 es multiplo de 3? (10 % 3 != 0) -> False
            Assert.False(funcionMultiplo(3));
        }

        [Fact]
        public void EsMultiploDe_SinClausura_DeterminaSiEsMultiplo()
        {
             Assert.True(Principal.EsMultiploDe_SinClausura(10, 2));
             Assert.False(Principal.EsMultiploDe_SinClausura(10, 3));
        }
    }
}
