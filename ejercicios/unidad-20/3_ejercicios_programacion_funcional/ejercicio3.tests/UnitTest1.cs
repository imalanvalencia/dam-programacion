using Xunit;
using Ejercicio3;
using System;
using System.IO;

namespace ejercicio3.tests
{
    public class UnitTest1
    {
        [Fact]
        public void Main_GeneraSalidaCorrecta()
        {
            // Arrancar
            var originalOut = Console.Out;
            using var sw = new StringWriter();
            Console.SetOut(sw);

            try
            {
                // Act
                Program.Main(new string[0]);
            }
            catch (InvalidOperationException)
            {
                // Ignorar error de Console.ReadKey() al no tener consola interactiva
            }
            finally
            {
                // Restaurar consola
                Console.SetOut(originalOut);
            }

            // Assert
            var result = sw.ToString();

            // Verificar que contiene parte de la salida esperada
            Assert.Contains("Ejercicio 3. Auditoría de Pedidos", result);

            // Verificar algunas líneas generadas por la lógica
            // AUD-001: Pedido 1 - Monitor (2 uds)
            Assert.Contains("AUD-001: Pedido 1 - Monitor (2 uds)", result);
            Assert.Contains("AUD-002: Pedido 1 - Ratón (1 uds)", result);
            Assert.Contains("AUD-003: Pedido 2 - Teclado (1 uds)", result);
            Assert.Contains("AUD-005: Pedido 3 - Toner (4 uds)", result);
        }

    }
}

