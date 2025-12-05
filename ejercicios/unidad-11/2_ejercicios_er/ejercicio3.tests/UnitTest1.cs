using Xunit;
using System.Text.RegularExpressions;

namespace ejercicio3.Tests
{
    public class AnalizaLogsTests
    {
        // ==================== TESTS PATRÓN LOG ====================
        
        [Theory]
        [InlineData("[2025-07-28 12:34:56] INFO: Inicio", true)]
        [InlineData("[2025-07-28 12:35:00] ERROR: Fallo de conexión", true)]
        [InlineData("[2025-07-28 12:36:00] WARN: Memoria baja", true)]
        [InlineData("[2025-12-31 23:59:59] DEBUG: Test", true)]
        [InlineData("[2024-01-01 00:00:00] TRACE: Mensaje largo con varios espacios", true)]
        [InlineData("2025-07-28 12:34:56] INFO: Sin corchete inicial", false)]
        [InlineData("[2025-07-28 12:34:56 INFO: Sin corchete de cierre", false)]
        [InlineData("[2025/07/28 12:34:56] INFO: Formato de fecha incorrecto", false)]
        [InlineData("[2025-07-28 12:34] INFO: Sin segundos", false)]
        [InlineData("", false)]  // Cadena vacía
        public void PatronLog_ValidaFormatoCorrectamente(string log, bool esperado)
        {
            bool resultado = Regex.IsMatch(log, Program.patronLog);
            Assert.Equal(esperado, resultado);
        }

        // ==================== TESTS EXTRACCIÓN DE GRUPOS ====================

        [Fact]
        public void PatronLog_ExtraeFechaHora_Correcto()
        {
            string log = "[2025-07-28 12:34:56] INFO: Inicio";
            Match match = Regex.Match(log, Program.patronLog);
            
            Assert.True(match.Success);
            Assert.Equal("2025-07-28 12:34:56", match.Groups["fecha_hora"].Value);
        }

        [Fact]
        public void PatronLog_ExtraeTipo_Correcto()
        {
            string log = "[2025-07-28 12:35:00] ERROR: Fallo de conexión";
            Match match = Regex.Match(log, Program.patronLog);
            
            Assert.True(match.Success);
            Assert.Equal("ERROR", match.Groups["tipo"].Value);
        }

        [Fact]
        public void PatronLog_ExtraeMensaje_Correcto()
        {
            string log = "[2025-07-28 12:36:00] WARN: Memoria baja";
            Match match = Regex.Match(log, Program.patronLog);
            
            Assert.True(match.Success);
            Assert.Equal("Memoria baja", match.Groups["mensaje"].Value);
        }

        [Fact]
        public void PatronLog_ExtraeMensajeLargo_Correcto()
        {
            string log = "[2025-07-28 12:36:00] WARN: Este es un mensaje muy largo con varios espacios y caracteres especiales: @#$%";
            Match match = Regex.Match(log, Program.patronLog);
            
            Assert.True(match.Success);
            Assert.Equal("Este es un mensaje muy largo con varios espacios y caracteres especiales: @#$%", match.Groups["mensaje"].Value);
        }

        [Fact]
        public void PatronLog_ExtraeTodosLosGrupos_Correcto()
        {
            string log = "[2025-12-04 08:15:30] DEBUG: Proceso completado";
            Match match = Regex.Match(log, Program.patronLog);
            
            Assert.True(match.Success);
            Assert.Equal("2025-12-04 08:15:30", match.Groups["fecha_hora"].Value);
            Assert.Equal("DEBUG", match.Groups["tipo"].Value);
            Assert.Equal("Proceso completado", match.Groups["mensaje"].Value);
        }

        // ==================== TESTS MÚLTIPLES TIPOS ====================

        [Theory]
        [InlineData("INFO")]
        [InlineData("ERROR")]
        [InlineData("WARN")]
        [InlineData("DEBUG")]
        [InlineData("TRACE")]
        [InlineData("FATAL")]
        public void PatronLog_AceptaDiferentesTipos(string tipo)
        {
            string log = $"[2025-07-28 12:34:56] {tipo}: Mensaje de prueba";
            Match match = Regex.Match(log, Program.patronLog);
            
            Assert.True(match.Success);
            Assert.Equal(tipo, match.Groups["tipo"].Value);
        }

        // ==================== TESTS MÉTODO ANALIZALOGS ====================

        [Fact]
        public void AnalizaLogs_ProcesaTextoCorrectamente()
        {
            string textoLogs = @"[2025-07-28 12:34:56] INFO: Inicio
[2025-07-28 12:35:00] ERROR: Fallo de conexión
[2025-07-28 12:36:00] WARN: Memoria baja
[2025-07-28 12:37:00] INFO: Fin";

            // El método debe ejecutarse sin lanzar excepciones
            var exception = Record.Exception(() => Program.AnalizaLogs(textoLogs));
            Assert.Null(exception);
        }

        [Fact]
        public void AnalizaLogs_ConTextoVacio_NoLanzaExcepcion()
        {
            string textoLogs = "";

            var exception = Record.Exception(() => Program.AnalizaLogs(textoLogs));
            Assert.Null(exception);
        }

        [Fact]
        public void AnalizaLogs_ConTextoSinLogs_NoLanzaExcepcion()
        {
            string textoLogs = "Solo texto sin formato de log";

            var exception = Record.Exception(() => Program.AnalizaLogs(textoLogs));
            Assert.Null(exception);
        }

        [Fact]
        public void PatronLog_ConDiferentesFechas_Funciona()
        {
            string[] fechas = {
                "2025-01-01 00:00:00",
                "2025-12-31 23:59:59",
                "2024-06-15 14:30:45",
                "2025-07-28 12:34:56"
            };

            foreach (var fecha in fechas)
            {
                string log = $"[{fecha}] INFO: Test";
                Match match = Regex.Match(log, Program.patronLog);
                
                Assert.True(match.Success);
                Assert.Equal(fecha, match.Groups["fecha_hora"].Value);
            }
        }
    }
}
