using System;
using System.Collections.Generic;

//TODO: Añade el código necesario para implementar los requisitos del ejercicio

public class Program
{
    public static void Main(string[] args)
    {
        GestionarEntrenamiento();
        Console.ReadKey();
    }

    public static void GestionarEntrenamiento()
    {
        Console.WriteLine("Ejercicio 4: Interfaces y entrenamiento\n\nCreando sesiones...\n");
        var s1 = new Sentadillas(Sentadillas.TipoSentadillas.Basica, 6, new DateTime(2025, 9, 10));
        s1.IniciaSesion();
        var s2 = new Sentadillas(Sentadillas.TipoSentadillas.Peso, 8, new DateTime(2025, 9, 10));
        s2.IniciaSesion();
        var r1 = new Running(7.5, 4, new DateTime(2025, 9, 11));
        r1.IniciaSesion();
        var lista = new List<IEntrenamientoDeportivo> { s1, s2, r1 };
        Console.WriteLine("Mostrando Sesiones realizadas...");
        Thread.Sleep(5000); // Simula duración de la sesión
        s1.TerminaSesion();
        s2.TerminaSesion();
        r1.TerminaSesion();
        s1.DuracionMinutos = 20;//Se utiliza para que la simulación sea realista
        s2.DuracionMinutos = 25;
        r1.DuracionMinutos = 45;
        foreach (var e in lista)
        {
            Console.WriteLine(e.ToString());
            Console.WriteLine();
        }
        Console.WriteLine("Comparaciones:");
        int cmp = s2.CompareTo(s1);
        string simbolo = cmp > 0 ? "> (mayor gasto calórico)" : (cmp < 0 ? "< (menor gasto calórico)" : "= (igual gasto calórico)");
        Console.WriteLine("  Sentadillas (Peso) vs Sentadillas (Basica): " + simbolo);
        Console.WriteLine();
        Console.WriteLine("Presiona cualquier tecla para continuar...");
    }
}
