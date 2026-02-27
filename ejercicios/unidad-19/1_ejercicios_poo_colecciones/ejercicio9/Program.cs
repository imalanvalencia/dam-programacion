using System;
using System.Collections;
using System.Collections.Generic;

namespace ejercicio9
{
   
    ///TODO: Implementar la clase genérica Pila<T> con los métodos Push, Pop, Peek y EstaVacia

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Ejercicio 9. Implementación de una Pila Genérica");
            Console.WriteLine();
            Console.WriteLine("--- Pila de Enteros ---");
            Pila<int> pilaEnteros = new Pila<int>();
            pilaEnteros.Push(10);
            pilaEnteros.Push(20);
            pilaEnteros.Push(30);

            Console.WriteLine(pilaEnteros);
            Console.WriteLine($"Cima (Peek): {pilaEnteros.Peek()}");
            Console.WriteLine($"Desapilando (Pop): {pilaEnteros.Pop()}");
            Console.WriteLine($"Nueva Cima (Peek): {pilaEnteros.Peek()}");
            Console.WriteLine($"¿Está vacía?: {pilaEnteros.EstaVacia()}");

            Console.WriteLine("\n--- Pila de Cadenas (desde Array) ---");
            string[] palabras = { "Hola", "Mundo", "C#" };
            Pila<string> pilaCadenas = new Pila<string>(palabras);

            Console.WriteLine(pilaCadenas);
            while (!pilaCadenas.EstaVacia())
            {
                Console.WriteLine($"Desapilando: {pilaCadenas.Pop()}");
            }

            try
            {
                pilaCadenas.Pop();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Excepción esperada: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Fin de la demostración de la pila.");
                Console.ReadLine();
            }
        }
    }
}