
using System;


public class Rotulador
{
    public enum Color { Rojo, Azul, Verde, Negro, Amarillo, Blanco, Naranja, Cafe, Gris, Rosado, Violeta };
}


public static class Estuche
{
    // obtener 
    public const int NUMERO_ROTULADORES = 10;

    public static Rotulador[] GetRotuladores()
    {
        Rotulador[] rotuladores = [];

        for (int i = 0; i < NUMERO_ROTULADORES; i++)
        {
            rotuladores = [..rotuladores, new Rotulador()];
        }

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
        return new Circulo(radio);
    }
}


public class Pincel
{

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
