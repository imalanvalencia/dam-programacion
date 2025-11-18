using System.Text.RegularExpressions;

public class Program
{
    public static List<string> IntroduceNombresModulos(int cantidad)
    {
        var nombres = new List<string>();

        for (int i = 1; i <= cantidad; i++)
        {
            Console.Write($"Introduce el nombre {i}: ");
            string entrada = Console.ReadLine()!;

            while (string.IsNullOrWhiteSpace(entrada))
            {
                Console.WriteLine("El nombre no puede estar vacío. Intenta de nuevo:");
                entrada = Console.ReadLine()!;
            }
           
            nombres.Add(entrada.Trim());
        }
        return nombres;
    }

    public static List<int> IntroduceNotas(int cantidad)
    {
        var notas = new List<int>();

        for (int i = 1; i <= cantidad; i++)
        {
            Console.Write($"Introduce la nota {i}: ");
            string entrada = Console.ReadLine()!;

            while (string.IsNullOrWhiteSpace(entrada) || !Regex.IsMatch(entrada, @"\d+"))
            {
                Console.WriteLine("La nota debe de ser un número válido. Intenta de nuevo:");
                entrada = Console.ReadLine()!;
            }
            int nota = int.Parse(entrada);
            if (nota < 0 || nota > 10)
            {
                Console.WriteLine("La nota debe estar entre 0 y 10. Intenta de nuevo:");
                i--;
            }
            else notas.Add(int.Parse(entrada));
        }

        return notas;
    }

    public static bool CompruebaEdad(int edad)
    {
        return edad >= 18 && edad <= 99;
    }

    public static bool ModuloAprobado(List<int> notas)
    {
        if (notas.Count < 3) return false;
        double promedio = notas.Average();
        return promedio >= 6;
    }

    public static string MensajeBienvenida()
    {
        return "Bienvenidos a la programación, futuros programadores!";
    }

    public static void Main()
    {
        Console.WriteLine(MensajeBienvenida());
        Console.WriteLine("Ingrese su edad:");
        int edad = int.Parse(Console.ReadLine()!);
        if (CompruebaEdad(edad))
        {
            Console.WriteLine("Edad válida.");
        }
        else
        {
            Console.WriteLine("Edad no válida.");
        }
        Console.WriteLine("Ingrese la cantidad de modulos a cursar:");
        int cantidadModulos = int.Parse(Console.ReadLine()!);
        var nombres = IntroduceNombresModulos(cantidadModulos);
        foreach (var nombre in nombres)
        {
            Console.WriteLine($"Ingrese la cantidad de pruebas para el módulo {nombre}:");
            int cantidadNotas = int.Parse(Console.ReadLine()!);
            Console.WriteLine($"Ingrese las notas de las {cantidadNotas} pruebas para {nombre} (0-10):");
            var notas = IntroduceNotas(cantidadNotas);
            if (ModuloAprobado(notas))
            {
                Console.WriteLine("Módulo aprobado.");
            }
            else
            {
                if(notas.Count < 3)
                {
                    Console.WriteLine("Módulo no aprobado: menos de 3 notas.");
                }
                else
                {
                    Console.WriteLine("Módulo no aprobado: promedio menor a 6.");
                }
            }
        }
        Console.ReadLine();
    }
}