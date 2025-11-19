using System;

namespace Ejercicio4

{

    public class Program
    {
        //TODO: Implementar los métodos necesarios
        public enum DiaSemana { Lunes, Martes, Miercoles, Jueves, Viernes, Sabado, Domingo };

        public enum PlatoVegetariano { EnsaladaDeQuinoa, CurryDeGarbanzos, HamburguesaVegetal, SopaDeLentejas, PastaConPesto, FalafelConEnsalada, TortillaDeEspinacas, CremaDeCalabaza, SushiVegetariano, PizzaVegetariana, BowlDeAvenaConFrutas, SmoothieVerde, WrapDeVerdurasYHummus, ArrozFritoConTofu, CazuelaDeVegetales, ChilesRellenosDeQueso, GnocchiConSalsaDeTomate, BerenjenasAlHornoConQueso };

        public static int[] caloriasPlatos = [350, 400, 300, 250, 450, 400, 200, 150, 500, 500, 350, 200, 300, 400, 300, 350, 450, 250];
        private static bool EstaPlatoRepetido(PlatoVegetariano platoAleatorio, PlatoVegetariano[] platos)
        {
            foreach (PlatoVegetariano plato in platos)
            {
                if (plato == platoAleatorio)
                    return true;
            }

            return false;
        }

        public static PlatoVegetariano[] GeneraDietaSemana()
        {

            int cantidadDePlatos = Enum.GetValues(typeof(PlatoVegetariano)).Length;
            PlatoVegetariano[] platos = new PlatoVegetariano[7];

            Random aleatorio = new();

            Console.WriteLine("Generando dieta aleatoria para la semana...");

            for (int i = 0; i < platos.Length; i++)
            {
                PlatoVegetariano platoGenerado;

                do
                {
                    platoGenerado = (PlatoVegetariano)aleatorio.Next(cantidadDePlatos);
                }
                while (EstaPlatoRepetido(platoGenerado, platos));

                platos[i] = platoGenerado;
            }

            return platos;
        }

        public static void MuestraDietaSemana(PlatoVegetariano[] dietaSemanal)
        {
            Console.WriteLine("=== DIETA DE LA SEMANA ===");

            for (var i = 0; i < dietaSemanal.Length; i++)
            {
                Console.WriteLine("{0}: {1} ({2} calorias)", (DiaSemana)i, dietaSemanal[i], caloriasPlatos[(int)dietaSemanal[i]]);
            }
        }

        public static DiaSemana DiaConMenosCalorias(PlatoVegetariano[] dietaSemanal)
        {
            int dia = 0;
            int caloriasMin = caloriasPlatos[(int)dietaSemanal[0]];

            for (int i = 0; i < dietaSemanal.Length; i++)
            {
                int caloriasActual = caloriasPlatos[(int)dietaSemanal[i]];
                if (caloriasActual < caloriasMin)
                {
                    caloriasMin = caloriasActual;
                    dia = i;
                }
            }

            return (DiaSemana)dia;
        }

        public static DiaSemana DiaConMasCalorias(PlatoVegetariano[] dietaSemanal)
        {
            int dia = 0;
            int caloriasMax = caloriasPlatos[(int)dietaSemanal[0]];

            for (int i = 0; i < dietaSemanal.Length; i++)
            {
                int caloriasActual = caloriasPlatos[(int)dietaSemanal[i]];
                if (caloriasActual > caloriasMax)
                {
                    caloriasMax = caloriasActual;
                    dia = i;
                }
            }

            return (DiaSemana)dia;
        }


        public static int CaloriasDieta(PlatoVegetariano[] dietaSemanal)
        {
            int caloriasTotales = 0;

            for (int i = 0; i < dietaSemanal.Length; i++)
            {
                caloriasTotales += caloriasPlatos[(int)dietaSemanal[i]];
            }

            return caloriasTotales;
        }

        public static double PromedioCaloriasDiarias(PlatoVegetariano[] dietaSemanal) => CaloriasDieta(dietaSemanal) / 7.0;


        public static void MuestraAnalisisNutricional(PlatoVegetariano[] dieta)
        {
            Console.WriteLine("=== ANÁLISIS NUTRICIONAL ===");

            DiaSemana diaMas = DiaConMasCalorias(dieta);
            DiaSemana diaMenos = DiaConMenosCalorias(dieta);

            Console.WriteLine("Calorías totales de la semana: {0}", CaloriasDieta(dieta));
            Console.WriteLine("Promedio de calorías por día: {0}", PromedioCaloriasDiarias(dieta));

            Console.WriteLine("Día con menos calorías: {0}({1} - {2} calorías)", diaMenos, dieta[(int)diaMenos], caloriasPlatos[(int)dieta[(int)diaMenos]]);
            Console.WriteLine("Día con más calorías: {0}({1} - {2} calorías)", diaMas, dieta[(int)diaMas], caloriasPlatos[(int)dieta[(int)diaMenos]]);

        }

        static void Main(string[] args)
        {
            Console.WriteLine("Ejercicio 4: Dieta semanal vegetariana");
            Console.WriteLine();

            //TODO: Implementar la lógica necesaria

            Console.WriteLine("=== GENERADOR DE DIETA SEMANAL ===");

            string opcion;

            do
            {
                Console.WriteLine("=== NUEVA DIETA GENERADA ===");
                PlatoVegetariano[] dieta = GeneraDietaSemana();

                MuestraDietaSemana(dieta);
                MuestraAnalisisNutricional(dieta);

                Console.Write("\n¿Quieres probar otro nivel? (S/N): ");
                opcion = Console.ReadLine() ?? "N";

            } while (opcion.Equals("S", StringComparison.OrdinalIgnoreCase) || !opcion.Equals("N", StringComparison.OrdinalIgnoreCase));


            Console.WriteLine("¡Que disfrutes de tu dieta vegetariana!");

            Console.ReadLine();
        }
    }
}
