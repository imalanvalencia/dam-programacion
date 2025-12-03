using System;
using System.Text;

namespace ejercicio3
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


        public static string Normaliza(string frase)
        {
            StringBuilder resultado = new();

            foreach (char caracter in frase)
            {
                if (char.IsLetter(caracter))
                    resultado.Append(SustituyeAcento(char.ToLower(caracter)));
            }

            return resultado.ToString();
        }



        static void Main(string[] args)
        {
            //TODO: Implementar la lógica necesaria. Fíjate en la salida por pantalla.

            Console.Write("Introduce una cadena: ");
            string frase = Console.ReadLine() ?? "";

            string fraseNormalizada = Normaliza(frase);
            Console.WriteLine("Normalizada: " + fraseNormalizada);
            Console.ReadLine();
        }

    }
}