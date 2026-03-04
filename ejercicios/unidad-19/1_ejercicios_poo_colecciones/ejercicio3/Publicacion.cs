using ejercicio3;

public class Publicacion : IEquatable<Publicacion>, IComparable<Publicacion>
{
    public DateTime Id { get; set; }
    public Usuario Autor { get; set; }
    public string Contenido { get; set; }
    public int Likes { get; set; }
    public List<string> Comentarios { get; set; }

    public Publicacion(DateTime id, Usuario autor, string contenido, int likes)
    {
        Id = id;
        Autor = autor;
        Contenido = contenido;
        Likes = likes;
        Comentarios = [];
    }


    public bool Equals(Publicacion? otro)
    {
        if (otro is null) return false;
        return Id == otro.Id;
    }

    public override bool Equals(object? obj)
    {
        if (obj is Publicacion otro) return Equals(otro);
        return false;
    }

    public override int GetHashCode() => Id.GetHashCode();

    public int CompareTo(Publicacion? otro) => otro == null ? 1 : Id.CompareTo(otro.Id);
}


public class PublicacionEqualityComparer : IEqualityComparer<Publicacion>
{
    public bool Equals(Publicacion? obj1, Publicacion? obj2)
    {
        if (obj1 is null || obj2 is null) return false;
        return obj1.Id == obj2.Id;
    }

    public int GetHashCode(Publicacion obj) => obj.Id.GetHashCode();
}

public class PublicacionComparer : IComparer<Publicacion>
{
    public int Compare(Publicacion? obj1, Publicacion? obj2) => (obj1 is null || obj2 is null) ? 0 : obj1.Id.CompareTo(obj2.Id);
}