using System;

public class Program
{
    // TODO: Implementa la lógica del resto de métodos
    public static int[] GeneraArrayAleatorio()
    {

        int[] enterosVector = new int[10];
        Random aleatorio = new();


        for (int e = 0; e < enterosVector.Length; e++)
        {
            enterosVector[e] = aleatorio.Next(101);
        }


        return enterosVector;
    }

    public static int EncuentraMayor(int[] vector)
    {
        int mayor = 0;
        foreach (int e in vector)
        {
            mayor = e > mayor ? e : mayor;
        }

        return mayor;
    }

    public static int EncuentraPosicionMayor(int[] vector)
    {
        int mayor = EncuentraMayor(vector);


        return Array.IndexOf(vector, mayor);
    }

    public static void MuestraArray(int[] vector)
    {
        Console.WriteLine($"Array: [{string.Join(", ", vector)}]");
    }


    public static void Main(string[] args)
    {
        Console.WriteLine("Ejercicio 3: Elemento mayor y su posición\n");

        // TODO: Implementa la lógica de este método

        int[] numerosVector = GeneraArrayAleatorio();
        int mayor = EncuentraMayor(numerosVector);
        int posiciónMayor = EncuentraPosicionMayor(numerosVector);

        MuestraArray(numerosVector);

        Console.WriteLine("El elemento mayor es: {0}\nPosición del elemento mayor: {1}\n", mayor, posiciónMayor);

        Console.WriteLine("\nPresiona cualquier tecla para salir...");
        Console.ReadKey();
    }
}
