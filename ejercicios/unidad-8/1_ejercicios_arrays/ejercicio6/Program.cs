using System;

public class Program
{
    // TODO: Implementa la lógica del resto de métodos
    public static double[] LeeCalificaciones()
    {
        Console.Write("¿Cuántos alumnos hay en la clase?");
        double[] calificaciones = new double[int.Parse(Console.ReadLine() ?? "0")];

        Console.Write("Introduce las calificaciones:");
        for (int i = 0; i < calificaciones.Length; i++)
        {
            Console.WriteLine("Alumno {0}:", i + 1);
            calificaciones[i] = double.Parse(Console.ReadLine() ?? "");
        }

        return calificaciones;
    }

    public static double CalculaPromedio(double[] calificaciones)
    {
        double suma = 0;
        foreach (double nota in calificaciones)
        {
            suma += nota;
        }
        return suma / calificaciones.Length;
    }

    public static double ObtieneMaxima(double[] calificaciones)
    {
        double max = calificaciones[0];
        foreach (double nota in calificaciones)
        {
            if (nota > max)
                max = nota;
        }
        return max;
    }

    public static double ObtieneMinima(double[] calificaciones)
    {
        double min = calificaciones[0];
        foreach (double nota in calificaciones)
        {
            if (nota < min)
                min = nota;
        }
        return min;
    }

    // Cuenta cuántos alumnos aprobaron
    public static int CuentaAprobados(double[] calificaciones)
    {
        int aprobados = 0;
        foreach (double nota in calificaciones)
        {
            if (nota >= 5.0)
                aprobados++;
        }
        return aprobados;
    }

    public static void MuestraEstadisticas(double[] calificaciones)
    {
        Console.WriteLine("\n--- ESTADÍSTICAS DE LA CLASE ---");

        Console.Write("Calificaciones: ");
        for (int i = 0; i < calificaciones.Length; i++)
        {
            Console.Write($"{calificaciones[i]:0.00}");
            if (i < calificaciones.Length - 1)
                Console.Write(" - ");
        }

        double promedio = CalculaPromedio(calificaciones);
        double maxima = ObtieneMaxima(calificaciones);
        double minima = ObtieneMinima(calificaciones);
        int aprobados = CuentaAprobados(calificaciones);
        int suspensos = calificaciones.Length - aprobados;

        Console.WriteLine($"\nPromedio de la clase: {promedio:0.00}\nCalificación más alta: {maxima:0.00}\nCalificación más baja: {minima:0.00}\nNúmero de aprobados: {aprobados}\nNúmero de suspensos: {suspensos}");

    }


    public static void Main(string[] args)
    {
        Console.WriteLine("Ejercicio 6: Gestor de calificaciones\n");

        // TODO: Implementa la lógica de este método
        double[] calificaciones = LeeCalificaciones();
        MuestraEstadisticas(calificaciones);

        Console.WriteLine("\nPresiona cualquier tecla para salir...");
        Console.ReadKey();
    }
}
