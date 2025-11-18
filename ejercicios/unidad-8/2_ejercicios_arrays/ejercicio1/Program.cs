public class Program
{
    //TODO: Implementa la lógica del resto de métodos

    public static int[][] CreaArray(int filas, int columnas)
    {
        int[][] arrayPadre = new int[filas][];

        for (int i = 0; i < filas; i++)
        {
            arrayPadre[i] = new int[columnas];
        }


        return arrayPadre;
    }


    public static void RellenaConPatron(int[][] array)
    {
        for (int fila = 0; fila < array.Length; fila++)
        {
            for (int columna = 0; columna < array[fila].Length; columna++)
            {
                array[fila][columna] = fila % 2 == 0 ? 1 : 0;
            }
        }
    }

    public static void MuestraArray(int[][] array)
    {
        Console.WriteLine($"Array {array.Length}x{array[0].Length} generado:");


        for (int fila = 0; fila < array.Length; fila++)
        {
            for (int columna = 0; columna < array[fila].Length; columna++)
            {
                Console.Write(columna);
            }

            Console.WriteLine();
        }

    }

    private static void Main(string[] args)
    {
        Console.WriteLine("Ejercicio 1: Tabla dentada cuadrada con patrón \n");

        //TODO: Implementa la lógica necesaria

        int[][] arrayCreado = CreaArray(10, 10);

        RellenaConPatron(arrayCreado);
        MuestraArray(arrayCreado);

        Console.WriteLine("\nPresiona cualquier tecla para salir...");
        Console.ReadKey();
    }
}