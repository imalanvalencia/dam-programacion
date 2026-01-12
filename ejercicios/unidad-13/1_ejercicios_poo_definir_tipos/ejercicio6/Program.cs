using System;

//TODO: Implementa la lógica pedida en el ejercicio
// Una clase tradicional (Entity)
public class Producto
{
    public Guid Id { get; }
    public string Nombre { get; }
    public Precio Precio { get; private set; }

    public Producto(Guid id, string nombre, Precio precio)
    {
        Id = id;
        Nombre = nombre;
        Precio = precio;
    }

    public void ActualizarPrecio(Precio nuevoPrecio)
    {
        Precio = nuevoPrecio;
    }
}

// Un value object por referencia (record)
public record Precio(decimal Valor, string Moneda)
{
    public override string ToString() => $"{Valor:F2} {Moneda}";
};


// Un value object por valor (struct)
public readonly struct Color
{
    public byte R { get; }
    public byte G { get; }
    public byte B { get; }

    public Color(byte r, byte g, byte b)
    {
        R = r;
        G = g;
        B = b;
    }

    public string ToHex() => $"{R:X2}{G:X2}{B:X2}";
}

public static class Program
{
    public static void Main()
    {
        Console.WriteLine("Ejercicio 6: Diagrama UML con diferentes tipos de definición\n");

        //TODO: Implementa la lógica pedida en el ejercicio

        Producto producto = new(Guid.NewGuid(), "Laptop Gaming", new Precio(1299.99m, "EUR"));

        Color color = new Color(255, 0, 0);

        Console.WriteLine("Producto (Clase tradicional):");
        Console.WriteLine($"Producto: {producto.Nombre} - {producto.Precio.ToString()}");

        Console.WriteLine("Precio (Value Object por valor):");
        Console.WriteLine($"Precio: {producto.Precio.Valor} {producto.Precio.Moneda} - Válido: True");

        Console.WriteLine("COLOR (Value Object por referencia):");
        Console.WriteLine($"Color RGB: ({color.R}, {color.G}, {color.B}) - Hex: {color.ToHex()}");

        Console.WriteLine("Pulsa cualquier tecla para continuar...");
        Console.ReadKey();
    }
}
