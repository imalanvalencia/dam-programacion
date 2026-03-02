using System;
using System.Collections.Generic;

public enum Color
{
    Blanco,
    Negro,
    Rojo,
    Azul,
    Gris,
    Verde,
    Amarillo
}

public record Automovil(string Marca, string Modelo, int Cilindrada, int AñoFabricacion, Color Color)
{
    public override string ToString() => $"{Marca} {Modelo} - {Cilindrada}cc - {AñoFabricacion} - {Color}";
}

public class Program
{
    public static void MostrarLista(List<Automovil> lista)
    {
        if (lista == null)
            throw new ArgumentNullException(nameof(lista), "La lista no puede ser null");

        Console.WriteLine($"Lista actual ({lista.Count} automóviles):");
        for (int i = 0; i < lista.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {lista[i]}");
        }
    }

    public static void AñadeAutomovil(List<Automovil> lista, Automovil auto)
    {
        if (lista == null)
            throw new ArgumentNullException(nameof(lista), "La lista no puede ser null");
        
        lista.Add(auto);
    }

    public static void EliminaAutomovil(List<Automovil> lista, int indice)
    {
        if (lista == null)
            throw new ArgumentNullException(nameof(lista), "La lista no puede ser null");

        if (indice < 0 || indice >= lista.Count)
            throw new ArgumentOutOfRangeException(nameof(indice), $"Índice {indice} fuera de rango. Debe estar entre 0 y {lista.Count - 1}");

        Console.WriteLine($"Eliminando automóvil en posición {indice + 1} ({lista[indice]})...");
        lista.RemoveAt(indice);
    }

    public static List<Automovil> AutomovilesPorAñoFabricacion(List<Automovil> lista, int anio)
    {
        if (lista == null)
            throw new ArgumentNullException(nameof(lista), "La lista no puede ser null");

        List<Automovil> resultado = new List<Automovil>();
        
        for (int i = 0; i < lista.Count; i++)
        {
            if (lista[i].AñoFabricacion == anio)
            {
                resultado.Add(lista[i]);
            }
        }

        if (resultado.Count == 0)
            throw new InvalidOperationException($"No se encontraron automóviles del año {anio}");

        return resultado;
    }

   public  static List<Automovil> AutomovilesPorAñoFabricacionYColor(List<Automovil> lista, int anio, Color color)
    {
        if (lista == null)
            throw new ArgumentNullException(nameof(lista), "La lista no puede ser null");

        List<Automovil> resultado = new List<Automovil>();
        
        for (int i = 0; i < lista.Count; i++)
        {
            if (lista[i].AñoFabricacion == anio && lista[i].Color == color)
            {
                resultado.Add(lista[i]);
            }
        }

        if (resultado.Count == 0)
            throw new InvalidOperationException($"No se encontraron automóviles del año {anio} y color {color}");

        return resultado;
    }

    public static void Main()
    {
        List<Automovil> automoviles = new List<Automovil>();

        Console.WriteLine("=== LISTA INICIAL DE AUTOMÓVILES ===");
        Console.WriteLine("Añadiendo automóviles a la lista...");
        
        AñadeAutomovil(automoviles, new Automovil("Toyota", "Corolla", 1600, 2020, Color.Blanco));
        AñadeAutomovil(automoviles, new Automovil("Honda", "Civic", 1800, 2019, Color.Negro));
        AñadeAutomovil(automoviles, new Automovil("Ford", "Focus", 2000, 2020, Color.Rojo));
        AñadeAutomovil(automoviles, new Automovil("Nissan", "Sentra", 1600, 2018, Color.Azul));
        AñadeAutomovil(automoviles, new Automovil("Volkswagen", "Golf", 1400, 2020, Color.Blanco));

        MostrarLista(automoviles);
        Console.WriteLine();

        Console.WriteLine("=== BÚSQUEDA POR AÑO DE FABRICACIÓN ===");
        Console.WriteLine("Automóviles del año 2020:");
        try
        {
            List<Automovil> autos2020 = AutomovilesPorAñoFabricacion(automoviles, 2020);
            foreach (var auto in autos2020)
            {
                Console.WriteLine($"- {auto}");
            }
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message);
        }
        Console.WriteLine();

        Console.WriteLine("=== BÚSQUEDA POR AÑO Y COLOR ===");
        Console.WriteLine("Automóviles del año 2020 y color Blanco:");
        try
        {
            List<Automovil> autos2020Blanco = AutomovilesPorAñoFabricacionYColor(automoviles, 2020, Color.Blanco);
            foreach (var auto in autos2020Blanco)
            {
                Console.WriteLine($"- {auto}");
            }
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message);
        }
        Console.WriteLine();

        Console.WriteLine("=== ELIMINACIÓN DE AUTOMÓVIL ===");
        try
        {
            EliminaAutomovil(automoviles, 1);
            Console.WriteLine($"Lista actualizada ({automoviles.Count} automóviles):");
            MostrarLista(automoviles);
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        Console.WriteLine();

        Console.WriteLine("=== AÑADIR NUEVO AUTOMÓVIL ===");
        Console.WriteLine("Añadiendo: BMW Serie 3 - 2000cc - 2021 - Gris");
        AñadeAutomovil(automoviles, new Automovil("BMW", "Serie 3", 2000, 2021, Color.Gris));
        Console.WriteLine($"Lista final ({automoviles.Count} automóviles):");
        MostrarLista(automoviles);
    }
}
