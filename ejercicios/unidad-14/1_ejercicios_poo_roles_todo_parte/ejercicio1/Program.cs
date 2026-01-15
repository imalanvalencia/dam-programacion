
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

	public void Enciende()
	{
		Encendido = true;
		Console.WriteLine("Motor encendido.");
	}


	public void Apaga()
	{
		Encendido = false;
		Console.WriteLine("Motor apagado.");
	}

	public bool EstaEncendido() => Encendido;

	public string ACadena() => $"Motor: {Potencia} CV - Estado: {(Encendido ? "Encendido" : "Apagado")}";
}

public class Vehiculo
{
	public string Marca { get; }
	public string Modelo { get;  }
	private Motor motor;	

	public Vehiculo(string marca, string modelo, int potencia)
	{
		Marca = marca;
		Modelo = modelo;
		motor = new Motor(potencia);
	}

	public void Arranca()
	{
		if (!motor.EstaEncendido())
		{
			motor.Enciende();
		}
	}

	public void Detiene()
	{
		if (motor.EstaEncendido())
		{
			motor.Apaga();
		}
	}

	public string ACadena() => $"Vehículo: {Marca} {Modelo}\nMotor: {motor.ACadena()}";
}



public class Program
{
	public static void GestionVehiculo()
	{
		Console.WriteLine("Ejercicio 1: Composición Vehículo-Motor\n");
        //TODO: Implementar la lógica de gestión de vehículos y motores
        Console.WriteLine("\nCreando un vehículo...");
		Vehiculo miCoche = new Vehiculo("Toyota", "Corolla", 120);
        Console.WriteLine(miCoche.ACadena());

        Console.WriteLine("\nArrancando el vehículo...");
		miCoche.Arranca();
        Console.WriteLine(miCoche.ACadena());

		Console.WriteLine("\nPresiona cualquier tecla para salir...");
		Console.ReadKey();
	}

	static void Main(string[] args)
	{
		GestionVehiculo();
	}
}
