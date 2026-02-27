using System;
using System.Collections.Generic;
using System.Text;

namespace ejercicio8
{
   ///TODO: Implementar las clases Plato, Pedido, Cliente y Restaurante usando Queue y List
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Ejercicio 8: Sistema de pedidos de restaurante");
            Console.WriteLine();

            Restaurante restaurante = new Restaurante();

            restaurante.AgregaPlato(new Plato("Ensalada César", 8.50m, Categoria.Entrante));
            restaurante.AgregaPlato(new Plato("Bruschetta", 6.00m, Categoria.Entrante)); 
            
            restaurante.AgregaPlato(new Plato("Paella Valenciana", 15.20m, Categoria.Principal));
            restaurante.AgregaPlato(new Plato("Salmón a la plancha", 18.50m, Categoria.Principal));
            
            restaurante.AgregaPlato(new Plato("Tiramisu", 7.80m, Categoria.Postre));
            restaurante.AgregaPlato(new Plato("Flan casero", 5.50m, Categoria.Postre));

            restaurante.MuestraMenu();
            Console.WriteLine();

    
            var p1 = new Pedido(5, new List<Plato> { 
                restaurante.PlatoDe("Paella Valenciana"), 
                restaurante.PlatoDe("Tiramisu") 
            }, DateTime.Now);
            
            var p2 = new Pedido(2, new List<Plato> { 
                restaurante.PlatoDe("Ensalada César"), 
                restaurante.PlatoDe("Salmón a la plancha") 
            }, DateTime.Now);

            var p3 = new Pedido(8, new List<Plato> { 
                restaurante.PlatoDe("Bruschetta"), 
                restaurante.PlatoDe("Flan casero") 
            }, DateTime.Now);

            restaurante.EncolaPedido(p1);
            restaurante.EncolaPedido(p2);
            restaurante.EncolaPedido(p3);

            restaurante.MuestraColaPedidos();
            Console.WriteLine();

            restaurante.ProcesaPedido();
            Console.WriteLine();

        
            Cliente c1 = new Cliente("Juan Martínez");
            for(int i=0; i<3; i++) c1.HistorialPedidos.Add(new Pedido(0, new List<Plato>{ restaurante.PlatoDe("Paella Valenciana") }, DateTime.Now)); 
            
            c1.HistorialPedidos.Add( new Pedido(5, new List<Plato>{ restaurante.PlatoDe("Paella Valenciana"), restaurante.PlatoDe("Tiramisu") }, new DateTime(2025, 10, 5)));
             c1.HistorialPedidos.Add(  new Pedido(5, new List<Plato>{ restaurante.PlatoDe("Ensalada César"), restaurante.PlatoDe("Salmón a la plancha") }, new DateTime(2025, 10, 2)));
            c1.HistorialPedidos.Add( new Pedido(5, new List<Plato>{ restaurante.PlatoDe("Paella Valenciana") }, new DateTime(2025, 9, 28)));


            restaurante.AñadeCliente(c1);
      
            Console.WriteLine();

            Console.WriteLine($"Cliente {c1}");

            Console.WriteLine("Pulsar Enter para salir...   ");
            Console.ReadLine();
        }
    }
}
