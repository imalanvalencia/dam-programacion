using System;
using System.Collections.Generic;

namespace ejercicio4
{
    public class Program
    {

        ///TODO: Implementar el método GestionPalabras
        public static void GestionPalabras()
        {
            Dictionary<string, int> palabras = [];

            string palabraIntroducida = "";
            while (!palabraIntroducida.Equals("fin", StringComparison.CurrentCultureIgnoreCase))
            {
                Console.Write("Introduce una palabra (o 'fin' para terminar): ");
                palabraIntroducida = Console.ReadLine()!;

                if (!palabraIntroducida.Equals("fin", StringComparison.CurrentCultureIgnoreCase))
                {
                    if (palabras.ContainsKey(palabraIntroducida)) palabras[palabraIntroducida]++;
                    else palabras[palabraIntroducida] = 1;
                }

            }


            Console.WriteLine("Nombres introducidos (Claves):");
            foreach (string palabra in palabras.Keys)
            {
                Console.WriteLine($"{palabra}");
            }

            Console.WriteLine("Nombres introducidos (Claves):");
            foreach (KeyValuePair<string, int> palabra in palabras)
            {
                Console.WriteLine($"{palabra.Key}: {palabra.Value}");
            }

        }
        public static void Main(string[] args)
        {
            Console.WriteLine("Ejercicio 4. Diccionario contador de palabras");
            Console.WriteLine();
            GestionPalabras();
            Console.WriteLine("\nPulsar Enter para salir...");
            Console.ReadLine();
        }


    }
}