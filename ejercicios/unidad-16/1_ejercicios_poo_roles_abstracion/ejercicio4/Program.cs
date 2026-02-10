using System;
using System.Collections.Generic;
using System.Threading;

//TODO: Añade el código necesario para implementar los requisitos del ejercicio
public interface IEntrenamientoDeportivo
{
  string Deporte {get;}
  int DuracionMinutos {get;} // DuracionMinutos * intensidad * factor
  float Factor {get;}
  int Intensidad {get;}
  double CaloriasEstimadas {get;}
  void IniciaSesion();
  void TerminaSesion();
}

public class Sentadillas: IEntrenamientoDeportivo, IComparable
{
  public enum TipoSentadillas {Basica=1, Bulgara=2, Salto=4, Peso=7}

  public float Factor => 1.3f;
  public DateTime Fecha { get; }
  public TipoSentadillas Tipo { get; }
  public string Deporte => "Sentadillas";
  public int DuracionMinutos { get; set; }
  public int Intensidad { get; private set; }
  public double CaloriasEstimadas => DuracionMinutos * Intensidad * Factor + (int)Tipo; 

  public DateTime InicioSesion { get; private set; }

  public Sentadillas(TipoSentadillas tipo, int intensidad, DateTime fecha) {
    Tipo = tipo;
    Intensidad = intensidad;
    Fecha = fecha;
    DuracionMinutos = 0;
  }

  public void IniciaSesion() {
    InicioSesion = DateTime.Now;
    Console.WriteLine($"Iniciando sesión de {Deporte} - Tipo: {Tipo} - Intensidad: {Intensidad}");
  }

  public void TerminaSesion() {
    Console.WriteLine($"Terminando sesión de {Deporte} - Duración: {DuracionMinutos} min - Calorías: {CaloriasEstimadas:F1}");
  }

  public int CompareTo(object? obj) {
    if (obj == null) return 1;
    
    IEntrenamientoDeportivo? otro = obj as IEntrenamientoDeportivo;
    if (otro != null) {
      return CaloriasEstimadas.CompareTo(otro.CaloriasEstimadas);
    }
    throw new ArgumentException("El objeto no es un IEntrenamientoDeportivo");
  }

  public override string ToString() {
    return $"{Deporte} - Tipo: {Tipo} - Fecha: {Fecha:dd/MM/yyyy} - Intensidad: {Intensidad} - Duración: {DuracionMinutos} min - Calorías: {CaloriasEstimadas:F1}";
  }
}

public class Running: IEntrenamientoDeportivo, IComparable
{
  public float Factor => 1.2f;
  public double DistanciaKm { get; private set; }
  public string Deporte => "Running";
  public int DuracionMinutos { get; set; }
  public int Intensidad { get; private set; }
  public double CaloriasEstimadas => DuracionMinutos* Intensidad * Factor + DistanciaKm * 10;
  public DateTime Fecha { get; private set; }
  public DateTime InicioSesion { get; private set; }

  public Running(double distanciaKm, int intensidad, DateTime fecha) {
    DistanciaKm = distanciaKm;
    Intensidad = intensidad;
    Fecha = fecha;
    DuracionMinutos = 0;
  }

  public void IniciaSesion() {
    InicioSesion = DateTime.Now;
    Console.WriteLine($"Iniciando sesión de {Deporte} - Distancia: {DistanciaKm} km - Intensidad: {Intensidad}");
  }

  public void TerminaSesion() {
    Console.WriteLine($"Terminando sesión de {Deporte} - Duración: {DuracionMinutos} min - Calorías: {CaloriasEstimadas:F1}");
  }

  public int CompareTo(object? obj) {
    if (obj == null) return 1;
    
    IEntrenamientoDeportivo? otro = obj as IEntrenamientoDeportivo;
    if (otro != null) {
      return CaloriasEstimadas.CompareTo(otro.CaloriasEstimadas);
    }
    throw new ArgumentException("El objeto no es un IEntrenamientoDeportivo");
  }

  public override string ToString() {
    return $"{Deporte} - Distancia: {DistanciaKm} km - Fecha: {Fecha:dd/MM/yyyy} - Intensidad: {Intensidad} - Duración: {DuracionMinutos} min - Calorías: {CaloriasEstimadas:F1}";
  }
}

public class Program
{
    public static void Main(string[] args)
    {
        GestionarEntrenamiento();
        Console.ReadKey();
    }

    public static void GestionarEntrenamiento()
    {
        Console.WriteLine("Ejercicio 4: Interfaces y entrenamiento\n\nCreando sesiones...\n");
        var s1 = new Sentadillas(Sentadillas.TipoSentadillas.Basica, 6, new DateTime(2025, 9, 10));
        s1.IniciaSesion();
        var s2 = new Sentadillas(Sentadillas.TipoSentadillas.Peso, 8, new DateTime(2025, 9, 10));
        s2.IniciaSesion();
        var r1 = new Running(7.5, 4, new DateTime(2025, 9, 11));
        r1.IniciaSesion();
        var lista = new List<IEntrenamientoDeportivo> { s1, s2, r1 };
        Console.WriteLine("Mostrando Sesiones realizadas...");
        Thread.Sleep(5000); // Simula duración de la sesión
        s1.TerminaSesion();
        s2.TerminaSesion();
        r1.TerminaSesion();
        s1.DuracionMinutos = 20;//Se utiliza para que la simulación sea realista
        s2.DuracionMinutos = 25;
        r1.DuracionMinutos = 45;
        foreach (var e in lista)
        {
            Console.WriteLine(e.ToString());
            Console.WriteLine();
        }
        Console.WriteLine("Comparaciones:");
        int cmp = s2.CompareTo(s1);
        string simbolo = cmp > 0 ? "> (mayor gasto calórico)" : (cmp < 0 ? "< (menor gasto calórico)" : "= (igual gasto calórico)");
        Console.WriteLine("  Sentadillas (Peso) vs Sentadillas (Basica): " + simbolo);
        Console.WriteLine();
        Console.WriteLine("Presiona cualquier tecla para continuar...");
    }
}
