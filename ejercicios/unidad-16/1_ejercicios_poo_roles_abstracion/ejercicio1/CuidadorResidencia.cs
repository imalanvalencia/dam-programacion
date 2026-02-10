public class CuidadorResidencia : PersonalCuidados
{
    public int PacientesAsignados { get; }
    public override List<TareaTurno> Tareas { get; } = [];

    public CuidadorResidencia(string nombre, string turno, int numeroPacientes) : base(nombre, turno)
    {
        PacientesAsignados = numeroPacientes;
    }

    public override void AñadeTareaTurno(TimeSpan hora, string descripcion) => Tareas.Add(new TareaTurno(hora, descripcion));
    public override void AñadeTareaTurno(TareaTurno tarea) => Tareas.Add(tarea);
    public override string DescripcionRol() => $"Supervisa y administra medicación a los pacientes";
    public override string GestionaTurno(DateTime horaActual) {
        foreach (var t in Tareas)
        {
            if (t.Hora <= horaActual.TimeOfDay)
            {
                return $"[{t.Hora:hh\\:mm}] Cuidador: {t.Descripcion}";
            }
        }
        return "No hay tareas asignadas para el momento actual.";
    }
    

    public override string ToString() => $"""
    Personal: {Nombre} - Rol: Cuidador
    Turno: {Turno}
    Pacientes asignados: {PacientesAsignados}
    Descripción: {DescripcionRol()}.
       - Tareas asignadas:
        {Tareas.ConvertAll(
            t => $"[{t.Hora:hh\\:mm}] Cuidador: {t.Descripcion}").Aggregate((a, b) => a + "\n        " + b
        )}
    """;
}
