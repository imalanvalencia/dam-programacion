
using System;

//TODO: Implementa las clases necesarias y la relación entre ellas para resolver el ejercicio
public record class Coordenada
{

	public double Latitud { get; }
	public double Longitud { get; }
	public int Altitud { get; }

	public Coordenada(double latitud, double longitud, int altitud)
	{
		Latitud = latitud switch
		{
			> 90 => 90,
			< -90 => -90,
			_ => latitud
		};


		Longitud = longitud switch
		{
			> 180 => 180,
			< -180 => -180,
			_ => longitud
		};
	
		Altitud = (altitud >= 0) ? altitud : 0;
	}

	private double ToRadians(double angle) => angle * Math.PI / 180;

	public double DistanciaA(Coordenada otra)
	{
		// Formula de Haversine - Haversine formula
		const double RADIO_TIERRA = 6371;



		double difLat = ToRadians(otra.Latitud - Latitud);
		double difLong = ToRadians(otra.Longitud - Longitud);

		double cuadradoSemiCuerda = Math.Pow(Math.Sin(difLat / 2), 2) +
				   Math.Cos(ToRadians(Latitud)) * Math.Cos(ToRadians(otra.Latitud)) *
				   Math.Pow(Math.Sin(difLong / 2), 2);

		double anguloCentral = 2 * Math.Atan2(Math.Sqrt(cuadradoSemiCuerda), Math.Sqrt(1 - cuadradoSemiCuerda));

		return RADIO_TIERRA * anguloCentral;
	}

	public bool EsHemisferioNorte => Latitud >= 0;
	public bool EsHemisferioEste => Longitud >= 0;

	public Coordenada MueveNorte(double grados) => new(Latitud + grados, Longitud, Altitud);
	public Coordenada MueveEste(double grados) => new(Latitud, Longitud + grados, Altitud);
}

public record class PuntoInteres(string Nombre, Coordenada Ubicacion);

public class RutaTuristica
{
	private Guid Id { get; }
	private List<PuntoInteres> puntos;
	public string Nombre { get; }
	// public string Descripcion { get; }


	public RutaTuristica(string nombre)
	{
		Id = Guid.NewGuid();
		Nombre = nombre;
		puntos = new();
	}

	public void AgregaPunto(PuntoInteres punto) => puntos.Add(punto);


	public double CalculaDistanciaTotal()
	{
		double distanciaTotal = 0.0;

		for (int i = 0; i < puntos.Count - 1; i++)
		{
			distanciaTotal += puntos[i].Ubicacion.DistanciaA(puntos[i + 1].Ubicacion);
		}

		return distanciaTotal;
	}

	public double CalculaAltitudPromedio()
	{
		if (puntos.Count == 0) return 0.0;

		int sumaAltitudes = 0;

		foreach (PuntoInteres punto in puntos) sumaAltitudes += punto.Ubicacion.Altitud;


		return (double)sumaAltitudes / puntos.Count;
	}

	public void MueveNorteRuta(double grados)
	{
		for (int i = 0; i < puntos.Count; i++)
		{
			Coordenada nuevaUbicacion = puntos[i].Ubicacion.MueveNorte(grados);
			puntos[i] = new(puntos[i].Nombre, nuevaUbicacion);
		}
	}


	public bool RutaMasAlEste()
	{
		int contadorEste = 0;
		int contadorOeste = 0;

		foreach (var punto in puntos)
		{
			if (punto.Ubicacion.EsHemisferioEste) contadorEste++;
			else contadorOeste++;
		}

		return contadorEste > contadorOeste;
	}

	public void MuestraRuta()
	{
		Console.WriteLine($"""
		Ruta Turística: {Nombre}
		Puntos de Interés:
		""");

		for (int i = 0; i < puntos.Count; i++)
		{
			Console.WriteLine($"""
			Punto {i + 1}: {puntos[i].Nombre} 
			Cordenadas: {puntos[i].Ubicacion.Latitud} º N, {puntos[i].Ubicacion.Longitud} º E
			Altitud: {puntos[i].Ubicacion.Altitud} metros
			""");
		}

		Console.WriteLine($"Distancia Total: {CalculaDistanciaTotal():F2} km");
		Console.WriteLine($"Altitud Promedio: {CalculaAltitudPromedio():F2} m");
	}
}



public class Program
{

	public static void GestionRutas()
	{
		Console.WriteLine("Creando puntos de interés...");
		PuntoInteres torreEiffel = new("Torre Eiffel", new Coordenada(48.8584, 2.2945, 300));
		PuntoInteres sagradaFamilia = new("Sagrada Familia", new Coordenada(41.4036, 2.1744, 170));
		PuntoInteres bigBen = new("Big Ben", new Coordenada(51.4994, -0.1245, 96));

		Console.WriteLine("\nCalculando distancias entre puntos...");
		Console.WriteLine($"Distancia entre Torre Eiffel y Sagrada Familia: {torreEiffel.Ubicacion.DistanciaA(sagradaFamilia.Ubicacion):F2} km");
		Console.WriteLine($"Distancia entre Torre Eiffel y Big Ben: {torreEiffel.Ubicacion.DistanciaA(bigBen.Ubicacion):F2} km");
		Console.WriteLine($"Distancia entre Sagrada Familia y Big Ben: {sagradaFamilia.Ubicacion.DistanciaA(bigBen.Ubicacion):F2} km");

		Console.WriteLine("\n--- Verificación de hemisferios ---");
		Console.WriteLine($"Torre Eiffel: Hemisferio Norte ({torreEiffel.Ubicacion.EsHemisferioNorte}), Hemisferio Este ({torreEiffel.Ubicacion.EsHemisferioEste})");
		Console.WriteLine($"Sagrada Familia: Hemisferio Norte ({sagradaFamilia.Ubicacion.EsHemisferioNorte}), Hemisferio Este ({sagradaFamilia.Ubicacion.EsHemisferioEste})");
		Console.WriteLine($"Big Ben: Hemisferio Norte ({bigBen.Ubicacion.EsHemisferioNorte}), Hemisferio Este ({bigBen.Ubicacion.EsHemisferioEste})");

		Console.WriteLine("\n--- Movimiento individual de coordenadas ---");
		Coordenada torreEiffelMovida = torreEiffel.Ubicacion.MueveNorte(0.01);
		Console.WriteLine($"Torre Eiffel movida 0.01° al Norte: {torreEiffelMovida.Latitud}° N, {torreEiffelMovida.Longitud}° E, {torreEiffelMovida.Altitud}m");
		Coordenada sagradaFamiliaMovida = sagradaFamilia.Ubicacion.MueveEste(0.05);
		Console.WriteLine($"Sagrada Familia movida 0.05° al Este: {sagradaFamiliaMovida.Latitud}° N, {sagradaFamiliaMovida.Longitud}° E, {sagradaFamiliaMovida.Altitud}m");

		Console.WriteLine("\nCreando ruta Europa Occidental...");
		RutaTuristica rutaEuropa = new("Europa Occidental");
		Console.WriteLine("Agregando Torre Eiffel a la ruta...");
		rutaEuropa.AgregaPunto(torreEiffel);
		Console.WriteLine("Agregando Sagrada Familia a la ruta...");
		rutaEuropa.AgregaPunto(sagradaFamilia);
		Console.WriteLine("Agregando Big Ben a la ruta...");
		rutaEuropa.AgregaPunto(bigBen);

		Console.WriteLine("\n--- Estado inicial de la ruta ---");
		rutaEuropa.MuestraRuta();

		Console.WriteLine("\n--- Cálculos generales ---");
		Console.WriteLine($"Distancia total de la ruta: {rutaEuropa.CalculaDistanciaTotal():F2} km");
		Console.WriteLine($"Altitud promedio de la ruta: {rutaEuropa.CalculaAltitudPromedio():F2} metros");
		Console.WriteLine($"¿La ruta tiene más puntos al Este? {rutaEuropa.RutaMasAlEste()}");

		Console.WriteLine("\n--- Moviendo toda la ruta 0.1° al Norte ---");
		rutaEuropa.MueveNorteRuta(0.1);
		Console.WriteLine("Aplicando movimiento a todos los puntos...");

		Console.WriteLine("\n--- Estado después del movimiento ---");
		rutaEuropa.MuestraRuta();

		Console.WriteLine("\n--- Nuevos cálculos tras el movimiento ---");
		Console.WriteLine($"Nueva distancia total: {rutaEuropa.CalculaDistanciaTotal():F2} km");
		Console.WriteLine($"Nueva altitud promedio: {rutaEuropa.CalculaAltitudPromedio():F2} metros (sin cambios)");
		Console.WriteLine($"¿La ruta modificada sigue teniendo más puntos al Este? {rutaEuropa.RutaMasAlEste()}");

	}

	static void Main(string[] args)
	{
		Console.WriteLine("Ejercicio 3: Sistema de coordenadas con records\n");
		//TODO: Implementar la lógica de gestión de coordenadas
		GestionRutas();
		Console.WriteLine("Presiona cualquier tecla para salir...");
		Console.ReadKey();
	}
}
