public class Program
{

    //TODO: Completa el código necesario para cumplir los requisitos del ejercicio
    public static readonly string[] DIAS = ["lunes", "martes", "miercoles", "jueves", "viernes", "sabado", "domingo"];


    public static (string, int)[] CreaPedidosDiarios(string[] harinas, string dia)
    {
        (string tipoHarina, int cantidad)[] ventasDiarias = new (string, int)[harinas.Length];

        Console.WriteLine("-- Pedidos del " + dia + " --\n Introduce la cantidad pedida en KG, de:");

        for (var i = 0; i < harinas.Length; i++)
        {
            foreach (string harina in harinas)
            {
                ventasDiarias[i].tipoHarina = harina;

                Console.WriteLine(ventasDiarias[i].tipoHarina + ": ");
                ventasDiarias[i].cantidad = int.Parse(Console.ReadLine() ?? "0");
            }
        }

        return ventasDiarias;
    }

    public static (string, int)[][] CreaPedidosSemana(string[] harinas)
    {

        (string tipoHarina, int cantidad)[][] ventas = new (string, int)[DIAS.Length][];


        foreach (string dia in DIAS)
        {
            int i = 0;
            ventas[i] = CreaPedidosDiarios(harinas, dia);
            i++;
        }


        return ventas;
    }


    public static void MuestraPedidosSemana((string, int)[][] ventasSemanales)
    {
        Console.WriteLine("Resumen pedidos semana (Lun-Dom):");

        for (var i = 0; i < ventasSemanales.Length; i++)
        {
            Console.WriteLine(DIAS[i] + ": ");

            for (int j = 0; j < ventasSemanales[i].Length; j++)
            {
            }
        }
    }



    public static void Main()
    {
        string[] harinas = new string[] { "Trigo", "Centeno", "Espelta", "Maíz" };
        Console.WriteLine("Ejercicio 5. Panadería: pedidos semanales por tipo de harina\n");

        var semana = CreaPedidosSemana(harinas);
        MuestraPedidosSemana(semana);
        MuestraTotalesPedidos(semana, harinas);

        Console.WriteLine("\nPresiona cualquier tecla para salir...");
        Console.ReadKey();
    }
}


