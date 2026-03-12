using System;

namespace Ejercicio4
{

    public class Program
    {
        ///TODO: Define el código necesario para el ejercicio
        public static string TextoMenu()
        {
            return
                "1. Ejecutar Ejercicio 1 (Operación)\n" +
                "2. Ejecutar Ejercicio 2 (Descuentos)\n" +
                "3. Salir\n";
        }

        public static int LeeNumero()
        {
            int n;

            Console.Write("Selecciona número entero: ");
            if (!int.TryParse(Console.ReadLine(), out n))
            {
                Console.WriteLine("Valor incorrecto, se ajustó a 0");
                n = 0;
            }
            return n;
        }


        public static void Main(string[] args)
        {
            Console.WriteLine("Ejercicio 4. Refactorización con Delegados Genéricos\n");
            ///TODO: Define el código necesario para el ejercicio

            ConsoleKeyInfo key;
            bool salir = false;
            Console.WriteLine("Ejercicio 1. Delegado Operación\n");


            do
            {

                Console.WriteLine(TextoMenu());
                Console.Write("Selecciona una opción: ");
                key = Console.ReadKey(true);
                switch (key.KeyChar)
                {
                    case '1':
                        Ejercicio1.Ejercicio1Main();

                        break;
                    case '2':
                        Ejercicio2.Ejercicio2Main();
                        break;
                    case '3':
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Selección inválida !!!");
                        break;
                }

                if (!salir)
                {
                    Console.Clear();
                }

                Console.ReadKey(true);
            } while (!salir);

            Console.WriteLine("Pulsar una tecla para finalizar...");
            Console.ReadKey(true);

        }
    }

}