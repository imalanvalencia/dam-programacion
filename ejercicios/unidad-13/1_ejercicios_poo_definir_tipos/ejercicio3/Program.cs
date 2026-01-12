
using System;

public enum Color { Rojo, Azul, Verde, Negro, Amarillo, Blanco, Naranja, Cafe, Gris, Rosado, Violeta };

public class Rotulador
{
    public Color ColorRotulador { get; private set; }
    
    public Rotulador(string nombreColor)
    {
        ColorRotulador = ConvertirStringAColor(nombreColor);
    }
    
    private Color ConvertirStringAColor(string nombreColor)
    {
        return nombreColor.ToLower() switch
        {
            "rojo" => Color.Rojo,
            "azul" => Color.Azul,
            "verde" => Color.Verde,
            "negro" => Color.Negro,
            "amarillo" => Color.Amarillo,
            "blanco" => Color.Blanco,
            "naranja" => Color.Naranja,
            "cafe" => Color.Cafe,
            "gris" => Color.Gris,
            "rosado" => Color.Rosado,
            "violeta" => Color.Violeta,
            _ => throw new ArgumentException("Color no válido")
        };
    }
    
    public Color ObtenerColor()
    {
        return ColorRotulador;
    }
    
    public void Rotula(float perimetro)
    {
        Console.WriteLine($"Rotulado el perímetro de {perimetro.ToString("F2", System.Globalization.CultureInfo.GetCultureInfo("es-ES"))} cm de color {ColorRotulador}");
    }
}


public static class Estuche
{
    public const int NUMERO_ROTULADORES = 5;

    public static Rotulador[] GetRotuladores()
    {
        Rotulador[] rotuladores =
        [
            new Rotulador("Rojo"),
            new Rotulador("Azul"),
            new Rotulador("Verde"),
            new Rotulador("Amarillo"),
            new Rotulador("Negro"),
        ];
        return rotuladores;
    }
}

public class Circulo
{
    public float Radio { get; set; }

    public Circulo(float radio)
    {
        Radio = radio;
    }


    public float Area()
    {
        return (float)(Math.PI * Radio * Radio);
    }

    public float Perimetro()
    {
        return (float)(2 * Math.PI * Radio);
    }
}


public class Compas
{
    public Circulo DibujaCirculo(float radio)
    {
        Console.WriteLine($"Dibujado un círculo de radio {radio.ToString("F1", System.Globalization.CultureInfo.GetCultureInfo("es-ES"))} cm");
        return new Circulo(radio);
    }
}


public class Pincel
{
    public Color ColorPincel { get; private set; }
    
    public void SetColor(Color color)
    {
        ColorPincel = color;
    }
    
    public void Pinta(float area)
    {
        Console.WriteLine($"Pintada el área de {area.ToString("F2", System.Globalization.CultureInfo.GetCultureInfo("es-ES"))} cm² de color {ColorPincel}");
    }
}

public class Program

{
    //TODO: Implementar la lógica necesaria para gestionar el sistema de dibujo

    static void Main()
    {
        Console.WriteLine("Ejercicio 3: Sistema de dibujo con herramientas");
        Console.WriteLine();

        Compas compas = new Compas();
        Circulo circulo = compas.DibujaCirculo(3.5f);
        Rotulador rotulador = Estuche.GetRotuladores()
                              [
                                  new Random().Next(0, Estuche.NUMERO_ROTULADORES)
                              ];
        rotulador.Rotula(circulo.Perimetro());
        Pincel pincel = new Pincel();
        pincel.SetColor(Color.Verde);
        pincel.Pinta(circulo.Area());

        Console.WriteLine("¡Dibujo completado con éxito!");
        Console.WriteLine("Presiona cualquier tecla para salir...");
        Console.ReadKey();
    }
}
