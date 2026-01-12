using System;

public class Vehiculo
{
    public string Matricula { get; private set; }
    public string Marca { get; private set; }
    public string Modelo { get; private set; }
    public int Año { get; private set; }
    public double Precio { get; private set; }
    public int Kilometros { get; private set; }

    public Vehiculo(string matricula, string marca, string modelo, int año, double precio, int kilometros)
    {
        Matricula = matricula;
        Marca = marca;
        Modelo = modelo;
        Año = año;
        Precio = precio;
        Kilometros = kilometros;
    }

    public string Estado => Kilometros <= 1000 ? "Nuevo" : "Usado";

    public int Antigüedad => DateTime.Now.Year - Año;

    public double DepreciacionKilometraje => Kilometros * 0.10;

    public double ValorReal => Precio - DepreciacionKilometraje;


    public string NombreCompleto => $"{Marca} {Modelo} ({Año})";

    public void AñadeKilometros(int km)
    {
        Kilometros += km;
    }

    public void AplicaDescuento(double porcentaje)
    {
        Precio -= Precio * (porcentaje / 100);
    }

    public void ActualizaPrecio(double nuevoPrecio)
    {
        Precio = nuevoPrecio;
    }

    public string ACadena()
    {
        return $"""
        -Matrícula: {Matricula}
        - Vehiculo: {Marca} {Modelo} ({Año})
        - Año: {Año}
        - Precio: {Precio:F2} €
        - Valor real: {ValorReal:F2} €
        - Kilómetros: {Kilometros}
        - Estado: {Estado}
        """;
    }
}

public class Program
{
    //TODO: Implementar la lógica necesaria para gestionar vehículos
    static void Main(string[] args)
    {
        Console.WriteLine("Ejercicio 4: Clase Vehículo con propiedades autoimplementadas");
        Console.WriteLine();

        Console.WriteLine("=== CREACIÓN DE VEHÍCULOS ===");
        Console.WriteLine("Registrando vehículos en el concesionario...");
        Console.WriteLine();

        Vehiculo vehiculo1 = new Vehiculo("1234ABC", "Toyota", "Corolla", 2022, 25000.00, 15000);
        Console.WriteLine("Vehículo 1:");
        Console.WriteLine($"- Matrícula: {vehiculo1.Matricula}");
        Console.WriteLine($"- Marca: {vehiculo1.Marca}");
        Console.WriteLine($"- Modelo: {vehiculo1.Modelo}");
        Console.WriteLine($"- Año: {vehiculo1.Año}");
        Console.WriteLine($"- Precio: {vehiculo1.Precio:F2}€");
        Console.WriteLine($"- Kilómetros: {vehiculo1.Kilometros}");
        Console.WriteLine($"- Estado: {vehiculo1.Estado}");
        Console.WriteLine();

        Vehiculo vehiculo2 = new Vehiculo("5678DEF", "BMW", "Serie 3", 2025, 45000.00, 0);
        Console.WriteLine("Vehículo 2:");
        Console.WriteLine($"- Matrícula: {vehiculo2.Matricula}");
        Console.WriteLine($"- Marca: {vehiculo2.Marca}");
        Console.WriteLine($"- Modelo: {vehiculo2.Modelo}");
        Console.WriteLine($"- Año: {vehiculo2.Año}");
        Console.WriteLine($"- Precio: {vehiculo2.Precio:F2}€");
        Console.WriteLine($"- Kilómetros: {vehiculo2.Kilometros}");
        Console.WriteLine($"- Estado: {vehiculo2.Estado}");
        Console.WriteLine();

        Console.WriteLine("=== OPERACIONES CON VEHÍCULOS ===");
        Console.WriteLine("--- Actualizaciones de kilometraje ---");
        Console.WriteLine($"{vehiculo1.Marca} {vehiculo1.Modelo} recorre 5000 km adicionales...");
        vehiculo1.AñadeKilometros(5000);
        Console.WriteLine($"Kilómetros totales: {vehiculo1.Kilometros} km");
        Console.WriteLine();

        Console.WriteLine($"{vehiculo2.Marca} {vehiculo2.Modelo} recorre 1200 km (entrega a cliente)...");
        vehiculo2.AñadeKilometros(1200);
        Console.WriteLine($"Kilómetros totales: {vehiculo2.Kilometros} km");
        Console.WriteLine();

        Console.WriteLine("--- Cambios de precio ---");
        Console.WriteLine($"Aplicando descuento del 8% al {vehiculo1.Marca} {vehiculo1.Modelo}...");
        Console.WriteLine($"Precio anterior: {vehiculo1.Precio:F2}€");
        vehiculo1.AplicaDescuento(8);
        Console.WriteLine($"Precio actual: {vehiculo1.Precio:F2}€");
        Console.WriteLine();

        Console.WriteLine($"Aplicando descuento del 5% al {vehiculo2.Marca} {vehiculo2.Modelo}...");
        Console.WriteLine($"Precio anterior: {vehiculo2.Precio:F2}€");
        vehiculo2.AplicaDescuento(5);
        Console.WriteLine($"Precio actual: {vehiculo2.Precio:F2}€");
        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine("=== ANÁLISIS DEL INVENTARIO ===");
        Console.WriteLine("--- Depreciación por uso ---");
        Console.WriteLine($"{vehiculo1.Marca} {vehiculo1.Modelo}:");
        Console.WriteLine($"- Depreciación por kilómetros: {vehiculo1.DepreciacionKilometraje:F2}€ ({vehiculo1.Kilometros} km × 0.10€/km)");
        Console.WriteLine($"- Valor con depreciación: {vehiculo1.ValorReal:F2}€");
        Console.WriteLine();

        Console.WriteLine($"{vehiculo2.Marca} {vehiculo2.Modelo}:");
        Console.WriteLine($"- Depreciación por kilómetros: {vehiculo2.DepreciacionKilometraje:F2}€ ({vehiculo2.Kilometros} km × 0.10€/km)");
        Console.WriteLine($"- Valor con depreciación: {vehiculo2.ValorReal:F2}€");
        Console.WriteLine();

        Console.WriteLine("=== ESTADO FINAL DEL INVENTARIO ===");
        Console.WriteLine("Vehículo 1:");
        Console.WriteLine(vehiculo1.ACadena());
        Console.WriteLine();

        Console.WriteLine("Vehículo 2:");
        Console.WriteLine(vehiculo2.ACadena());
        Console.WriteLine("Pulse cualquier tecla para continuar...");
        Console.ReadKey();
    }
}
