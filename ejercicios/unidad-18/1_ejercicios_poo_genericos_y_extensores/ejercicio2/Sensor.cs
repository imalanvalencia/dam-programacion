interface ISensor<T>
{
    T ValorActual { get; }
}

public class SensorBasico : ISensor<int>
{
    readonly Random random = new();
    public int ValorActual => random.Next(0, 101);
}

public class SensorPreciso : ISensor<double>
{
    readonly Random random = new();
    public double ValorActual => random.NextDouble() * 101 ;
}
