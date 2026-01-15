using System;
using System.Collections.Generic;

//TODO: Implementa las clases necesarias y la relación entre ellas para resolver el ejercicio
public class Estudiante
{
	public string Dni { get; }
	public string Nombre { get; }
	public int Edad { get; }

	public Estudiante(string dni, string nombre, int edad)
	{
		Dni = dni;
		Nombre = nombre;
		Edad = edad;
	}

	public string ACadena() => $"{Nombre} ({Edad} años)";
}

public class Curso
{
	public Guid Id { get; }
	public string Nombre { get; }
	public int Creditos { get; }
	public int NumeroMaximoEstudiantes { get; }
	public short EdadMinima { get; }
	public List<Estudiante> Estudiantes { get; }

	public Curso(string nombre, int creditos, int numeroMaximoEstudiantes, short edadMinima)
	{
		Id = Guid.NewGuid();
		Nombre = nombre;
		Creditos = creditos;
		NumeroMaximoEstudiantes = numeroMaximoEstudiantes;
		EdadMinima = edadMinima;
		Estudiantes = [];
	}

	public bool Matricula(Estudiante estudiante)
	{
		Console.WriteLine($"Matriculando a {estudiante.Nombre}...");
		if (Estudiantes.Count >= NumeroMaximoEstudiantes)
		{
			Console.WriteLine("Lo siento, ya no se pueden matricular más estudiantes, el curso está completo.");
			Console.WriteLine();
			return false;
		}

		if (estudiante.Edad < EdadMinima)
		{
			Console.WriteLine($"Lo siento, este estudiante no tiene la edad adecuada, debe ser mayor de {EdadMinima} años.");
			Console.WriteLine();
			return false;
		}


		Estudiantes.Add(estudiante);
		return true;
	}

	public string ACadena() => $"""
	Curso: {Nombre} Créditos: {Creditos} - {Estudiantes.Count} estudiantes matriculados
	{(
		Estudiantes.Any() ?
		"Estudiantes:\n" + string.Join("\n", Estudiantes.ConvertAll(e => $"- {e.ACadena()}"))
		: ""
	)}
	""";

}

public class Program
{
	public static void GestionMatricula()
	{
		Console.WriteLine("Ejercicio 2: Agregación Curso-Estudiantes (1 a muchos)\n");
		//TODO: Implementar la lógica de gestión de cursos y estudiantes
		Console.WriteLine("Creando curso independiente...");
		Curso curso = new("Programación", 6, 4, 17);
		Console.WriteLine(curso.ACadena());

		Console.WriteLine("\nMatriculando estudiantes en el curso...");
		Console.WriteLine("-----------------------");

		Estudiante estudiante1 = new Estudiante("11223344C", "Ana García", 20);
		curso.Matricula(estudiante1);
		Estudiante estudiante2 = new Estudiante("12345678A", "Luis Pérez", 19);
		curso.Matricula(estudiante2);
		Estudiante estudiante3 = new Estudiante("87654321B", "María López", 21);
		curso.Matricula(estudiante3);


		Console.WriteLine("\nCurso después de las matrículaciones:");
		Console.WriteLine(curso.ACadena());

		Console.WriteLine("\nMatriculando estudiantes en el curso...");
		Console.WriteLine("-----------------------");

		Estudiante estudiante4 = new Estudiante("23456789D", "Pedro Sanchez", 16);
		curso.Matricula(estudiante4);

		Estudiante estudiante5 = new Estudiante("34567890E", "Marisa Rodríguez", 32);
		curso.Matricula(estudiante5);

		Estudiante estudiante6 = new Estudiante("45678901F", "Rosa Palacios", 23);
		curso.Matricula(estudiante6);


		Console.WriteLine("\nCurso después de las matrículaciones:");
		Console.WriteLine(curso.ACadena());

		Console.WriteLine("\nPresiona cualquier tecla para salir...");
		Console.ReadKey();
	}

	static void Main(string[] args)
	{
		GestionMatricula();
	}
}
