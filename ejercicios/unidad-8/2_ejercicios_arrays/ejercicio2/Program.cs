public class Program
{
    //TODO: Implementa la lógica del resto de métodos
    public static int[][] CreaArrayIdentidad (int tamaño)
    {
        int[][] arrayPadre = new int[tamaño][];

        for (int i = 0; i < tamaño; i++)
        {
            arrayPadre[i] = new int[tamaño];
        }


        return arrayPadre;
    }


    public static void InicializaDiagonal(int[][] array)
    {
        for (int fila = 0; fila < array.Length; fila++)
        {
            for (int columna = 0; columna < array[fila].Length; columna++)
            {
                array[fila][columna] = fila == columna  ? 1 : 0;
            }
        }
    }

    public static void MuestraArrayConForeach(int[][] array)
    {
        Console.WriteLine($"Array identidad  {array.Length}x{array[0].Length}:");
        foreach (int[] fila in array)
        {
            foreach (int columna in fila)
            {
                Console.Write(columna);
            }
            Console.WriteLine();
        }
    }
    private static void Main(string[] args)
    {
        Console.WriteLine("Ejercicio 2: Diagonal en tabla de tablas\n");
        //TODO: Implementa la lógica necesaria
        int[][] arrayCreado = CreaArrayIdentidad(5);

        InicializaDiagonal(arrayCreado);
        MuestraArrayConForeach(arrayCreado);
        
        Console.WriteLine("\nPresiona cualquier tecla para salir...");
        Console.ReadKey();
    }
}
