using System;
using System.Collections.Generic;

namespace Ejercicio2
{
    public class Principal
    {
        static void Pausa(string mensaje)
        {
            Console.Write($"\n{mensaje}\nPulsa una tecla...");
            Console.ReadKey();
            Console.Write("\n");
        }

        // Versión con Clausura: Recibe la lista y devuelve una función que "atrapa" esa lista.
        public static Func<string, List<string>> CoincidenciasCadena_UsandoClausuras(List<string> lista)
        {
            // La lambda captura 'lista' del parámetro
            return (cadena) => lista.FindAll(x => x.Contains(cadena));
        }

        // Versión sin Clausura: Recibe ambos parámetros directamente.
        public static List<string> CoincidenciasCadena_SinUsarClausuras(string cadena, List<string> lista)
        {
            return lista.FindAll(x => x.Contains(cadena));
        }


        /// TODO: Implementar el método CoincidenciasCadena_SinUsarClausuras
        /// 
        public static void Main()
        {
            List<String> lista = new List<String>() { "rosa", "mesa", "flor", "ventana", "blanco", "perro", "sillón", "azul", "melón" };

            Console.WriteLine("Ejercicio 2.  Coincidencia en lista de cadenas\n");
            Console.Write("Lista: ");
            lista.ForEach(x => Console.Write($"{x} "));

            Console.Write("\nIntroduce una cadena a buscar: ");
            string cadena = Console.ReadLine();

            Pausa($"Buscar coincidencias de {cadena} - Usando Clausuras");
            //TODO: Llamar al método CoincidenciasCadena_UsandoClausuras

            var busquedaClausura = CoincidenciasCadena_UsandoClausuras(lista);

            foreach (var texto in busquedaClausura)
                Console.Write($"{texto} ");

            Pausa($"Buscar coincidencias de {cadena} - Sin usar Clausuras");
            //TODO: Llamar al método CoincidenciasCadena_SinUsarClausuras con Foreach para mostrar los resultados

            var busquedaSinClausura = CoincidenciasCadena_SinUsarClausuras(lista, cadena);
            busquedaSinClausura.ForEach(cadena => Console.WriteLine(cadena));
            Pausa("");
        }
    }
}