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

       /// TODO: Implementar el método CoincidenciasCadena_UsandoClausuras
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
            var busquedaClausura = //TODO: Llamar al método CoincidenciasCadena_UsandoClausuras
            foreach (var texto in busquedaClausura(cadena))
                Console.Write($"{texto} ");

            Pausa($"Buscar coincidencias de {cadena} - Sin usar Clausuras");
            //TODO: Llamar al método CoincidenciasCadena_SinUsarClausuras con Foreach para mostrar los resultados
            Pausa("");
        }
    }
}