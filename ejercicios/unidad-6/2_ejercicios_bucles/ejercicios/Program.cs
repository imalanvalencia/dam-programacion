using System;
using System.Security.Cryptography.X509Certificates;

public class Program
{
    public static void NumerosAmigos()
    {
        Console.WriteLine("Ejercicio 1: Números amigos");
        //TODO: implementar la lógica del método
        Console.Write("Introduzca valor 1: ");
        int value1 = int.Parse(Console.ReadLine() ?? "0");

        Console.Write("Introduzca valor 2: ");
        int value2 = int.Parse(Console.ReadLine() ?? "0");

        int areCousin = 0;

        for (int i = 1; i < value1; i++)
        {
            if (value1 % i == 0)
            {
                areCousin += i;
            }
        }

        if (value1 <= 0 || value2 <= 0) Console.WriteLine("ERROR: Sólo se permiten números positivos");
        else if (areCousin == value2) Console.WriteLine("Los valores son amigos");
        else Console.WriteLine("Los valores no son amigos");

    }

    public static void Calculadora()
    {
        Console.WriteLine("\nEjercicio 2: Calculadora");
        //TODO: implementar la lógica del métod
        bool outKey;



        do
        {
            Console.WriteLine("1. Sumar");
            Console.WriteLine("2. Restar");
            Console.WriteLine("3. Multiplicar");
            Console.WriteLine("4. Dividir");
            Console.WriteLine("ESC. Salir");

            Console.Write("Pulsa una opción: ");
            var pushKey = Console.ReadKey(true);
            Console.WriteLine();

            outKey = pushKey.Key == ConsoleKey.Escape; // Comprueba si la tecla pulsada es escape.

            if (pushKey.Key == ConsoleKey.Escape)
            {
                Console.WriteLine("Saliendo...");
            }

            else
            {

                Console.Write("Introduce el primer operando: ");
                double firstOperator = double.Parse(Console.ReadLine() ?? "0");

                Console.Write("Introduce el segundo operando: ");
                double secondOperator = double.Parse(Console.ReadLine() ?? "0");

                char characterPushKey = pushKey.KeyChar;


                double operation = characterPushKey switch
                {
                    '1' => firstOperator + secondOperator,
                    '2' => firstOperator - secondOperator,
                    '3' => firstOperator * secondOperator,
                    '4' => firstOperator / secondOperator,
                    _ => double.NaN

                };

                Console.WriteLine($"El resultado es {operation}");
            }

        } while (!outKey);

    }

    public static void MultiplosDe7()
    {
        Console.WriteLine("\nEjercicio 3: Múltiplos de 7");
        //TODO: implementar la lógica del método
        const int NUMBER = 7;
        const int LIMIT = 16;

        string outputMessage = "";

        for (int i = 1; i <= LIMIT; i++)
        {
            if (i == 1) outputMessage = $"{NUMBER * i}";
            else outputMessage += $" {NUMBER * i}";
        }

        Console.WriteLine(outputMessage);
    }

    public static void SecuenciaDeNumeros()
    {
        Console.WriteLine("\nEjercicio 4: Secuencia de números");
        //TODO: implementar la lógica del método

        Console.Write("Introduzca un numero entero: ");
        int inputNumber = int.Parse(Console.ReadLine() ?? "");

        for (int i = 0; i <= inputNumber; i++)
        {
            for (int j = 0; j < i; j++)
            {
                Console.Write(i);
            }
        }
    }

    public static void TrianguloDeAsteriscos()
    {
        Console.WriteLine("\nEjercicio 5: Triángulo de asteriscos");
        //TODO: implementar la lógica del método

        Console.Write("Introduce el número de filas: ");
        int high = int.Parse(Console.ReadLine() ?? "");


        for (int row = 1; row <= high; row++)
        {

            for (int column = 0; column < row; column++)
            {
                Console.Write("* ");

            }

            Console.WriteLine();
        }

    }

    public static void PiramideDeNumeros()
    {
        Console.WriteLine("\nEjercicio 6: Pirámide de números");
        //TODO: implementar la lógica del método

        Console.Write("Introduce el número de filas: ");
        int high = int.Parse(Console.ReadLine() ?? "");


        for (int row = 1; row <= high; row++)
        {

            for (int column = 0; column < row; column++)
            {
                Console.Write($"{(1 + column) % 10} ");

            }

            Console.WriteLine();
        }
    }

    public static void SumaDeDigitos()
    {
        Console.WriteLine("\nEjercicio 7: Suma de dígitos");
        //TODO: implementar la lógica del método

        Console.WriteLine("Introduzca un numero: ");
        int inputNumber = int.Parse(Console.ReadLine() ?? "0");

        int copyNumber = inputNumber;

        int manyDigits = 0;
        int suma = 0;

        while (copyNumber > 0)
        {
            suma += copyNumber % 10;
            copyNumber /= 10;
            manyDigits++;
        }

        Console.WriteLine($"Número de dígitos: {manyDigits}");
        Console.WriteLine($"Suma de dígitos: {suma}");
    }

    public static void PiramideDeNumerosDos()
    {
        Console.WriteLine("\nEjercicio 8: Pirámide de números dos");
        //TODO: implementar la lógica del método
        //FIXME: No funciona

        // Console.Write("Introduce el número de filas: ");
        int high = int.Parse(Console.ReadLine() ?? "0");
        int rowNumber = 3;


        for (int row = 1; row <= high; row++)
        {
            int columnNumber = rowNumber; // Recuperando el valor inicial de la fila

            for (int column = 1; column <= row; column++)
            {
                Console.Write($"{columnNumber % 10} "); // Pinta los numeros de al lado
                columnNumber += 3;
            }

            Console.WriteLine();
            rowNumber += 2;
        }
    }

    public static void PiramideDeNumerosCompleta()
    {
        Console.WriteLine("\nEjercicio 9: Pirámide de números completa");
        //TODO: implementar la lógica del método

        Console.Write("Introduce el número de filas: ");
        int high = int.Parse(Console.ReadLine() ?? "");

        for (int row = 1; row <= high; row++)
        {
            // Pinta los espacios en blanco
            for (int spaceToAlign = 1; spaceToAlign <= high - row; spaceToAlign++)
            {
                Console.Write(" ");
            }

            // Pinta los números ascendentes
            for (int numUp = 0; numUp < row; numUp++)
            {
                Console.Write((row + numUp) % 10);  // %10 para ciclo 0-9
            }

            // Pinta los números descendentes (excluyendo el pico ya impreso)
            for (int numDown = row - 2; numDown >= 0; numDown--)
            {
                Console.Write((row + numDown) % 10);
            }


            Console.WriteLine();
        }

    }

    public static void BuscarUbicacionDeNumero()
    {
        Console.WriteLine("\nEjercicio 10: Buscar la ubicación de un número");
        //TODO: implementar la lógica del método

        Console.Write("Introduce el número a ubicar: ");
        int numeroAUbicar = int.Parse(Console.ReadLine() ?? "");
        int numberInput = -1;
        int minimo = 0;
        int maximo = 0;
        bool findIt = false;

        Console.WriteLine("Introduce los números de la lista en orden ascendente(terminando con 0):");

        while (numberInput != 0)
        {
            numberInput = int.Parse(Console.ReadLine() ?? "");

            // Asegurar que no lea cuando sea cero
            if (numberInput != 0)
            {
                // Validar con flags
                if (numberInput == numeroAUbicar) findIt = true;
                else if (minimo == 0 || numberInput < minimo) minimo = numberInput;
                else if (maximo == 0 || numberInput > maximo) maximo = numberInput;
            }
        }

        if (findIt) Console.WriteLine("En la lista");
        else if (numeroAUbicar < minimo) Console.WriteLine("Fuera de lista a la Izquierda");
        else if (numeroAUbicar > maximo) Console.WriteLine("Fuera de lista a la Derecha");
        else Console.WriteLine("Fuera de lista a la Intercalado");
    }

    public static void Main(string[] args)
    {
        // NumerosAmigos();
        // Calculadora();
        // MultiplosDe7();
        // SecuenciaDeNumeros();
        // TrianguloDeAsteriscos();
        // PiramideDeNumeros();
        // PiramideDeNumerosDos();
        // PiramideDeNumerosCompleta();
        BuscarUbicacionDeNumero();
        Console.WriteLine("\nPresiona cualquier tecla para salir...");
        Console.ReadKey();
    }
}