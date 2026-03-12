using System;

namespace Ejercicio3
{
    public class Principal
    {

        ///TODO: Define el código necesario para el ejercicio 
        public delegate void MuestraMatrizDelegate<T>(T[][] matriz);

        public static void Mostrar<T>(T[][] matriz)
        {
            for (int i = 0; i < matriz.Length; i++)
            {
                for (int j = 0; j < matriz[i].Length; j++)
                {
                    Console.Write($"{matriz[i][j],8}");
                }
                Console.WriteLine();
            }
        }

        public static void Main()
        {

            float[][] mNumeros = [[3, 4, 5], [2.4f, 4.4f, 5]];
            String[][] mPalabras = [["SAL", "AGUA", "AZUCAR", "VINO"], ["COLA", "CAFE", "ZUMO", "LECHE"]];

            Console.WriteLine("Ejercicio 3. Delegado genérico Comparador\n");
            MuestraMatrizDelegate<float> muestraNumeros = Mostrar;
            MuestraMatrizDelegate<string> muestraPalabras = Mostrar;
            
            muestraPalabras.Invoke(mPalabras);
            Console.WriteLine();
            muestraNumeros.Invoke(mNumeros);
            Console.WriteLine();


            ///TODO: Define el código necesario para el ejercicio
            Console.WriteLine("Pulsar una tecla para finalizar...");
            Console.ReadKey(true);

        }
    }
}
