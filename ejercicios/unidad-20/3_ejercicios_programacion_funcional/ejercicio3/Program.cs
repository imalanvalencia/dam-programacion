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
                new(1, "a", [new("Monitor", 2), new("Ratón", 1)]),
                new(2, "b", [new("Teclado", 1)]),
                new(3, "c", [new("Impresora", 1), new("Toner", 4)])
            ];


            var pedidosAplanados = pedidos.SelectMany(pedido =>
                pedido.Lineas.Select(linea => new
                {
                    IdPedido = pedido.Id,
                    linea.Producto,
                    linea.Cantidad
                })
            );

            var pedidosAUD = pedidosAplanados.Zip(
                Enumerable.Range(1,
                pedidosAplanados.Count()).Select(n => $"AUD-{n:D3}"
            ));

            foreach (var pedido in pedidosAUD)
            {
                var (p, audId) = pedido;

                Console.WriteLine($"{audId}: Pedido {p.IdPedido} - {p.Producto} ({p.Cantidad} uds)");
            }




            Console.WriteLine("Pulsa una tecla para finalizar...");
            // Console.ReadKey();
        }
    }
}