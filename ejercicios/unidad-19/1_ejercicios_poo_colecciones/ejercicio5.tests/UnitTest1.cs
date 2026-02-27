using Xunit;
using ejercicio5;
using System.Collections.Generic;
using System;
using System.IO;

namespace ejercicio5.tests
{
    public class UnitTest1
    {
        [Fact]
        public void Producto_Equals_ComparaPorCodigo()
        {
            var p1 = new Producto("001", "A");
            var p2 = new Producto("001", "B");
            Assert.True(p1.Equals(p2));
            Assert.Equal(p1.GetHashCode(), p2.GetHashCode());
        }

        [Fact]
        public void Program_GestionInventario_FuncionaCorrectamente()
        {
             using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                Program.GestionInventario();
                var output = sw.ToString();
                Assert.Contains("True", output); // Verifica que ContainsKey devolvió true
                Assert.Contains("Stock recuperado", output);
            }
        }
    }
}
