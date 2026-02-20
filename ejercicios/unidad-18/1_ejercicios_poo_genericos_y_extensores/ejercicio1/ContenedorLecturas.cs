public class ContenedorException(string message) : Exception(message);

public class ContenedorLecturas<T> where T : IComparable<T>
{
    private List<T> _contenedor = [];
    public IReadOnlyList<T> Lecturas => _contenedor.AsReadOnly();
    public int Conteo => _contenedor.Count;


    public T Ultima
    {
        get
        {
            if (_contenedor.Count == 0)
                throw new ContenedorException("No hay lecturas");
            return _contenedor[^1];
        }
    }

    public T Primera
    {
        get
        {
            if (_contenedor.Count == 0)
                throw new ContenedorException("No hay lecturas");
            return _contenedor[0];
        }
    }


    public void Agrega(T lectura)
    {
        foreach (T item in _contenedor)
        {
            if (item.CompareTo(lectura) != 0)
            {
                _contenedor.Add(lectura);
                return;
            }
        }

    }

    public T LecturaIndice(int indice)
    {
        if (indice < 0 || indice >= _contenedor.Count)
            throw new ContenedorException("Índice fuera de rango");
        return _contenedor[indice];
    }

    public override string ToString() => $"Lecturas ({Conteo}):{(Conteo > 0 ? string.Join(",", _contenedor) : string.Empty)}";

    public void Limpia() => _contenedor.Clear();

    public void AgregaRango(ContenedorLecturas<T> otro)
    {
        if (otro != null)
            foreach (var item in otro.Lecturas)
            {
                Agrega(item);
            }
    }
}
