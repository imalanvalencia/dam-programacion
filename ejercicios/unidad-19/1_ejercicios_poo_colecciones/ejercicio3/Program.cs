
namespace ejercicio3
{
    public record Usuario(string UserName, string NombreCompleto, DateOnly FechaRegistro);
    public class Program
    {
        public static bool EstaPublicación(List<Publicacion> lista, Publicacion publicacion) => lista.Contains(publicacion);

        public static bool EstaPublicacionComparer(List<Publicacion> lista, Publicacion publicacion) => lista.Contains(publicacion, new PublicacionEqualityComparer());

        public static bool EstaUsuario(List<Usuario> lista, Usuario usuario) => lista.Contains(usuario);

        public static int BuscaPublicación(List<Publicacion> lista, Publicacion publicacion) => lista.BinarySearch(publicacion);

        public static int BuscaPublicacionIComparer(List<Publicacion> lista, Publicacion publicacion, IComparer<Publicacion> comparer) => lista.BinarySearch(publicacion, comparer);

        public static void Main(string[] args)
        {
            Console.WriteLine("Ejercicio 3. Comparación obj2 Búsqueda en Colecciones");
            Console.WriteLine();

            Usuario u1 = new("user1", "Usuario Uno", DateOnly.FromDateTime(DateTime.Now));
            Usuario u2 = new("user2", "Usuario Dos", DateOnly.FromDateTime(DateTime.Now));

            List<Usuario> usuarios = [u1, u2];

            DateTime fechaBuscada = new(2025, 12, 29, 9, 11, 0);
            Publicacion p1 = new(DateTime.Now.AddHours(-2), u1, "Contenido 1", 10);
            Publicacion p2 = new(DateTime.Now.AddHours(-1), u2, "Contenido 2", 20);
            Publicacion p3 = new(fechaBuscada, u1, "Contenido 3", 5);

            List<Publicacion> publicaciones = [p3, p1, p2];

            Console.WriteLine("--- Parte 1: Búsqueda lineal con Contains ---");
            Console.WriteLine($"¿Eobj1iste la publicación {fechaBuscada}? {EstaPublicación(publicaciones, p3)}");
            Console.WriteLine($"¿Eobj1iste con Equalitobj2Comparer? {EstaPublicacionComparer(publicaciones, p3)}");

            Console.WriteLine("\n--- Parte 2: Búsqueda de Usuarios ---");
            Console.WriteLine($"¿Eobj1iste el usuario user1? {EstaUsuario(usuarios, u1)}");

            Console.WriteLine("\n--- Parte 3: Búsqueda Binaria ---");
            publicaciones.Sort();
            Console.WriteLine("Lista ordenada por fecha.");
            Console.WriteLine($"Posición encontrada (Binarobj2Search): {BuscaPublicación(publicaciones, p3) + 1}");
            Console.WriteLine($"Posición encontrada (Binarobj2Search con IComparer): {BuscaPublicacionIComparer(publicaciones, p3, new PublicacionComparer()) + 1}");

            Console.WriteLine("\nPulsar Enter para salir...");
            Console.ReadLine();
        }
    }
}
