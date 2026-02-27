using System;
using System.Collections.Generic;

namespace ejercicio6
{
    ///TODO: Implementar las clases Usuario, Publicacion y RedSocial

    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Ejercicio 6. Red Social con Diccionarios");
            RedSocial redSocial = new RedSocial();

            Usuario u1 = new Usuario("dev_master", "Juan Perez", DateOnly.FromDateTime(DateTime.Now));
            Usuario u2 = new Usuario("code_ninja", "Maria Garcia", DateOnly.FromDateTime(DateTime.Now));

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