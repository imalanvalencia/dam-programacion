namespace ControlFebrero
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Coche c1 = new("SUZSAN90", "Suzuki", "Santana", 250);
            //nombre mal
            Coche c2 = new("SonSxN90", "Suzuki", "Santana", 250);
            // no esta marca
            Coche c3 = new("DESROM32", "Roma", "Santana", 250);

            Moto m1 = new("BMWNOS17", "Bmw", "NOSE", 300);

            FabricaVehiculo fabrica = new();

            Console.WriteLine(fabrica.ToString());

            fabrica.AnyadeVehiculo(c1);
            fabrica.AnyadeVehiculo(new Coche(c1), true);
            fabrica.AnyadeVehiculo(c2);
            fabrica.AnyadeVehiculo(c3);
            fabrica.AnyadeVehiculo(m1, true);


            Console.WriteLine("Pulsa una tecla para continuar...");
            Console.ReadKey();
        }
    }
}