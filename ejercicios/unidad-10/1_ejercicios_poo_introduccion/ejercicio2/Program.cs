using System;

namespace Ejercicio2
{
    // Clase contenedor con métodos estáticos

    //TODO: Clase CalculadoraEstatica para realizar operaciones matemáticas
    public class CalculadoraEstatica
    {
        public static double Suma(double a, double b) => a + b;
        public static double Resta(double a, double b) => a - b;
        public static double Multiplica(double a, double b) => a * b;
        public static double Divide(double a, double b) => (b != 0) ? a / b : 0;
    }

    // Clase TAD (permite crear objetos)
    public class CalculadoraTAD
    {
        public double Valor1 { get; set; }
        public double Valor2 { get; set; }

        public CalculadoraTAD(double valor1, double valor2)
        {
            Valor1 = valor1;
            Valor2 = valor2;
        }

        public double Suma()
        {
            return Valor1 + Valor2;
        }

        public double Resta()
        {
            return Valor1 - Valor2;
        }

        public double Multiplica()
        {
            return Valor1 * Valor2;
        }

        public double Divide()
        {
            return Valor1 / Valor2;
        }

        public void CambiaValores(double nuevoValor1, double nuevoValor2)
        {
            Valor1 = nuevoValor1;
            Valor2 = nuevoValor2;
        }

        public void MuestraEstado()
        {
            Console.WriteLine($"Valor1={Valor1}, Valor2={Valor2}");
        }
    }

    public class Program
    {
        //TODO: Implementar la lógica de los métodos que faltan


        static void Main(string[] args)
        {
            Console.WriteLine("Ejercicio 2: Calculadora matemática (Clase contenedor vs TAD)");
            Console.WriteLine();

            // Demostrar clase estática
            Console.WriteLine("--- CLASE CONTENEDOR (Métodos estáticos) ---");

            double valor1 = PideNumero("Introduce primer número para TAD: ");
            double valor2 = PideNumero("Introduce segundo número para TAD: ");
            Console.WriteLine();
            DemuestraCalculadoraEstatica(valor1, valor2);

            // Obtener los mismos valores para la demostración TAD
            Console.WriteLine();
            Console.WriteLine("--- CLASE TAD (Objetos) ---");

            valor1 = PideNumero("Introduce primer número para TAD: ");
            valor2 = PideNumero("Introduce segundo número para TAD: ");

            // Demostrar clase TAD
            DemuestraCalculadoraTAD(valor1, valor2);

            Console.WriteLine("¡Hasta la próxima!");
            Console.ReadKey();
        }
    }
}
