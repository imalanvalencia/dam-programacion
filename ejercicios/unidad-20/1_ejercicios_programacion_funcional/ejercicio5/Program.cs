using System;

namespace Ejercicio5
{

    public class Principal
    {
        public static int Suma(int n1, int n2) => n1 + n2;
        public static int CuadradoDe(int number) => number * number;
        public static double GetVelocidadParada() => 108.4;
        public static bool EsMultiploDeCinco(int n) => n % 5 == 0;
        public static double Calcula(string tipo, string nom1, string nom2)
        {
            Console.WriteLine($"Introduce {nom1}");
            string temp1 = Console.ReadLine();
            int var1 = Int32.Parse(temp1);
            Console.WriteLine($"Introduce {nom2}");
            string temp2 = Console.ReadLine();
            int var2 = Int32.Parse(temp2);
            return tipo == "Potencia" ? var1 * var2 : var1 / var2;
        }
        public static void ProcedimientoDesconocido(double[,] x, int[] y, String z)
        {
            if (x.Length == y.Length)
            {
                int p = 0;
                foreach (double c in x)
                {
                    z += c + y[p];
                    z += " ";
                    p++;
                }
            }
            Console.WriteLine(z);
        }
        static void Main()
        {

            Console.WriteLine("Ejercicio 5. Practicando con delegados predefinidos");
            ///TODO: Define el código necesario para el ejercicio

            string UserInput(int numValor)
            {
                Console.WriteLine($"Introduce Valor ${numValor}");
                return Console.ReadLine()!;
            }
            ;

            Func<int, int, int> suma = Suma;
            Func<int, int> cuadrado = CuadradoDe;
            Func<double> velocidadParada = GetVelocidadParada;
            Func<int, bool> multiploDeCinco = EsMultiploDeCinco;
            Func<string, string, string, double> calculo = Calcula;
            Action<double[,], int[], string> procedimientoDesconocido = ProcedimientoDesconocido;

            Console.WriteLine($"""
            AddTwoNumbers --> {suma(5, 7)}
            SquareANumber --> {cuadrado(8)}
            GetTopSpeed --> {velocidadParada()}
            MultiploCinco --> {multiploDeCinco(25)}
            """);
            // ProcedimientoDesconocido -->{procedimientoDesconocido(new double[,] { { 1.5, 2.5 }, { 3.5, 4.5 } }, new int[] { 1, 2, 3, 4 }, "")}

            Console.WriteLine($"Calcula --> {calculo("Potencia", UserInput(1), UserInput(2))}");


            Console.WriteLine("Pulsa una tecla para continuar...");
            Console.ReadKey(true);
        }
    }
}
