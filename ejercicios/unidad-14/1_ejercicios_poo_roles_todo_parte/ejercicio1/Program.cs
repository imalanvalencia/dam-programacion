
using System;

//TODO: Implementa las clases necesarias y la relación entre ellas para resolver el ejercicio
public class Motor
{
	public int Potencia { get; set; }
	public bool Encendido { get; set; }

	public Motor(int potencia)
	{
		Potencia = potencia;
		Encendido = false;
	}

	public void Encender()
	{
		Encendido = true;
		Console.WriteLine("Motor encendido.");
	}


	public void Apagar()
	{
		Encendido = false;
		Console.WriteLine("Motor apagado.");
	}

	public bool EstaEncendido() => Encendido;

}



public class Program
{
	public static void GestionVehiculo()
	{
		Console.WriteLine("Ejercicio 1: Composición Vehículo-Motor\n");
		//TODO: Implementar la lógica de gestión de vehículos y motores

		Console.WriteLine("\nPresiona cualquier tecla para salir...");
		Console.ReadKey();
	}

	static void Main(string[] args)
	{
		GestionVehiculo();
	}
}
