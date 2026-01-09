using System;
using System.Text.RegularExpressions;

//TODO: Implementar las clases necesarias para la gestión de productos
public class Producto
{
    // Propiedades 
    private string _codigo;
    private string _nombre;
    private double _precio;
    private int _stock;
    private static string[] codigosGenerados = [];

    public  const double PRECIO_MINIMO = 20.0;

    public  const int STOCK_MINIMO = 1;



    // Constructor
    private string GenerarCodigoUnico()
    {
        Random random = new();
        string codigo;
        do
        {
            int numero = random.Next(0, 10);

            char letra1 = (char)random.Next('A', 'Z' + 1);
            char letra2 = (char)random.Next('A', 'Z' + 1);
            char letra3 = (char)random.Next('A', 'Z' + 1);

            codigo = $"PR{numero}{letra1}{letra2}{letra3}";
        } while (codigosGenerados.Contains(codigo));

        codigosGenerados = [.. codigosGenerados, codigo];

        return codigo;
    }

    public Producto(string nombre, double precio, int stock)
    {
        _codigo = GenerarCodigoUnico();
        _nombre = nombre;
        Precio = precio;
        Stock = stock;
    }

    // Getters y Setters

    public string Codigo => _codigo;

    public string Nombre => _nombre;

    public double Precio
    {
        get => _precio;
        set => _precio = (value <= 0) ? PRECIO_MINIMO : value;
    }

    public int Stock
    {
        get => _stock;
        set => _stock = (value >= 0) ? value : STOCK_MINIMO;
    }

    public static string[] CodigosGenerados => codigosGenerados;

    // Propiedades calculadas
    public double ValorTotal => _precio * _stock;

    public string Estado => _stock switch
    {
        <= 0 => "Sin stock",
        < 10 => "Stock bajo",
        _ => "En stock"
    };

    // Métodos
    public bool Vende(int cantidad) => _stock >= cantidad && (_stock -= cantidad) >= 0;

    public void Repone(int cantidad) => _stock = Math.Max(0, _stock + cantidad);

    public void AplicaDescuento(double porcentaje) => Precio -= Precio * (porcentaje / 100);

    public string ACadena()
    {
        return $"""
        Código: {Codigo}
        Nombre: {Nombre}
        Precio: {Precio:F2} €
        Stock: {Stock} unidades
        Estado: {Estado}
        Valor total en stock: {ValorTotal:F2} €
        """;
    }
}

public class Program
{

    //TODO: Implementar los métodos necesarios para conseguir la lógica pedida
    public static Producto CreaProducto()
    {
        Console.Write("  Nombre del producto: ");
        string nombre = Console.ReadLine() ?? "";
        Console.Write("  Precio del producto: ");
        double precio = double.Parse(Console.ReadLine() ?? "0");
        Console.Write("  Stock inicial del producto: ");
        int stock = int.Parse(Console.ReadLine() ?? "0");

        return new(nombre, precio, stock);
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Ejercicio 2: Clase Producto con propiedades no autoimplementadas");
        Console.WriteLine();

        //TODO: Implementar la lógica necesaria para gestionar productos

        Console.WriteLine("=== CREACIÓN DE PRODUCTOS ===");
        Console.WriteLine("Creando productos del inventario...");

        Producto producto1 = CreaProducto();
        Producto producto2 = CreaProducto();
        Console.WriteLine("Producto 1:");
        Console.WriteLine(producto1.ACadena());
        Console.WriteLine("Producto 2:");
        Console.WriteLine(producto2.ACadena());


        Console.WriteLine("=== OPERACIONES CON STOCK ===");
        Console.WriteLine("--- Venta de productos ---");
        Console.WriteLine($"Vendiendo 5 unidades de {producto1.Nombre}...");
        if (producto1.Vende(5))
        {
            Console.WriteLine($"Stock actualizado: {producto1.Stock} unidades");
        }
        else
        {
            Console.WriteLine($"ERROR: Stock insuficiente. Stock actual: {producto1.Stock}, solicitado: 5");
        }

        Console.WriteLine();
        Console.WriteLine($"Vendiendo 20 unidades de {producto2.Nombre}...");
        if (producto2.Vende(20))
        {
            Console.WriteLine($"Stock actualizado: {producto2.Stock} unidades");
        }
        else
        {
            Console.WriteLine($"ERROR: Stock insuficiente. Stock actual: {producto2.Stock}, solicitado: 20");
        }

        Console.WriteLine();
        Console.WriteLine("--- Reposición de stock ---");
        Console.WriteLine($"Reponiendo 8 unidades de {producto1.Nombre}...");
        producto1.Repone(8);
        Console.WriteLine($"Stock actualizado: {producto1.Stock} unidades");

        Console.WriteLine();
        Console.WriteLine($"Intentando vender 25 unidades de {producto1.Nombre}...");
        if (producto1.Vende(25))
        {
            Console.WriteLine($"Stock actualizado: {producto1.Stock} unidades");
        }
        else
        {
            Console.WriteLine($"ERROR: Stock insuficiente. Stock actual: {producto1.Stock}, solicitado: 25");
        }

        Console.WriteLine();
        Console.WriteLine("=== CAMBIO DE PRECIOS ===");
        Console.WriteLine("--- Aplicar descuentos ---");
        Console.WriteLine($"Aplicando 10% de descuento a {producto1.Nombre}...");
        Console.WriteLine($"Precio anterior: {producto1.Precio:F2}€");
        producto1.AplicaDescuento(10);
        Console.WriteLine($"Precio nuevo: {producto1.Precio:F2}€");

        Console.WriteLine();
        Console.WriteLine($"Aplicando 20% de descuento a {producto2.Nombre}...");
        Console.WriteLine($"Precio anterior: {producto2.Precio:F2}€");
        producto2.AplicaDescuento(20);
        Console.WriteLine($"Precio nuevo: {producto2.Precio:F2}€");

        Console.WriteLine();
        Console.WriteLine("--- Intentar precio inválido ---");
        Console.WriteLine($"Intentando establecer precio negativo en {producto1.Nombre}...");
        double precioInvalido = -50.0;

        producto1.Precio = precioInvalido;
        if (producto1.Precio == Producto.PRECIO_MINIMO)
        {
            Console.WriteLine("ERROR: El precio no puede ser negativo o cero se establece al mínimo permitido.");
        }
        else
        {
            Console.WriteLine($"Precio actualizado a: {producto1.Precio:F2}€");
        }

        Console.WriteLine();
        Console.WriteLine("=== ESTADO FINAL DEL INVENTARIO ===");
        Console.WriteLine("Producto 1:");
        Console.WriteLine(producto1.ACadena());

        Console.WriteLine("Producto 2:");
        Console.WriteLine(producto2.ACadena());


        Console.WriteLine("Pulse cualquier tecla para continuar...");
        Console.ReadKey();
    }
}
