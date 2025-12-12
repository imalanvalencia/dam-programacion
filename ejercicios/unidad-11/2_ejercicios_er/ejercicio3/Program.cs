using System;
using System.Text;
using System.Text.RegularExpressions;

public class Program
{

    public static string patronLog = @"^\[(?<fecha_hora>\d{4}-\d{2}-\d{2} \d{2}:\d{2}:\d{2})\]\s+(?<tipo>[A-Z]+):\s+(?<mensaje>.+)$";

    public static void AnalizaLogs(string textoLogs)
    {
        MatchCollection matches = Regex.Matches(textoLogs, patronLog, RegexOptions.Multiline);


        if (matches.Count == 0)
        {
            Console.WriteLine("No se encontraron logs válidos.");
            return;
        }

        Console.WriteLine("Errores encontrados:");
        StringBuilder tiposEventos = new();
        string primerMensaje = matches.First().Groups["mensaje"].Value;
        string ultimoMensaje = matches.Last().Groups["mensaje"].Value;

        foreach (Match match in matches)
        {
            string tipo = match.Groups["tipo"].Value;

            // tiposEventos.Add(tipo); -- si tiposEventos fuera un HashSet
            if (!Regex.IsMatch(tiposEventos.ToString(), $@"\b{tipo}\b"))
                tiposEventos.Append(tipo + ", ");

            if (tipo == "ERROR")
            {
                Console.WriteLine("- " + match.Groups["mensaje"].Value);
            }
        }

        if (tiposEventos.Length >= 3)
            tiposEventos.Remove(tiposEventos.Length - 2, 2);

        Console.WriteLine("Tipos de eventos únicos: " + tiposEventos);
        Console.WriteLine("Primer mensaje: " + primerMensaje);
        Console.WriteLine("Último mensaje: " + ultimoMensaje);
    }

    static void Main()
    {
        string textoLogs =
@"[2025-07-28 12:34:56] INFO: Inicio
[2025-07-28 12:35:00] ERROR: Fallo de conexión
[2025-07-28 12:36:00] WARN: Memoria baja
[2025-07-28 12:37:00] INFO: Fin";

        Console.WriteLine("Ejercicio 3: Análisis de Logs\n");
        Console.WriteLine("Texto de logs:");
        Console.WriteLine(textoLogs);
        Console.WriteLine("\nResultados:");
        AnalizaLogs(textoLogs);
        Console.WriteLine("\nPresiona Enter para salir...");
        Console.ReadLine();
    }
}