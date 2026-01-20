
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

    public Propietario(string nombre, string dni, DateOnly fechaNacimiento)
    {
        Nombre = nombre;
        Dni = dni;
        FechaNacimiento = fechaNacimiento;
    }



    public string ACadena() => $"""
    Propietario: {Nombre}
    DNI: {Dni}
    Fecha de nacimiento: {FechaNacimiento:dd/MM/yyyy}
    """;
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
        Id = Guid.NewGuid();
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
    Teléfono ID: {Id}
    Marca: {Marca}
    Modelo: {Modelo}
    Fecha de compra: {FechaCompra}
    Propietario: {Propietario.Nombre}
    Compañía: {Compañia.Nombre}
    """;

}

public class Program
{
    //TODO: Implementa las clases necesarias y la relación entre ellas para resolver el ejercicio
    /* 

    Registrando teléfono en la compañía...
    Teléfono registrado en Movistar
    Teléfonos registrados en Movistar: 1

    === ESTADO FINAL DEL SISTEMA ===
    --- Teléfono ---
    Teléfono ID: a1b2c3d4-e5f6-7890-abcd-ef1234567890
    Marca: iPhone, Modelo: 15 Pro
    Fecha de compra: 15/08/2025
    Propietario: Ana García (DNI: 12345678A)
    Compañía: Movistar (ES001)
    Contactos almacenados: 3
      - Luis Pérez: 666111222
      - María López: 677333444
      - Pedro Ruiz: 688555666   
    --- Compañía ---
    Compañía: Movistar (ES001)
    Teléfonos registrados: 1
    Presiona cualquier tecla para salir...
     */
    public static void GestionTelefono()
    {
        Console.WriteLine("Ejercicio 4: Sistema de gestión de teléfonos\n");
        //TODO: Implementar la lógica de gestión de teléfonos y contactos
        System.Console.WriteLine("Creando propietario del teléfono...");
        Propietario propietario = new Propietario("Ana García", "12345678A", new DateOnly(1990, 5, 15));

        CompañiaTelefonica movistar = new("ES001", "Movistar");

        System.Console.WriteLine("Creando un nuevo teléfono...");
        Telefono telefono = new("Samsung", "Galaxy S21", "123-456-7890", new(15, 8, 2025), propietario, movistar);

        System.Console.WriteLine("Añadiendo contactos al teléfono...");
        /* 
        Contacto añadido: Luis Pérez - 666111222
        Contacto añadido: María López - 677333444
        Contacto añadido: Pedro Ruiz - 688555666
         */
        
        
         

        System.Console.WriteLine(telefono);
        Console.WriteLine("\n\"Presiona cualquier tecla para salir...");
        Console.ReadKey();
    }

    static void Main(string[] args)
    {
        GestionTelefono();
    }
}
