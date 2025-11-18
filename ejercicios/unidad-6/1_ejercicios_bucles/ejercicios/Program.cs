using System;

public class Program
{
    public static void ContadorDeNumeros()
    {
        Console.WriteLine("Ejercicio 1: Contador de números");
        // TODO: Implementa la lógica de este método

        int inputNumber;
        int counter = 1;
        int positiveNumbers = 0;
        int negativeNumbers = 0;

        do
        {
            Console.Write($"Introduzca valor {counter}: ");
            inputNumber = int.Parse(Console.ReadLine() ?? "0");
            if (inputNumber > 0) positiveNumbers++;
            if (inputNumber < 0) negativeNumbers++;

            counter++;
        } while (inputNumber != 0 || counter == 1);

        Console.WriteLine($"Números positivos introducidos: {positiveNumbers}");
        Console.WriteLine($"Números negativos introducidos: {negativeNumbers}");

    }

    public static void SumaYProducto()
    {
        Console.WriteLine("\nEjercicio 2: Suma y producto");
        // TODO: Implementa la lógica de este método
        const int LIMIT_NUMBER = 10;
        int suma = 0;
        int producto = 1;

        for (int i = 1; i <= LIMIT_NUMBER; i++)
        {
            suma += i;
            producto *= i;
        }

        Console.WriteLine($"SUMA: {suma}");
        Console.WriteLine($"PRODUCTO: {producto}");

    }

    public static void ContadorNumerosPares()
    {
        Console.WriteLine("\nEjercicio 3: Contador de números pares");
        // TODO: Implementa la lógica de este método
        int evenNumbers = 0;

        Console.Write("Introduce un número: ");
        int inputNumber = int.Parse(Console.ReadLine() ?? "");

        for (int i = 1; i <= inputNumber; i++)
        {
            if (i % 2 == 0) evenNumbers += 1;
        }

        Console.WriteLine($"Entre 1 y {inputNumber} hay {evenNumbers} números pares");
    }

    public static void SumaDeNumeros()
    {
        Console.WriteLine("\nEjercicio 4: Suma de números");
        // TODO: Implementa la lógica de este método

        int inputNumber;
        int sumaTotal = 0;

        do
        {
            Console.Write("Introduce un número (0 o negativo para terminar): ");
            inputNumber = int.Parse(Console.ReadLine() ?? "0");

            if (inputNumber > 0) sumaTotal += inputNumber;

        } while (inputNumber > 0);

        Console.WriteLine($"La suma total es: {sumaTotal}");
    }

    public static void ProductoMedianteSumas()
    {
        Console.WriteLine("\nEjercicio 5: Producto mediante sumas sucesivas");
        // TODO: Implementa la lógica de este método

        double producto = 0;

        Console.Write("Introduzca operador 1: ");
        int operador1 = int.Parse(Console.ReadLine() ?? "");

        Console.Write("Introduzca operador 2: ");
        int operador2 = int.Parse(Console.ReadLine() ?? "");



        if (operador1 <= 0 || operador2 <= 0) Console.WriteLine("ERROR: Sólo se permiten números positivos");

        else
        {
            Console.WriteLine("Sumando....");
            for (int i = 0; i < operador2; i++)
            {
                producto += operador1;
            }

            Console.WriteLine($" {operador1} x {operador2} = {producto}");
        }
    }

    public static void ValidacionDeEntrada()
    {
        Console.WriteLine("\nEjercicio 6: Validación de entrada");
        // TODO: Implementa la lógica de este método

        int inputNumber;

        const int MININUM = 1;
        const int MAXINUM = 10;

        bool VALIDATION_LIMITS;

        do
        {
            Console.Write($"Introduce un número entre {MININUM} y {MAXINUM}: ");
            inputNumber = int.Parse(Console.ReadLine() ?? "0");

            VALIDATION_LIMITS = inputNumber is >= MININUM and <= MAXINUM;


            if (VALIDATION_LIMITS)
            {
                Console.WriteLine($"Número válido: {inputNumber}");
            }

            else Console.Write("Número inválido. ");

        } while (!VALIDATION_LIMITS);
    }

    public static void DivisionMedianteRestas()
    {
        Console.WriteLine("\nEjercicio 7: División mediante restas sucesivas");
        // TODO: Implementa la lógica de este método


        Console.Write("Introduzca dividendo: ");
        int dividendo = int.Parse(Console.ReadLine() ?? "");

        Console.Write("Introduzca divisor: ");
        int divisor = int.Parse(Console.ReadLine() ?? "");

        double resto = dividendo;
        double cociente = 0;

        if (dividendo <= 0 || divisor <= 0) Console.WriteLine("ERROR: Sólo se permiten números positivos");

        else
        {
            while (divisor <= resto)
            {
                resto -= divisor;
                cociente++;
            }

            Console.WriteLine($"{dividendo} / {divisor} = {cociente}");
            Console.WriteLine($"Resto: {resto}");
        }

    }

    public static void AdivinaNumero(int? semilla = null)
    {
        Console.WriteLine("\nEjercicio 8: Adivinar número");
        // Usamos una semilla opcional para hacer el número a adivinar predecible en tests
        // Si semilla es null, se usa un Random normal
        Random aleatorio = semilla.HasValue ? new Random(semilla.Value) : new Random();
        // TODO: Implementa la lógica de este método

        int toGuess = aleatorio.Next(1, 101);
        int inputNumber;
        int tries = 0;

        do
        {

            Console.WriteLine("Adivina el número entre 1 y 100");
            Console.Write("Introduce tu número: ");
            inputNumber = int.Parse(Console.ReadLine() ?? "");

            if (toGuess > inputNumber)
            {
                Console.Write("El número es mayor");
                tries++;
            }

            else if (toGuess < inputNumber)
            {
                Console.Write("El número es menor");
                tries++;
            }
            else
            {
                tries++;
                Console.WriteLine($"¡Correcto! Has adivinado el número en {tries} intentos");
            }
        } while (toGuess != inputNumber);
    }

    public static void MaximoYMinimo()
    {
        Console.WriteLine("\nEjercicio 9: Máximo y mínimo");
        // TODO: Implementa la lógica de este método
        int minimumInputNumber = 0;
        int maximumInputNumber = 0;

        int actualInputNumber;

        for (int i = 1; i < 6; i++)
        {
            Console.Write($"Introduce el número {i}: ");
            actualInputNumber = int.Parse(Console.ReadLine() ?? "");

            if (i == 1)
            {
                minimumInputNumber = actualInputNumber;
                maximumInputNumber = actualInputNumber;
            }

            if (actualInputNumber < minimumInputNumber) minimumInputNumber = actualInputNumber;
            if (actualInputNumber > maximumInputNumber) maximumInputNumber = actualInputNumber;
        }


        Console.WriteLine($"El número mayor es: {maximumInputNumber}");
        Console.WriteLine($"El número menor es: {minimumInputNumber}");
    }

    public static void SecuenciaFibonacci()
    {
        Console.WriteLine("\nEjercicio 10: Secuencia Fibonacci");
        // TODO: Implementa la lógica de este método
        Console.Write("Introduce cuántos números de Fibonacci quieres: ");
        int inputNumber = int.Parse(Console.ReadLine() ?? "");

        if (inputNumber <= 0) Console.WriteLine("El número debe ser positivo.");

        else
        {

            string output = "";
            int before = 0;
            int actual = 1;



            for (int i = 0; i < inputNumber; i++)
            {
                if (i == 0) output += $"{before}";
                else output += $", {before}";

                int after = before + actual;
                before = actual;
                actual = after;
            }

            Console.WriteLine(output);
        }
    }

    public static void Main(string[] args)
    {
        ContadorDeNumeros();
        SumaYProducto();
        ContadorNumerosPares();
        SumaDeNumeros();
        ProductoMedianteSumas();
        ValidacionDeEntrada();
        DivisionMedianteRestas();
        AdivinaNumero();
        MaximoYMinimo();
        SecuenciaFibonacci();

        Console.WriteLine("\nPresiona cualquier tecla para salir...");
        Console.ReadLine();
    }
}