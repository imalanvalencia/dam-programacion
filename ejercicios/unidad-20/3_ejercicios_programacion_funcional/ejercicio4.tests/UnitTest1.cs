using Xunit;
using Ej5_ConsultasProductos;
using System.IO;
using System;
using System.Reflection;

namespace ejercicio4.tests
{
    public class UnitTest1
    {
        [Fact]
        public void Main_EjecutaYProduceSalida_UsandoReflexion()
        {
            var originalOut = Console.Out;
            using var sw = new StringWriter();
            Console.SetOut(sw);
            
            // Console.In redirection to force ReadKey to fail fast if not already
            var originalIn = Console.In;
            Console.SetIn(new StringReader(""));

            try
            {
                // Reflexion para llegar a Datos.Principal.Main()
                var datosType = typeof(Datos); // Datos es public static en Ej5_ConsultasProductos
                // Principal es private default (nested)
                var principalType = datosType.GetNestedType("Principal", BindingFlags.NonPublic);
                Assert.NotNull(principalType);

                var mainMethod = principalType.GetMethod("Main", BindingFlags.NonPublic | BindingFlags.Static);
                Assert.NotNull(mainMethod);

                try
                {
                    mainMethod.Invoke(null, null);
                }
                catch (TargetInvocationException ex) when (ex.InnerException is InvalidOperationException)
                {
                     // Console.ReadKey() fallando como se esperaba
                }
            }
            finally
            {
                Console.SetOut(originalOut);
                Console.SetIn(originalIn);
            }

            var output = sw.ToString();

            // Verificaciones básicas de que las consultas se ejecutaron
            Assert.Contains("Ejercicio 5. Consultas sobre lista de productos", output);
            Assert.Contains("Consulta 1:", output);
            Assert.Contains("Consulta 11:", output);
            
            // Verificar algún dato específico
            // Consulta 1 (precio entre 10 y 30): A01(15.05), A04(18.45)
            // { CodArticulo = A01, Descripcion = Uno, Precio = 15,05 }
            Assert.Contains("CodArticulo = A01", output);
            Assert.Contains("CodArticulo = A04", output);
        }
    }
}
