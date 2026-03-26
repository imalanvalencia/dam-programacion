using System;
using System.Collections.Generic;
using System.Linq;

namespace Ejercicio3
{

    ///TODO: Completar el código del ejercicio aquí
    public record LineaPedido(string Producto, int Cantidad);
    public record Pedido(int Id, string Cliente, List<LineaPedido> Lineas);

    public class Program
    {
        public static void Main(string[] args)
        {

            Console.WriteLine("Ejercicio 3. Auditoría de Pedidos");


            ///TODO: Completar el código del ejercicio aquí
            List<Pedido> pedidos = [
                new(1, "a", [new("pan", 1), new("harina", 1), new("aceite", 1)]),
                new(2, "b", [new("carbon", 1), new("perejil", 1), new("aceituna", 1)]),
                new(3, "c", [new("perico", 1), new("arroz", 1), new("cafe", 1)])
            ];


            var resultado = pedidos.SelectMany(((int id, List<LineaPedido> lineasParam) pedido) =>
        lineas.Select(linea => new
        {
            IdPedido = id,
            linea.Producto,
            linea.Cantidad
        })
    );
            Console.WriteLine("Pulsa una tecla para finalizar...");
            // Console.ReadKey();
        }
    }
}