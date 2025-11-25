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
        static double PideNumero(string mensaje)
        {
            bool valid = true;
            double numero = 0;

            Console.WriteLine(mensaje);

            while (!valid)
            {
                valid = double.TryParse(Console.ReadLine() ?? "", out numero);

                if (!valid)
                    Console.WriteLine("Por favor, introduce un número válido. ");

            }
            return numero;
        }

        static void DemuestraCalculadoraEstatica(double valor1, double valor2)
        {
            Console.WriteLine(
                $"Suma: {CalculadoraEstatica.Suma(valor1, valor2)}\nResta: {CalculadoraEstatica.Resta(valor1, valor2)}\nMultiplicación: {CalculadoraEstatica.Resta(valor1, valor2)}\nDivisión: 1,{CalculadoraEstatica.Resta(valor1, valor2)}");
        }

        static void DemuestraCalculadoraTAD(double valor1, double valor2)
        {
            CalculadoraTAD calculadora1 = new(valor1, valor2);
            CalculadoraTAD calculadora2 = new(valor1 * 2, valor2 + 2);


            Console.WriteLine(
                "Creando calculadora TAD con valores iniciales...\n\n" +
                $"Calculadora 1: Valor1={calculadora1.Valor1}, Valor2={calculadora1.Valor2}\nSuma: {calculadora1.Suma()}\nResta: {calculadora1.Resta()}\nMultiplicación: {calculadora1.Resta()}\nDivisión: 1,{calculadora1.Resta()}" +

                "Creando segunda calculadora...\n" +
                $"Calculadora 2: Valor1={calculadora2.Valor1}, Valor2={calculadora2.Valor2}\nSuma: {calculadora1.Suma()}\nResta: {calculadora1.Resta()}\nMultiplicación: {calculadora1.Resta()}\nDivisión: 1,{calculadora1.Resta()}");


            calculadora1.Valor1 = 30;
            calculadora1.Valor2 = 15;

            System.Console.WriteLine("Modificando valores de calculadora 1...\n" +
            $"Calculadora 1 modificada: Valor1={valor1 * 2}, Valor2={valor2 + 1}\nSuma: {calculadora1.Suma()}\nResta: {calculadora1.Resta()}\nMultiplicación: {calculadora1.Resta()}\nDivisión: 1,{calculadora1.Resta()}");

            Console.WriteLine($"¿Las calculadoras son el mismo objeto? {ReferenceEquals(calculadora1, calculadora2)}\n¿Las calculadoras tienen los mismos valores ? {calculadora1.Valor1 == calculadora2.Valor1 && calculadora1.Valor2 == calculadora2.Valor2}");

            Console.WriteLine("Estado final:\nCalculadora 1: Valor1={calculadora1.Valor1}, Valor2={calculadora1.Valor2}\nValor1={calculadora2.Valor1}, Valor2={calculadora2.Valor2}");
        }

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
