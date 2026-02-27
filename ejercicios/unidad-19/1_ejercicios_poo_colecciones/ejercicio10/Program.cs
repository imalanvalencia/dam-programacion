using System;
using System.Collections;
using System.Collections.Generic;

namespace ejercicio10
{
   ///TODO: Implementar la clase genérica Pila<T> con soporte para el patrón Iterator

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Ejercicio 10. Patrón Iterator en la Pila Genérica");
            Console.WriteLine();

            Pila<string> pila = new Pila<string>();
            pila.Push("Primero");
            pila.Push("Segundo");
            pila.Push("Tercero");
            pila.Push("Cuarto");

            Console.WriteLine("Recorriendo la pila con foreach (LIFO):");
            foreach (string item in pila)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\nPulsar Enter para salir...");
            Console.ReadLine();
        }
    }
}