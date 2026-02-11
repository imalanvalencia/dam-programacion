using System;
using System.Collections.Generic;

//TODO: Añade el código necesario para implementar los requisitos del ejercicio
public abstract record Validacion
{
	public record Exito() : Validacion;
	public record Error(string Mensaje) : Validacion;
}

public static class Validador
{
	public static Validacion ValidaDni(string dni) =>
		!string.IsNullOrWhiteSpace(dni) && dni.Length == 9
			? new Validacion.Exito()
			: new Validacion.Error("El DNI debe tener 9 caracteres.");

	public static Validacion ValidaNombre(string nombre) =>
		!string.IsNullOrWhiteSpace(nombre)
			? new Validacion.Exito()
			: new Validacion.Error("El nombre no puede estar vacío.");

	public static Validacion ValidaFechaNacimiento(DateTime fecha) =>
		fecha < DateTime.Today.AddYears(-10)
			? new Validacion.Exito()
			: new Validacion.Error("La fecha de nacimiento no es válida.");
}

public abstract class Formulario
{
	public string Dni { get; set; }
	public string Nombre { get; set; }
	public DateTime FechaNacimiento { get; set; }
	public Formulario(string dni, string nombre, DateTime fechaNacimiento)
	{
		Dni = dni;
		Nombre = nombre;
		FechaNacimiento = fechaNacimiento;
	}

	public virtual Validacion Validacion
	{
		get
		{
			if (Validador.ValidaDni(Dni) is Validacion.Error errorDni) return errorDni;
			if (Validador.ValidaNombre(Nombre) is Validacion.Error errorNombre) return errorNombre;
			return Validador.ValidaFechaNacimiento(FechaNacimiento);
		}
	}
}

public class Estudiante : Formulario
{
	public enum EstudiosEnum { SMR, ASIR, DAM, DAW }
	public string Estudios { get; set; }

	public Estudiante(string dni, string nombre, DateTime fechaNacimiento, string estudios) : base(dni, nombre, fechaNacimiento)
	{
		Estudios = estudios;
	}




	public override Validacion Validacion
	{
		get
		{          
			if (base.Validacion is Validacion.Error errorPadre) return errorPadre;
			if (Enum.IsDefined(typeof(EstudiosEnum), Estudios)) return new Validacion.Exito();
			return new Validacion.Error("Los estudios no están definidos");
		}
	}
}

public class Profesor : Formulario
{
	public string Especialidad { get; set; }
	public string Departamento { get; set; }

	public Profesor(string dni, string nombre, DateTime fechaNacimiento, string especialidad, string departamento) : base(dni, nombre, fechaNacimiento)
	{
		Especialidad = especialidad;
		Departamento = departamento;
	}

	public override Validacion Validacion
	{
		get
		{
			if (base.Validacion is Validacion.Error errorBase) return errorBase;
			if (string.IsNullOrWhiteSpace(Especialidad)) return new Validacion.Error("La especialidad no puede estar vacía.");
			if (string.IsNullOrWhiteSpace(Departamento)) return new Validacion.Error("El departamento no puede estar vacío.");
			if (Departamento.Length < 4) return new Validacion.Error("El departamento debe tener al menos cuatro caracteres.");
			return new Validacion.Exito();
		}
	}
}



public class Program
{
	public static void Main(string[] args)
	{
		GestionaFormularios();
		Console.ReadKey();
	}

	public static void GestionaFormularios()
	{
		Console.WriteLine("Ejercicio 3: Validación de formularios\n\nPara las entradas de datos...");
		
		// Estudiante 1: Estudios inválidos
		var est1 = new Estudiante("12345678A", "Ana Ruiz", new DateTime(2005, 5, 10), "Informática");
		Console.WriteLine($"Estudiante: DNI={est1.Dni}, Nombre={est1.Nombre}, FechaNacimiento={est1.FechaNacimiento:dd/MM/yyyy}, Estudios={est1.Estudios}");
		if (est1.Validacion is Validacion.Exito)
		{
			Console.WriteLine("    Validación: CORRECTO");
		}
		else if (est1.Validacion is Validacion.Error error)
		{
			Console.WriteLine($"    Validación: INCORRECTO -> {error.Mensaje}");
		}
		Console.WriteLine();

		// Estudiante 2: DNI vacío
		var est2 = new Estudiante("", "Pedro", new DateTime(2005, 5, 10), "DAM");
		Console.WriteLine($"Estudiante: DNI={est2.Dni}, Nombre={est2.Nombre}, FechaNacimiento={est2.FechaNacimiento:dd/MM/yyyy}, Estudios={est2.Estudios}");
		if (est2.Validacion is Validacion.Exito)
		{
			Console.WriteLine("    Validación: CORRECTO");
		}
		else if (est2.Validacion is Validacion.Error error)
		{
			Console.WriteLine($"    Validación: INCORRECTO -> {error.Mensaje}");
		}
		Console.WriteLine();

		// Profesor válido
		var prof = new Profesor("87654321B", "Luis Pérez", new DateTime(1980, 11, 20), "Matemáticas", "FISC");
		Console.WriteLine($"Profesor: DNI={prof.Dni}, Nombre={prof.Nombre}, FechaNacimiento={prof.FechaNacimiento:dd/MM/yyyy}, Especialidad={prof.Especialidad}, Departamento={prof.Departamento}");
		if (prof.Validacion is Validacion.Exito)
		{
			Console.WriteLine($"    Validación: CORRECTO -> El profesor {prof.Nombre} con DNI: {prof.Dni} y de la especialidad de {prof.Especialidad.ToLower()} 'ha sido añadido al sistema'.");
		}
		else if (prof.Validacion is Validacion.Error error)
		{
			Console.WriteLine($"    Validación: INCORRECTO -> {error.Mensaje}");
		}
		
		Console.WriteLine("\nPresiona cualquier tecla para salir...");
	}
}
