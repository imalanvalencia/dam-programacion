using System;
using System.Text;

namespace ejercicio5
{
    public class Program
    {
        //TODO: Implementar los métodos necesarios
        public static string PidePalabraAAdivinar() { Console.Write("Introduce la palabra a adivinar: "); return Console.ReadLine() ?? string.Empty; }

        public static int PideMaximoFallos() { Console.Write("Introduce el número máximo de fallos permitidos: "); return int.Parse(Console.ReadLine() ?? "0"); }

        public static bool EstaLetraEnLetras(char letra, string letras) => letras.Contains(letra);

        public static bool EstaLetraEnLetrasAcertadas(char letra, string letrasAcertadas) =>
            EstaLetraEnLetras(letra, letrasAcertadas);

        public static bool EstaLetraEnLetrasFalladas(char letra, string letrasFalladas) =>
            EstaLetraEnLetras(letra, letrasFalladas);

        public static bool EstaLetraEnLetrasIntroducidas(char letra, string letrasAcertadas, string letrasFalladas) => EstaLetraEnLetrasAcertadas(letra, letrasAcertadas) || EstaLetraEnLetrasFalladas(letra, letrasFalladas);

        public static char PideLetraNoRepetida(string palabraParcialmenteAdivinada, string letrasFalladas)
        {
            Console.Write("Introduce una letra: ");
            bool letraValida;

            char letra;

            do
            {
                letraValida = char.TryParse(Console.ReadLine(), out letra);
                if (!letraValida || EstaLetraEnLetrasIntroducidas(letra, palabraParcialmenteAdivinada, letrasFalladas))
                {
                    Console.Write("Letra no válida o ya introducida. Introduce otra letra: ");
                    letraValida = false;
                }

            } while (!letraValida);

            return letra;
        }
        public static string Espaciada(string texto) => string.Join(" ", texto);

        public static void MuestraEstadoJuego(string palabraParcialmenteAdivinada, string letrasFalladas)
        {
            Console.Write("Palabra a adivinar: ");
        }
        public static void MuestraEstadoJuego(StringBuilder palabraParcialmenteAdivinada, StringBuilder letrasFalladas)
        {
            Console.WriteLine("Palabra: " + palabraParcialmenteAdivinada);
            Console.WriteLine("Fallos: " + letrasFalladas);
        }

        public static void AñadeLetraALetrasPalabraFalladas(in char letra, StringBuilder letrasFalladas) => letrasFalladas.Append(letra);
        
        public static void AñadeLetraALetrasPalabraAMostrar(string palabraAAdivinar, in char letra, StringBuilder palabraParcialmenteAdivinada)
        {
            for (int i = 0; i < palabraAAdivinar.Length; i++)
            {
                if (palabraAAdivinar[i] == letra)
                {
                    palabraParcialmenteAdivinada[i] = letra;
                }
            }
        }
        public static bool FinDeJuego(int numFallos, int maxFallos, string palabraAAdivinar, string palabraParcialmenteAdivinada, out string mensajeSiFin) { }
        public static void Jugar(string palabraAAdivinar, int maximoFallos)
        {
            Console.WriteLine("¡Comienza el juego!");

            do
            {

                MuestraEstadoJuego()
            } while (true);
        }
        static void Main(string[] args)
        {
            //TODO: Implementar la lógica necesaria. Fíjate en la salida por pantalla.
            string palabraAAdivinar = PidePalabraAAdivinar();
            int maximoFallos = PideMaximoFallos();

            Jugar(palabraAAdivinar, maximoFallos);
        }

    }
}