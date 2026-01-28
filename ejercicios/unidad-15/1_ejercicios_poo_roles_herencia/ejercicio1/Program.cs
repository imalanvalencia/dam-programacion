
using System;

namespace Ejercicio1
{
	//TODO: Crea las clases necesarias para implementar el enunciado del ejercicio
	public class Herramienta
	{
		Guid Id = new();
		public string Nombre { get; }
		public string Marca { get; }
		public double Peso { get; }
		public virtual double Precio { get; }

		public Herramienta(string nombre, string marca, double peso, double precioBase)
		{
			Nombre = nombre;
			Marca = marca;
			Peso = peso;
			Precio = precioBase;
		}

		public virtual string ACadena() => $"{Nombre}, Marca: {Marca}, Peso: {Peso:0.#}, Precio: {Precio:0.##}";
	}

	public class Taladro : Herramienta
	{
		public int Potencia { get; }
		public int VelocidadMaxima { get; }

		public Taladro(string nombre, string marca, double peso, double precioBase, int potencia, int velocidadMaxima) : base(nombre, marca, peso, precioBase)
		{
			Potencia = potencia;
			VelocidadMaxima = velocidadMaxima;
		}


		public override double Precio => base.Precio - base.Precio * .15;

		public override string ACadena() => base.ACadena() + $", Potencia: {Potencia}, Velocidad Máxima: {VelocidadMaxima}";
	}


	public class Program
	{
		public static void GestionHerramientas()
		{
			Herramienta martillo = new Herramienta("Martillo", "Stanley", .5, 25);
			Taladro taladro = new("Taladro Percutor", "Bosch", 2.3, 105, 750, 3000);

			Console.WriteLine(
			$"""
			Creando herramientas ....

			{martillo.ACadena()}

			// para un precio sin rebajar de 105.00
			{taladro.ACadena()}
			""");
		}

		static void Main(string[] args)
		{
			GestionHerramientas();
			Console.WriteLine("\nPresiona cualquier tecla para salir...");
			Console.ReadKey();
		}

		//TODO: Implementa el método GestionHerramientas
	}


}