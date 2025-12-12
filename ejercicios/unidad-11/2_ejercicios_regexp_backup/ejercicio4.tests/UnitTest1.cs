using Xunit;

namespace ejercicio4.Tests
{
    public class AnalizaLogsTests
    {
        [Fact]
        public void AnalizaLogs_ExtraeCorrectamente()
        {
            string[] logs = {
                "[2025-07-28 12:34:56] INFO: Inicio",
                "[2025-07-28 12:35:00] ERROR: Fallo de conexión",
                "[2025-07-28 12:36:00] WARN: Memoria baja",
                "[2025-07-28 12:37:00] INFO: Fin"
            };

            // Test de tipos
            string[] tiposEsperados = { "INFO", "ERROR", "WARN" };
            string[] tipos = new string[logs.Length];
            int tiposCount = 0;
            foreach (var log in logs)
            {
                string tipo = Program.ExtraeTipo(log);
                if (!EstaEnArray(tipo, tipos, tiposCount))
                    tipos[tiposCount++] = tipo;
            }
            Assert.Equal(tiposEsperados, tipos[..tiposCount]);

            // Test de errores
            string[] erroresEsperados = { "Fallo de conexión" };
            string[] errores = new string[logs.Length];
            int erroresCount = 0;
            foreach (var log in logs)
            {
                if (Program.ExtraeTipo(log) == "ERROR")
                    errores[erroresCount++] = Program.ExtraeMensaje(log);
            }
            Assert.Equal(erroresEsperados, errores[..erroresCount]);

            // Test primer y último mensaje
            Assert.Equal("Inicio", Program.ExtraeMensaje(logs[0]));
            Assert.Equal("Fin", Program.ExtraeMensaje(logs[3]));
        }

        private static bool EstaEnArray(string valor, string[] array, int len)
        {
            for (int i = 0; i < len; i++)
                if (array[i] == valor) return true;
            return false;
        }
    }
}
