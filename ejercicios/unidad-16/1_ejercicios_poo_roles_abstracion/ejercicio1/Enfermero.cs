public class Enfermero : PersonalCuidados
{
    public int PacientesAsignados { get; }
    public override List<TareaTurno> Tareas { get; } = [];

    public Enfermero(string nombre, string turno, int numeroPacientes) : base(nombre, turno)
    {
        PacientesAsignados = numeroPacientes;
    }

    public override void AñadeTareaTurno(TimeSpan hora, string descripcion) => Tareas.Add(new TareaTurno(hora, descripcion));
    public override void AñadeTareaTurno(TareaTurno tarea) => Tareas.Add(tarea);
    public override string DescripcionRol() => $"Supervisa y administra medicación a los pacientes";
    public override string GestionaTurno(DateTime horaActual)
    {
        return base.GestionaTurno(horaActual);
    }

    public override string ToString() => $"""
    Personal: {Nombre} - Rol: Enfermero
    Turno: {Turno}
    Pacientes asignados: {PacientesAsignados}
    Descripción: {DescripcionRol()}.
       - Tareas asignadas:
        {Tareas.ConvertAll(
            t => GestionaTurno(new DateTime(2025, 9, 10, t.Hora.Hours, t.Hora.Minutes, t.Hora.Seconds))).Aggregate((a, b) => a + "\n        " + b
        )}
    """;
}