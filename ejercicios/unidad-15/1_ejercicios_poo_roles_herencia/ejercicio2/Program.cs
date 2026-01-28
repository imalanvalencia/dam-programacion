
using System;
using System.Collections.Generic;

public record Dimension(float Ancho, float Largo);

public class Local
{
	public string Ciudad { get; }
	public string Calle { get; }
	public string NumeroPlantas { get; }
	public Dimension Dimensiones { get; }

	public Local(string ciudad, string calle, string numeroPlantas, float ancho, float largo)
	{
		Ciudad = ciudad;
		Calle = calle;
		NumeroPlantas = numeroPlantas;
		Dimensiones = new(ancho, largo);
	}

	public virtual string ACadena() => $"""
	Local:
	Ciudad: {Ciudad}
	Calle: {Calle}	
	Número de plantas: {NumeroPlantas}
	Dimensiones: {Dimensiones.Ancho * Dimensiones.Largo} m²
	""";
}

public class LocalComercial : Local
{
	public string RazonSocial { get; }
	public string NumeroLicencia { get; }

	public LocalComercial
	(string ciudad, string calle, string numeroPlantas, float ancho, float largo, string razonSocial, string numeroLiciencia)
	: base(ciudad, calle, numeroPlantas, ancho, largo)
	{
		RazonSocial = razonSocial;
		NumeroLicencia = numeroLiciencia;
	}

	public override string ACadena() => $"""
	{base.ACadena()}

	Local Comercial:
	Razón Social: {RazonSocial}
	Número de Licencia: {NumeroLicencia}
	""";
}

public class Cine : LocalComercial
{
	public int AforoSala { get; }

	public Cine
	(string ciudad, string calle, string numeroPlantas, float ancho, float largo, string razonSocial, string numeroLiciencia, int aforoSala)
	: base(ciudad, calle, numeroPlantas, ancho, largo, razonSocial, numeroLiciencia)
	{
		AforoSala = aforoSala;
	}

	public override string ACadena() => $"""
	{base.ACadena()}
	
	Cine:
	Aforo de la sala: {AforoSala} personas
	""";
}

namespace Ejercicio2
{
	//TODO: Crea las clases necesarias para implementar el código que se pide en los ejercicios
	public class Program
	{
		//TODO: Implementa el método GestionCines
        static Cine cinesa = new Cine("Alicante", "Calle Falsa", "2", 10, 20, "Cinesa", "123", 200);
        static Cine yelmoCines = new Cine("Alicante", "Calle Falsa", "2", 10, 20, "Yelmo cines", "123", 350);
        static Cine plazaAyuntamiento = new Cine("Alicante", "Calle Falsa", "2", 10, 20, "Plaza de ayuntamiento", "123", 450);


		public static void GestionCines()
		{
			Console.WriteLine("=== Creando y mostrando cines ===");
			Console.WriteLine(cinesa.ACadena());
			Console.WriteLine(yelmoCines.ACadena());
			Console.WriteLine(plazaAyuntamiento.ACadena());
		}

		static void Main(string[] args)
		{
			GestionCines();
			Console.WriteLine("\nPresiona cualquier tecla para salir...");
			Console.ReadKey();
		}

	}
}

