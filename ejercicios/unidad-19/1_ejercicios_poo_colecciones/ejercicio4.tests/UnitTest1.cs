using Xunit;
using ejercicio4;
using System;
using System.IO;

namespace ejercicio4.tests
{
    public class UnitTest1
    {
        [Fact]
        public void Program_GestionPalabras_CuentaCorrectamente()
        {
            var input = "Ana\nPepe\nAna\nfin\n";
            using (var sr = new StringReader(input))
            using (var sw = new StringWriter())
            {
                Console.SetIn(sr);
                Console.SetOut(sw);

                Program.GestionPalabras();

                var output = sw.ToString();
                Assert.Contains("Ana: 2", output);
                Assert.Contains("Pepe: 1", output);
            }
        }
    }
}
