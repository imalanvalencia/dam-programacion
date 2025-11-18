public class Program
{
    //TODO: Implementa la lógica del resto de métodos

    public static int[][] LeeArray()
    {
        int[][] InputArray = [
            new int[5],
            new int[5],
            new int[5],
        ];

        Console.WriteLine("Introduce los elementos del array 3x5:");

        for (int fila = 0; fila < InputArray.Length; fila++)
        {
            for (int columna = 0; columna < InputArray[fila].Length; columna++)
            {
                Console.Write("Fila {0}, Columna {1}:", fila, columna);
                InputArray[fila][columna] = int.Parse(Console.ReadLine() ?? "0");
            }
        }

        return InputArray;
    }

    public static int[][] CreaTranspuesta(int[][] array)
    {
        int filas = array.Length;
        int columnas = array[0].Length;

        int[][] arrayTranspuestos = new int[columnas][];

        // Primero asigno los espacios en memoria (No se puede hacer todo junto)
        for (int i = 0; i < columnas; i++)
            arrayTranspuestos[i] = new int[filas];


        for (int fila = 0; fila < filas; fila++)
        {
            for (int columna = 0; columna < columnas; columna++)
            {
                arrayTranspuestos[columna][fila] = array[fila][columna];
            }
        }

        return arrayTranspuestos;
    }

    public static void MuestraArray(int[][] array, string text)
    {
        Console.WriteLine(text);

        foreach (int[] fila in array)
        {
            foreach (int columna in fila)
            {

                Console.Write($"{columna,3}");
            }

            Console.WriteLine();
        }
    }


    private static void Main(string[] args)
    {
        Console.WriteLine("Ejercicio 3: Transposición de arrays\n");

        int[][] array = [[-1, 2, 1, 4, 7], [-3, 3, 5, 8, 9], [6, 0, -2, 1, 3],]; // LeeArray();

        MuestraArray(array, "Array original (3x5):");

        int[][] arrayTranspuesto = CreaTranspuesta(array);
        MuestraArray(arrayTranspuesto, "Array transpuesto (5x3):");

        //TODO: Implementa la lógica necesaria
        Console.WriteLine("\nPresiona cualquier tecla para salir...");
        Console.ReadKey();
    }
}
