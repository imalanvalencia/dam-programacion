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

        // Versión con Clausura: Tiene que "atrapar" las variables 'cadena' y 'lista' desde afuera para realizar la búsqueda.
        public static Func<List<string>, Func<string, List<string>>> CoincidenciasCadena_UsandoClausuras = (lista) => (cadena) => lista.FindAll(x => x.Contains(cadena));

        // Versión sin Clausura: Recibe parametros necesarios para realizar la búsqueda sin necesidad de "atrapar" variables externas.
        public static Func<string, List<string>, List<string>> CoincidenciasCadena_SinUsarClausuras = (cadena, lista) => lista.FindAll(x => x.Contains(cadena));


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
            8
            Pausa($"Buscar coincidencias de {cadena} - Usando Clausuras");
            //TODO: Llamar al método CoincidenciasCadena_UsandoClausuras

            // No es necesario el invoke, pero se deja para mostrar que es una función que devuelve otra función.
            var busquedaClausura = CoincidenciasCadena_UsandoClausuras(lista).Invoke(cadena);

            foreach (var texto in busquedaClausura)
                Console.Write($"{texto} ");

            Pausa($"Buscar coincidencias de {cadena} - Sin usar Clausuras");
            //TODO: Llamar al método CoincidenciasCadena_SinUsarClausuras con Foreach para mostrar los resultados



            var busquedaSinClausura = CoincidenciasCadena_SinUsarClausuras(cadena, lista);
            busquedaSinClausura.ForEach(texto => Console.WriteLine(texto));
            Pausa("");
        }
    }
}