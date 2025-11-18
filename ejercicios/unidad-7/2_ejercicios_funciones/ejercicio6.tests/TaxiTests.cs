using Xunit;
using System;

namespace Ejercicio01.Tests
{
    public class TaxiTests
    {
        [Fact]
        public void CosteCarrera_CarreraNormal_CalculaCorrectamente()
        {
            double resultado = Taxi.CosteCarrera(20, 5);
            Assert.Equal(20.82, Math.Round(resultado, 2));
        }

        [Fact]
        public void CosteCarrera_CarreraNocturna_CalculaCorrectamente()
        {
            double resultado = Taxi.CosteCarrera(20, 5, true);
            Assert.Equal(20.82, Math.Round(resultado, 2)); // El resultado esperado depende de la lógica nocturna
        }

        [Fact]
        public void CosteCarrera_CarreraConOcupacionExtra_CalculaCorrectamente()
        {
            double resultado = Taxi.CosteCarrera(20, 5, 1u);
            Assert.Equal(21.82, Math.Round(resultado, 2));
        }

        [Fact]
        public void CosteCarrera_CarreraFestivo_CalculaCorrectamente()
        {
            double resultado = Taxi.CosteCarrera(20, 5, 40);
            Assert.Equal(29.15, Math.Round(resultado, 2));
        }

        [Fact]
        public void CosteCarrera_CarreraNocturnaFestivo_CalculaCorrectamente()
        {
            double resultado = Taxi.CosteCarrera(20, 5, true, 20);
            Assert.Equal(24.98, Math.Round(resultado, 2));
        }

        [Fact]
        public void CosteCarrera_CarreraNocturnaFestivoOcupacionExtra_CalculaCorrectamente()
        {
            double resultado = Taxi.CosteCarrera(20, 5, true, 40, 2u);
            Assert.Equal(31.15, Math.Round(resultado, 2));
        }
    }
}
