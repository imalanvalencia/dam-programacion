using System;


namespace Ejercicio6
{
    public class Program
    {
        public class TemperaturasXProvincia
        {
            public string Provincia { get; }
            public float TemperaturaMaxima { get; }
            public float TemperaturaMinima { get; }
            public TemperaturasXProvincia(string provincia, float temperaturaMaxima, float temperaturaMinima)
            {
                Provincia = provincia;
                TemperaturaMaxima = temperaturaMaxima;
                TemperaturaMinima = temperaturaMinima;
            }


            override public string ToString()
            {
                return $"Provincia: {Provincia}, Temperatura máxima:" +
                       $"{TemperaturaMaxima}ºC, Temperatura mínima: {TemperaturaMinima}ºC.";
            }
        }

        public static float ObtenTemperaturaMaxima(TemperaturasXProvincia txp) => txp.TemperaturaMaxima;
        public static float ObtenTemperaturaMinima(TemperaturasXProvincia txp) => txp.TemperaturaMinima;
        public static bool MayorQue(float t1, float t2) => t1 > t2;
        public static bool MenorQue(float t1, float t2) => t1 < t2;
        public static bool IgualQue(float t1, float t2) => t1 == t2;

        public static float MediaTemperaturas(
                            TemperaturasXProvincia[] temperaturasPorProvincia,
                            Func<TemperaturasXProvincia, float> ot)
        {
            float media = 0;
            for (int i = 0; i < temperaturasPorProvincia.Length; i++)
                media += ot(temperaturasPorProvincia[i]);
            return media / temperaturasPorProvincia.Length;
        }

        public static void MuestraProvincias(
                            TemperaturasXProvincia[] temperaturasPorProvincia,
                            float media,
                            Func<TemperaturasXProvincia, float> ot,
                            Func<float, float, bool> p)
        {
            foreach (var temperaturaPorProvincia in temperaturasPorProvincia)
                if (p(ot(temperaturaPorProvincia), media))
                    Console.WriteLine(temperaturaPorProvincia.Provincia);
        }

        public static void MuestraProvincias(
                            TemperaturasXProvincia[] temperaturasPorProvincia)
        {
            foreach (var temperaturaPorProvincia in temperaturasPorProvincia)
                Console.WriteLine(temperaturaPorProvincia);
        }
        public static TemperaturasXProvincia[] RecogeTemperaturasPorProvincia()
        {
            Console.Write("\nDe cuantas provincias quieres recoger la temperatura: ");

            var temperaturasPorProvincia = new TemperaturasXProvincia[int.Parse(Console.ReadLine())];

            Random seed = new Random();
            for (int i = 0; i < temperaturasPorProvincia.Length; i++)
            {
                Console.Write($"Introduce la provincia nº{i + 1}:  ");
                string provincia = Console.ReadLine();
                float temperaturaMaxima = seed.Next(17, 25);
                float temperaturaMinima = seed.Next(-5, 17);
                Console.Write("\n\n");

                temperaturasPorProvincia[i] = new TemperaturasXProvincia(
                                                    provincia,
                                                    temperaturaMaxima,
                                                    temperaturaMinima);
            }
            return temperaturasPorProvincia;
        }

        public static void Main()
        {
            Console.WriteLine("Ejercicio 6. Ampliando Interfaces genéricas. Temperaturas por provincia\n");

            TemperaturasXProvincia[] temperaturasPorProvincia = RecogeTemperaturasPorProvincia();

            MuestraProvincias(temperaturasPorProvincia);


            float mediaMaximas = MediaTemperaturas(
                temperaturasPorProvincia,
                ObtenTemperaturaMaxima);

            Console.WriteLine($"\nMuestra las provincias con temperatura máxima superior a la media: {mediaMaximas}");
            MuestraProvincias(
                temperaturasPorProvincia, mediaMaximas,
                ObtenTemperaturaMaxima,
                MayorQue);

            float mediaMinimas = MediaTemperaturas(
                temperaturasPorProvincia,
                ObtenTemperaturaMinima);
            Console.WriteLine($"\nMuestra las provincias con temperatura mínima inferior a la media: {mediaMinimas}");
            MuestraProvincias(
                temperaturasPorProvincia, mediaMinimas,
                ObtenTemperaturaMinima,
                MenorQue);
            Console.WriteLine($"\nMuestra las provincias con temperatura mínima igual a la media: {mediaMinimas}");
            MuestraProvincias(
                temperaturasPorProvincia, mediaMinimas,
                ObtenTemperaturaMaxima,
                IgualQue);

            Console.WriteLine("\nFin de la aplicación.");
            Console.ReadKey();
        }
    }
}
