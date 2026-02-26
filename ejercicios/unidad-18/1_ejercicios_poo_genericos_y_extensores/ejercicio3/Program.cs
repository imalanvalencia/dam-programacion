
//TODO: Incluye el código necesario para implementar las entidades que se piden en el ejercicio

public static class Comparador
{
    public static bool Mayor<T>(T a, T b) where T : IComparable<T>
    {
        return a.CompareTo(b) > 0;
    }

    public static bool Menor<T>(T a, T b) where T : IComparable<T>
    {
        return a.CompareTo(b) < 0;
    }
}

public class Persona : IComparable<Persona>, ICloneable
{
    public string Nombre { get; set; }
    public int Edad { get; set; }

    public Persona(string nombre, int edad)
    {
        Nombre = nombre;
        Edad = edad;
    }

    public override string ToString()
    {
        return $"Nombre: {Nombre}, Edad: {Edad} años.";
    }

    public int CompareTo(Persona? other) => Edad.CompareTo(other?.Edad);
    

    public object Clone()
    {
        return new Persona(Nombre, Edad);
    }
}

public class Ej03_PersonaICloneable
{
    static void Main(string[] args)
    {
        Console.WriteLine("Ejercicio 3. Métodos genéricos y restricciones de tipo\n");

        Console.WriteLine("Probando los métodos genéricos con tipos básicos:");
        Console.Write("\tComparando si la cadena `Hola` es mayor que `Hola`: ");
        Console.WriteLine($"{Comparador.Mayor("Hola", "Hola")}");
        Console.Write("\tComparando si el carácter 'c' es mayor que 'b':");
        Console.WriteLine($"{Comparador.Mayor('c', 'b')}");
        Console.Write("\tComparando si el número 4 es mayor que 3: ");
        Console.WriteLine($"{Comparador.Mayor(4, 3)}");

        Persona p1 = new Persona("James Raynor", 35);
        Persona p2 = new Persona("Sarah Kerrigan", 32);

        Persona p3 = (Persona)p2.Clone();
        Console.WriteLine("\nProbando los métodos genéricos con el tipo Persona:");
        Console.WriteLine("\tMostrando las personas:");
        Console.WriteLine(p1);
        Console.WriteLine(p2);
        Console.WriteLine(p3);

        Console.Write($"\tComparando si {p1} es mayor \n\tque {p2}: ");
        Console.WriteLine($"{Comparador.Mayor(p1, p2)}");
        Console.Write($"\tComparando si {p3} es mayor \n\tque {p1}: ");
        Console.WriteLine($"{Comparador.Mayor(p3, p1)}");
        Console.Write($"\tComparando si {p3} es menor \n\tque {p1}:");
        Console.WriteLine($"{Comparador.Menor(p3, p1)}");

        Console.WriteLine("\nFin de la aplicación.");
    }
}

