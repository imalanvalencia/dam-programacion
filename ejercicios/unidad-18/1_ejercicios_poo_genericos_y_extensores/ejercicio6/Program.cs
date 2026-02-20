using System;
//TODO: Incluye el código necesario para implementar las entidades que se piden en el ejercicio
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
        //TODO: Implementa el código para instanciar los objetos y conseguir la salida
        
        Console.WriteLine("\nFin de la aplicación.");
        Console.ReadKey();
    }
}