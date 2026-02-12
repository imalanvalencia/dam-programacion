using System;
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
        else
        {
            Console.Write("Libro encontrado. ¿Desea tomarlo prestado? (s/n):");
            if (Regex.IsMatch(Console.ReadLine()!, @"^s$", RegexOptions.IgnoreCase)) Disponible = false;
        }
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

        for (int i = 0; i < Libros.Length; i++)
        {

            if (Libros[i] == null)
            {
                Libros[i] = libro;
                libroAñadido = true;
            }
        }

        if (!libroAñadido) throw new LimitePrestamosException("Intentando tomar un cuarto libro prestado...\nError: Has alcanzado el límite de préstamos.");
    }

}

public class Biblioteca
{
    public Libro[] Libros { get; set; }
}



class Program
{
    static void Main()
    {

    }
}