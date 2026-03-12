using Xunit;
using System.Collections.Generic;
using Ejercicio1;

namespace ejercicio1.tests
{
    public class UnitTest1
    {
        private Biblioteca CrearBibliotecaPrueba()
        {
            var libros = new List<Libro>
            {
                new Libro("Titulo1", "Autor1", "Ed1", 100, "ISBN1", "Reseña1"),
                new Libro("Titulo2", "Autor2", "Ed2", 200, "ISBN2", "Reseña2"),
                new Libro("Titulo3", "Autor1", "Ed3", 300, "ISBN3", "Reseña3")
            };
            return new Biblioteca("Biblioteca Test", libros);
        }

        [Fact]
        public void BuscaPorISBN_EncuentraLibroSiExiste()
        {
            var biblio = CrearBibliotecaPrueba();
            var libro = biblio.BuscaPorISBN("ISBN1");
            Assert.NotNull(libro);
            Assert.Equal("Titulo1", libro.Titulo);
        }

        [Fact]
        public void BuscaPorISBN_RetornaNullSiNoExiste()
        {
            var biblio = CrearBibliotecaPrueba();
            var libro = biblio.BuscaPorISBN("ISBN_FALSO");
            Assert.Null(libro);
        }

        [Fact]
        public void Presta_AñadeLibroAPrestamos()
        {
            var biblio = CrearBibliotecaPrueba();
            biblio.Presta("DNI1", "ISBN1");
            Assert.True(biblio.EstaPrestado("ISBN1"));
        }

        [Fact]
        public void Presta_LanzaExcepcionSiLibroNoExiste()
        {
            var biblio = CrearBibliotecaPrueba();
            Assert.Throws<BibliotecaException>(() => biblio.Presta("DNI1", "ISBN_FALSO"));
        }

        [Fact]
        public void CuentaLibrosConNumeroDePaginasMenorA_CuentaCorrectamente()
        {
            var biblio = CrearBibliotecaPrueba();
            // Libro1(100), Libro2(200), Libro3(300)
            int count = biblio.CuentaLibrosConNumeroDePaginasMenorA(250);
            Assert.Equal(2, count);
        }

        [Fact]
        public void EliminaPorAutor_EliminaLibrosDelAutor()
        {
            var biblio = CrearBibliotecaPrueba();
            biblio.EliminaPorAutor("Autor1");
            // Autor1 tiene Libro1 y Libro3. Debería quedar solo Libro2.
            Assert.Single(biblio.Libros);
            Assert.Equal("Titulo2", biblio.Libros[0].Titulo);
        }
        
        [Fact]
        public void AutorTitulo_RetornaTituloAutorCorrecto()
        {
             var biblio = CrearBibliotecaPrueba();
             var tituloAutor = biblio.AutorTitulo("ISBN1");
             Assert.NotNull(tituloAutor);
             Assert.Equal("Titulo1", tituloAutor.Titulo);
             Assert.Equal("Autor1", tituloAutor.Autor);
        }
    }
}

