using System;

public class Program
{
    static string InputUser(string message)
    {
        Console.Write(message);
        return Console.ReadLine() ?? "";
    }


    static bool TieneDivisor(int n)
    {
        int numero = n > 1 ? n : ValorAbsoluto(n);

        for (int i = 2; i <= Math.Sqrt(numero); i++)
            if (n % i == 0)
                return true;
        return false;
    }

    public static int ValorAbsoluto(int numero) => (numero < 0) ? numero * -1 : numero;
    public static bool EsPar(int n) => n % 2 == 0;
    public static bool EsPrimo(int n) => !TieneDivisor(n);
    public static int Maximo(int a, int b) => a > b ? a : b;
    public static int Minimo(int a, int b) => a > b ? b : a;

    public static void MuestraMenu()
    {

    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Ejercicio 5. Funciones con cuerpo de expresión");

        //TODO: Implementa el código necesario

        Console.WriteLine("\nPresiona cualquier tecla para salir...");
        Console.ReadKey();
    }
}