using System;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection.Metadata;
using System.Linq;


namespace Ejercicio4
{


    public class Program
    {

        public static Func<double, double> VolumenEsfera() => (radio) => 1.0 * Math.PI * Math.Pow(radio, 2);

        public static Predicate<string> EsCapitular() => (cadena) => char.IsUpper(cadena.FirstOrDefault());

        public static Func<string, Dictionary<string, int>> DiccionarioDePalabras() => frase => frase.Split(" ").ToHashSet().ToDictionary(palabra => palabra, palabra => palabra.Length);


        ///TODO: Implementa los métodos indicados en el enunciado
        public static void Main()
        {

            Console.WriteLine("Ejercicio 4. Operaciones con funciones Lambda\n");
            var volumen = VolumenEsfera();
            Console.WriteLine(volumen(4));

            Console.WriteLine(EsCapitular()("Luego"));

            foreach (var e in DiccionarioDePalabras()("Esto es una prueba para crear el diccionario"))
                Console.WriteLine($"la palabra {e.Key} tiene una longitud de {e.Value}");

            Console.WriteLine("Pulsa una tecla para finalizar...");
            Console.ReadLine();


        }
    }
}