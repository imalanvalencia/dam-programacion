public enum Severidad { Baja = 1, Media, Alta, Critica };
public enum EstadoNodo { Activo, Saturado, Caido, Mantenimiento };
public class IncidenciaException(string mensaje) : Exception(mensaje);

public interface IIncidencia : IComparable<IIncidencia>, IEquatable<IIncidencia>
{
    Guid Id { get; }
    DateTime Fecha { get; }
    Severidad Severidad { get; }
    string Dispositivo { get; }

    bool Resuelta { get; set; }
    string NodoAsignado { get; set; }

    int PuntosImpacto { get; }

    int CalculaMinutosResolucion();
    void ObtenDescripcion();
}
