using System;
using System.Numerics;

public class Program
{
    // TODO: Implementa la lógica del resto de métodos
    public static int[] LeeNumeros()
    {
        int[] arrNumeros = new int[10];
        Console.WriteLine("Introduce 10 números:");

        for (int i = 0; i < arrNumeros.Length; i++)
        {
            Console.WriteLine("Número {0}:", i + 1);
            arrNumeros[i] = int.Parse(Console.ReadLine() ?? "");
        }

        return arrNumeros;

    }

    public static void DesplazaDerechaCircular(int[] vector)
    {
        int ultimo = vector[^1];

        for (int i = vector.Length - 1; i > 0; i--)
        {
            vector[i] = vector[i - 1];
        }


        vector[0] = ultimo;
    }


    public static int[] DesplazaDerechaCircularConRangos(int[] vector) => [vector[^1], .. vector[..^1]];



    public static void MuestraArray(int[] arr)
    {
        Console.WriteLine($"[{string.Join(", ", arr)}]");
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Ejercicio 5: Desplazamiento circular a la derecha\n");

        // TODO: Implementa la lógica de este método
        int[] arrNumeros = [10, 20, 30, 40, 50, 60, 70, 80, 90, 100];  // LeeNumeros();

        Console.WriteLine($"\nArray original:");
        MuestraArray(arrNumeros);

        DesplazaDerechaCircular(arrNumeros);
        Console.WriteLine($"\nArray después del PRIMER desplazamiento:");
        MuestraArray(arrNumeros);


        Console.WriteLine($"\nArray después del SEGUNDO desplazamiento:");
        MuestraArray(DesplazaDerechaCircularConRangos(arrNumeros));

        Console.WriteLine("\nPresiona cualquier tecla para salir...");
        Console.ReadKey();
    }
}
