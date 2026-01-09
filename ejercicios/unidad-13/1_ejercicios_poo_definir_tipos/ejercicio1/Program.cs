using System;
using System.Security.Cryptography;
using System.Text;


//TODO: Implementar las clases necesarias para la gestión de empleados
public class Empleado
{
    public enum Categoria
    {
        Subalterno = 10,
        Administrativo = 20,
        JefeDepartamento = 40,
        Gerente = 60
    }

    private readonly string _dni;
    private readonly string _nombre;
    private readonly int _añoNacimiento;
    private Categoria _categoria;

    public const double SALARIO_BASE = 1200;


    public Empleado(string dni, string nombre, int añoNacimiento)
    {
        _dni = dni;
        _nombre = nombre;
        _añoNacimiento = añoNacimiento;
        _categoria = Categoria.Subalterno;
    }

    public Empleado(Empleado otro)
    {
        _dni = otro._dni;
        _nombre = otro._nombre;
        _añoNacimiento = otro._añoNacimiento;
        _categoria = otro._categoria;
    }


    public string GetDni() => _dni;
    public string GetNombre() => _nombre;
    public int GetAñoNacimiento() => _añoNacimiento;
    public Categoria GetCategoria() => _categoria;

    public void SetCategoria(Categoria categoria)
    {
        _categoria = categoria;
    }

    public double Salario()
    {
        return SALARIO_BASE + (SALARIO_BASE * (int)GetCategoria() / 100f);
    }

    public int CalculaEdad()
    {
        return DateTime.Now.Year - GetAñoNacimiento();
    }

    public bool TieneMayorSalario(Empleado otro)
    {
        return Salario() > otro.Salario();
    }

    public bool EsMayorCategoria(Empleado otro)
    {
        return GetCategoria() > otro.GetCategoria();
    }

    public int CalculaDiferenciaEdad(Empleado otro)
    {
        return Math.Abs(CalculaEdad() - otro.CalculaEdad());
    }

    public string ACadena()
    {
        return $"""
            DNI: {GetDni()}
            Nombre: {GetNombre()}
            Año de nacimiento: {GetAñoNacimiento()}
            Edad: {CalculaEdad()} años
            Categoría: {GetCategoria()}
            Salario: {Salario()} (base: {SALARIO_BASE}€ + {(int)GetCategoria()}% incremento)
            """;
    }
}



public class Program
{

    static (string dni, string nombre, int añoNacimiento, string categoria) PideDatosUsuario()
    {
        Console.Write("  DNI: ");
        string dni = Console.ReadLine() ?? "";
        Console.Write("  Nombre: ");
        string nombre = Console.ReadLine() ?? "";
        Console.Write("  Año de nacimiento: ");
        int añoNacimiento = int.Parse(Console.ReadLine() ?? "0");
        Console.Write("  Categoría(Subalterno / Administrativo / JefeDepartamento / Gerente): ");
        string categoria = Console.ReadLine() ?? "";

        return (dni, nombre, añoNacimiento, categoria);
    }

    public static Empleado.Categoria ParseaCategoria(string texto)
    {
        if (string.IsNullOrWhiteSpace(texto))
            return Empleado.Categoria.Subalterno;


        if (int.TryParse(texto, out int valor) &&
            Enum.IsDefined(typeof(Empleado.Categoria), valor))
            return (Empleado.Categoria)valor;

        if (Enum.TryParse(texto, true, out Empleado.Categoria categoria) &&
            Enum.IsDefined(typeof(Empleado.Categoria), categoria))
            return categoria;

        return Empleado.Categoria.Subalterno;
    }


    static void Main(string[] args)
    {

        Console.WriteLine("Ejercicio 1: Clase Empleado con métodos Get/Set");
        Console.WriteLine();

        //TODO: Implementar la lógica necesaria para gestionar empleados
        Console.OutputEncoding = System.Text.Encoding.UTF8;


        Console.WriteLine($"=== CREACIÓN DE EMPLEADOS ===");

        Console.WriteLine("Introduce datos del primer empleado:");
        var (dni1, nombre1, añoNacimiento1, categoria1) = PideDatosUsuario();
        Empleado empleado1 = new(dni1, nombre1, añoNacimiento1);
        empleado1.SetCategoria(ParseaCategoria(categoria1));


        // Console.WriteLine("Introduce datos del segundo empleado:");
        // var (dni2, nombre2, añoNacimiento2, categoria2) = PideDatosUsuario();
        // Empleado empleado2 = new(dni2, nombre2, añoNacimiento2);
        // empleado1.SetCategoria(ParseaCategoria(categoria2));


        Console.WriteLine($"=== INFORMACIÓN DE EMPLEADOS ===");
        Console.WriteLine($"---Empleado 1---\n{empleado1.ACadena()}");
        // Console.WriteLine($"---Empleado 2---\n{empleado2.ACadena()}");



        Console.WriteLine("=== PROMOCIONES Y CAMBIOS ===");
        Console.WriteLine("Promocionando a Ana García a JefeDepartamento...");
        empleado1.SetCategoria(Empleado.Categoria.JefeDepartamento);

        // Console.WriteLine("Promocionando a Carlos López a Gerente...");
        // empleado2.SetCategoria(Empleado.Categoria.Gerente);

        Console.WriteLine("---Estado después de promociones---");
        Console.WriteLine($"Empleado 1:\n{empleado1.ACadena()}");
        // Console.WriteLine($"Empleado 2:\n{empleado2.ACadena()}");

        Console.WriteLine("=== CREACIÓN DE COPIA ===");
        Console.WriteLine("Creando copia de Ana García...");
        Empleado copiaEmpleado1 = new(empleado1);
        Console.WriteLine($"Empleado copiado:\n{copiaEmpleado1.ACadena()}");

        Console.WriteLine("=== COMPARACIONES ===");
        // Console.WriteLine($"¿Ana García tiene mayor salario que Carlos López? {empleado1.TieneMayorSalario(empleado2)}");
        // Console.WriteLine($"¿Carlos López es de mayor categoría que Ana García? {empleado2.EsMayorCategoria(empleado1)}");
        // Console.WriteLine($"Diferencia de edad: {empleado1.CalculaDiferenciaEdad(empleado2)} años");


        Console.WriteLine("Presiona cualquier tecla para salir...");
        Console.ReadKey();
    }
}
