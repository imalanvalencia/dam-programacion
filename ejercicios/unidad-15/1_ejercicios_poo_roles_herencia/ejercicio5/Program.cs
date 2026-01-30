
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ejercicio5
{
    //TODO: Implementar las clases necesarias para el ejercicio 5
    public record class Direccion(string Ciudad, string Pais);
    public record class Reserva(int Plaza, bool EsTemporadaAlta);

    public class Albergue
    {
        public string Nombre { get; }
        public int Capacidad { get; }
        public Direccion Direccion { get; }
        public List<string> Servicios { get; set; }
        protected List<Reserva> Reservas { get; }

        public virtual double Precio { get; }

        public int PlazasOcupadas => Reservas.Sum(r => r.Plaza);
        protected int PorcentajeOcupacion => Capacidad == 0 ? 0 : PlazasOcupadas * 100 / Capacidad;

        public Albergue(string nombre, int capacidad, Direccion direccion, double precioBase)
        {
            Nombre = nombre;
            Capacidad = capacidad > 0 ? capacidad : 1;
            Direccion = direccion;
            Precio = precioBase;
            Servicios = [];
            Reservas = [];
        }


        public void AgregaServicio(string servicio)
        {
            if (!Servicios.Contains(servicio)) Servicios.Add(servicio);
            else Console.WriteLine(servicio + " ya existe");
        }

        private void AñadeReservaInterna(Reserva reserva)
        {
            Reservas.Add(reserva);
        }

        protected virtual bool AdmiteReserva(int NumeroPlazas, bool EsTemporadaAlta)
        {
            if (NumeroPlazas <= 0) return false;
            if (PlazasOcupadas + NumeroPlazas > Capacidad) return false;
            return true;
        }

        public bool RegistraReserva(int NumeroPlazas, bool EsTemporadaAlta)
        {
            if (!AdmiteReserva(NumeroPlazas, EsTemporadaAlta)) return false;
            AñadeReservaInterna(new Reserva(NumeroPlazas, EsTemporadaAlta));
            return true;
        }

        public virtual double CalculaPrecioActual() => Precio;

        public virtual string InformacionComplementaria() => "Sin información complementaria";

        public override string ToString()
        {
            var servicios = Servicios.Count > 0 ? string.Join(", ", Servicios) : "Ninguno";

            return $"{Nombre} - {GetType().Name} - Capacidad: {Capacidad} - Ocupación: {PorcentajeOcupacion}% - Servicios: {servicios}";
        }

        public int PlazasOcupadasPublic => PlazasOcupadas;
        public int PorcentajeOcupacionPublic => PorcentajeOcupacion;
    }


    public class AlbergueRural : Albergue
    {
        public AlbergueRural(string nombre, int capacidad, Direccion direccion, double precioBase)
            : base(nombre, capacidad, direccion, precioBase) { }

        protected override bool AdmiteReserva(int NumeroPlazas, bool EsTemporadaAlta)
        {
            if (NumeroPlazas > Capacidad * 0.5) return false;
            return base.AdmiteReserva(NumeroPlazas, EsTemporadaAlta);
        }

        public override double CalculaPrecioActual()
        {
            var basePrecio = base.CalculaPrecioActual();
            bool hayTemporada = Reservas.Any(r => r.EsTemporadaAlta);
            if (hayTemporada && PorcentajeOcupacion >= 20) return basePrecio * 2.15;
            return basePrecio * 1.15;
        }

        public override string InformacionComplementaria()
        {
            return "Clima previsto: Montañoso.";  
        }
    }

    public class AlbergueUrbano : Albergue
    {
        public AlbergueUrbano(string nombre, int capacidad, Direccion direccion, double precioBase)
            : base(nombre, capacidad, direccion, precioBase) { }

        public override double CalculaPrecioActual()
        {
            var basePrecio = base.CalculaPrecioActual();
            if (PorcentajeOcupacion >= 60) return basePrecio * 1.10;
            return basePrecio;
        }

        public override string InformacionComplementaria()
        {
            return "Eventos urbanos: actividad cultural y ocio en la ciudad.";
        }
    }

    public class AlbergueCostero : Albergue
    {
        public AlbergueCostero(string nombre, int capacidad, Direccion direccion, double precioBase)
            : base(nombre, capacidad, direccion, precioBase) { }

        protected override bool AdmiteReserva(int NumeroPlazas, bool EsTemporadaAlta)
        {
            int restante = Capacidad - PlazasOcupadas;
            if (EsTemporadaAlta && NumeroPlazas > restante * 0.6) return false;
            return base.AdmiteReserva(NumeroPlazas, EsTemporadaAlta);
        }

        public override double CalculaPrecioActual()
        {
            double precio = base.CalculaPrecioActual();
            if (Reservas.Count > 0 && Reservas.Last().EsTemporadaAlta) precio += 3;
            if (PorcentajeOcupacion >= 40) precio += 2;
            return precio;
        }

        public override string InformacionComplementaria()
        {
            return "Oleaje estimado: Moderado.";
        }
    }


    public class Program
    {
        //TODO: Crea los métodos necesarios
        public static void AñadeAlbergue(List<Albergue> albergues)
        {
            Console.Write("Tipo (Rural=R / Urbano=U / Costero=C): ");
            var tipo = Console.ReadLine()?.Trim().ToUpper();
            if (string.IsNullOrEmpty(tipo) || !(tipo == "R" || tipo == "U" || tipo == "C"))
            {
                Console.WriteLine("Tipo no válido");
                return;
            }
            Console.Write("Nombre: ");
            var nombre = Console.ReadLine() ?? "Sin nombre";
            Console.Write("Capacidad (>0): ");
            if (!int.TryParse(Console.ReadLine(), out int capacidad) || capacidad <= 0)
            {
                Console.WriteLine("Capacidad no válida");
                return;
            }
            Console.Write("Precio base (>0): ");
            if (!double.TryParse(Console.ReadLine(), out double precio) || precio <= 0)
            {
                Console.WriteLine("Precio no válido");
                return;
            }
            Console.Write("Ciudad: ");
            var ciudad = Console.ReadLine() ?? "";
            Console.Write("País: ");
            var pais = Console.ReadLine() ?? "";
            Console.Write("Servicios (separados por coma): ");
            var serviciosRaw = Console.ReadLine() ?? "";
            var servicios = serviciosRaw.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => s.Trim()).Where(s => s.Length > 0).ToList();

            Albergue nuevo = tipo switch
            {
                "R" => new AlbergueRural(nombre, capacidad, new Direccion(ciudad, pais), precio),
                "U" => new AlbergueUrbano(nombre, capacidad, new Direccion(ciudad, pais), precio),
                _ => new AlbergueCostero(nombre, capacidad, new Direccion(ciudad, pais), precio),
            };
            nuevo.Servicios = servicios;
            albergues.Add(nuevo);
            Console.WriteLine($"Albergue '{nombre}' añadido.");
        }

        public static void RegistraReserva(List<Albergue> albergues)
        {
            Console.WriteLine("Listado de albergues:");
            for (int i = 0; i < albergues.Count; i++) Console.WriteLine($"({i}) {albergues[i].Nombre}");
            Console.Write("Elija índice: ");
            if (!int.TryParse(Console.ReadLine(), out int idx) || idx < 0 || idx >= albergues.Count)
            {
                Console.WriteLine("Índice inválido");
                return;
            }
            var seleccionado = albergues[idx];
            Console.Write("Plazas a reservar: ");
            if (!int.TryParse(Console.ReadLine(), out int plazas) || plazas <= 0)
            {
                Console.WriteLine("Número de plazas no válido");
                return;
            }
            Console.Write("¿Temporada alta? (S/N): ");
            var ta = Console.ReadLine();
            bool esTemporada = ta != null && ta.Trim().Equals("S", StringComparison.OrdinalIgnoreCase);

            int antes = seleccionado.PlazasOcupadasPublic;
            bool ok = seleccionado.RegistraReserva(plazas, esTemporada);
            int despues = seleccionado.PlazasOcupadasPublic;
            var estado = ok ? "ACEPTADA" : "RECHAZADA";
            var tipoTemp = esTemporada ? "ALTA" : "BAJA";
            Console.WriteLine($"[Reserva] {seleccionado.Nombre}: {plazas} plazas ({tipoTemp}) => {estado}. ");
            if (ok)
            {
                Console.WriteLine($"Ocupación ahora {despues}/{seleccionado.Capacidad} ({seleccionado.PorcentajeOcupacionPublic}%)");
            }
        }

        public static void MuestraEstado(List<Albergue> albergues)
        {
            Console.WriteLine("\n=== ESTADO ACTUAL ===");
            foreach (var a in albergues)
            {
                var servicios = a.Servicios != null && a.Servicios.Count > 0 ? string.Join(", ", a.Servicios) : "";
                Console.WriteLine($"{a.Nombre} ({a.GetType().Name}) - Capacidad: {a.Capacidad}, Ocupación: {a.PorcentajeOcupacionPublic}%, Servicios: [{servicios}]");
                Console.WriteLine($"Precio base: {FormatPrice(a.Precio)} ,Precio actual: {FormatPrice(a.CalculaPrecioActual())}");
            }
        }

        public static void MuestraInfoComplementaria(List<Albergue> albergues)
        {
            Console.WriteLine("\nInformación complementaria:");
            foreach (var a in albergues)
            {
                Console.WriteLine($"{a.Nombre} => {a.InformacionComplementaria()}");
            }
        }

        public static string FormatPrice(double v)
        {
            return v.ToString("0.##").Replace('.', ',');
        }


        public static void GestionAlbergues()
        {
            var albergues = new List<Albergue>
            {
                new AlbergueRural("Montaña Verde", 40, new Direccion("Granada", "España"), 22.00) { Servicios = ["Desayuno","Cena","Rutas"] },
                new AlbergueUrbano("City Hostel", 80, new Direccion("Madrid", "España"), 18.00) { Servicios = ["WiFi","Lavandería"] },
                new AlbergueCostero("Surf Point", 55, new Direccion("Tarifa", "España"), 20.00) { Servicios = ["Clases de surf","Parking"] }
            };

            albergues[0].RegistraReserva(3, false);
            albergues[1].RegistraReserva(5, false);
            albergues[2].RegistraReserva(10, false);


            ConsoleKeyInfo key;
            do
            {
                Console.WriteLine("\n--- MENÚ GESTIÓN ALBERGUES ---");
                Console.WriteLine("[1] Añadir albergue");
                Console.WriteLine("[2] Registrar reserva");
                Console.WriteLine("[3] Muestra estado");
                Console.WriteLine("[4] Muestra información complementaria");
                Console.WriteLine("[ESC] Salir");
                Console.Write("Seleccione opción: ");

                key = Console.ReadKey(intercept: true);

                Console.WriteLine(key.Key == ConsoleKey.Escape ? " ESC " : key.KeyChar.ToString());

                if (key.Key == ConsoleKey.Escape) Console.WriteLine("Saliendo del gestor...");

                switch (key.KeyChar)
                {
                    case '1':
                        AñadeAlbergue(albergues);
                        break;
                    case '2':
                        RegistraReserva(albergues);
                        break;
                    case '3':
                        MuestraEstado(albergues);
                        break;
                    case '4':
                        MuestraInfoComplementaria(albergues);
                        break;
                    default:
                        Console.WriteLine("Opción no reconocida");
                        break;
                }

            } while (!(key.Key == ConsoleKey.Escape));

        }



        public static void Main(string[] args)
        {
            GestionAlbergues();

            Console.WriteLine("\nPulse una tecla para continuar...");
            Console.ReadKey();
        }


    }
}
