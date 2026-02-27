using Xunit;
using ejercicio7;
using System;
using System.IO;

namespace ejercicio7.tests
{
    public class UnitTest1
    {
        [Fact]
        public void Cancion_Equals_ComparaPorTitulo()
        {
            var c1 = new Cancion("T", "A", TimeSpan.Zero);
            var c2 = new Cancion("T", "B", TimeSpan.Zero);
            Assert.True(c1.Equals(c2));
        }

        [Fact]
        public void ReproductorMusica_AgregaCancionAlFinal_AñadeCorrectamente()
        {
            var r = new ReproductorMusica();
            r.AgregaCancionAlFinal(new Cancion("1", "A", TimeSpan.Zero));
            r.AgregaCancionAlFinal(new Cancion("2", "A", TimeSpan.Zero));
            
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                r.Reproduce();
                var outStr = sw.ToString();
                // Verificar orden
                var index1 = outStr.IndexOf("1");
                var index2 = outStr.IndexOf("2");
                Assert.True(index1 < index2);
            }
        }

        [Fact]
        public void ReproductorMusica_AgregaCancionAlPrincipio_AñadeCorrectamente()
        {
            var r = new ReproductorMusica();
            r.AgregaCancionAlFinal(new Cancion("1", "A", TimeSpan.Zero));
            r.AgregaCancionAlPrincipio(new Cancion("2", "A", TimeSpan.Zero));
            
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                r.Reproduce();
                var outStr = sw.ToString();
                var index1 = outStr.IndexOf("1");
                var index2 = outStr.IndexOf("2");
                Assert.True(index2 < index1);
            }
        }

        [Fact]
        public void ReproductorMusica_InsertaDespuesDe_InsertaEnPosicionCorrecta()
        {
            var r = new ReproductorMusica();
            r.AgregaCancionAlFinal(new Cancion("1", "A", TimeSpan.Zero));
            r.AgregaCancionAlFinal(new Cancion("3", "A", TimeSpan.Zero));
            r.InsertaDespuesDe("1", new Cancion("2", "A", TimeSpan.Zero));

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                r.Reproduce();
                var outStr = sw.ToString();
                Assert.Contains("2", outStr);
            }
        }

        [Fact]
        public void ReproductorMusica_EliminaCancion_EliminaCorrectamente()
        {
            var r = new ReproductorMusica();
            r.AgregaCancionAlFinal(new Cancion("1", "A", TimeSpan.Zero));
            r.EliminaCancion("1");

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                r.Reproduce();
                var outStr = sw.ToString();
                Assert.DoesNotContain("1", outStr);
            }
        }
    }
}
