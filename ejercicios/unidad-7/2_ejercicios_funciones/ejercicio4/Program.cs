using System;

public class Program
{

    static string InputUser(string message)
    {
        Console.Write(message);
        return Console.ReadLine() ?? "";
    }

    static int ValorAbsoluto(int numero) => (numero < 0) ? numero * -1 : numero;

    public static string PasaABinario(int numeroDecimal) => Conversor(numeroDecimal, 2);

    public static string PasaAOctal(int numeroDecimal) => Conversor(numeroDecimal, 8);

    public static string PasaAHexadecimal(int numeroDecimal) => Conversor(numeroDecimal, 16);

    public static string Conversor(int numero, int basesita)
    {
        int absoluto = ValorAbsoluto(numero);
        string salida = numero == 0 ? "0" : "";

        while (absoluto > 0)
        {
            int resto = absoluto % basesita;

            salida = resto switch
            {
                10 => "A",
                11 => "B",
                12 => "C",
                13 => "D",
                14 => "E",
                15 => "F",
                > 15 => "?",
                _ => $"{resto}"
            } + salida;

            absoluto /= basesita;
        }

        return numero < 0 ? $"-{salida}" : salida;
    }

    public static int MostrarMenu()
    {
        int option;
        bool validOption;

        do
        {
            validOption = int.TryParse(InputUser("=== CONVERSOR DE BASES ===\n1. Convertir a binario (base 2)\n2. Convertir a octal (base 8)\n3. Convertir a hexadecimal (base 16)\n4. Salir\nSelecciona una opción (1-4): "), out option);

            if (option > 4 || option < 1) Console.WriteLine("Opción no válida. Por favor, selecciona una opción del 1 al 4.\n");
        } while (!validOption || option < 1 || option != 4);

        return option;
    }





    public static void Main(string[] args)
    {
        Console.WriteLine("Ejercicio 4. Proyecto conversores");

        //TODO: Implementa el código necesario
        int numeroDecimal = int.Parse(InputUser("Introduce un número decimal: "));

        int option = MostrarMenu();

        string resultado;

        switch (option)
        {
            case 1:
                resultado = PasaABinario(numeroDecimal);
                Console.WriteLine("{0} en binario es: {1}", numeroDecimal, resultado);
                break;
            case 2:
                resultado = PasaAOctal(numeroDecimal);
                Console.WriteLine("{0} en octal es: {1}", numeroDecimal, resultado);
                break;
            case 3:
                resultado = PasaAHexadecimal(numeroDecimal);
                Console.WriteLine("{0} en hexadecimal es: {1}", numeroDecimal, resultado);
                break;
        }

        Console.WriteLine("Presiona cualquier tecla para salir...");
        Console.ReadKey();
    }
}