using System;
using System.Text;

public class Program
{

  // TODO: Implementa la lógica del resto de métodos

  public static double[] GeneraNumerosAleatorios()
  {
    var numeros = new double[10];

    for (int e = 0; e < numeros.Length; e++)
    {
      double numero = new Random().NextDouble() * 101;

      if (numero > 100)
        numeros[e] = 100;
      else
        numeros[e] = numero;

    }

    return numeros;
  }

  public static void MuestraArrayCompleto(double[] numeros)
  {
    Console.WriteLine("Array completo:");
    for (int e = 0; e < numeros.Length; e++)
    {
      Console.WriteLine($"[{e}]: {numeros[e].ToString("F2")}");
    }

  }

  public static void MuestraMultiplosDe4(double[] numeros)
  {
    Console.WriteLine("\nNúmeros en posiciones múltiplo de 4:");
    for (int e = 0; e < numeros.Length; e++)
    {
      if (e % 4 == 0)
        Console.WriteLine($"Posición [{e}]: {numeros[e].ToString("F2")}");
    }

  }

  public static void Main(string[] args)
  {
    Console.WriteLine("Ejercicio 1: Números aleatorios en posiciones múltiplo de 4\n");

    // TODO: Implementa la lógica de este método

    double[] numerosListaObtenida = GeneraNumerosAleatorios();
    MuestraArrayCompleto(numerosListaObtenida);
    MuestraMultiplosDe4(numerosListaObtenida);




    Console.WriteLine("\nPresiona cualquier tecla para salir...");
    Console.ReadKey();
  }
}