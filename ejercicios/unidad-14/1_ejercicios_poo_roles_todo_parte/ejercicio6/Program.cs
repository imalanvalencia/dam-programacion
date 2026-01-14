internal class Program
{
   static void Main()
    {
        Console.WriteLine("Ejercicio 6: Sistema de dibujo con herramientas");
        Console.WriteLine();

        Compas compas = new Compas();
        Circulo circulo = compas.DibujaCirculo(3.5f);
        Rotulador rotulador = Estuche.GetRotuladores()
                              [
                                  new Random().Next(0, Estuche.NUMERO_ROTULADORES)
                              ];
        rotulador.Rotula(circulo.Perimetro());
        Pincel pincel = new Pincel();
        pincel.Color= Color.Verde;
        pincel.Pinta(circulo.Area());
        Console.WriteLine("\n¡Dibujo completado con éxito!");
        Console.WriteLine("Presiona cualquier tecla para salir...");
        Console.ReadKey();
    }
}