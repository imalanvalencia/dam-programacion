using System;

public class Program
{

    static string InputUser(string message)
    {
        Console.Write(message);
        return Console.ReadLine() ?? "";
    }

    public static (int numeroDepartamento, float costePorHora, float horasTrabajadas) Lee()
    {

        int numeroDepartamento = int.Parse(InputUser("Número de departamento: "));
        float costePorHora = float.Parse(InputUser("Coste por hora: ")), horasTrabajadas = float.Parse(InputUser("Coste por hora: "));

        return (numeroDepartamento, costePorHora, horasTrabajadas);

    }

    public static float Salario(float costePorHora, float horasTrabajadas)
    {
        return costePorHora * horasTrabajadas;
    }

    public static void Muestra(float salario, int numeroDepartamento, float costePorHora, float horasTrabajadas)
    {
        Console.WriteLine("--- INFORMACIÓN DEL EMPLEADO ---");
        Console.WriteLine("Número de departamento: {0}", numeroDepartamento);
        Console.WriteLine("Coste por hora: {0} ?", costePorHora);
        Console.WriteLine("Horas trabajadas: {0}", horasTrabajadas);
        Console.WriteLine("Salario semanal: {0} ?", salario);
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Ejercicio 1: Calculadora de Salario");

        //TODO: Implementa el código necesaro

        var data = Lee();

        float salarioSemanal = Salario(data.costePorHora, data.horasTrabajadas);

        Muestra(salarioSemanal, data.numeroDepartamento, data.costePorHora, data.horasTrabajadas);



        Console.WriteLine("\nPresiona cualquier tecla para salir...");
        Console.ReadKey();
    }
}