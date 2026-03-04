using System;
using System.Collections.Generic;
using System.Linq;

namespace ejercicio6
{

    public record Usuario(string Username, string NombreCompleto, DateOnly FechaRegistro);

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
            Comentarios = [];
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

        public int GetHashCode(Publicacion obj) => obj.Id.GetHashCode();
    }

    public class PublicacionComparer : IComparer<Publicacion>
    {
        public int Compare(Publicacion? x, Publicacion? y)
        {
            if (x is null || y is null) return 0;
            return x.Id.CompareTo(y.Id);
        }
    }

    public class RedSocial
    {
        public class RedSocialException(string message) : Exception(message);

        public Dictionary<string, Usuario> Usuarios { get; set; }
        public SortedDictionary<DateTime, Publicacion> Publicaciones { get; set; }
        public Dictionary<string, List<long>> PublicacionesPorUsuario { get; set; }

        public RedSocial()
        {
            Usuarios = [];
            Publicaciones = [];
            PublicacionesPorUsuario = [];
        }

        public void RegistraUsuario(Usuario usuario)
        {
            if (Usuarios.ContainsKey(usuario.Username)) throw new RedSocialException("El usuario ya existe.");

            Usuarios.Add(usuario.Username, usuario);
            PublicacionesPorUsuario.Add(usuario.Username, []);
        }

        void AñadePublicacionAUsuario(Usuario usuario, long idPublicacion)
        {
            if (!Usuarios.ContainsKey(usuario.Username)) throw new RedSocialException("El usuario de la publicación no existe.");
            PublicacionesPorUsuario[usuario.Username].Add(idPublicacion);
        }

        public void AñadePublicacion(Publicacion publicacion)
        {
            AñadePublicacionAUsuario(publicacion.Autor, publicacion.Id.Ticks);
            Publicaciones.Add(publicacion.Id, publicacion);
        }

        public void MostrarTodasPublicaciones()
        {
            foreach (var p in Publicaciones.Values)
            {
                Console.WriteLine($"{p.Id:dd/MM/yyyy HH:mm:ss} - {p.Autor.Username}: {p.Contenido} ({p.Likes} likes)");
            }
        }

        public void MostrarPublicacionesUsuario(string username)
        {
            foreach (var pUser in Publicaciones.Values)
            {
                if (pUser.Autor.Username == username)
                    Console.WriteLine($"{pUser.Id:dd/MM/yyyy HH:mm:ss} - {pUser.Autor.Username}: {pUser.Contenido} ({pUser.Likes} likes)");

            }
        }
    }



    public class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Ejercicio 3. Comparación y Búsqueda en Colecciones");
            Console.WriteLine();

            RedSocial redSocial = new RedSocial();

            Usuario u1 = new Usuario("user1", "Usuario Uno", DateOnly.FromDateTime(DateTime.Now));
            Usuario u2 = new Usuario("user2", "Usuario Dos", DateOnly.FromDateTime(DateTime.Now));

            redSocial.RegistraUsuario(u1);
            redSocial.RegistraUsuario(u2);

            DateTime fechaBuscada = new DateTime(2025, 12, 29, 9, 11, 0);
            Publicacion p1 = new Publicacion(DateTime.Now.AddHours(-2), u1, "Contenido 1", 10);
            Publicacion p2 = new Publicacion(DateTime.Now.AddHours(-1), u2, "Contenido 2", 20);
            Publicacion p3 = new Publicacion(fechaBuscada, u1, "Contenido 3", 5);

            redSocial.AñadePublicacion(p3);
            redSocial.AñadePublicacion(p1);
            redSocial.AñadePublicacion(p2);

            Console.WriteLine("--- Parte 1: Búsqueda lineal con Contains ---");
            Console.WriteLine($"¿Existe la publicación {fechaBuscada}? {redSocial.EstaPublicacion(p3)}");
            Console.WriteLine($"¿Existe con EqualityComparer? {redSocial.EstaPublicacionComparer(p3)}");

            Console.WriteLine("\n--- Parte 2: Búsqueda de Usuarios ---");
            Console.WriteLine($"¿Existe el usuario user1? {redSocial.EstaUsuario(u1)}");

            Console.WriteLine("\n--- Parte 3: Búsqueda Binaria ---");
            Console.WriteLine("Lista ordenada por fecha.");
            Console.WriteLine($"Posición encontrada (BinarySearch): {redSocial.BuscaPublicacion(p3) + 1}");
            Console.WriteLine($"Posición encontrada (BinarySearch con IComparer): {redSocial.BuscaPublicacionIComparer(p3) + 1}");

            Console.WriteLine("\nPulsar Enter para salir...");
            Console.ReadLine();
        }
    }
}
