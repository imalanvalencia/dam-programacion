using System;

public class CalculadoraAvanzada
{
    public static double Dividir(int a, int b) => a / b;

    public static double RaizCuadrada(double x)
    {
        if (x < 0)
            throw new ArgumentOutOfRangeException(nameof(x), "No se puede calcular la raíz cuadrada de un número negativo.");

        return Math.Sqrt(x);
    }

    public static int ObtenerElemento(int[] array, int indice) => array[indice];

    public static int ParsearEntero(string texto) => int.Parse(texto);

    public static void Main()
    {
        try
        {
            Console.Write("Introduce el dividendo: ");
            int dividendo = int.Parse(Console.ReadLine()!);

            Console.Write("Introduce el divisor: ");
            int divisor = int.Parse(Console.ReadLine()!);

            double resultadoDivision = Dividir(dividendo, divisor);
            Console.WriteLine($"Resultado de la división: {resultadoDivision}");
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Error: No se puede dividir por cero.");
        }

        try
        {
            Console.Write("Introduce un número para la raíz cuadrada: ");
            double numero = double.Parse(Console.ReadLine()!);
            double resultadoRaiz = RaizCuadrada(numero);
            Console.WriteLine($"Resultado de la raíz cuadrada: {resultadoRaiz}");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Error: No se puede calcular la raíz cuadrada de un número negativo.");
        }

        try
        {
            int[] array = [1, 2, 3];
            Console.Write("Introduce el índice del array (array de 3 elementos): ");
            int indice = int.Parse(Console.ReadLine()!);
            int elemento = ObtenerElemento(array, indice);
            Console.WriteLine($"Elemento en el índice {indice}: {elemento}");
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("Error: Índice fuera de rango.");
        }

        try
        {
            Console.Write("Introduce un texto para convertir a entero: ");
            string texto = Console.ReadLine()!;
            int numeroConvertido = ParsearEntero(texto);
            Console.WriteLine($"Número convertido: {numeroConvertido}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Error: Formato no válido para convertir a entero.");
        }

        Console.ReadLine();
    }
}