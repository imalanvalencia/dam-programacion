using System;
using System.Collections.Generic;

namespace ejercicio2
{
    ///TODO: Completa la clase Automovil y el enum Color aquí
    public enum Color { Rojo, Verde, Azul, Blanco, Negro }
    public record class Automovil(string Marca, string Modelo, int Cilindrada, int AñoFabricacion, Color Color);

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Ejercicio 2: Gestión de lista de automóviles");
            Console.WriteLine();

            ///TODO: Crea una lista de automóviles con al menos 5 elementos aquí
            List<Automovil> concecionaria = [
                new Automovil("Toyota", "Corolla", 1600, 2020, Color.Blanco),
                new Automovil("Honda", "Civic", 1800, 2019, Color.Negro),
                new Automovil("Ford", "Focus", 2000, 2020, Color.Rojo),
                new Automovil("Nissan", "Sentra", 1600, 2018, Color.Azul),
                new Automovil("Volkswagen", "Golf", 1400, 2020, Color.Blanco  )
                ];




            Console.WriteLine();
            Console.WriteLine("Fin de la demostración.");
            Console.ReadLine();
        }

        ///TODO: Implementa el método MostrarAutomoviles aquí
    }
}