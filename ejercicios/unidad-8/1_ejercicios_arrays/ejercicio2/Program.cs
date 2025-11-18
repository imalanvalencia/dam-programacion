using System;

public class Program
{
    // TODO: Implementa la lógica del resto de métodos




    public static char[] GeneraCaracteresAleatorios()
    {

        char[] caracterVector = new char[10];
        Random aleatorio = new();


        for (int e = 0; e < caracterVector.Length; e++)
        {
            int ascii;
            int tipo = aleatorio.Next(2);

            switch (tipo)
            {
                case 0: // Mayúsculas (A–Z)
                    ascii = aleatorio.Next(65, 91);
                    break;

                case 1: // Minúsculas (a–z)
                    ascii = aleatorio.Next(97, 123);
                    break;

                default:
                    ascii = 63; // Valor por defecto ? (No comila si no lo pones)
                    break;
            }

            caracterVector[e] = (char)ascii;
        }


        return caracterVector;
    }

    public static void ConvierteMayusculasMinusculas(char[] vector)
    {
        for (int e = 0; e < vector.Length; e++)
        {
            if (char.IsLower(vector[e]))
                vector[e] = char.ToUpper(vector[e]);
            else
                vector[e] = char.ToLower(vector[e]);
        }
    }

    public static void MuestraArray(char[] vector, string mensaje)
    {

        Console.WriteLine(mensaje);
        foreach (char e in vector)
        {
            Console.Write($"{e} ");
        }

    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Ejercicio 2: Conversión mayúsculas y minúsculas\n");

        // TODO: Implementa la lógica de este método    

        char[] vector = GeneraCaracteresAleatorios();
        MuestraArray(vector, "Array original:");

        ConvierteMayusculasMinusculas(vector);
        MuestraArray(vector, "\nArray modificado:");


        Console.WriteLine("\nPresiona cualquier tecla para salir...");
        Console.ReadKey();
    }
}
