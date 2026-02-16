using System;
using System.Text;
using System.Text.RegularExpressions;

public class LibroNoDisponibleException(string message) : Exception(message);
public class LimitePrestamosException(string message) : Exception(message);


public class Libro
{
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public bool Disponible { get; set; }

    public Libro(string titulo, string autor)
    {
        Titulo = titulo;
        Autor = autor;
        Disponible = true;
    }

    public void Prestar()
    {
        if (!Disponible) throw new LibroNoDisponibleException("Error: El libro no está disponible.");
        else Disponible = false;

    }
}

public class Usuario
{
    public string Nombre { get; set; }
    public Libro[] Libros { get; set; }

    public Usuario(string nombre)
    {
        Nombre = nombre;
        Libros = new Libro[3];
    }


    public void TomarPrestado(Libro libro)
    {
        bool libroAñadido = false;
        int libroPrestado = 0;

        while (!libroAñadido && libroPrestado < Libros.Length)
        {

            if (Libros[libroPrestado] == null)
            {
                Libros[libroPrestado] = libro;
                libro.Prestar();
                libroAñadido = true;
            }

            libroPrestado++;
        }


        if (!libroAñadido) throw new LimitePrestamosException("Intentando tomar un cuarto libro prestado...\nError: Has alcanzado el límite de préstamos.");
    }

}

public class Biblioteca
{
    public Libro[] Libros { get; set; }

    public Biblioteca(Libro[] libros)
    {
        Libros = libros;
    }

    public Libro BuscarLibro(string titulo)
    {
        for (int i = 0; i < Libros.Length; i++)
        {
            if (Regex.IsMatch(Libros[i].Titulo, @$"^{titulo}$", RegexOptions.IgnoreCase)) return Libros[i];
        }

        throw new InvalidOperationException("Error: El libro no existe en la biblioteca.");
    }


}



class Program
{
    static string? ReadLineWithEscape()
    {
        StringBuilder sb = new StringBuilder();
        while (true)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.Escape)
            {
                return null;
            }
            else if (key.Key == ConsoleKey.Enter)
            {
                Console.WriteLine(); // Para nueva línea
                return sb.ToString();
            }
            else if (key.Key == ConsoleKey.Backspace)
            {
                if (sb.Length > 0)
                {
                    sb.Remove(sb.Length - 1, 1);
                    Console.Write("\b \b"); // Borrar el carácter en pantalla
                }
            }
            else
            {
                sb.Append(key.KeyChar);
                Console.Write(key.KeyChar);
            }
        }
    }

    static void Main()
    {
        // crear libros y agregarlo a biblioteca
        Libro potter = new("Harry Potter", "J.K. Rolling");
        Libro quijote = new("El Quijote", "cervantes");
        Libro dune = new("Dune", "Frank Herbert");
        Libro harryPotter2 = new("Harry Potter 2", "J.K. Rolling");
        Libro harryPotter3 = new("Harry Potter 3", "J.K. Rolling");
        Libro harryPotter4 = new("Harry Potter 4", "J.K. Rolling");
        Libro harryPotter5 = new("Harry Potter 5", "J.K. Rolling");
        Libro harryPotter6 = new("Harry Potter 6", "J.K. Rolling");
        Libro harryPotter7 = new("Harry Potter 7", "J.K. Rolling");
        Libro harryPotter8 = new("Harry Potter 8", "J.K. Rolling");

        Libro[] librosConocidos = [potter, quijote, dune, harryPotter2, harryPotter3, harryPotter4, harryPotter5, harryPotter6, harryPotter7, harryPotter8];

        Biblioteca biblioteca = new(librosConocidos);

        // crear usuario
        Usuario usuario = new("Juan");

        Console.WriteLine("--------------- Hola {usuario.Nombre} ---------------\nPresiona escape para salir de la biblioteca.\n");

        bool salir = false;
        do
        {
            Console.Write("Introduce el título del libro a buscar: ");
            string? libroAPedir = ReadLineWithEscape();

            if (libroAPedir == null) salir = true;

            else if (!string.IsNullOrWhiteSpace(libroAPedir))
            {
                try
                {
                    var libro = biblioteca.BuscarLibro(libroAPedir);

                    Console.Write("Libro encontrado. ¿Desea tomarlo prestado? (s/n): ");
                    ConsoleKeyInfo respuesta = Console.ReadKey(true);
                    Console.WriteLine(respuesta.KeyChar); // Eco de la tecla

                    if (char.ToLower(respuesta.KeyChar) == 's') usuario.TomarPrestado(libro);

                    else if (respuesta.Key == ConsoleKey.Escape) salir = true;
                    else Console.WriteLine("Vale. Ahora me toca guardarlo");

                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message + "\n");
                }
                catch (LibroNoDisponibleException e)
                {
                    Console.WriteLine(e.Message + "\n");
                }
                catch (LimitePrestamosException e)
                {
                    Console.WriteLine(e.Message + "\n");
                }
            }

        } while (!salir);

        Console.WriteLine("\nLa biblioteca ha cerrado. ¡Hasta luego!");

    }
}