using System;
using System.Collections.Generic;
using System.Text;

//TODO: Añade el código necesario para implementar los requisitos del ejercicio

public class Program
{
     public static void Main(string[] args)
    {
        GestionaPersonal();
        Console.ReadKey();
        Console.WriteLine("Presiona cualquier tecla para salir...");
        Console.ReadKey();
    }

    public static void GestionaPersonal()
    {
        Console.WriteLine("Ejercicio 1: Gestión de personal de cuidados\n\nCreando personal...\n");
        var enfermero = new Enfermero("Ana Ruiz", "Noche", 12);
        enfermero.AñadeTareaTurno(new TimeSpan(8, 0, 0), "Entrega de turno y repaso de incidencias.");
        enfermero.AñadeTareaTurno(new TimeSpan(23, 0, 0), "Realiza ronda de control y prepara medicación nocturna.");
        enfermero.AñadeTareaTurno(new TareaTurno(new TimeSpan(3, 0, 0), "Atiende emergencias y revisa signos vitales de pacientes críticos."));
        enfermero.AñadeTareaTurno(new TareaTurno(new TimeSpan(19, 0, 0), "Prepara informes de pacientes y coordina con el equipo médico."));
        var cuidador = new CuidadorResidencia("Luis Pérez", "Mañana", 3);
        cuidador.AñadeTareaTurno(new TimeSpan(7, 0, 0), "Ayuda en el aseo matutino.");
        cuidador.AñadeTareaTurno(new TimeSpan(15, 0, 0), "Revisión de habitaciones y apoyo a residentes con necesidades especiales.");
        cuidador.AñadeTareaTurno(new TareaTurno(new TimeSpan(12, 0, 0), "Asiste en la hora de la comida y supervisa la ingesta alimentaria."));
        var lista = new List<PersonalCuidados> { enfermero, cuidador };
        Console.WriteLine("Mostrando información:");
        foreach (var p in lista)
        {
            Console.WriteLine(p.ToString());
        }
        Console.WriteLine();
        Console.WriteLine("  - Gestión de turno a las 23:00:");
        DateTime hora1 = new DateTime(2025, 9, 10, 23, 0, 0);
        Console.WriteLine(enfermero.GestionaTurno(hora1));
        Console.WriteLine(cuidador.GestionaTurno(hora1));
        Console.WriteLine();
        Console.WriteLine("  - Gestión de turno a las 15:00:");
        DateTime hora2 = new DateTime(2025, 9, 10, 15, 0, 0);
        Console.WriteLine(enfermero.GestionaTurno(hora2));
        Console.WriteLine(cuidador.GestionaTurno(hora2));
        Console.WriteLine();
    }
}
