namespace Ejercicio4;

public interface ISensor<T>
{
    T ValorActual { get; }
}

public class SensorBasico : ISensor<int>
{
    readonly Random random = new();
    public int ValorActual => random.Next(0, 101);
}

public class SensorPreciso : ISensor<float>
{
    readonly Random random = new();
    public float ValorActual => (float)(random.NextDouble() * (100 - 0 + 1) + 0);
}

public class SensorMuyPreciso : ISensor<double>
{
    readonly Random random = new();
    public double ValorActual => random.NextDouble() * (100 - 0 + 1) + 0;
}


