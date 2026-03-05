using System;
using System.Collections.Generic;

namespace ejercicio7
{
    ///TODO: Implementar las clases Cancion y ReproductorMusical usando LinkedList
    public class Cancion(string Titulo, string Artista, TimeSpan Duracion) : IEquatable<Cancion>
    {
        
    };

    public class ReproductorMusica
    {
        LinkedList<Cancion> listaReproduccion = [];

        public void AgregaCancionAlFinal(Cancion c)
        {
            listaReproduccion.AddLast(c);
        }

        public void AgregaCancionAlPrincipio(Cancion c)
        {
            listaReproduccion.AddFirst(c);
        }

        public void InsertaDespuesDe(string tituloCancionExistente, Cancion c)
        {
            LinkedListNode<Cancion> nodo = listaReproduccion.Find(new Cancion(tituloCancionExistente, "", TimeSpan.Zero))!;

            if (nodo != null)
            {
                listaReproduccion.AddAfter(nodo, c);
            }
        }

        public void EliminaCancion(string titulo)
        {
            LinkedListNode<Cancion> nodo = listaReproduccion.Find(new Cancion(titulo, "", TimeSpan.Zero))!;

            if (nodo != null)
            {
                listaReproduccion.Remove(nodo);
            }
        }
    }


    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Ejercicio 7. Reproductor de Música con LinkedList");
            Console.WriteLine();
            ///TODO: Crear instancia de ReproductorMusical y añadir canciones, reproducirlas, etc.
            Console.WriteLine("\nPulsar Enter para salir...");
            Console.ReadLine();
        }
    }
}