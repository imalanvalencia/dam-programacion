using System;
using System.Threading;
using System.Globalization;

//TODO: Incluye el código necesario para implementar las entidades que se piden en el ejercicio

internal class Program
{


    private static void Main(string[] args)
    {
        GestionAlarma();
    }
    private static void GestionAlarma()
    {
        Console.WriteLine("Ejercicio 2: Interfaz Genérica Alarma\n");
        //TODO: Implementa el código para instanciar los objetos y conseguir la salida
        Console.WriteLine("Configurando alarma genérica (umbral = 70)...");
        Alarma<int> umbralSetenta = new(70, new SensorBasico());
        umbralSetenta.Enciende();
        umbralSetenta.Comprueba();

        Console.WriteLine("Configurando alarma genérica (umbral = 70)...");
        Alarma<float> umbralSetentaFloat = new(70f, new SensorPreciso());
        umbralSetentaFloat.Enciende();
        umbralSetentaFloat.Comprueba();


        Console.WriteLine("Fin de la aplicación.");
        Console.ReadKey();
    }
}