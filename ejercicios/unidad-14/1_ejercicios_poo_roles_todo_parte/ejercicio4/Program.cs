
using System;
using System.Collections.Generic;
using System.Text;

public record class Contacto(string Nombre, string Telefono);

public class CompañiaTelefonica
{
    public string Codigo { get; }
    public string Nombre { get; }
    public Guid Id { get; }
    public List<string> TelefonosRegistrados { get; private set; }

    public CompañiaTelefonica(string codigo, string nombre)
    {
        Codigo = codigo;
        Nombre = nombre;
        Id = Guid.NewGuid();
        TelefonosRegistrados = [];
    }

    public void RegistraTelefono(Telefono telefono) => TelefonosRegistrados.Add(telefono.Numero);

    public int CantidadTelefonosRegistrados => TelefonosRegistrados.Count;

    public string ACadena() => $"Compañía: {Nombre} ({Codigo})\nTeléfonos registrados: {CantidadTelefonosRegistrados}";
}

public class Propietario
{
    public string Dni { get; }
    public string Nombre { get; }
    public DateOnly FechaNacimiento { get; }

    public Propietario(string dni, string nombre, DateOnly fechaNacimiento)
    {
        Nombre = nombre;
        Dni = dni;
        FechaNacimiento = fechaNacimiento;
    }



    public string ACadena() => $"{Nombre}\nDNI: {Dni}\nFecha de nacimiento: {FechaNacimiento:dd/MM/yyyy}";
}


public class Telefono
{
    private Guid Id { get; }
    public string Marca { get; }
    public string Modelo { get; }
    public string Numero { get; }
    public DateOnly FechaCompra { get; }
    public Propietario Propietario { get; }
    public CompañiaTelefonica Compañia { get; }
    public List<Contacto> Contactos { get; }


    public Telefono(string numero, string marca, string modelo, DateOnly fechaCompra, Propietario propietario, CompañiaTelefonica compañia)
    {
        Id = new();
        Marca = marca;
        Modelo = modelo;
        Numero = numero;
        FechaCompra = fechaCompra;
        Propietario = propietario;
        Compañia = compañia;
        Contactos = [];
    }

    public void AñadeContacto(Contacto contacto) => Contactos.Add(contacto);

    public string ACadena() => $"""
    Teléfono ID: {Numero}
    Marca: {Marca}, Modelo: {Modelo}
    Fecha de compra: {FechaCompra:dd/MM/yyyy}
    Propietario: {Propietario.Nombre} (DNI: {Propietario.Dni})
    Compañía: {Compañia.Nombre} ({Compañia.Codigo})
    Contactos almacenados: {Contactos.Count}
    {string.Join("\n    ", Contactos.Select(c => $"  - {c.Nombre}: {c.Telefono}"))}
    """;

}

public class Program
{
    //TODO: Implementa las clases necesarias y la relación entre ellas para resolver el ejercicio

    public static void GestionTelefono()
    {
        Console.WriteLine("Ejercicio 4: Sistema de gestión de teléfonos\n");
        //TODO: Implementar la lógica de gestión de teléfonos y contactos
        Console.WriteLine("Creando propietario del teléfono...");
        Propietario propietario = new Propietario("Ana García", "12345678A", new DateOnly(1990, 5, 15));

        CompañiaTelefonica movistar = new("ES001", "Movistar");

        Console.WriteLine("Creando un nuevo teléfono...");
        Telefono telefono = new("123-456-7890", "iPhone", "15 Pro", new DateOnly(2025, 8, 15), propietario, movistar);

        Console.WriteLine("Añadiendo contactos al teléfono...");
        telefono.AñadeContacto(new Contacto("Luis Pérez", "666111222"));
        Console.WriteLine("Contacto añadido: Luis Pérez - 666111222");

        telefono.AñadeContacto(new Contacto("María López", "677333444"));
        Console.WriteLine("Contacto añadido: María López - 677333444");

        telefono.AñadeContacto(new Contacto("Pedro Ruiz", "688555666"));
        Console.WriteLine("Contacto añadido: Pedro Ruiz - 688555666");

        Console.WriteLine("\nRegistrando teléfono en la compañía...");
        movistar.RegistraTelefono(telefono);
        Console.WriteLine("Teléfono registrado en Movistar");
        Console.WriteLine($"Teléfonos registrados en Movistar: {movistar.CantidadTelefonosRegistrados}");

        Console.WriteLine("\n=== ESTADO FINAL DEL SISTEMA ===");
        Console.WriteLine("--- Teléfono ---");
        Console.WriteLine(telefono.ACadena());
        Console.WriteLine("--- Compañía ---");
        Console.WriteLine(movistar.ACadena());

        Console.WriteLine("\nPresiona cualquier tecla para salir...");
        Console.ReadKey();
    }

    static void Main(string[] args)
    {
        GestionTelefono();
    }
}
