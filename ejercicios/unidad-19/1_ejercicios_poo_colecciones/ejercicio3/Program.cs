using System;
using System.Collections.Generic;
using System.Linq;

namespace ejercicio3
{
    ///TODO: Completa las clases Usuario, Publicacion, PublicacionEqualityComparer y PublicacionComparer aquí
   
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Ejercicio 3. Comparación y Búsqueda en Colecciones");
            Console.WriteLine();

            Usuario u1 = new Usuario("user1", "Usuario Uno", DateOnly.FromDateTime(DateTime.Now));
            Usuario u2 = new Usuario("user2", "Usuario Dos", DateOnly.FromDateTime(DateTime.Now));

            List<Usuario> usuarios = new List<Usuario> { u1, u2 };

            Publicacion p1 = new Publicacion(DateTime.Now.AddHours(-2), u1, "Contenido 1", 10);
            Publicacion p2 = new Publicacion(DateTime.Now.AddHours(-1), u2, "Contenido 2", 20);
            Publicacion p3 = new Publicacion(DateTime.Now, u1, "Contenido 3", 5);

            List<Publicacion> publicaciones = new List<Publicacion> { p3, p1, p2 };

            Console.WriteLine("--- Parte 1: Búsqueda lineal con Contains ---");
            ///TODO: Completa el código para buscar una publicación existente y una que no existe
            Console.WriteLine("\n--- Parte 2: Búsqueda de Usuarios ---");
           ///TODO: Completa el código para buscar un usuario existente y uno que no existe
            Console.WriteLine("\n--- Parte 3: Búsqueda Binaria ---");
           ///TODO: Completa el código para buscar una publicación existente y una que no existe usando búsqueda binaria
            Console.WriteLine("\nPulsar Enter para salir...");
            Console.ReadLine();
        }

    }
}