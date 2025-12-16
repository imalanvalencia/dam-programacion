using System;
using System.Text;

public class Program
{
    //TODO: Implementa la lógica necesaria para solucionar el ejercicio
    public static void DemuestraTipoValor()
    {
        DateTime fecha1 = new(2025, 12, 25, 10, 30, 0);
        DateTime fecha2 = fecha1;

        Console.WriteLine($"""
        --- DateTime (tipo valor) ---
        Fecha original: {fecha1}
        Fecha copiada:  {fecha2}

        ¿Misma referencia?: {ReferenceEquals(fecha1, fecha2)}
        ¿Mismo valor?:      {fecha1 == fecha2}

        """);


        fecha2 = fecha1.AddDays(5);
        Console.WriteLine($"""
        Modificando fecha copiada (añadiendo 5 días)...
        Fecha original: {fecha1}
        Fecha copiada:  {fecha2}

        ¿Misma referencia?: {ReferenceEquals(fecha1, fecha2)}
        ¿Mismo valor?:      {fecha1 == fecha2}

        """);
    }

    public static void DemuestraTipoReferencia()
    {
        StringBuilder sb1 = new("Hola mundo");
        StringBuilder sb2 = sb1;

        Console.WriteLine($"""
        --- StringBuilder (tipo referencia) ---
        Texto original: {sb1}
        Texto copiado:  {sb2}

        ¿Misma referencia?: {ReferenceEquals(sb1, sb2)}
        ¿Mismo valor?:      {sb1 == sb2}

        """);

        sb2.Append(" !!!");

        Console.WriteLine($"""
        Modificando el texto copiado (añadiendo ' !!!')...
        Texto original: {sb1}
        Texto copiado:  {sb2}

        ¿Misma referencia?: {ReferenceEquals(sb1, sb2)}
        ¿Mismo valor?:      {sb1 == sb2}

        """);
    }

    public static void ModificaTipoValor(DateTime fecha) => fecha.AddDays(5);

    public static void ModificaTipoReferencia(StringBuilder texto) => texto.Append(" mundo");


    public static void Main(string[] args)
    {
        Console.WriteLine("Ejercicio 1: Comparación entre tipos valor y tipos referencia\n");

        DemuestraTipoValor();
        Console.WriteLine();
        DemuestraTipoReferencia();
        Console.WriteLine();
        Console.WriteLine("\n--- Tipos valor como parámetros ---");
        DateTime fechaTipoValor = new DateTime(2025, 1, 1, 12, 0, 0);
        Console.WriteLine($"DateTime antes de llamar a método: {fechaTipoValor}");
        ModificaTipoValor(fechaTipoValor);
        Console.WriteLine($"DateTime después de llamar a método: {fechaTipoValor}");
        Console.WriteLine("(El método no puede modificar el original)");

        Console.WriteLine("\n--- Tipos referencia como parámetros ---");
        StringBuilder textoTipoReferencia = new StringBuilder("Inicial");
        Console.WriteLine($"StringBuilder antes de llamar a método: \"{textoTipoReferencia}\"");
        ModificaTipoReferencia(textoTipoReferencia);
        Console.WriteLine($"StringBuilder después de llamar a método: \"{textoTipoReferencia}\"");
        Console.WriteLine("(El método SÍ puede modificar el original)");

        Console.WriteLine("\nPulsa una tecla para acabar...");
        Console.ReadKey();
    }
}
