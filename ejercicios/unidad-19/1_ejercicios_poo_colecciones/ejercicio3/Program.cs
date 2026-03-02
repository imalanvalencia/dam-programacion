using System;
using System.Collections.Generic;
using System.Linq;

namespace ejercicio3
{
    public record Usuario(string UserName, string NombreCompleto, DateOnly FechaRegistro);

    public class Publicacion : IEquatable<Publicacion>, IComparable<Publicacion>
    {
        public DateTime Id { get; set; }
        public Usuario Autor { get; set; }
        public string Contenido { get; set; }
        public int Likes { get; set; }
        public List<string> Comentarios { get; set; }

        public Publicacion(DateTime id, Usuario autor, string contenido, int likes)
        {
            Id = id;
            Autor = autor;
            Contenido = contenido;
            Likes = likes;
            Comentarios = new List<string>();
        }

        public bool Equals(Publicacion? other)
        {
            if (other is null) return false;
            return Id == other.Id;
        }

        public override bool Equals(object? obj)
        {
            if (obj is Publicacion other) return Equals(other);
            return false;
        }

        public override int GetHashCode() => Id.GetHashCode();

        public int CompareTo(Publicacion? other)
        {
            if (other is null) return 1;
            return Id.CompareTo(other.Id);
        }
    }

    public class PublicacionEqualityComparer : IEqualityComparer<Publicacion>
    {
        public bool Equals(Publicacion? x, Publicacion? y)
        {
            if (x is null || y is null) return false;
            return x.Id == y.Id;
        }

        public int GetHashCode(Publicacion obj)
        {
            return obj.Id.GetHashCode();
        }
    }

    public class PublicacionComparer : IComparer<Publicacion>
    {
        public int Compare(Publicacion? x, Publicacion? y)
        {
            if (x is null || y is null) return 0;
            return x.Id.CompareTo(y.Id);
        }
    }

    public class Program
    {
        public static bool EstaPublicacion(List<Publicacion> lista, Publicacion publicacion)
        {
            return lista.Contains(publicacion);
        }

        public static bool EstaPublicacionComparer(List<Publicacion> lista, Publicacion publicacion)
        {
            return lista.Contains(publicacion, new PublicacionEqualityComparer());
        }

        public static bool EstaUsuario(List<Usuario> lista, Usuario usuario)
        {
            return lista.Contains(usuario);
        }

        public static int BuscaPublicacion(List<Publicacion> lista, Publicacion publicacion)
        {
            return lista.BinarySearch(publicacion);
        }

        public static int BuscaPublicacionIComparer(List<Publicacion> lista, Publicacion publicacion)
        {
            return lista.BinarySearch(publicacion, new PublicacionComparer());
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Ejercicio 3. Comparación y Búsqueda en Colecciones");
            Console.WriteLine();

            Usuario u1 = new Usuario("user1", "Usuario Uno", DateOnly.FromDateTime(DateTime.Now));
            Usuario u2 = new Usuario("user2", "Usuario Dos", DateOnly.FromDateTime(DateTime.Now));

            List<Usuario> usuarios = new List<Usuario> { u1, u2 };

            DateTime fechaBuscada = new DateTime(2025, 12, 29, 9, 11, 0);
            Publicacion p1 = new Publicacion(DateTime.Now.AddHours(-2), u1, "Contenido 1", 10);
            Publicacion p2 = new Publicacion(DateTime.Now.AddHours(-1), u2, "Contenido 2", 20);
            Publicacion p3 = new Publicacion(fechaBuscada, u1, "Contenido 3", 5);

            List<Publicacion> publicaciones = new List<Publicacion> { p3, p1, p2 };

            Console.WriteLine("--- Parte 1: Búsqueda lineal con Contains ---");
            Console.WriteLine($"¿Existe la publicación {fechaBuscada}? {EstaPublicacion(publicaciones, p3)}");
            Console.WriteLine($"¿Existe con EqualityComparer? {EstaPublicacionComparer(publicaciones, p3)}");

            Console.WriteLine("\n--- Parte 2: Búsqueda de Usuarios ---");
            Console.WriteLine($"¿Existe el usuario user1? {EstaUsuario(usuarios, u1)}");

            Console.WriteLine("\n--- Parte 3: Búsqueda Binaria ---");
            publicaciones.Sort();
            Console.WriteLine("Lista ordenada por fecha.");
            Console.WriteLine($"Posición encontrada (BinarySearch): {BuscaPublicacion(publicaciones, p3) + 1}");
            Console.WriteLine($"Posición encontrada (BinarySearch con IComparer): {BuscaPublicacionIComparer(publicaciones, p3) + 1}");

            Console.WriteLine("\nPulsar Enter para salir...");
            Console.ReadLine();
        }
    }
}
