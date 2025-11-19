using System;

namespace Ejercicio3
{
    public enum EstadoPedido { Pendiente, Procesando, Enviado, Entregado, Cancelado };


    public class Program
    {
        //TODO: Implementar los métodos necesarios

        static readonly string pedidosDisponibles = string.Join(", ", Enum.GetNames(typeof(EstadoPedido)));

        public static EstadoPedido[] AsignaEstados(int numeroPedidos)
        {
            Console.WriteLine("--- ASIGNACIÓN DE ESTADOS ---");
            EstadoPedido[] pedidos = new EstadoPedido[numeroPedidos];
            bool valido;
            int i = 0;

            do
            {
                Console.Write("Pedido {0} - Introduce estado: ", i + 1);

                valido = Enum.TryParse(Console.ReadLine(), true, out EstadoPedido pedido);

                if (valido) { pedidos[i] = pedido; i++; }
                else Console.Write($"Estado invalido, Estados disponibles: {pedidosDisponibles}");


            } while (!valido || i < pedidos.Length);

            return pedidos;
        }

        public static void MuestraResumen(EstadoPedido[] pedidos)
        {
            Console.WriteLine("=== RESUMEN DE PEDIDOS ===");
            for (int i = 0; i < pedidos.Length; i++)
            {
                Console.WriteLine("Pedidos {0}:", i + 1, pedidos[i]);
            }
        }


        public static int[] CuentaPorEstado(EstadoPedido[] pedidos)
        {
            int[] cuenta = new int[Enum.GetValues(typeof(EstadoPedido)).Length];

            foreach (var pedido in pedidos)
            {
                cuenta[(int)pedido]++;
            }

            return cuenta;
        }

        public static void MuestraEstadisticas(int[] cuenta)
        {
            Console.WriteLine("=== ESTADÍSTICAS ===");
            for (int i = 0; i < cuenta.Length; i++)
            {
                Console.WriteLine($"{(EstadoPedido)i}: {cuenta[i]} pedidos");
            }
        }

        public static void MuestraPedidosActivos(EstadoPedido[] pedidos)
        {
            Console.WriteLine("=== ESTADÍSTICAS ===");

            int pedidosActivos = 0;

            for (int i = 0; i < pedidos.Length; i++)
            {
                if (pedidos[i] == EstadoPedido.Entregado || pedidos[i] == EstadoPedido.Cancelado) Console.WriteLine("Pedido {0}: {1}", i, pedidos[i]); pedidosActivos++;
            }

            Console.WriteLine("Total de pedidos activos:" + pedidosActivos);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Ejercicio 3: Gestión de estados de pedidos");

            //TODO: Implementar la lógica necesaria
            Console.WriteLine("=== SISTEMA DE PEDIDOS ===");
            Console.WriteLine("Tipos de abono disponibles: " + pedidosDisponibles + "\n");

            bool numeroValido;
            int cantidadPedidos;

            do
            {
                Console.Write("Número de pedidos a gestionar: ");
                numeroValido = int.TryParse(Console.ReadLine(), out cantidadPedidos);

                if (!numeroValido) Console.Write("Has introducido un numero invalido. Introduce un numero valido: ");

            } while (!numeroValido);



            EstadoPedido[] pedidos = AsignaEstados(cantidadPedidos);
            MuestraResumen(pedidos);
            int[] cuenta = CuentaPorEstado(pedidos);
            MuestraEstadisticas(cuenta);
            MuestraPedidosActivos(pedidos);



            Console.WriteLine("¡Gracias por usar nuestro servicio!");
            Console.ReadLine();
        }
    }
}
