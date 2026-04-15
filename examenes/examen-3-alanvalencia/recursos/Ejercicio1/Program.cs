using System;
using System.Collections.Generic;

internal partial class Program
{
    private static void MuestraEstado(SistemaIncidencias sistema)
    {
        foreach(var sis in sistema)
        {
            Console.WriteLine(sis);
        }
    }

    private static void Main(string[] args)
    {
        Console.WriteLine("=== PRUEBA SistemaIncidencias ===");

        var sistema = new SistemaIncidencias();

        var nodoA = new Nodo("NODO-MADRID", 2);
        var nodoB = new Nodo("NODO-VALENCIA", 3);
        var nodoC = new Nodo("NODO-SEVILLA", 2);

        try
        {
            sistema.RegistraNodo(nodoA);
            sistema.RegistraNodo(nodoB);
            sistema.RegistraNodo(nodoC);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }



        var incidencias = new List<IIncidencia>
        {
            IncidenciaFactory.Crea("CPU_ALTA", "Sensor-A1", 91.2F),
            IncidenciaFactory.Crea("CPU_ALTA", "Router-Norte", 180),
            IncidenciaFactory.Crea("TEMPERATURA_ALTA", "Rack-22", 87.5F),
            IncidenciaFactory.Crea("CPU_ALTA", "Nodo-IoT-77", 97.4F),
            IncidenciaFactory.Crea("CPU_ALTA", "Backbone-Este", 320),
            IncidenciaFactory.Crea("TEMPERATURA_ALTA", "MicroDC-Malaga", 79.0F)
        };

        Console.WriteLine($"Tiempo estimado antes de procesar: {sistema.ObtenTiempoEstimado()} min");

        foreach (var incidencia in incidencias)
        {
            sistema.RecibeIncidencia(incidencia);
        }

        try
        {
            sistema.ProcesaPendientes();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        MuestraEstado(sistema);
        Console.WriteLine($"Tiempo estimado total: {sistema.ObtenTiempoEstimado()} min");

        Console.WriteLine();
        Console.WriteLine("Resolviendo una incidencia...");
        sistema.ResuelveIncidencia(incidencias[0]);

        MuestraEstado(sistema);
        Console.WriteLine($"Tiempo estimado tras resolver 1: {sistema.ObtenTiempoEstimado()} min");

        Console.WriteLine();
        Console.WriteLine("Probando excepción al registrar un nodo repetido...");

        try
        {
            sistema.RegistraNodo(nodoA);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        Console.ReadLine();
    }

}