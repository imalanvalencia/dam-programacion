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
			: new Validacion.Error("INCORRECTO: El DNI debe tener 9 caracteres.");

	public static Validacion ValidaNombre(string nombre) =>
		!string.IsNullOrWhiteSpace(nombre)
			? new Validacion.Exito()
			: new Validacion.Error("INCORRECTO: El nombre no puede estar vacío.");

	public static Validacion ValidaFechaNacimiento(DateTime fecha) =>
		fecha < DateTime.Today.AddYears(-10)
			? new Validacion.Exito()
			: new Validacion.Error("INCORRECTO: La fecha de nacimiento no es válida.");
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
			return new Validacion.Error("INCORRECTO: Los estudios no son válidos.");
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
			if (string.IsNullOrWhiteSpace(Especialidad)) return new Validacion.Error("INCORRECTO: La especialidad no puede estar vacía.");
			if (string.IsNullOrWhiteSpace(Departamento)) return new Validacion.Error("INCORRECTO: El departamento no puede estar vacío.");
			if (Departamento.Length < 4) return new Validacion.Error("INCORRECTO: El departamento debe tener al menos cuatro caracteres.");
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
		//TODO: Añade el código necesario para implementar los requisitos del método
		
		Console.WriteLine("Presiona cualquier tecla para salir...");
	}
}
