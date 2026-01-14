using System;
//TODO: Implementa la lógica pedida en el ejercicio


public record Juguete(string Nombre, double Precio)
{
    public Juguete CalculaDescuento(double porcentaje)
    {
        double precioConDescuento = Precio * (1 - porcentaje / 100);
        return new Juguete(Nombre, precioConDescuento);
        // return this with { Precio = precioConDescuento };
    }
}

public enum EscalaTemperatura
{
    Celsius,
    Fahrenheit,
    Kelvin
}

public record Temperatura
{
    /* 
    Celsius: -273.15°C (cero absoluto)
    Fahrenheit: -459.67°F (cero absoluto)
    Kelvin: 0.0ºK (cero absoluto) 
    */
    public double Grados { get; set; }
    public EscalaTemperatura Escala { get; }

    public Temperatura(double grados, EscalaTemperatura escala)
    {
        Escala = escala;

        Grados = Escala switch
        {
            EscalaTemperatura.Celsius when grados < -273.15 => -273.15 ,
            EscalaTemperatura.Fahrenheit when grados < -459.67 => -459.67,
            EscalaTemperatura.Kelvin when grados < 0.0 => 0.0,
            _ => grados
        };
    }

    public Temperatura ConvierteA(EscalaTemperatura nueva)
    {
        if (Escala == nueva)
            return this;

        double gradosEnCelsius = Escala switch
        {
            EscalaTemperatura.Celsius => Grados,
            EscalaTemperatura.Fahrenheit => (Grados - 32) * 5 / 9,
            EscalaTemperatura.Kelvin => Grados - 273.15,
            _ => Grados
        };

        double gradosConvertidos = nueva switch
        {
            EscalaTemperatura.Celsius => gradosEnCelsius,
            EscalaTemperatura.Fahrenheit => (gradosEnCelsius * 9 / 5) + 32,
            EscalaTemperatura.Kelvin => gradosEnCelsius + 273.15,
            _ => gradosEnCelsius
        };

        return new Temperatura(gradosConvertidos, nueva);
    }

};



public static class Program
{
    //TODO: Implementa la lógica pedida en el ejercicio
    public static void GestionJuguete()
    {
        Juguete jugueteOriginal = new("Pelota", 15.50);
        Console.WriteLine($"Juguete original: {jugueteOriginal}");

        Juguete jugueteConDescuento = jugueteOriginal with { Precio = 12.40 };
        Console.WriteLine($"Juguete con descuento usando 'with': {jugueteConDescuento}");

        Juguete jugueteRenombrado = jugueteOriginal with { Nombre = "Pelota Roja" };
        Console.WriteLine($"Juguete renombrado usando 'with': {jugueteRenombrado}");
        Juguete jugueteModificado = new("Muñeca", 25.99);
        Console.WriteLine($"Juguete modificado completamente: {jugueteModificado}");

        Console.WriteLine("\n--- Operaciones con juguetes ---");
        double precioPromedio = (jugueteOriginal.Precio + jugueteConDescuento.Precio) / 2;
        Console.WriteLine($"Precio promedio entre juguete original y con descuento: {precioPromedio:F2}€");
        double diferenciaPrecio = jugueteOriginal.Precio - jugueteConDescuento.Precio;
        Console.WriteLine($"Diferencia de precio: {diferenciaPrecio:F2}€");

    }

    public static void GestionTemperatura()
    {
        Console.WriteLine("=== RECORDS EXTENDIDOS (Value Objects con validación) ===");
        Console.WriteLine("Creando temperaturas con records extendidos y validación...\n");

        Console.WriteLine("--- Creación exitosa ---");
        Temperatura tempAmbiente = new(22.5, EscalaTemperatura.Celsius);
        Console.WriteLine($"Temperatura ambiente: {tempAmbiente}");

        Temperatura tempAguaHirviendo = new(100.0, EscalaTemperatura.Celsius);
        Console.WriteLine($"Temperatura agua hirviendo: {tempAguaHirviendo}");

        Temperatura tempAguaCongelando = new(32.0, EscalaTemperatura.Fahrenheit);
        Console.WriteLine($"Temperatura agua congelando: {tempAguaCongelando}\n");

        Console.WriteLine("--- Conversiones de temperatura (creando nuevos objetos) ---");
        Temperatura tempAmbienteF = tempAmbiente.ConvierteA(EscalaTemperatura.Fahrenheit);
        Console.WriteLine($"22.5°C convertido a Fahrenheit: {tempAmbienteF}");

        Temperatura tempAguaHirviendoK = tempAguaHirviendo.ConvierteA(EscalaTemperatura.Kelvin);
        Console.WriteLine($"100°C convertido a Kelvin: {tempAguaHirviendoK}");

        Temperatura tempAguaCongelandoC = tempAguaCongelando.ConvierteA(EscalaTemperatura.Celsius);
        Console.WriteLine($"32°F convertido a Celsius: {tempAguaCongelandoC}");

    }

    public static void Main()
    {
        Console.WriteLine("Ejercicio 5: Records como Value Objects\n");
        GestionJuguete();
        Console.WriteLine();
        // GestionTemperatura();
        Console.WriteLine("Pulsa cualquier tecla para continuar...");
        Console.ReadKey();
    }


}
