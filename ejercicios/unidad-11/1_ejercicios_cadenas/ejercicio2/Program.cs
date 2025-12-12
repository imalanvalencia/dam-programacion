using System;
using System.Text;

namespace ejercicio2
{
    public class Program
    {
        //TODO: Implementar los métodos necesarios

        public static char SustituyeAcento(char caracter) => caracter switch
        {
            'á' or 'à' or 'ä' or 'â' => 'a',
            'é' or 'è' or 'ë' or 'ê' => 'e',
            'í' or 'ì' or 'ï' or 'î' => 'i',
            'ó' or 'ò' or 'ö' or 'ô' => 'o',
            'ú' or 'ù' or 'ü' or 'û' => 'u',
            _ => caracter,
        };

        public static string FormateaString(string frase)
        {
            StringBuilder cadenaFormateada = new(string.Join("", frase.Split(" ")).ToLower());

            foreach (var character in cadenaFormateada.ToString())
            {
                if (char.IsLetter(character))
                {
                    cadenaFormateada.Replace(character, SustituyeAcento(character));
                }
            }

            return cadenaFormateada.ToString();
        }

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