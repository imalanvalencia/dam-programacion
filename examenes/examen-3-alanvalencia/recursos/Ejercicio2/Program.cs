
using System.Text;

public record Venta(
 int ID,
 string Cliente,
 string Videojuego,
 string Plataforma,
 int Cantidad,
 double PrecioUnitario,
 bool EsPremium
);

public record Plataforma(
    string Nombre,
    List<string> Juegos,
    string Fabricante,
    string Version
);


public static class TiendaVideojuegos
{

    public static IEnumerable<Venta> Ventas
    {
        get
        {
            yield return new(1, "Ana", "FIFA 25", "PS5", 2, 69.99, true);
            yield return new(2, "Luis", "Zelda", "Switch", 1, 59.99, false);
            yield return new(3, "Marta", "Spider-Man 2", "PS5", 1, 74.99, true);
            yield return new(4, "Carlos", "Mario Kart 8", "Switch", 3, 49.99, false);
            yield return new(5, "Elena", "Halo Infinite", "Xbox", 2, 39.99, true);
            yield return new(6, "Pablo", "Forza Horizon 5", "Xbox", 1, 59.99, false);
            yield return new(7, "Lucía", "FIFA 25", "PS5", 1, 69.99, false);
            yield return new(8, "Ana", "Zelda", "Switch", 2, 59.99, true);
        }
    }

    public static IEnumerable<Plataforma> Plataformas
    {
        get
        {
            yield return new Plataforma("PS5", new List<string> { "FIFA 25", "Spider-Man 2" }, "Sony", "Gen 9");
            yield return new Plataforma("Switch", new List<string> { "Zelda", "Mario Kart 8" }, "Nintendo", "Gen 8");
            yield return new Plataforma("Xbox", new List<string> { "Halo Infinite", "Forza Horizon 5" }, "Microsoft", "Series X|S");
            yield return new Plataforma("PS4", new List<string> { "God of War", "Horizon Zero Dawn" }, "Sony", "Gen 8");
            yield return new Plataforma("PC", new List<string> { "Minecraft", "Baldur's Gate 3" }, "Varios", "Windows/Linux");
            yield return new Plataforma("SteamDeck", new List<string> { "Hades", "Stardew Valley" }, "Valve", "OLED");
        }
    }


}

internal class Program
{
    private static void Main(string[] args)
    {


        //CONSULTA 1: Obtener el importe total vendido en "Xbox".

        var totalXbox = TiendaVideojuegos.Ventas.Where(v => v.Plataforma == "Xbox").Sum(v => v.PrecioUnitario * v.Cantidad);


        Console.WriteLine($"Total vendido en Xbox: {totalXbox}");
        Console.WriteLine($"---------------------------------");


        //CONSULTA 2: Obtener el total de unidades vendidas de juegos que cuestan más de 60€.
        var totalUnidadesCaras = TiendaVideojuegos.Ventas.Where(v => v.PrecioUnitario > 60).Sum(v => v.Cantidad);

        Console.WriteLine($"Total unidades de juegos caros: {totalUnidadesCaras}");
        Console.WriteLine($"-------------------------------");


        //CONSULTA 3: Gasto por cliente

        var gastoPorCliente = TiendaVideojuegos
                                .Ventas
                                .GroupBy(
                                    v => v.Cliente,
                                    (gn, c) => new { Cliente = gn, GastoPorCliente = c.Sum(v => v.PrecioUnitario * v.Cantidad) }
                                )
                                .Select(v => $"{v.Cliente} ha gastado {v.GastoPorCliente:C2}");

        //Salida formateada
        Console.WriteLine($"{string.Join("\n", gastoPorCliente)}");
        Console.WriteLine($"----------------------------------");

        //CONSULTA 4: Cliente que compra más productos

        var clienteMasCompras = TiendaVideojuegos
                                .Ventas
                                .GroupBy(
                                    v => v.Cliente,
                                    (gn, c) => new { Cliente = gn, CantidadProductos = c.Sum(v => v.Cantidad) }
                                )
                                .OrderByDescending(v => v.CantidadProductos)
                                .First();

        Console.WriteLine($"Cliente con más compras: {clienteMasCompras}");
        Console.WriteLine($"----------------------------------");



        //CONSULTA 5: Lista el nombre de la plataforma, el fabricante y la lista de juegos disponibles
        var informacion = TiendaVideojuegos.Plataformas.Select(p => $"{p.Nombre} - {p.Fabricante}\n  {string.Join("\n  " , p.Juegos)}");

        //Salida formateada
        Console.WriteLine($"{string.Join("\n", informacion)}");

        Console.WriteLine($"----------------------------------");


        Console.ReadLine();
    }
}
