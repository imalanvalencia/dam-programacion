
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ejercicio5
{
    //TODO: Implementar las clases necesarias para el ejercicio 5
    public class Program
    {
        static void Main(string[] args)
        {
            GestionAlbergues();

            Console.WriteLine("\nPulse una tecla para continuar...");
            Console.ReadKey();
        }

        //TODO: Crea los métodos necesarios

        public static void GestionAlbergues()
        {
            var albergues = new List<Albergue>
            {
                new AlbergueRural("Montaña Verde", 40, new Direccion("Granada", "España"), 22.00) { Servicios = new List<string>{"Desayuno","Cena","Rutas"} },
                new AlbergueUrbano("City Hostel", 80, new Direccion("Madrid", "España"), 18.00) { Servicios = new List<string>{"WiFi","Lavandería"} },
                new AlbergueCostero("Surf Point", 55, new Direccion("Tarifa", "España"), 20.00) { Servicios = new List<string>{"Clases de surf","Parking"} }
            };
            // Reservas iniciales
            albergues[0].RegistraReserva(3, false);
            albergues[1].RegistraReserva(5, false);
            albergues[2].RegistraReserva(10, false);

            //TODO: Crea el código del menú con las llamadas a los métodos
    
        }
   
    }

}
