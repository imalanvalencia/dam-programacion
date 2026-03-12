 using System;
using System.Collections.Generic;

namespace Ejercicio3
{
    public class Principal
    {
        static void Pausa(string mensaje)
        {
            Console.Write($"\n{mensaje}\nPulsa una tecla...");
            Console.ReadKey();
            Console.Write("\n");
        }

        ///TODO: Implementar el método EsMultiploDe_ConClausura
        /// TODO: Implementar el método EsMultiploDe_SinClausura
        public static void Main()
        {
            List<int> lista = new List<int>() { 2, 4, 12, 3, 18, 4, 7, 6, 21, 33, 17, 30, 27 };

            Console.WriteLine("Ejercicio 3.  Múltiplos en lista de números\n");
            Console.Write("Lista: ");
            lista.ForEach(x => Console.Write($"{x} "));

            Console.Write("\nIntroduce un número: ");
            int n = int.Parse(Console.ReadLine());

            Pausa($"Múltiplos de {n} - Usando Clausuras");
            foreach (int x in lista)
            {
                var check = EsMultiploDe_ConClausura(x);
                Console.Write(check(n) ? $"{x} " : "");
            }

            Pausa($"Múltiplos de {n} - Sin usar Clausuras");
            lista.ForEach(x => Console.Write((EsMultiploDe_SinClausura(x, n) ? $"{x} " : "")));

            Pausa("");
        }
    }
}