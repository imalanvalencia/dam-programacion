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
            if (PublicacionesPorUsuario[usuario.Username].Contains(idPublicacion)) throw new RedSocialException("La publicación ya existe para este usuario.");

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
            foreach (Publicacion pUser in Publicaciones.Values)
            {
                if (pUser.Autor.Username == username)
                    Console.WriteLine($"{pUser.Id:dd/MM/yyyy HH:mm:ss} - {pUser.Autor.Username}: {pUser.Contenido} ({pUser.Likes} likes)");

            }
        }
    }



    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Ejercicio 6. Red Social con Diccionarios");
            RedSocial redSocial = new RedSocial();

            Usuario u1 = new("dev_master", "Juan Perez", DateOnly.FromDateTime(DateTime.Now));
            Usuario u2 = new("code_ninja", "Maria Garcia", DateOnly.FromDateTime(DateTime.Now));

            try
            {
                redSocial.RegistraUsuario(u1);
                redSocial.RegistraUsuario(u2);
                Console.WriteLine("Usuarios registrados correctamente.");

                Publicacion p1 = new Publicacion(DateTime.Now.AddMinutes(-10), u1, "Hola mundo!", 5);
                Publicacion p2 = new Publicacion(DateTime.Now.AddMinutes(-5), u2, "Aprendiendo C#", 10);
                Publicacion p3 = new Publicacion(DateTime.Now, u1, "Diccionarios son útiles", 3);

                redSocial.AñadePublicacion(p1);
                redSocial.AñadePublicacion(p2);
                redSocial.AñadePublicacion(p3);
                Console.WriteLine("Publicaciones añadidas.");

                Console.WriteLine();
                redSocial.MostrarTodasPublicaciones();

                Console.WriteLine();
                redSocial.MostrarPublicacionesUsuario("dev_master");

                Console.WriteLine();
                redSocial.MostrarPublicacionesUsuario("code_ninja");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("\nPulsar Enter para salir...");
                Console.ReadLine();
            }
        }
    }
}
