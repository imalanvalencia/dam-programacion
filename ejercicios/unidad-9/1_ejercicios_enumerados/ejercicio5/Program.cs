using System;

namespace Ejercicio5
{

    public class Program
    {
        //TODO: Implementar los métodos necesarios
        [Flags]
        public enum TurnoTrabajo
        {
            Ninguno = 0b_0000_0000,    // 0
            Mañana = 0b_0000_0001,     // 1
            Tarde = 0b_0000_0010,      // 2
            Noche = 0b_0000_0100,      // 4
            FinDeSemana = 0b_0000_1000 // 8
        }

        public static TurnoTrabajo ParseaTurnos(string turnosKey)
        {
            char[] turnosKeyChar = turnosKey.ToCharArray();
            TurnoTrabajo turnos = TurnoTrabajo.Ninguno;

            foreach (char turno in turnosKeyChar)
            {
                turnos |= CaracterATurno(turno);
            }

            return turnos;
        }

        public static TurnoTrabajo CaracterATurno(char turno) =>
                                char.ToUpper(turno) switch
                                {
                                    'M' => TurnoTrabajo.Mañana,
                                    'T' => TurnoTrabajo.Tarde,
                                    'N' => TurnoTrabajo.Noche,
                                    'F' => TurnoTrabajo.FinDeSemana,
                                    _ => TurnoTrabajo.Ninguno
                                };


        public static bool TieneTurno(TurnoTrabajo turnosEmpleado, TurnoTrabajo turnoAPreguntar) => (turnosEmpleado & turnoAPreguntar) != 0;

        public static int CalculaHorasSemanales(TurnoTrabajo turnos)
        {
            int horas = 0;

            if (TieneTurno(turnos, TurnoTrabajo.Mañana))
                horas += 8;

            if (TieneTurno(turnos, TurnoTrabajo.Tarde))
                horas += 8;

            if (TieneTurno(turnos, TurnoTrabajo.Noche))
                horas += 8;

            if (TieneTurno(turnos, TurnoTrabajo.FinDeSemana))
                horas += 10;

            return horas;
        }

        public static double CalculaSalario(TurnoTrabajo turnos)
        {
            double salario = 0;

            if (TieneTurno(turnos, TurnoTrabajo.Mañana))
                salario += 8 * 10;

            if (TieneTurno(turnos, TurnoTrabajo.Tarde))
                salario += 8 * 10;

            if (TieneTurno(turnos, TurnoTrabajo.Noche))
                salario += 8 * 15;

            if (TieneTurno(turnos, TurnoTrabajo.FinDeSemana))
                salario += 10 * 20;

            return salario;
        }

        public static TurnoTrabajo AñadeTurno(TurnoTrabajo turnosActuales, TurnoTrabajo nuevoTurno) => turnosActuales | nuevoTurno;

        public static TurnoTrabajo QuitaTurno(TurnoTrabajo turnosActuales, TurnoTrabajo turnoAQuitar) => turnosActuales & ~turnoAQuitar;


        public static void MuestraInformacion(string nombreEmpleado, TurnoTrabajo turnos)
        {
            Console.WriteLine("=== INFORMACIÓN DEL EMPLEADO ===");
            Console.WriteLine($"Empleado: {nombreEmpleado}");

            string turnosActivos = "";

            if (!TieneTurno(turnos, TurnoTrabajo.Ninguno)) turnosActivos += "Ninguno";
            if (TieneTurno(turnos, TurnoTrabajo.Mañana)) turnosActivos += "Mañana, ";
            if (TieneTurno(turnos, TurnoTrabajo.Tarde)) turnosActivos += "Tarde, ";
            if (TieneTurno(turnos, TurnoTrabajo.Noche)) turnosActivos += "Noche, ";
            if (TieneTurno(turnos, TurnoTrabajo.FinDeSemana)) turnosActivos += "FinDeSemana, ";

            if (turnosActivos.EndsWith(", "))
                turnosActivos = turnosActivos.Substring(0, turnosActivos.Length - 2);

            Console.WriteLine($"Turnos: {turnosActivos}");

            int horas = CalculaHorasSemanales(turnos);
            double salario = CalculaSalario(turnos);

            Console.WriteLine($"Horas semanales: {horas}");
            Console.WriteLine($"Salario base: {salario:F2}€\n");
        }


        static void Main(string[] args)
        {
            //El método Main se os da resuelto, cuando hayas realizado el resto de métodos
            //puedes descomentar las líneas siguientes
            Console.WriteLine("Ejercicio 5: Sistema de turnos de trabajo con flags");
            Console.WriteLine();
            Console.WriteLine("=== GESTIÓN DE TURNOS ===");

            string nombreEmpleado = "Juan Pérez";
            Console.WriteLine($"Empleado: {nombreEmpleado}");
            Console.WriteLine();

            Console.WriteLine("Turnos disponibles:");
            Console.WriteLine("M = Mañana, T = Tarde, N = Noche, F = FinDeSemana");
            Console.WriteLine();

            Console.Write("Introduce turnos asignados (ej: MTF): ");
            string inputTurnos = Console.ReadLine() ?? "";

            TurnoTrabajo turnosEmpleado = ParseaTurnos(inputTurnos);

            Console.WriteLine("=== INFORMACIÓN DEL EMPLEADO ===");

            MuestraInformacion(nombreEmpleado, turnosEmpleado);
            Console.WriteLine();
            string operacion;
            do
            {
                Console.WriteLine("Operaciones disponibles:");
                Console.WriteLine("A = Añadir turno, Q = Quitar turno, M = Mostrar info, S = Salir");
                Console.WriteLine();
                Console.Write("Operación: ");
                operacion = Console.ReadLine()?.ToUpper() ?? "";

                switch (operacion)
                {
                    case "A":
                        Console.Write("Turno a añadir (M/T/N/F): ");
                        char turnoAñadir = Console.ReadKey().KeyChar;
                        Console.WriteLine();

                        TurnoTrabajo nuevoTurno = CaracterATurno(turnoAñadir);
                        if (nuevoTurno != TurnoTrabajo.Ninguno)
                        {
                            turnosEmpleado = AñadeTurno(turnosEmpleado, nuevoTurno);
                            Console.WriteLine($"Turno {nuevoTurno} añadido.");
                        }
                        break;

                    case "Q":
                        Console.Write("Turno a quitar (M/T/N/F): ");
                        char turnoQuitar = Console.ReadKey().KeyChar;
                        Console.WriteLine();

                        TurnoTrabajo turnoAEliminar = CaracterATurno(turnoQuitar);
                        if (turnoAEliminar != TurnoTrabajo.Ninguno)
                        {
                            turnosEmpleado = QuitaTurno(turnosEmpleado, turnoAEliminar);
                            Console.WriteLine($"Turno {turnoAEliminar} quitado.");
                        }
                        break;

                    case "M":
                        Console.WriteLine("=== INFORMACIÓN DEL EMPLEADO ===");
                        MuestraInformacion(nombreEmpleado, turnosEmpleado);
                        break;

                    case "S":
                        Console.WriteLine("¡Hasta luego!");
                        break;

                    default:
                        Console.WriteLine("Operación no válida.");
                        break;
                }

                Console.WriteLine();

            } while (operacion != "S");
            Console.ReadLine();
        }
    }
}
