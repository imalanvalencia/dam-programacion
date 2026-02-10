using System;
using System.Text.RegularExpressions;

namespace Ej03_CuentaBancaria
{
    public class Ej04_CuentaBancaria
    {
        //TODO: Crea las clases necesarias
        static void Main()
        {
            while (true)
            {
                   Console.Write("Introduce el número de cuenta: ");
                    string ? numCuenta = Console.ReadLine();
                    Console.Write("Introduce el titular: ");
                    string ? titular = Console.ReadLine() ?? "";

                    Cuenta cuenta = new Cuenta(numCuenta, titular);
                    Console.WriteLine("Cuenta creada correctamente.\n");

                    bool salir = false;
                    while (!salir)
                    {
                        Console.Write("Introduce cantidad a retirar: ");
                    string entrada = Console.ReadLine() ?? "";
                        
                        //TODO: Crea el código necesario
                    }

                Console.WriteLine();
                Console.Write("¿Desea introducir otra cuenta? (s/n): ");
                string respuesta = Console.ReadLine() ?? "";
                if (respuesta == null || respuesta.ToLower() != "s")
                    break;
                Console.WriteLine();
            }
        }
    }
}