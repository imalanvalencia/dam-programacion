using System;
using System.Collections.Generic;

namespace ejercicio5
{
    ///TODO: Implementar la clase ClaveProducto

    public class Producto: IEquatable<Producto>
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }

        public Producto(string codigo, string nombre)
        {
            Codigo = codigo;
            Nombre = nombre;
        }

        public bool Equals(Producto? other)
        {
            if (other == null) return false;
            return Codigo == other.Codigo;
        }

        public override int GetHashCode() => Codigo.GetHashCode();

        public override bool Equals(object? obj) => Equals(obj as Producto);
    }
    public class Program
    {
        public static void GestionInventario()
        {
            Producto p1 = new("001", "P1");
            Producto p2 = new("001", "P2");

            Dictionary<Producto, int> inventario = new()
            {
                [p1] = 10
            };

            // FIXME: El resultado es false porque lo que valida ahora mismo es por referencia, no por código. Debería validar por código, lo que implica implementar Equals y GetHashCode en Producto o usar una clase ClaveProducto como clave del diccionario.
            
            Console.WriteLine("Añadido p1: Laptop (A001) con stock 10");
            Console.WriteLine("¿El inventario contiene p2 (misma info que p1)? " + inventario.ContainsKey(p2));

            Console.WriteLine("Stock recuperado de p2: " + inventario[p2]);
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Ejercicio 5. Diccionario con Clave Personalizada");
            Console.WriteLine();
            GestionInventario();
            Console.WriteLine("\nPulsar Enter para salir...");
            Console.ReadLine();

        }


    }
}