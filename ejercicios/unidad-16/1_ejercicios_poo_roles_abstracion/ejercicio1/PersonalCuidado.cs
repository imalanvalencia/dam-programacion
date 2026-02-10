public record class TareaTurno(TimeSpan Hora, string Descripcion);

public abstract class PersonalCuidados
{
    public string Nombre { get; }
    public string Turno { get; }
    public abstract List<TareaTurno> Tareas { get; }

    public PersonalCuidados(string nombre, string turno)
    {
        Nombre = nombre;
        Turno = turno;
    }

    public abstract void AñadeTareaTurno(TimeSpan hora, string descripcion);
    public abstract void AñadeTareaTurno(TareaTurno tareaTurno);

    public abstract string DescripcionRol();
    public virtual string GestionaTurno(DateTime horaActual)
    {
        foreach (var t in Tareas)
        {
            if (t.Hora <= horaActual.TimeOfDay)
            {
                return $"[{t.Hora:hh\\:mm}] {DescripcionRol()}: {t.Descripcion}";
            }
        }
        return "No hay tareas asignadas para el momento actual.";
    }

    public override string ToString() => $"""
    Personal: {Nombre} - Rol: Enfermero
    Turno: {Turno}
    Descripción: {DescripcionRol()}.
       - Tareas asignadas:
        {Tareas.ConvertAll(
            t => GestionaTurno(new DateTime(2025, 9, 10, t.Hora.Hours, t.Hora.Minutes, t.Hora.Seconds))).Aggregate((a, b) => a + "\n        " + b
        )}
    """;
}
