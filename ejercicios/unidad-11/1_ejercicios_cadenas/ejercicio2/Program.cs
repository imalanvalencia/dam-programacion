using System;

namespace ejercicio2
{
    public class Program
    {
        //TODO: Implementar los métodos necesarios
        public static string FormateaString(string frase) => string.Join("", frase.ToLower().Split(' '));

        public static string Reverse(string frase)
        {
            string revereString = "";

            foreach (var character in frase)
            {
                revereString = character + revereString;
            }

            return revereString;
        }

        public static bool EsPalindroma(string frase) => FormateaString(frase) == FormateaString(Reverse(frase));

        static void Main(string[] args)
        {
            //TODO: Implementar la lógica necesaria. Fíjate en la salida por pantalla.

            Console.Write("Introduce una frase: ");
            string frase = Console.ReadLine() ?? "";

            Console.WriteLine(EsPalindroma(frase) ? "Es palíndroma" : "No es palíndroma");



            Console.WriteLine("Presiona cualquier tecla para salir...");
            Console.ReadLine();
        }

    }
}