using System;
using System.Text;

namespace ejercicio4
{
    // Traduce según las tres reglas indicadas

    public class Program
    {
        // Implementación usando switch a través de wrappers con indexadores
        private static readonly string[] Numeros = ["cero", "uno", "dos", "tres", "cuatro", "cinco", "seis", "siete", "ocho", "nueve"];

        private static bool EsVocal(char caracter) => caracter is 'a' or 'e' or 'i' or 'o' or 'u';

        private static string TransformaEmoji(char vocal) => vocal switch
        {
            'a' => "😂",
            'e' => "😄",
            'i' => "😆",
            'o' => "🤣",
            _ => "😒"
        };

        private static int IntentaProcesarRisa(string cadena, int posicionActual, StringBuilder sb)
        {
            if (posicionActual + 1 >= cadena.Length || cadena[posicionActual] != 'j')
                return 0;

            char vocal = cadena[posicionActual + 1];

            if (!EsVocal(vocal))
                return 0;

            string emoji = TransformaEmoji(vocal);
            int i = posicionActual;
            int count = 0;

            int tamañoRisa = 4;
            bool hayRisa = i + tamañoRisa - 1 < cadena.Length &&
                             cadena[i] == 'j' && cadena[i + 1] == vocal &&
                             cadena[i + 2] == 'j' && cadena[i + 3] == vocal;

            while (hayRisa)
            {
                sb.Append(emoji);
                count++;
                i += tamañoRisa;

                hayRisa = i + tamañoRisa - 1 < cadena.Length &&
                            cadena[i] == 'j' && cadena[i + 1] == vocal &&
                            cadena[i + 2] == 'j' && cadena[i + 3] == vocal;
            }

            return count * 4;
        }

        private static string NormalizaEspacios(string texto)
        {
            StringBuilder sb = new();
            bool hayEspacioAntes = false;

            foreach (char ch in texto)
            {
                if (char.IsWhiteSpace(ch))
                {
                    if (!hayEspacioAntes)
                        sb.Append(' ');
                    hayEspacioAntes = true;
                }
                else
                {
                    sb.Append(ch);
                    hayEspacioAntes = false;
                }
            }

            return sb.ToString().Trim();
        }

        public static string TraducirTiko(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return texto;

            StringBuilder sb = new();
            char ultimo = '\0';

            for (int i = 0; i < texto.Length; i++)
            {
                char c = texto[i];
                int avance = IntentaProcesarRisa(texto, i, sb);

                if (avance > 0)
                {
                    i += avance;
                }

                else if (char.IsDigit(c))
                {
                    sb.Append(Numeros[c - '0']).Append(' ');
                    ultimo = ' ';
                }

                else if (char.IsLetter(c))
                {
                    if (c != ultimo)
                    {
                        sb.Append(c);
                        ultimo = c;
                    }
                }

                else if (char.IsWhiteSpace(c))
                {
                    if (ultimo != ' ')
                    {
                        sb.Append(' ');
                        ultimo = ' ';
                    }
                }
                else
                {
                    sb.Append(c);
                    ultimo = c;
                }
            }

            return NormalizaEspacios(sb.ToString());
        }


        static void Main(string[] args)
        {
            //TODO: Implementar la lógica necesaria. Fíjate en la salida por pantalla.
            Console.Write("Introduce una frase: ");
            string entrada = Console.ReadLine() ?? string.Empty;
            string salida = TraducirTiko(entrada);
            Console.WriteLine("Tiko extendido: " + salida);
        }

    }
}