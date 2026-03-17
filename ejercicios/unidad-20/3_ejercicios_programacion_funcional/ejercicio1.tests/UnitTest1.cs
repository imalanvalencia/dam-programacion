using Xunit;
using Ejercicio1;
using BibliotecaExtensions;
using System.Collections.Generic;

namespace ejercicio1.tests
{
    public class UnitTest1
    {
        private List<Libro> libros;

        public UnitTest1()
        {
            // Setup común
            libros = new List<Libro>
            {
                new Libro("Libro 1", "Autor 1", "Editorial 1", 100, "1111", "Reseña 1"),
                new Libro("Libro 2", "Autor 2", "Editorial 2", 200, "2222", "Reseña 2"),
                new Libro("Libro 3", "Autor 1", "Editorial 3", 300, "3333", "Reseña 3"),
                new Libro("Libro 4", "Autor 3", "Editorial 4", 500, "4444", "Reseña 4")
            };
        }

        [Fact]
        public void BuscaPorISBN_DevuelveLibro_SiExiste()
        {
            var biblioteca = new Biblioteca("Test", libros);
            var resultado = biblioteca.BuscaPorISBN("1111");
            Assert.NotNull(resultado);
            Assert.Equal("Libro 1", resultado.Titulo);
        }

        [Fact]
        public void BuscaPorISBN_DevuelveNull_SiNoExiste()
        {
            var biblioteca = new Biblioteca("Test", libros);
            var resultado = biblioteca.BuscaPorISBN("9999");
            Assert.Null(resultado);
        }

        [Fact]
        public void Presta_AñadeLibroAPrestamos()
        {
            var biblioteca = new Biblioteca("Test", libros);
            biblioteca.Presta("12345678A", "1111");
            Assert.True(biblioteca.EstaPrestado("1111"));
        }

        [Fact]
        public void Presta_LanzaExcepcion_SiNoExiste()
        {
            var biblioteca = new Biblioteca("Test", libros);
            Assert.Throws<BibliotecaException>(() => biblioteca.Presta("123", "9999"));
        }

        [Fact]
        public void EstaPrestado_DevuelveTrue_SiEstaPrestado()
        {
            var biblioteca = new Biblioteca("Test", libros);
            biblioteca.Presta("123", "1111");
            Assert.True(biblioteca.EstaPrestado("1111"));
        }

         [Fact]
        public void EstaPrestado_DevuelveFalse_SiNoEstaPrestado()
        {
            var biblioteca = new Biblioteca("Test", libros);
            Assert.False(biblioteca.EstaPrestado("1111"));
        }

        [Fact]
        public void CuentaLibrosConNumeroDePaginasMenorA_CuentaCorrectamente()
        {
            var biblioteca = new Biblioteca("Test", libros);
            var resultado = biblioteca.CuentaLibrosConNumeroDePaginasMenorA(250);
            Assert.Equal(2, resultado); // Libro 1 (100) y Libro 2 (200)
        }

        [Fact]
        public void EliminaPorAutor_EliminaLibrosDelAutor()
        {
            var biblioteca = new Biblioteca("Test", new List<Libro>(libros)); // Copia para no modificar original en otros tests si no se recreara
            biblioteca.EliminaPorAutor("Autor 1");
            Assert.Equal(2, biblioteca.Libros.Count);
            Assert.Null(biblioteca.BuscaPorISBN("1111"));
            Assert.Null(biblioteca.BuscaPorISBN("3333"));
        }

        [Fact]
        public void AutorTitulo_DevuelveTituloAutor_SiExiste()
        {
            var biblioteca = new Biblioteca("Test", libros);
            var resultado = biblioteca.AutorTitulo("1111");
            Assert.NotNull(resultado);
            Assert.Equal("Libro 1", resultado.Titulo);
            Assert.Equal("Autor 1", resultado.Autor);
        }

        [Fact]
        public void ISBNS_DevuelveArrayOrdenado()
        {
            var biblioteca = new Biblioteca("Test", libros);
            var resultado = biblioteca.ISBNS();
            Assert.Equal(4, resultado.Length);
            Assert.Equal("1111", resultado[0]);
            Assert.Equal("2222", resultado[1]);
            Assert.Equal("3333", resultado[2]);
            Assert.Equal("4444", resultado[3]);
        }
    }
}
