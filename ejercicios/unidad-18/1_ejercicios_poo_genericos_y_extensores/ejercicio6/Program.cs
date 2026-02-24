using System;

public interface IObténTemperatura
{
    float Temperatura(TemperaturasXProvincia t);
}

public interface ICumplePredicado<T>
{
    bool Predicado(T o1, T o2);
}

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
        return $"Provincia: {Provincia}, Temperatura máxima:{TemperaturaMaxima}ºC, Temperatura mínima: {TemperaturaMinima}ºC.";
    }

    public class ObténMaxima : IObténTemperatura
    {
        public float Temperatura(TemperaturasXProvincia t) => t.TemperaturaMaxima;
    }

    public class ObténMinima : IObténTemperatura
    {
        public float Temperatura(TemperaturasXProvincia t) => t.TemperaturaMinima;
    }

    public class MayorQue : ICumplePredicado<float>
    {
        public bool Predicado(float o1, float o2) => o1 > o2;
    }

    public class MenorQue : ICumplePredicado<float>
    {
        public bool Predicado(float o1, float o2) => o1 < o2;
    }

    public class IgualQue : ICumplePredicado<float>
    {
        public bool Predicado(float o1, float o2) => Math.Abs(o1 - o2) < 0.0001f;
    }
}

public class Program
{
    public static float MediaTemperaturas(
                        TemperaturasXProvincia[] temperaturasPorProvincia,
                        IObténTemperatura ot)
    {
        float media = 0;
        for (int i = 0; i < temperaturasPorProvincia.Length; i++)
            media += ot.Temperatura(temperaturasPorProvincia[i]);
        return media / temperaturasPorProvincia.Length;
    }

    public static void MuestraProvincias(
                        TemperaturasXProvincia[] temperaturasPorProvincia,
                        float media,
                        IObténTemperatura ot,
                        ICumplePredicado<float> p)
    {
        foreach (var temperaturaPorProvincia in temperaturasPorProvincia)
            if (p.Predicado(ot.Temperatura(temperaturaPorProvincia), media))
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
        string? inputNum = Console.ReadLine();
        int numProvincias = string.IsNullOrEmpty(inputNum) ? 3 : int.Parse(inputNum);

        var temperaturasPorProvincia = new TemperaturasXProvincia[numProvincias];

        Random seed = new Random();
        string[] nombres默认 = ["Alicante", "Castellón", "Valencia"];
        
        for (int i = 0; i < temperaturasPorProvincia.Length; i++)
        {
            Console.Write($"Introduce la provincia nº{i + 1}:  ");
            string? provincia = Console.ReadLine();
            provincia = string.IsNullOrEmpty(provincia) ? nombres默认[i % nombres默认.Length] : provincia;
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
        
        var temperaturas = RecogeTemperaturasPorProvincia();
        MuestraProvincias(temperaturas);

        var obtieneMax = new TemperaturasXProvincia.ObténMaxima();
        var obtieneMin = new TemperaturasXProvincia.ObténMinima();
        var mayorQue = new TemperaturasXProvincia.MayorQue();
        var menorQue = new TemperaturasXProvincia.MenorQue();
        var igualQue = new TemperaturasXProvincia.IgualQue();

        float mediaMaximas = MediaTemperaturas(temperaturas, obtieneMax);
        float mediaMinimas = MediaTemperaturas(temperaturas, obtieneMin);

        Console.WriteLine($"\nMuestra las provincias con temperatura máxima superior a la media: {mediaMaximas}");
        MuestraProvincias(temperaturas, mediaMaximas, obtieneMax, mayorQue);

        Console.WriteLine($"\nMuestra las provincias con temperatura mínima inferior a la media: {mediaMinimas}");
        MuestraProvincias(temperaturas, mediaMinimas, obtieneMin, menorQue);

        Console.WriteLine($"\nMuestra las provincias con temperatura mínima igual a la media: {mediaMinimas}");
        MuestraProvincias(temperaturas, mediaMinimas, obtieneMin, igualQue);

        Console.WriteLine("\nFin de la aplicación.");
    }
}
