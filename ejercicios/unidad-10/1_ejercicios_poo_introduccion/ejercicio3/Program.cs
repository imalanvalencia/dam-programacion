using System;

namespace Ejercicio3
{
    public class Program
    {
     

        static void Main(string[] args)
        {
            Console.WriteLine("Ejercicio 3: Sistema de gestión de URIs (TAD de la BCL)");
            Console.WriteLine("Usando la clase Uri de System");
            Console.WriteLine();
            Console.WriteLine("=== CREACIÓN DE URIs Y ANÁLISIS ===");

            Uri[] uris = CreaUris(4);

            // Mostrar información de cada URI válida
            for (int i = 0; i < uris.Length; i++)
            {
                if (uris[i] != null)
                {
                    MuestraInformacion(uris[i]);
                    Console.WriteLine();
                }
            }

            Console.WriteLine("=== COMPARACIONES ===");

            if (uris[0] != null && uris[1] != null)
            {
                Console.Write($"Comparando {uris[0].OriginalString} y {uris[1].OriginalString} ");
                Console.WriteLine(ComparaUris(uris[0], uris[1]) ? "son iguales." : "Son diferentes.");
            }
            if (uris[2] != null && uris[2] != null)
            {
                Console.Write($"Comparando {uris[2].OriginalString} y {uris[2].OriginalString} ");
                Console.WriteLine(ComparaUris(uris[2], uris[2]) ? "son iguales." : "Son diferentes.");
            }
            Console.ReadLine();
        }
    }
}

