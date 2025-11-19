using System;

namespace Ejercicio2
{
    public enum TipoAbono { QuinceDias = 70, TreintaDias = 60, FamiliasNumerosas = 50, TerceraEdad = 30, Discapacidad = 20, Juvenil = 65, Infantil = 35, Turistico = 90 };





    public class Program
    {
        //TODO: Implementar los métodos necesarios

        public static TipoAbono RecogeAbono()
        {
            TipoAbono abono;
            bool valido;

            do
            {
                Console.Write("Introduce el tipo de abono: ");
                valido = Enum.TryParse(Console.ReadLine(), true, out abono);

                if (!valido)
                    Console.WriteLine($"Abono no válido. Abonos disponibles: " + string.Join(", ", Enum.GetNames(typeof(TipoAbono))));
                else
                    Console.WriteLine("Tipo de abono seleccionado: " + abono + "\n");


            } while (!valido);


            return abono;
        }

        public static bool EsAbonoFijo(TipoAbono abono) => abono == TipoAbono.QuinceDias || abono == TipoAbono.TreintaDias;

        public static int RecogeDias(TipoAbono abono)
        {
            Console.WriteLine("Los abonos QuinceDias y TreintaDias tienen duración fija.");
            if (!EsAbonoFijo(abono))
            {
                int dias;
                bool diasValido;
                do
                {
                    Console.Write("Para otros abonos, introduce días (mínimo 7, máximo 60): ");
                    diasValido = int.TryParse(Console.ReadLine(), out dias);
                }
                while (!diasValido || dias < 7 || dias > 60);
                return dias;
            }

            else if (abono == TipoAbono.QuinceDias)
                return 15;

            else
                return 30;
        }

        public static (double costeTotal, int dias) CalculaCosteTotal(TipoAbono precioViaje, int dias) => ((int)precioViaje * dias / 100.0, dias);

        public static void MuestraDetalle(TipoAbono tipoAbono, double precioViaje, int dias, double total) => Console.Write("\n=== DETALLES DEL ABONO ===\nTipo de abono: {0}\nPrecio por viaje: {1}:C2 \nDías del abono: {2} \nCoste total del abono: {3}:C2 ", tipoAbono, precioViaje, dias, total);

        static void Main(string[] args)
        {
            Console.WriteLine("Ejercicio 2: Control de abono de transporte urbano");
            //TODO: Implementar la lógica necesaria

            Console.WriteLine("=== CALCULADORA DE ABONOS ===");
            Console.WriteLine("Tipos de abono disponibles: " + string.Join(", ", Enum.GetNames(typeof(TipoAbono))) + "\n");

            string opcion;

            do
            {
                TipoAbono abonoUsuario = RecogeAbono();
                (double costeTotal, int dias) = CalculaCosteTotal(abonoUsuario, RecogeDias(abonoUsuario));

                MuestraDetalle(abonoUsuario, (int)abonoUsuario / 100.0, dias, costeTotal);

                Console.Write("\n¿Quieres probar otro nivel? (S/N): ");
                opcion = Console.ReadLine() ?? "N";

            } while (opcion.Equals("S", StringComparison.OrdinalIgnoreCase) || !opcion.Equals("N", StringComparison.OrdinalIgnoreCase));

            Console.WriteLine("¡Gracias por usar nuestro servicio!");
            Console.ReadLine();
        }
    }
}
