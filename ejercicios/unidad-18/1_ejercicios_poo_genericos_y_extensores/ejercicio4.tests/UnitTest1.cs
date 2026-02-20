using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Globalization;
using Xunit;

namespace ejercicio4.tests
{
    public class UnitTest1
    {
        [Fact]
        public void SensorBasico_ValorActualEnRango()
        {
            var sensor = new Ejercicio4.SensorBasico();
            int valor = sensor.ValorActual;
            Assert.InRange(valor, 0, 100);
        }

        [Fact]
        public void SensorPreciso_ValorActualEnRango()
        {
            var sensor = new Ejercicio4.SensorPreciso();
            float valor = sensor.ValorActual;
            Assert.InRange(valor, 0f, 100f);
        }

        [Fact]
        public void Timbre_ActivaCambiaEstadoYImprime()
        {
            var timbre = new Ejercicio4.Timbre(1, "Ring");
            var sw = new System.IO.StringWriter();
            var originalOut = Console.Out;
            try
            {
                Console.SetOut(sw);
                timbre.Activa();
            }
            finally { Console.SetOut(originalOut); }
            Assert.True(timbre.Estado);
            Assert.Contains("Ring", sw.ToString());
        }

        [Fact]
        public void Timbre_DesactivaCambiaEstadoYImprime()
        {
            var timbre = new Ejercicio4.Timbre(1, "Ring");
            timbre.Activa();
            var sw = new System.IO.StringWriter();
            var originalOut = Console.Out;
            try
            {
                Console.SetOut(sw);
                timbre.Desactiva();
            }
            finally { Console.SetOut(originalOut); }
            Assert.False(timbre.Estado);
            Assert.Contains("detenido", sw.ToString());
        }

        [Fact]
        public void Bombilla_ActivaCambiaEstadoYImprime()
        {
            var bombilla = new Ejercicio4.Bombilla(ConsoleColor.Red);
            var sw = new System.IO.StringWriter();
            var originalOut = Console.Out;
            try
            {
                Console.SetOut(sw);
                bombilla.Activa();
            }
            finally { Console.SetOut(originalOut); }
            Assert.True(bombilla.Estado);
            Assert.Contains("encendida", sw.ToString());
        }

        [Fact]
        public void Bombilla_DesactivaCambiaEstadoYImprime()
        {
            var bombilla = new Ejercicio4.Bombilla(ConsoleColor.Red);
            bombilla.Activa();
            var sw = new System.IO.StringWriter();
            var originalOut = Console.Out;
            try
            {
                Console.SetOut(sw);
                bombilla.Desactiva();
            }
            finally { Console.SetOut(originalOut); }
            Assert.False(bombilla.Estado);
            Assert.Contains("apagada", sw.ToString());
        }

        [Fact]
        public void Llamada_ActivaCambiaEstadoYImprime()
        {
            var llamada = new Ejercicio4.Llamada(new List<string> { "123", "456" });
            var sw = new System.IO.StringWriter();
            var originalOut = Console.Out;
            try
            {
                Console.SetOut(sw);
                llamada.Activa();
            }
            finally { Console.SetOut(originalOut); }
            Assert.True(llamada.Estado);
            Assert.Contains("Llamando", sw.ToString());
        }

        [Fact]
        public void Llamada_DesactivaCambiaEstadoYImprime()
        {
            var llamada = new Ejercicio4.Llamada(new List<string> { "123" });
            llamada.Activa();
            var sw = new System.IO.StringWriter();
            var originalOut = Console.Out;
            try
            {
                Console.SetOut(sw);
                llamada.Desactiva();
            }
            finally { Console.SetOut(originalOut); }
            Assert.False(llamada.Estado);
            Assert.Contains("Fin de llamadas", sw.ToString());
        }

        [Fact]
        public void Alarma_ConstructorInicializaCorrectamente()
        {
            var sensor = new Ejercicio4.SensorBasico();
            var timbre = new Ejercicio4.Timbre(1, "Ring");
            var alarma = new Ejercicio4.Alarma<int, Ejercicio4.IAvisador>(30, sensor, timbre);
            Assert.Equal(30, alarma.Umbral);
        }

        [Fact]
        public void Alarma_AñadeAvisadorAgregaAvisador()
        {
            var sensor = new Ejercicio4.SensorBasico();
            var timbre = new Ejercicio4.Timbre(1, "Ring");
            var bombilla = new Ejercicio4.Bombilla(ConsoleColor.Red);
            var alarma = new Ejercicio4.Alarma<int, Ejercicio4.IAvisador>(30, sensor, timbre);
            alarma.AñadeAvisador(bombilla);
            // No hay getter público, pero no lanza excepción y no duplica
            alarma.AñadeAvisador(bombilla);
        }

        [Fact]
        public void Alarma_EnciendeActivaAlarma()
        {
            var sensor = new Ejercicio4.SensorBasico();
            var timbre = new Ejercicio4.Timbre(1, "Ring");
            var alarma = new Ejercicio4.Alarma<int, Ejercicio4.IAvisador>(30, sensor, timbre);
            alarma.Enciende();
            // No hay getter público, pero no lanza excepción
        }

        [Fact]
        public void Alarma_ApagaDesactivaAlarma()
        {
            var sensor = new Ejercicio4.SensorBasico();
            var timbre = new Ejercicio4.Timbre(1, "Ring");
            var alarma = new Ejercicio4.Alarma<int, Ejercicio4.IAvisador>(30, sensor, timbre);
            alarma.Enciende();
            alarma.Apaga();
        }

        [Fact]
        public void Alarma_ActivaActivaAvisadores()
        {
            var sensor = new Ejercicio4.SensorBasico();
            var timbre = new Ejercicio4.Timbre(1, "Ring");
            var alarma = new Ejercicio4.Alarma<int, Ejercicio4.IAvisador>(30, sensor, timbre);
            alarma.Activa();
            Assert.True(timbre.Estado);
        }

        [Fact]
        public void Alarma_DesactivaDesactivaAvisadores()
        {
            var sensor = new Ejercicio4.SensorBasico();
            var timbre = new Ejercicio4.Timbre(1, "Ring");
            var alarma = new Ejercicio4.Alarma<int, Ejercicio4.IAvisador>(30, sensor, timbre);
            alarma.Activa();
            alarma.Desactiva();
            Assert.False(timbre.Estado);
        }

        [Fact]
        public void Alarma_EtiquetaAvisadorDevuelveEtiqueta()
        {
            var metodo = typeof(Ejercicio4.Alarma<int, Ejercicio4.IAvisador>).GetMethod("EtiquetaAvisador", BindingFlags.NonPublic | BindingFlags.Static);
            Assert.NotNull(metodo);
            var timbre = new Ejercicio4.Timbre(1, "Ring");
            var etiqueta = metodo.Invoke(null, new object[] { timbre });
            Assert.Equal("TIMBRE", etiqueta);
        }

    }
}
