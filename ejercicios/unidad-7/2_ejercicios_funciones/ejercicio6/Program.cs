using System;

namespace Ejercicio01
{
       class Program
    {
        static void Main()
        {
            Console.WriteLine("Ejercicio 6. Polimorfismo funcional. Gestión Taxi\n");
            Console.WriteLine($"Coste carrera lunes mañana -> {Taxi.CosteCarrera(20, 5):f2}");
            Console.WriteLine($"Coste carrera lunes noche -> {Taxi.CosteCarrera(20, 5, true):f2}");
            Console.WriteLine($"Coste carrera lunes con mi mascota Dogo -> " +
                              $"{Taxi.CosteCarrera(20, 5, 1u):f2}");
            Console.WriteLine($"Coste carrera Domingo de Ramos -> {Taxi.CosteCarrera(20, 5, 40):f2}");
            Console.WriteLine($"Coste carrera Domingo noche -> {Taxi.CosteCarrera(20, 5, true, 20):f2}");
            Console.WriteLine($"Coste carrera Domingo de Ramos noche con Dogo y Minina -> " +
                              $"{Taxi.CosteCarrera(20, 5, true, 40, 2u):f2}");

        
            Console.WriteLine("\nPulse una tecla para finalizar...");
            Console.ReadKey(true);
        }
    }
}


