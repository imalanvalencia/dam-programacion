using System;
using System.Linq;
using System.Collections.Generic;

namespace Ejercicio
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Ejercicio 2.  Coincidencia en lista de cadenas");

            List<double> reales = new List<double> { 0.5, 1.6, 2.8, 3.9, 4.1, 5.2, 6.3, 7.4, 8.1, 9.2 };

            string texto = "Elementos: ";
            reales.ForEach(n => texto = $"{texto} {n}");
            Console.WriteLine(texto);

            int cuentaParteDecimalMenorA05 = CuentaParteDecimalMenorA05(reales);
            Console.Write($"\nNúmero elementos con parte decimal < 0,5 = {cuentaParteDecimalMenorA05}\n");

            double sumaElemParteEnteraMultiploDe3 = SumaElemParteEnteraMultiploDe3(reales);
            Console.Write($"\nSuma elementos con parte entera múltiplo de 3 = {sumaElemParteEnteraMultiploDe3}\n");

            double maximoCuyaParteDecimalMayorA05 = MaximoCuyaParteDecimalMayorA05(reales);
            Console.Write($"\nMáximo cuya parte decimal > 0,5 = {maximoCuyaParteDecimalMayorA05}\n");

            texto = "Elementos parte entera es primo: ";
            List<double> primos = ElementosParteEnteraEsPrimo(reales);
            primos.ForEach(n => texto = $"{texto} {n}");
            Console.WriteLine(texto);
            Console.WriteLine("Pulsa una tecla para finalizar...");
            Console.ReadKey();
        }

        public static int CuentaParteDecimalMenorA05(List<double> reales)
        {
            return reales
                .Select(n => n % 1)
                .Count(n => n < 0.5);
        }

        public static double SumaElemParteEnteraMultiploDe3(List<double> reales)
        {
            return reales
                .GroupBy(n => (int)n, (pk, n) => new { pk, n })
                .Where(g => g.pk != 0 && g.pk % 3 == 0)
                .Sum(g => g.n.Sum()); //A completar
        }

        public static double MaximoCuyaParteDecimalMayorA05(List<double> reales)
        {
            return reales.Max(n => n % 1 > 0.5 ? n : 0); //A completar
        }



        public static List<double> ElementosParteEnteraEsPrimo(List<double> reales)
        {
            return [.. reales
                    .Where(n =>
                            (int)n > 1 &&
                            Enumerable.Range(2, (int)Math.Sqrt((int)n - 1)
                            ).All(i => (int)n % i != 0) ||(int)n == 2
                        )
                    ]; //A completar
        }

    }
}

