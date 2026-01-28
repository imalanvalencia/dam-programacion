
using System;


using System.Text;
using System.Collections.Generic;


namespace Ejercicio3
{

    public record Habilidad(string Nombre, int Daño);

    public class Personaje
    {
        public string Nombre { get; }
        public int Energia { get; protected set; }
        public List<Habilidad> Habilidades { get; }
        public int Nivel => Energia / 10;

        public Personaje(string nombre, int energia, List<Habilidad> habilidades)
        {
            Nombre = nombre;
            Energia = energia;
            Habilidades = new List<Habilidad>();
            if (habilidades == null || habilidades.Count == 0)
                Habilidades.Add(new Habilidad("No Hábil", 0));
            else
                Habilidades.AddRange(habilidades);
        }

        public void AñadeHabilidad(Habilidad habilidad)
        {
            if (habilidad != null)
                Habilidades.Add(habilidad);
        }

        public virtual string Ataca()
        {
            var principal = Habilidades[0];
            foreach (var h in Habilidades)
                if (h.Daño > principal.Daño) principal = h;

            return $"{Nombre} ataca con {principal.Nombre}";
        }

        public virtual string ACadena()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Personaje: {Nombre}, Nivel: {Nivel}, Energía: {Energia}");
            sb.AppendLine("  Habilidades:");
            foreach (var h in Habilidades)
                sb.AppendLine($"    * {h.Nombre} (Daño: {h.Daño})");
            return sb.ToString();
        }
    }

    public class Guerrero : Personaje
    {
        public int Fuerza { get; }

        public Guerrero(string nombre, int energia, List<Habilidad> habilidades, int fuerza)
            : base(nombre, energia, habilidades)
        {
            Fuerza = fuerza;
        }

        public override string Ataca()
        {
            var totalDaño = 0;
            foreach (var h in Habilidades) totalDaño += h.Daño;

            int total = Fuerza + (totalDaño / 2);
            return $"{base.Ataca()}! (fuerza {Fuerza} + mitad habilidades = {total})";
        }

        public override string ACadena()
        {
            var sb = new StringBuilder(base.ACadena());
            sb.AppendLine($"  Fuerza: {Fuerza}");
            return sb.ToString();
        }
    }

    public class Mago : Personaje
    {
        public int Mana { get; }

        public Mago(string nombre, int energia, List<Habilidad> habilidades, int mana)
            : base(nombre, energia, habilidades)
        {
            Mana = mana;
        }

        public override string Ataca()
        {
            var totalDaño = 0;
            foreach (var h in Habilidades) totalDaño += h.Daño;

            return $"{base.Ataca()}! lanza {Habilidades[0].Nombre} con fuerza {Habilidades[0].Daño} y se apoya con: (maná {Mana} + total habilidades = {totalDaño + Mana})";
        }

        public override string ACadena()
        {
            var sb = new StringBuilder(base.ACadena());
            sb.AppendLine($"  Maná: {Mana}");
            return sb.ToString();
        }
    }

    public class Program
    {

        public static void GestionPersonajes()
        {
            Console.WriteLine("Ejercicio 3: Sistema de Personajes\n");

            // Habilidades para el Guerrero
            var habilidadesGuerrero = new List<Habilidad>
            {
                new Habilidad("Furia", 50),
                new Habilidad("Golpe Giratorio", 30)
            };
            Guerrero conan = new Guerrero("Conan", 100, habilidadesGuerrero, 20);
            Console.WriteLine("=== Creando un Guerrero ===");
            Console.WriteLine($"Guerrero creado: {conan.ACadena()} ");

            // Habilidades para el Mago
            var habilidadesMago = new List<Habilidad>
            {
                new Habilidad("Rayo", 40),
                new Habilidad("Bola de Fuego", 70),
                new Habilidad("Escarcha", 25)
            };
            Mago gandalf = new Mago("Gandalf", 120, habilidadesMago, 50);
            Console.WriteLine("=== Creando un Mago ===");
            Console.WriteLine($"Mago creado: {gandalf.ACadena()}");

            // Añadir una habilidad más al mago
            gandalf.AñadeHabilidad(new Habilidad("Telequinesis", 10));

            Console.WriteLine($"Mago con nueva habilidad añadida: {gandalf.ACadena()}");

            Console.WriteLine("=== Acciones de los personajes ===");
            Console.WriteLine("--- Guerrero ---");
            Console.WriteLine(conan.Ataca());
            Console.WriteLine("\n--- Mago ---");
            Console.WriteLine(gandalf.Ataca());
        }

        static void Main(string[] args)
        {
            GestionPersonajes();
            Console.WriteLine("\nPresiona cualquier tecla para salir...");
            Console.ReadKey();
        }


    }


}
