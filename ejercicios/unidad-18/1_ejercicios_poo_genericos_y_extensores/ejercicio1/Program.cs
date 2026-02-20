using System;
using System.Collections.Generic;
using System.Globalization;

//TODO: Incluye el código necesario para implementar las entidades que se piden en el ejercicio

public class Program
{
	public static void GestionContenedor()
	{
		//TODO: Incluye el código necesario para implementar las entidades que se piden en el ejercicio

		Console.WriteLine("Creando contenedor de temperaturas (double)...");
		var c1 = new ContenedorLecturas<double>();
		// añadimos lecturas y mostramos cada una
		Console.WriteLine($"Agregando: {21.5.ToString(CultureInfo.InvariantCulture)}");
		c1.Agrega(21.5);
		Console.WriteLine($"Agregando: {22.1.ToString(CultureInfo.InvariantCulture)}");
		c1.Agrega(22.1);
		Console.WriteLine($"Agregando: {20.9.ToString(CultureInfo.InvariantCulture)}");
		c1.Agrega(20.9);
		Console.WriteLine(c1.ToString());
		Console.WriteLine($"Última: {c1.Ultima.ToString(CultureInfo.InvariantCulture)}");

		Console.WriteLine("Creando segundo contenedor de temperaturas (double)...");
		var c2 = new ContenedorLecturas<double>();
		c2.Agrega(23);
		c2.Agrega(24.5);
		c2.Agrega(22.1);
		c2.Agrega(22.8);
		Console.WriteLine(c2.ToString());

		Console.WriteLine("Agregando rango del segundo contenedor al primero...");
		c1.AgregaRango(c2);
		Console.WriteLine(c1.ToString());

		Console.WriteLine("Limpiando...");
		c1.Limpia();
		Console.WriteLine(c1.ToString());
		Console.WriteLine();

		Console.WriteLine("Creando contenedor de códigos (string)...");
		var c3 = new ContenedorLecturas<string>();
		try
		{
			_ = c3.Ultima;
		}
		catch (ContenedorException ex)
		{
			Console.WriteLine($"Error: {ex.Message}");
		}
		Console.WriteLine("Agregando: A1");
		c3.Agrega("A1");
		Console.WriteLine("Agregando: B2");
		c3.Agrega("B2");
		Console.WriteLine("Agregando: C3");
		c3.Agrega("C3");
		Console.WriteLine(c3.ToString());
	}
	private static void Main(string[] args)
	{
		Console.WriteLine("Ejercicio 1: Contenedor genérico de lecturas\n");

		GestionContenedor();

		Console.WriteLine("Pulsa una tecla para continuar...");
		Console.ReadKey();
	}
}


