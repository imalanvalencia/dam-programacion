using System.Drawing;
using System.Text;

public class Program
{

    //TODO: Implementa la lógica del resto de métodos
    public static int ColorMasAlto(int[][] arrayPadre)
    {
        int maxColor = arrayPadre[0][0];

        foreach (int[] arrayHijo in arrayPadre)
        {
            foreach (int e in arrayHijo)
            {

                maxColor = e > maxColor ? e : maxColor;
            }
        }

        return maxColor;
    }

    public static int[] CuentaFloresPorColor(int[][] jardin)
    {
        int maxColor = ColorMasAlto(jardin);
        int[] inventario = new int[maxColor];

        foreach (int[] arriate in jardin)
        {
            foreach (int flor in arriate)
            {
                inventario[flor - 1]++;
            }
        }


        return inventario;
    }


    public static void MuestraInventarioColoresFlores(int[] inventario)
    {
        for (int i = 0; i < inventario.Length; i++)
        {
            if (inventario[i] > 0)
            {
                Console.ForegroundColor = (ConsoleColor)(i + 1 % 16);
                Console.WriteLine($"Color {i + 1}: {inventario[i]} flores");
                Console.ResetColor();
            }
        }
    }

    public static (int numArriate, int cantidadColores) ArriateMasDiverso(int[][] jardin)
    {
        int maxColores = 0;
        int indiceArriate = 0;

        for (int i = 0; i < jardin.Length; i++)
        {
            int coloresDistintos = CuentaColores(jardin[i]);
            
            if (coloresDistintos > maxColores)
            {
                maxColores = coloresDistintos;
                indiceArriate = i;
            }
        }

        return (indiceArriate, maxColores);
    }

    public static int CuentaColores(int[] arriate)
    {
        int[] coloresFlores = new int[arriate.Length];
        int cantidad = 0;

        foreach (int color in arriate)
        {


            if (Array.IndexOf(coloresFlores, color, 0, cantidad) == -1)
            {
                coloresFlores[cantidad] = color;
                cantidad++;
            }
        }


        return cantidad;
    }

    public static void Muestra(int[][] array)
    {
        foreach (int[] arriete in array)
        {
            foreach (int flor in arriete)
            {
                Console.BackgroundColor = (ConsoleColor)(flor % 16);

                Console.Write($"{flor,2}");

                Console.ResetColor();
            }

            Console.WriteLine();
        }

        Console.WriteLine();
    }

    public static void Main()
    {
        Console.WriteLine("Ejercicio 4: Jardín de flores con inventario colorido\n");
        //TODO: Implementa la lógica necesaria

        int[][] jardin = new int[][]
        {
            new int[] {1, 3, 2, 1},
            new int[] {4, 4, 2},
            new int[] {2, 1, 3, 3, 5},
            new int[] {3, 2}
        };

        Muestra(jardin);

        int[] inventario = CuentaFloresPorColor(jardin);
        MuestraInventarioColoresFlores(inventario);

        var (numArriate, cantidadColores) = ArriateMasDiverso(jardin);
        Console.WriteLine($"\nArriate más diverso: Arriate {numArriate + 1} con {cantidadColores} colores distintos.");


        Console.WriteLine("\nPresiona cualquier tecla para salir...");
        Console.ReadKey();
    }

}
