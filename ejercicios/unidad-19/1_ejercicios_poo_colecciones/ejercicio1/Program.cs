using System;
using System.Collections.Generic;

namespace ejercicio1
{
    ///TODO: Completa la clase Plato y el enum Categoria aquí
    public enum Categoria { Entrante, Principal, Postre }
    public class Plato
    {
        public string Nombre { get; }
        public decimal Precio { get; }
        public Categoria Categoria { get; set; }

        public Plato(string nombre, decimal precio, Categoria categoria)
        {
            Nombre = nombre;
            Precio = precio;
            Categoria = categoria;
        }

        public override string ToString() => $"{Nombre} - {Precio} - {Categoria}";

        public override bool Equals(object? obj) => obj is Plato plato && Nombre == plato.Nombre && Precio == plato.Precio;

        public override int GetHashCode() => ToString().GetHashCode();

        public static bool operator ==(Plato? p1, Plato? p2) => Equals(p1, p2);

        public static bool operator !=(Plato? p1, Plato? p2) => !Equals(p1, p2);
    }

    public class Program
    {
        public static void BuscaPlato(List<Plato> lista, Plato plato)
        {
            Console.Write(lista.IndexOf(plato) == -1 ? "Plato no encontrado" :
            $"{lista.IndexOf(plato)} Plato encontrado");
        }
        public static void AñadePlato(List<Plato> lista, Plato plato) => lista.Add(plato);
        public static void EliminaPlato(List<Plato> lista, int indice) => lista.RemoveAt(indice);

        public static void MuestraPlatos(List<Plato> lista)
        {
            Console.WriteLine("Lista de Platos:");
            for (int i = 0; i < lista.Count; i++)
            {

                Console.WriteLine($"{i}. {lista[i]}");
            }
        }

        public static void Main(string[] args)
        {
            List<Plato> listaPlatos = new List<Plato>
            {
                new Plato("Ensalada", 10.5m, Categoria.Entrante),
                new Plato("Solomillo", 20.0m, Categoria.Principal),
                new Plato("Tarta de Queso", 6.5m, Categoria.Postre)
            };

            Console.WriteLine(" Ejercicio 1. Gestión de lista de Platos\n");
            ///TODO: Llama a los métodos para mostrar la lista, buscar, añadir y eliminar platos aquí
            MuestraPlatos(listaPlatos);


            Console.WriteLine("Buscando plato Solomillo 20.0:");
            Console.WriteLine("Plato encontrado en la posición: ");
            BuscaPlato(listaPlatos, new Plato("Solomillo", 20.0m, Categoria.Principal));
            Console.WriteLine("Plato encontrado en la posición: ");
            BuscaPlato(listaPlatos, new Plato("Solomillo", 25.0m, Categoria.Principal));

            Console.WriteLine("Eliminando plato en posición 0: Ensalada - 10,5 - Entrante");
            EliminaPlato(listaPlatos, 0);
            MuestraPlatos(listaPlatos);

            Console.WriteLine("Añadiendo nuevo plato: Sopa - 8,0 - Entrante");
            AñadePlato(listaPlatos, new Plato("Sopa", 8.0m, Categoria.Entrante));
            MuestraPlatos(listaPlatos);


            Console.WriteLine("Presiona Enter para salir...");
            Console.ReadLine();
        }

        //TODO: Implementa los métodos para mostrar, buscar, añadir y eliminar platos aquí
    }
}