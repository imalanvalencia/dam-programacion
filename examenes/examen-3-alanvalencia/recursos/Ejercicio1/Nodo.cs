public class NodoException(string mensaje) : Exception(mensaje);

public class Nodo : IComparable<Nodo>
{
    public string Nombre { get; }
    int CapacidadMaxima { get; }
    List<IIncidencia> IncidenciasAsignadas { get; }

    public Nodo(string nombre, int capacidadMaxima)
    {
        Nombre = nombre;
        CapacidadMaxima = capacidadMaxima;
        IncidenciasAsignadas = [];
    }


    public bool TieneCapacidad => IncidenciasAsignadas.Count < CapacidadMaxima;
    public int EspacioDisponible => CapacidadMaxima - IncidenciasAsignadas.Count;

    public void Asigna(IIncidencia incidencia)
    {
        if (!TieneCapacidad) throw new NodoException($"el nodo {Nombre} no tiene capacidad disponible");

        incidencia.NodoAsignado = Nombre;
        IncidenciasAsignadas.Add(incidencia);
    }

    public int ObtenCargaMinutos() => IncidenciasAsignadas.Sum(inc => inc.CalculaMinutosResolucion());
    public bool Busca(IIncidencia incidencia) => IncidenciasAsignadas.Contains(incidencia);
    public void Elimina(IIncidencia incidencia) => IncidenciasAsignadas.Remove(incidencia);

    public override string ToString() => $"Nombre: {Nombre} Capacidad Maxima: {CapacidadMaxima} Espacio Disponible: {EspacioDisponible} | Carga(min): {ObtenCargaMinutos()}";

    public int CompareTo(Nodo? other)
    {
        if (ObtenCargaMinutos() < other?.ObtenCargaMinutos()) return -1;
        if (ObtenCargaMinutos() > other?.ObtenCargaMinutos()) return 1;
        return 0;
    }
}
