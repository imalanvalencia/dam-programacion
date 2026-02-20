using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Xunit;


// Tests por cada método público de ContenedorLecturas<T>
namespace ejercicio1.tests
{
    public partial class UnitTest1
    {
        [Fact]
        public void Agrega_AgregaElemento()
        {
            // Arrange
            var c = new ContenedorLecturas<int>();

            // Act
            c.Agrega(10);

            // Assert
            Assert.Equal(1, c.Conteo);
            Assert.Equal(10, c.Ultima);
        }

        [Fact]
        public void Ultima_DevuelveUltima()
        {
            var c = new ContenedorLecturas<int>();
            c.Agrega(1);
            c.Agrega(2);
            c.Agrega(3);
            Assert.Equal(3, c.Ultima);
        }

        [Fact]
        public void Primera_DevuelvePrimera()
        {
            var c = new ContenedorLecturas<string>();
            c.Agrega("A");
            c.Agrega("B");
            Assert.Equal("A", c.Primera);
        }

        [Fact]
        public void Conteo_ReflejaNumElementos()
        {
            var c = new ContenedorLecturas<int>();
            Assert.Equal(0, c.Conteo);
            c.Agrega(5);
            c.Agrega(6);
            Assert.Equal(2, c.Conteo);
        }

        [Fact]
        public void LecturaIndice_DevuelveValor()
        {
            var c = new ContenedorLecturas<int>();
            c.Agrega(7);
            c.Agrega(8);
            c.Agrega(9);
            Assert.Equal(8, c.LecturaIndice(1));
        }

        [Fact]
        public void ToString_FormatoCorrecto()
        {
            var c = new ContenedorLecturas<int>();
            c.Agrega(1);
            c.Agrega(2);
            var s = c.ToString();
            Assert.Contains("Lecturas", s);
            Assert.Contains("1", s);
            Assert.Contains("2", s);
        }

        [Fact]
        public void Limpia_VaciaContenedor()
        {
            var c = new ContenedorLecturas<int>();
            c.Agrega(1);
            c.Limpia();
            Assert.Equal(0, c.Conteo);
        }

        [Fact]
        public void AgregaRango_AgregaSinDuplicados()
        {
            var a = new ContenedorLecturas<int>();
            a.Agrega(1);
            var b = new ContenedorLecturas<int>();
            b.Agrega(1);
            b.Agrega(2);
            a.AgregaRango(b);
            Assert.Equal(2, a.Conteo);
        }

        [Fact]
        public void AgregaRango_NoDuplica()
        {
            // Arrange
            var a = new ContenedorLecturas<int>();
            a.Agrega(1);
            var b = new ContenedorLecturas<int>();
            b.Agrega(2);
            b.Agrega(1);

            // Act
            a.AgregaRango(b);

            // Assert
            Assert.Equal(2, a.Conteo);
        }

        [Fact]
        public void Primera_Throws_WhenEmpty()
        {
            // Arrange
            var c = new ContenedorLecturas<int>();

            // Act/Assert
            Assert.Throws<ContenedorException>(() => { var p = c.Primera; });
        }

        [Fact]
        public async Task GestionContenedor_MuestraFlujoSalida()
        {
            var originalOut = Console.Out;
            try
            {
                using (var sw = new StringWriter())
                {
                    Console.SetOut(sw);
                    await Task.Run(() =>
                    {
                        foreach (var a in AppDomain.CurrentDomain.GetAssemblies())
                        {
                            var name = a.GetName()?.Name;
                            if (name != null && name.StartsWith("ejercicio1", StringComparison.OrdinalIgnoreCase))
                            {
                                var type = Array.Find(a.GetTypes(), t => t.Name == "Program");
                                if (type == null) continue;
                                var method = type.GetMethod("GestionContenedor", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                                if (method != null)
                                {
                                    method.Invoke(null, null);
                                    return;
                                }
                            }
                        }
                    });

                    var output = sw.ToString();
                    Assert.Contains("Creando contenedor de temperaturas", output);
                    Assert.Contains("Agregando: 21.5", output);
                    Assert.Contains("Última:", output);
                    Assert.Contains("Agregando rango del segundo contenedor al primero", output);
                    Assert.Contains("Limpiando", output);
                    Assert.Contains("Creando contenedor de códigos", output);
                    Assert.Contains("Error:", output);
                    Assert.Contains("Agregando: A1", output);
                }
            }
            finally
            {
                Console.SetOut(originalOut);
            }
        }
    }
}
