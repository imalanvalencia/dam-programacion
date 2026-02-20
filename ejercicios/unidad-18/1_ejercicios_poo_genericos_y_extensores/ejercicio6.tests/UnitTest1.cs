using System;
using Xunit;



namespace ejercicio6.tests
{
    public class UnitTest1
    {
        [Fact]
        public void TemperaturasXProvincia_ToString_DevuelveFormatoCorrecto()
        {
            var txp = new TemperaturasXProvincia("Madrid", 25.5f, 10.2f);
            var esperado = "Provincia: Madrid, Temperatura máxima:25,5ºC, Temperatura mínima: 10,2ºC.";
            Assert.Equal(esperado, txp.ToString());
        }

        [Fact]
        public void ObténMaxima_TemperaturaDevuelveMaxima()
        {
            var txp = new TemperaturasXProvincia("Madrid", 25.5f, 10.2f);
            var obtMax = new TemperaturasXProvincia.ObténMaxima();
            Assert.Equal(25.5f, obtMax.Temperatura(txp));
        }

        [Fact]
        public void ObténMinima_TemperaturaDevuelveMinima()
        {
            var txp = new TemperaturasXProvincia("Madrid", 25.5f, 10.2f);
            var obtMin = new TemperaturasXProvincia.ObténMinima();
            Assert.Equal(10.2f, obtMin.Temperatura(txp));
        }

        [Fact]
        public void MayorQue_PredicadoDevuelveTrueSiMayor()
        {
            var mayor = new TemperaturasXProvincia.MayorQue();
            Assert.True(mayor.Predicado(5f, 3f));
            Assert.False(mayor.Predicado(3f, 5f));
        }

        [Fact]
        public void MenorQue_PredicadoDevuelveTrueSiMenor()
        {
            var menor = new TemperaturasXProvincia.MenorQue();
            Assert.True(menor.Predicado(3f, 5f));
            Assert.False(menor.Predicado(5f, 3f));
        }

        [Fact]
        public void IgualQue_PredicadoDevuelveTrueSiIgual()
        {
            var igual = new TemperaturasXProvincia.IgualQue();
            Assert.True(igual.Predicado(5f, 5f));
            Assert.False(igual.Predicado(5f, 3f));
        }

        [Fact]
        public void Program_MediaTemperaturas_CalculaMediaCorrecta()
        {
            var arr = new[] {
            new TemperaturasXProvincia("A", 10f, 5f),
            new TemperaturasXProvincia("B", 20f, 15f)
        };
            float media = Program.MediaTemperaturas(arr, new TemperaturasXProvincia.ObténMaxima());
            Assert.Equal(15f, media);
        }

        [Fact]
        public void Program_MuestraProvincias_ExisteMetodoSobrecargado()
        {
            var tipo = typeof(Program);
            var metodos = tipo.GetMethods(System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public);
            Assert.Contains(metodos, m => m.Name == "MuestraProvincias" && m.GetParameters().Length == 1);
            Assert.Contains(metodos, m => m.Name == "MuestraProvincias" && m.GetParameters().Length == 4);
        }

        [Fact]
        public void Program_RecogeTemperaturasPorProvincia_ExisteMetodoEstatico()
        {
            var tipo = typeof(Program);
            var metodo = tipo.GetMethod("RecogeTemperaturasPorProvincia", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public);
            Assert.NotNull(metodo);
        }
    }
}
