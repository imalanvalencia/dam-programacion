using System;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection.Metadata;
using System.Linq;


namespace Ejercicio5
{
    public class Program
    {
        // Escribe un método AplicaIva, que devuelva un Delegado con el precio total de un producto, a partir de aplicar un IVA al precio inicial.
       
        // Escribe un método AplicaDescuento, que devuelva un Delegado con el precio total de un producto a partir de aplicar un descuento a un precio inicial.
        

        // Escribe un método CarritoCompra, que devuelva un Delegado con el precio total de una lista de la compra.
        // La lista de la compra se recibirá como una lista de tuplas o pares de valores
        

        public static void Main()
        {

            Console.WriteLine("Ejercicio 5. Carrito compra con Lambdas\n");
            
            var calcularIva = AplicaIva();
            var calcularDescuento = AplicaDescuento();

            Console.WriteLine($"Para un precio de 4 euros y un IVA de 3% el total final será: {calcularIva(3, 4)}");
            Console.WriteLine($"Para un precio de 4 euros y un descuento de 3% el total final será: {calcularDescuento(3, 4)}");

            // Calculando el precio del carrito
            // Lista simulada: (Precio, Porcentaje)
            var cesta = new List<(float precio, float porcentaje)>
            {
                (10, 1),
                (20, 2),
                (30, 3)
            };

            var procesarCarrito = CarritoCompra();
            
            // Usando Descuentos
            // 10->9.9, 20->19.6, 30->29.1 => Total 58.6
            float totalDescuento = procesarCarrito(cesta, calcularDescuento);
            Console.WriteLine($"El total del carrito con descuentos es: {totalDescuento}");

            Console.WriteLine("Pulsa una tecla para finalizar...");
            Console.ReadLine();
        }
    }
}