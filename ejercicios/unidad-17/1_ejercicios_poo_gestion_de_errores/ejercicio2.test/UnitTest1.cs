using Xunit;

namespace ejercicio2.Tests
{
    public class BibliotecaTests
    {
        [Fact]
        public void TomarPrestado_LibroDisponible_PrestamoCorrecto()
        {
            var libro = new Libro("El Quijote", "Cervantes");
            var usuario = new Usuario("Ana");
            usuario.TomarPrestado(libro);
            Assert.False(libro.Disponible);
        }

        [Fact]
        public void TomarPrestado_LibroNoDisponible_LanzaLibroNoDisponibleException()
        {
            var libro = new Libro("El Quijote", "Cervantes");
            libro.Prestar();
            var usuario = new Usuario("Ana");
            Assert.Throws<LibroNoDisponibleException>(() => usuario.TomarPrestado(libro));
        }

        [Fact]
        public void TomarPrestado_MasDeTresLibros_LanzaLimitePrestamosException()
        {
            var usuario = new Usuario("Ana");
            var libro1 = new Libro("L1", "A");
            var libro2 = new Libro("L2", "B");
            var libro3 = new Libro("L3", "C");
            var libro4 = new Libro("L4", "D");
            usuario.TomarPrestado(libro1);
            usuario.TomarPrestado(libro2);
            usuario.TomarPrestado(libro3);
            Assert.Throws<LimitePrestamosException>(() => usuario.TomarPrestado(libro4));
        }

        [Fact]
        public void BuscarLibro_LibroNoExiste_LanzaInvalidOperationException()
        {
            var biblioteca = new Biblioteca(new Libro[] { new Libro("L1", "A") });
            Assert.Throws<InvalidOperationException>(() => biblioteca.BuscarLibro("NoExiste"));
        }

        [Fact]
        public void BuscarLibro_LibroExiste_DevuelveLibro()
        {
            var libro = new Libro("L1", "A");
            var biblioteca = new Biblioteca(new Libro[] { libro });
            var encontrado = biblioteca.BuscarLibro("L1");
            Assert.Equal(libro, encontrado);
        }
    }
}