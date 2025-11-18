using System;

public class Program
{
    // TODO: Implementa la lógica del resto de métodos
    public static char[] LeeNumero()
    {

        Console.Write("Introduce un número: ");
        return Console.ReadLine()?.ToCharArray() ?? [];
    }

    static char[] RevierteArray(char[] vector)
    {
        char[] invertido = new char [vector.Length]; // OPTIMIZE: Optimizando el codigo

        for (int i = 0; i < vector.Length; i++)
        {
            // invertido[i] = vector[vector.Length - 1 - i]; - Forma antigua
            invertido[i] = vector[^(i+1)]; // Froma nueva
        }

        return invertido;
    }

    public static bool EsCapicua(char[] vector)
    {
        char[] reverseChars = RevierteArray(vector);
        bool sonIguales = false;

        for (int i = 0; i < vector.Length; i++)
        {
            sonIguales = vector[i] == reverseChars[i];
        }


        return sonIguales;
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Ejercicio 4: Verificador de números capicúa\n");

        // TODO: Implementa la lógica de este método
        char[] splitNumber = LeeNumero();

        if (EsCapicua(splitNumber))
        {
            Console.WriteLine($"El número {string.Join("", splitNumber)} es capicúa.");
        }
        else
        {
            Console.WriteLine($"El número {string.Join("", splitNumber)} no es capicúa");
        }

        Console.WriteLine("\nPresiona cualquier tecla para salir...");
        Console.ReadKey();
    }
}
