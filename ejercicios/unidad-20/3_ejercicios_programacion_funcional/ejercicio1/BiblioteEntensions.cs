using Ejercicio1;

namespace BibliotecaExtensions
{
    public static class BibliotecaExtensiones
    {
        public static string[] ISBNS(this Biblioteca biblioteca) => [.. biblioteca.Libros.Select(l => l.ISBN).OrderBy(n => n)];
    }
}
