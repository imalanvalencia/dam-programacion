
public static class ReglasDescuento
{
    public static double DescuentoPorCantidad(double importe, int cantidad, bool esVip) => cantidad switch
    {
        > 10 => importe * 0.15,
        > 5 => importe * 0.05,
        _ => 0
    };

    public static double DescuentoVip(double importe, int cantidad, bool esVip)
    {
        if (esVip)
            return importe * 0.20;
        return 0;
    }

    public static double DescuentoCombinado(double importe, int cantidad, bool esVip) => DescuentoPorCantidad(importe, cantidad, esVip) + DescuentoVip(importe, cantidad, esVip);

}


public class Ejercicio2
{
    public static void ProcesaPedido(double importe, int cantidad, bool esVip, Func<double, int, bool, double> reglaDescuento)
    {
        double descuento = reglaDescuento(importe, cantidad, esVip);
        double total = importe - descuento;
        Console.WriteLine($"Descuento aplicado: {descuento:C2}, Precio Final: {total:C2}");
    }
    public static void Ejercicio2Main()
    {
        Console.WriteLine("Ejercicio 2. Delegados con parámetros variados");

        // Caso 1: VIP, mucha cantidad
        double importe1 = 1000;
        int cantidad1 = 12;
        bool esVip1 = true;

        Console.WriteLine($"\nPedido 1: Importe={importe1}, Cantidad={cantidad1}, VIP={esVip1}");

        Console.WriteLine("-> Usando DescuentoPorCantidad:");
        ///TODO: Llamar a ProcesaPedido con la regla de descuento 
        ProcesaPedido(importe1, cantidad1, esVip1, ReglasDescuento.DescuentoPorCantidad);
        Console.WriteLine("-> Usando DescuentoVip:");
        ///TODO: Llamar a ProcesaPedido con la regla de descuento DescuentoVip
        ProcesaPedido(importe1, cantidad1, esVip1, ReglasDescuento.DescuentoVip);


        Console.WriteLine("-> Usando DescuentoCombinado:");
        ///TODO: Llamar a ProcesaPedido con la regla de descuento DescuentoCombinado
        ProcesaPedido(importe1, cantidad1, esVip1, ReglasDescuento.DescuentoCombinado);

        // Caso 2: No VIP, poca cantidad
        double importe2 = 500;
        int cantidad2 = 3;
        bool esVip2 = false;

        Console.WriteLine($"\nPedido 2: Importe={importe2}, Cantidad={cantidad2}, VIP={esVip2}");

        Console.WriteLine("-> Usando DescuentoPorCantidad:");
        ///TODO: Llamar a ProcesaPedido con la regla de descuento DescuentoPorCantidad
        ProcesaPedido(importe2, cantidad2, esVip2, ReglasDescuento.DescuentoPorCantidad);

        Console.WriteLine("-> Usando DescuentoVip:");
        ///TODO: Llamar a ProcesaPedido con la regla de descuento DescuentoVip
        ProcesaPedido(importe2, cantidad2, esVip2, ReglasDescuento.DescuentoVip);

        Console.WriteLine("-> Usando DescuentoCombinado:");
        ///TODO: Llamar a ProcesaPedido con la regla de descuento DescuentoCombinado
        ProcesaPedido(importe2, cantidad2, esVip2, ReglasDescuento.DescuentoCombinado);

        Console.WriteLine("Pulsar una tecla para finalizar...");
        Console.ReadKey(true);
    }
}
