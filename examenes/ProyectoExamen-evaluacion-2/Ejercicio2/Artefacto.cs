public record class CoordenadaGalactica(string Sector, int Cuadrante, string Sistema);

public abstract class Artefacto : IComparable
{
    private Guid Id { get; }
    public string Titulo { get; }
    public DateTime FechaIngreso { get; }
    private CoordenadaGalactica Ubicacion { get; }

    public Artefacto(string titulo, DateTime fechaIngreso, CoordenadaGalactica ubicacion)
    {clear

        Id = new();
        Titulo = titulo;
        FechaIngreso = fechaIngreso;
        Ubicacion = ubicacion;
    }

    public Artefacto(Artefacto copia)
    {
        Id = copia.Id;
        Titulo = copia.Titulo;
        FechaIngreso = copia.FechaIngreso;
        Ubicacion = copia.Ubicacion;
    }

    public override bool Equals(object? obj) => Id.Equals((obj as Artefacto)!.Id);

    public int CompareTo(object? obj) => FechaIngreso.CompareTo((obj as Artefacto)!.FechaIngreso);

 

    public abstract string Investiga();

    /*
    Holocron
    |
    --> Lado oscuro: Susurros Sith escuchados
    |
    --> Else: Proyeccion holografica activada

    PergaminoAntiguo
    |
    --> Contenido Decifrado: [...]
    |
    -->Else: Escritura borrosa, ilegible
    */
}
