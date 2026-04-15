public class TemperaturAlta : IIncidencia
{
    public Guid Id { get; }

    public DateTime Fecha { get; }

    public Severidad Severidad { get; }

    public string Dispositivo { get; }

    public bool Resuelta { get; set; }
    public string NodoAsignado { get; set; }

    public int PuntosImpacto => (int)Grados - 60 switch
    {
        < 0 => (int)Severidad * 10,
        _ => (int)Grados - 60 + ((int)Severidad * 10)
    };

    public float Grados { get; }

    public TemperaturAlta(string dispositivo, float gradosCelsius)
    {
        Id = new();
        Fecha = DateTime.Now;
        Resuelta = false;
        Dispositivo = dispositivo;
        Grados = gradosCelsius;
        Severidad = gradosCelsius switch
        {
            >= 90f => Severidad.Critica,
            >= 80f => Severidad.Alta,
            _ => Severidad.Media
        };

        NodoAsignado = "";
    }

    public int CalculaMinutosResolucion() => (int)Severidad * 10;

    public void ObtenDescripcion() => Console.WriteLine($"Temperatura Alta detectada en {Dispositivo}: {Grados} ºC");

    int IComparable<IIncidencia>.CompareTo(IIncidencia? other) => PuntosImpacto.CompareTo(other?.PuntosImpacto);

    bool IEquatable<IIncidencia>.Equals(IIncidencia? other) => Id.Equals(other?.Id);
}