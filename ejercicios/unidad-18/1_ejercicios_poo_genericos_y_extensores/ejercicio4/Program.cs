using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Ejercicio4
{
    //TODO: Incluye el código necesario para implementar las entidades que se piden en el ejercicio
    

    public class Program
    {
        public static void Main(string[] args)
        {
            GestionAlarma();
        }

        public static void GestionAlarma()
        {
            Console.WriteLine("Ejercicio 4. Alarma genérica con sensores y avisadores\n");
            Console.WriteLine("Creando alarmas...");

            var sensor = new SensorBasico();
            var timbre = new Timbre(50, "Ring....");
            var alarma1 = new Alarma<int, IAvisador>(30, sensor, timbre);

            Console.WriteLine($"Alarma (umbral=70): Encendiendo y comprobando (pulsa una tecla para detener)...");
            alarma1.Enciende();
            alarma1.Comprueba();
            alarma1.Apaga();



            var bombilla = new Bombilla(ConsoleColor.Red);
            alarma1.AñadeAvisador(bombilla);

            Console.WriteLine();
            Console.WriteLine($"Alarma luminosa (umbral=50): Encendiendo...");
            alarma1.Enciende();
            alarma1.Comprueba();
            alarma1.Apaga();

            var llamada = new Llamada(new List<string>() { "+34123456789", "+34123456780" });
            alarma1.AñadeAvisador((IAvisador)llamada);
            alarma1.Enciende();

            alarma1.Comprueba();

            Console.WriteLine();
            Console.WriteLine("Apagando alarmas.");
            alarma1.Apaga();
            Console.WriteLine("Fin de la demo.\n");
            Console.WriteLine("Presiona cualquier tecla para salir...");
            Console.ReadKey(true);
        }
    }
}