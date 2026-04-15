using System.Collections;

public class SistemaIncidenciasException(string mensaje) : Exception(mensaje);

public class SistemaIncidencias : IEnumerable
{
    public Dictionary<string, Nodo> Nodos { get; }
    public Stack<IIncidencia> IncidenciasPendientes { get; }
    Action<string> LanzaNotificacion = (str) => Console.WriteLine(str);

    public SistemaIncidencias()
    {
        Nodos = [];
        IncidenciasPendientes = [];
    }

    public void RegistraNodo(Nodo nodo)
    {
        try
        {
            Nodos.Add(nodo.Nombre, nodo);
            LanzaNotificacion($"[NODO REGISTRADO] \n {nodo}");
        }
        catch (Exception)
        {
            throw new SistemaIncidenciasException($"El nodo {nodo.Nombre} ya existe");
        }
    }

    internal void RecibeIncidencia(IIncidencia incidencia)
    {
        IncidenciasPendientes.Push(incidencia);
        LanzaNotificacion($"[NUEVA INCIDENCIA PENDIENTE]: {incidencia.Id}");
    }

    internal void ResuelveIncidencia(IIncidencia incidencia)
    {
        foreach (var nodo in Nodos.Values)
        {
            if (nodo.Busca(incidencia))
            {
                nodo.Elimina(incidencia);
                return;
            }
        }
    }

    internal int ObtenTiempoEstimado() => Nodos.Values.Sum(n => n.ObtenCargaMinutos());


    internal void ProcesaPendientes()
    {
        if (Nodos.Values.All(n => n.TieneCapacidad))
        {
            var NodoMasEspacio = Nodos.Values.MaxBy(n => n.EspacioDisponible);
            IIncidencia inc = IncidenciasPendientes.Pop();
            NodoMasEspacio?.Asigna(inc);
        }
        else
        {
            throw new SistemaIncidenciasException("No hay espacio en ningun nodo");
        }
    }

    public IEnumerator GetEnumerator()
    {
        foreach (var nodo in Nodos.Values)
        {
            yield return nodo;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}