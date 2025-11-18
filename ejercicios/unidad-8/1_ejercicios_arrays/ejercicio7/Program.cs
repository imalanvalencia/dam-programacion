using System;

public class Program
{
    // TODO: Implementa la lógica del resto de métodos
    public static double[] LeeTemperaturas()
    {
        double[] temperaturas = new double[7];
        Random rnd = new();

        for (int i = 0; i < temperaturas.Length; i++)
        {

            temperaturas[i] = 4 + rnd.NextDouble() * (35 - 4);
        }
        return temperaturas;
    }
    public static void MuestraTemperaturas(double[] temperaturas)
    {
        string[] diasSemana = ["Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado", "Domingo"];

        Console.WriteLine("Temperaturas de la semana:");
        for (int i = 0; i < temperaturas.Length; i++)
        {
            Console.WriteLine($"{diasSemana[i]}: {temperaturas[i]:0.0}°C");
        }
    }

    public static double CalculaMedia(double[] temperaturas)
    {
        double suma = 0;
        foreach (double temperatura in temperaturas)
            suma += temperatura;
        return suma / temperaturas.Length;
    }

    public static (double temperatura, int dia) BuscaMaximo(double[] temperaturas)
    {
        double max = temperaturas[0];
        int diaMax = 0;

        for (int i = 1; i < temperaturas.Length; i++)
        {
            if (temperaturas[i] > max)
            {
                max = temperaturas[i];
                diaMax = i;
            }
        }
        return (max, diaMax);
    }

    public static (double temperatura, int dia) BuscaMinimo(double[] temperaturas)
    {
        double min = temperaturas[0];
        int diaMin = 0;

        for (int i = 1; i < temperaturas.Length; i++)
        {
            if (temperaturas[i] < min)
            {
                min = temperaturas[i];
                diaMin = i;
            }
        }
        return (min, diaMin);
    }

    public static int CuentaDiasSuperioresA(double[] temperaturas, double umbral)
    {
        int contador = 0;
        foreach (double temperatura in temperaturas)
        {
            if (temperatura > umbral)
                contador++;
        }
        return contador;
    }

    public static double[] TemperaturasAltas(double[] temperaturas)
    {
        int contador = 0;
        foreach (double t in temperaturas)
        {
            if (t > 25)
                contador++;
        }

        double[] altas = new double[contador];
        int index = 0;
        foreach (double temperatura in temperaturas)
        {
            if (temperatura > 25)
            {
                altas[index] = temperatura;
                index++;
            }
        }
        return altas;
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Ejercicio 7: Análisis de temperaturas\n");

        // TODO: Implementa la lógica de este método

        string[] diasSemana = ["Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado", "Domingo"];
        string[] diasCortos = ["L", "M", "X", "J", "V", "S", "D"];

        double[] temperaturas = { 4.0, 35.0, 0.5, 100.7, 15.25, 30.99, 8.1 };


        MuestraTemperaturas(temperaturas);

        Console.WriteLine("\n--- ANÁLISIS SEMANAL ---");

        Console.Write("Temperaturas: ");
        for (int i = 0; i < temperaturas.Length; i++)
        {
            Console.Write($"{diasCortos[i]}:{temperaturas[i]:0.0}");
            if (i < temperaturas.Length - 1)
                Console.Write(" ");
        }

        // Calculos
        double media = CalculaMedia(temperaturas);
        var max = BuscaMaximo(temperaturas);
        var min = BuscaMinimo(temperaturas);
        int diasSuperioresMedia = CuentaDiasSuperioresA(temperaturas, media);
        double[] altas = TemperaturasAltas(temperaturas);

        Console.WriteLine($"\nTemperatura media: {media:0.0}°C");
        Console.WriteLine($"Temperatura máxima: {max.temperatura:0.0}°C ({diasSemana[max.dia]})");
        Console.WriteLine($"Temperatura mínima: {min.temperatura:0.0}°C ({diasSemana[min.dia]})");
        Console.WriteLine($"Días con temperatura superior a la media: {diasSuperioresMedia}");

        Console.WriteLine("\n--- TEMPERATURAS POR ENCIMA DE 25°C ---");
        for (int i = 0; i < altas.Length; i++)
        {
            Console.WriteLine($"{diasSemana[i]}: {temperaturas[i]:0.0}°C");
        }

        Console.WriteLine("\nPresiona cualquier tecla para salir...");
        Console.ReadKey();
    }
}
