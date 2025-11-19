using System;
using System.Reflection.Metadata.Ecma335;

namespace Ejercicio1
{

    public enum NivelDificultad { Facil = 1, Medio, Dificil, Extremo };

    public class Program
    {

        public static NivelDificultad RecogeNivel()
        {
            NivelDificultad nivelIntroducido;
            bool esValido;

            do
            {
                Console.Write("\nIntroduce el nivel deseado: ");
                string entrada = (Console.ReadLine() ?? "").Trim();

                esValido = Enum.TryParse(entrada, true, out nivelIntroducido);

                if (!esValido)
                {
                    Console.WriteLine($"Nivel no válido. Niveles disponibles: {string.Join(", ", Enum.GetNames(typeof(NivelDificultad)))}");
                }

            } while (!esValido);

            return nivelIntroducido;
        }

        public static int ObtenVidas(NivelDificultad nivelIntroducido) => nivelIntroducido switch
        {
            NivelDificultad.Facil => 10,
            NivelDificultad.Medio => 5,
            NivelDificultad.Dificil => 3,
            NivelDificultad.Extremo => 1,
            _ => 0,
        };


        public static int ObtenPuntosPorEnemigo(NivelDificultad nivelIntroducido) => nivelIntroducido switch
        {
            NivelDificultad.Facil => 5,
            NivelDificultad.Medio => 15,
            NivelDificultad.Dificil => 30,
            NivelDificultad.Extremo => 50,
            _ => 0,
        };


        public static void MuestraEstadisticas(NivelDificultad nivelIntroducido, int vidas, int vidaEnemigo) =>
            Console.WriteLine(
                "=== ESTADÍSTICAS DEL NIVEL ===" +
                $"Nivel: {nivelIntroducido}\nVidas: {vidas}\nPuntos por enemigo: {vidaEnemigo}");



        static void Main(string[] args)
        {
            Console.WriteLine("Ejercicio 1: Sistema de gestión de niveles de dificultad");

            string opcion;

            Console.WriteLine("=== CONFIGURACIÓN DE DIFICULTAD ===");
            Console.Write($"Niveles disponibles: ");
            Console.WriteLine(string.Join(" ,", Enum.GetNames(typeof(NivelDificultad))));

            do
            {
                NivelDificultad nivelJugador = RecogeNivel();
                int vidasJugador = ObtenVidas(nivelJugador);
                int vidasEnemigo = ObtenPuntosPorEnemigo(nivelJugador);

                MuestraEstadisticas(nivelJugador, vidasJugador, vidasEnemigo);

                Console.Write("\n¿Quieres probar otro nivel? (S/N): ");
                opcion = Console.ReadLine() ?? "N";

            } while (opcion.Equals("S", StringComparison.OrdinalIgnoreCase) || !opcion.Equals("N", StringComparison.OrdinalIgnoreCase));


            Console.WriteLine("¡Gracias por jugar!");
            Console.ReadLine();
        }
    }
}