internal class Program
{
    enum TipoFruta { Manzana, Piña, Naranja, Frambuesa }
    enum TamañoPaquete { P, G }

    static double[] precios = [1, 1, 1.25, 1.50];

    /* 
    Recipientes sol P O G
    manzana | piña = 1
    naranja = 1.25
    frambuesa = 1.50

    if es grande y es frambuesa o naranja precio + .50
     */

    static TipoFruta PideFruta()
    {
        TipoFruta fruta;
        bool frutaValida;

        do
        {
            Console.Write($"Introduce una fruta, Opciones validas ({string.Join(", ", Enum.GetNames(typeof(TipoFruta)))}): ");
            frutaValida = Enum.TryParse(Console.ReadLine(), true, out fruta);

        } while (!frutaValida);
        return fruta;

    }

    static TamañoPaquete PideTamaño()
    {
        TamañoPaquete tamaño;
        bool tamañoValido;

        do
        {
            Console.Write($"Introduce un tamaño de paquete, Opciones validas ({string.Join(", ", Enum.GetNames(typeof(TamañoPaquete)))}): ");
            tamañoValido = Enum.TryParse(Console.ReadLine(), true, out tamaño);

        } while (!tamañoValido);

        return tamaño;
    }

    static double PrecioAdicional(TipoFruta fruta, TamañoPaquete tamaño)
    {
        return tamaño switch
        {
            TamañoPaquete.G when fruta == TipoFruta.Frambuesa => 0.5,
            TamañoPaquete.G when fruta == TipoFruta.Naranja => 0.5,
            _ => 0
        };
    }

    static double CalculaPrecio(TipoFruta fruta, TamañoPaquete tamaño)=>  precios[(int)fruta] + PrecioAdicional(fruta, tamaño);

    private static void Main(string[] args)
    {

        TipoFruta fruta = PideFruta();
        TamañoPaquete tamaño = PideTamaño();

        double precioPagar = CalculaPrecio(fruta, tamaño);


        Console.WriteLine("Fruta elegida {0} \nTamaño Elegido {1} \nPrecio a Pagar: {2}", fruta, tamaño, precioPagar);


        Console.ReadLine();
    }
}



















































































































































































































































































































// init: XC-MA