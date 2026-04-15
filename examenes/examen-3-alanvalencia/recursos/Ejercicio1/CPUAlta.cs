public class CPUAlta : IIncidencia
{

    public Guid Id { get; }

    public DateTime Fecha { get; }


    public Severidad Severidad { get; }

    public string Dispositivo { get; }

    public bool Resuelta { get; set; }
    public string NodoAsignado { get; set; }

    public int PuntosImpacto => (int)Severidad * 10 + (PorcentajeUso > 95f ? 20 : 0);

    public float PorcentajeUso { get; }

    public CPUAlta(string dispositivo, float porcentajeUso)
    {
        Id = new();
        Fecha = DateTime.Now;
        Resuelta = false;
        Dispositivo = dispositivo;
        PorcentajeUso = porcentajeUso;
        Severidad = porcentajeUso switch
        {
            >= 95f => Severidad.Critica,
            >= 85f => Severidad.Alta,
            _ => Severidad.Media
        };

        NodoAsignado = "";
    }

    public int CalculaMinutosResolucion() => (int)Severidad * 10;

    public void ObtenDescripcion() => Console.WriteLine($"CPU Alta detectada en {Dispositivo}: {PorcentajeUso}%");

    int IComparable<IIncidencia>.CompareTo(IIncidencia? other) => PuntosImpacto.CompareTo(other?.PuntosImpacto);

    bool IEquatable<IIncidencia>.Equals(IIncidencia? other) => Id.Equals(other?.Id);


}
