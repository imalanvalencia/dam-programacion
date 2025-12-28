using Xunit;

namespace ejercicio4.tests
{
    public class UnitTest1
    {
        [Fact]
        public void UsoGuid_MuestraMensajesYFormatosCorrectos()
        {
            // Redirigir la salida estándar
            var sw = new System.IO.StringWriter();
            var originalOut = Console.Out;
            Console.SetOut(sw);

            // Ejecutar el método a testear
            Program.UsoGuid();

            // Restaurar salida estándar
            Console.SetOut(originalOut);

            string output = sw.ToString();

            // Comprobaciones clave
            Assert.Contains("Generando identificadores únicos", output);
            Assert.Contains("Usuarios del sistema", output);
            Assert.Contains("Información del primer GUID", output);
            Assert.Contains("Verificación de duplicados", output);
            Assert.Contains("Conversión desde texto", output);
            Assert.Contains("Convertido correctamente", output);
            Assert.Contains("Error en conversión", output);

            // Comprobar que aparecen 3 GUIDs de usuario
            var usuarios = System.Text.RegularExpressions.Regex.Matches(output, @"Usuario \d+:");
            Assert.Equal(3, usuarios.Count);

            // Comprobar formato sin guiones (32 caracteres hex)
            var sinGuiones = System.Text.RegularExpressions.Regex.Match(output, @"Formato sin guiones: ([a-fA-F0-9]{32})");
            Assert.True(sinGuiones.Success);

            // Comprobar formato con llaves
            var conLlaves = System.Text.RegularExpressions.Regex.Match(output, @"Formato con llaves: \{[a-fA-F0-9\-]{36}\}");
            Assert.True(conLlaves.Success);

            // Comprobar formato con paréntesis
            var conParentesis = System.Text.RegularExpressions.Regex.Match(output, @"Formato con paréntesis: \([a-fA-F0-9\-]{36}\)");
            Assert.True(conParentesis.Success);
        }
    }
}
