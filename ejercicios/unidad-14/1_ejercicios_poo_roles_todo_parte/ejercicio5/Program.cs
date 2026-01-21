
using System;
using System.Collections.Generic;
using System.Text;

//TODO: Implementa las clases necesarias y la relación entre ellas para resolver el ejercicio
public class Animal
{
    public Guid Id { get; }
    public string Nombre { get; }
    public string Especie { get; }

    private bool Asignado { get; set; }
    public int Edad { get; set; }

    public Animal(string nombre, string especie, int edad)
    {
        Nombre = nombre;
        Especie = especie;
        Edad = edad;
    }

    public bool EstaAsignado() => Asignado;
    public void Libera() => Asignado = false;
    public void Asigna() => Asignado = true;

    public string ACadena() => $"Animal: {Nombre} ({Especie}) - {Edad} años\n  Estado: {(Asignado ? "Asignado" : "No asignado")} ";
}


public class Cuidador
{
    public string Dni { get; }
    public string Nombre { get; }
    public int NumeroMaximoMascotas { get; }
    public string Especialidad { get; }
    public int NumeroMascotasAsignadas { get; private set; }

    public Cuidador(string dni, string nombre, int numeroMaximoMascotas, string especialidad)
    {
        Dni = dni;
        Nombre = nombre;
        NumeroMaximoMascotas = numeroMaximoMascotas;
        Especialidad = especialidad;
        NumeroMascotasAsignadas = 0;
    }

    public void Disponible() => NumeroMascotasAsignadas++;
    public void Libera() => NumeroMascotasAsignadas--;
    public bool AsignaMascotaSiDisponible() => NumeroMascotasAsignadas < NumeroMaximoMascotas;

    public string ACadena() => $"Cuidador: {Nombre} ({Especialidad})\n  Mascotas asignadas: {NumeroMascotasAsignadas}/{NumeroMaximoMascotas}\n  Disponible para más asignaciones: {(AsignaMascotaSiDisponible() ? "Si" : "No")}";
}

public class Refugio
{
    public Guid Id { get; }
    public string Nombre { get; }
    private List<Animal> Animales { get; set; }
    private List<Cuidador> Cuidadores { get; set; }
    private List<(Animal, Cuidador)> Asignaciones { get; set; }

    public Refugio(string nombre)
    {
        Id = new();
        Nombre = nombre;
        Animales = [];
        Cuidadores = [];
        Asignaciones = [];
    }

    public void AñadeCuidador(Cuidador cuidador) => Cuidadores.Add(cuidador);

    public void EliminaCuidador(Cuidador cuidador)
    {
        for (int i = 0; i < Cuidadores.Count; i++)
        {
            if (cuidador.Dni == Cuidadores[i].Dni)
            {
                // Eliminar todas las asignaciones asociadas a este cuidador
                for (int j = Asignaciones.Count - 1; j >= 0; j--)
                {
                    if (Asignaciones[j].Item2.Dni == cuidador.Dni)
                    {
                        Asignaciones[j].Item1.Libera();
                        Asignaciones.RemoveAt(j);
                    }
                }
                Cuidadores.RemoveAt(i);
                return;
            }
        }
    }

    public void AñadeAnimal(Animal animal) => Animales.Add(animal);
    public void EliminaAnimal(Animal animal)
    {
        for (int i = 0; i < Animales.Count; i++)
        {
            if (animal.Id == Animales[i].Id)
            {
                // Eliminar todas las asignaciones asociadas a este animal
                for (int j = Asignaciones.Count - 1; j >= 0; j--)
                {
                    if (Asignaciones[j].Item1.Id == animal.Id)
                    {
                        Asignaciones[j].Item2.Libera();
                        Asignaciones.RemoveAt(j);
                    }
                }
                Animales.RemoveAt(i);
                return;
            }
        }
    }

    public void AsignaAnimalACuidador(Animal animal, Cuidador cuidador)
    {
        if (!cuidador.AsignaMascotaSiDisponible()) return;
        if (!animal.EstaAsignado()) return;

        Asignaciones.Add((animal, cuidador));
        cuidador.Disponible();
        animal.Asigna();

    }

    public string ACadena()
    {
        StringBuilder sb = new();
        sb.AppendLine($"Refugio: {Nombre}");
        sb.AppendLine("--- Información de animales ---");

        foreach (var animal in Animales)
            sb.AppendLine($"Animal: {animal.ACadena()}");


        sb.AppendLine("--- Información de cuidadores ---");
        foreach (var cuidador in Cuidadores)
            sb.AppendLine($"Cuidador: {cuidador.Nombre} ({cuidador.Especialidad})");

        sb.AppendLine("--- Resumen del refugio ---");
        sb.AppendLine("Detalle de asignaciones:");
        foreach (var (animal, cuidador) in Asignaciones)
            sb.AppendLine($"- {animal.Nombre} ↔ {cuidador.Nombre}");

        return sb.ToString();
    }
}

public class Program
{
    public static void GestionRefugio()
    {
        Console.WriteLine("Ejercicio 5: Sistema de refugio con agregación múltiple\n");
        Console.WriteLine("Creando refugio...");
        Refugio refugio = new("Hogar Feliz");
        Console.WriteLine($"Refugio creado: {refugio.Nombre}\n");

        Console.WriteLine("Registrando cuidadores en el refugio...");
        Cuidador ana = new("11111111A", "Ana López", 5, "Veterinaria");
        refugio.AñadeCuidador(ana);
        Console.WriteLine("Cuidador añadido: Ana López (Veterinaria) - Máximo 5 mascotas");
        Cuidador carlos = new("22222222B", "Carlos Ruiz", 3, "Entrenador");
        refugio.AñadeCuidador(carlos);
        Console.WriteLine("Cuidador añadido: Carlos Ruiz (Entrenador) - Máximo 3 mascotas");
        Cuidador maria = new("33333333C", "María Pérez", 2, "Voluntaria");
        refugio.AñadeCuidador(maria);
        Console.WriteLine("Cuidador añadido: María Pérez (Voluntaria) - Máximo 2 mascotas");

        Console.WriteLine("\nRegistrando animales en el refugio...");
        Animal max = new("Max", "Perro", 3);
        refugio.AñadeAnimal(max);
        Console.WriteLine("Animal añadido: Max (Perro) - Edad: 3 años");
        Animal luna = new("Luna", "Gato", 2);
        refugio.AñadeAnimal(luna);
        Console.WriteLine("Animal añadido: Luna (Gato) - Edad: 2 años");

        Console.WriteLine("\nRealizando asignaciones de cuidadores...");
        Console.WriteLine("Asignando Max a Ana López...");
        Console.WriteLine("  - Verificando disponibilidad de Ana López... " + (ana.NumeroMascotasAsignadas < ana.NumeroMaximoMascotas ? "Disponible" : "No disponible"));
        refugio.AsignaAnimalACuidador(max, ana);
        Console.WriteLine("  - Max ha sido asignado correctamente");

        Console.WriteLine("Asignando Max a Carlos Ruiz...");
        Console.WriteLine("  - Verificando disponibilidad de Carlos Ruiz... " + (carlos.NumeroMascotasAsignadas < carlos.NumeroMaximoMascotas ? "Disponible" : "No disponible"));
        refugio.AsignaAnimalACuidador(max, carlos);
        Console.WriteLine("  - Max ha sido asignado correctamente");

        Console.WriteLine("Asignando Luna a Ana López...");
        Console.WriteLine("  - Verificando disponibilidad de Ana López... " + (ana.NumeroMascotasAsignadas < ana.NumeroMaximoMascotas ? "Disponible" : "No disponible"));
        refugio.AsignaAnimalACuidador(luna, ana);
        Console.WriteLine("  - Luna ha sido asignado correctamente");

        Console.WriteLine("Asignando Luna a María Pérez...");
        Console.WriteLine("  - Verificando disponibilidad de María Pérez... " + (maria.NumeroMascotasAsignadas < maria.NumeroMaximoMascotas ? "Disponible" : "No disponible"));
        refugio.AsignaAnimalACuidador(luna, maria);
        Console.WriteLine("  - Luna ha sido asignado correctamente");

        Console.WriteLine("\nEstado actual del refugio:");
        Console.WriteLine(refugio.ACadena());

        Console.WriteLine("\nPresiona cualquier tecla para salir...");
        Console.ReadKey();
    }

    static void Main(string[] args)
    {
        GestionRefugio();
    }
}
