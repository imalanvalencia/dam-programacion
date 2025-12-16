
using System;
public class Program
{
    //TODO: Implementar la lógica necesaria para gestionar el sistema de dibujo
    static void Main()
    {
        Console.WriteLine("Ejercicio 3: Sistema de dibujo con herramientas");
        Console.WriteLine();

        Console.WriteLine("=== HERRAMIENTAS DE DIBUJO ===");
        Console.WriteLine("Creando herramientas de dibujo...");
        Console.WriteLine();

        Console.WriteLine("Inicializando estuche con rotuladores de colores aleatorios...");
        Rotulador[] rotuladores = Estuche.GetRotuladores();
        Console.WriteLine($"Estuche preparado con {Estuche.NUMERO_ROTULADORES} rotuladores:");
        for (int i = 0; i < rotuladores.Length; i++)
        {
            Console.WriteLine($"- Rotulador {i + 1}: {rotuladores[i].ObtenerColor()}");
        }
        Console.WriteLine();

        Console.WriteLine("=== DIBUJANDO FIGURAS ===");
        Console.WriteLine("--- Creación de círculo ---");
        Console.WriteLine("Usando compás para dibujar...");

        Compas compas = new Compas();
        Circulo circulo = compas.DibujaCirculo(3.5f);
        Console.WriteLine();

        Console.WriteLine("--- Selección aleatoria de rotulador ---");
        Console.WriteLine("Seleccionando rotulador aleatorio del estuche...");
        Random random = new Random();
        int indiceRotulador = random.Next(0, Estuche.NUMERO_ROTULADORES);
        Rotulador rotulador = Estuche.GetRotuladores()[indiceRotulador];
        Color colorRotulador = rotulador.ObtenerColor();
        Console.WriteLine($"Rotulador seleccionado: {colorRotulador}");
        Console.WriteLine();

        Console.WriteLine("--- Rotulando perímetro ---");
        Console.WriteLine("Calculando perímetro del círculo...");
        float perimetro = circulo.Perimetro();
        Console.WriteLine($"Perímetro: {perimetro:F2} cm");
        rotulador.Rotula(perimetro);
        Console.WriteLine();

        Console.WriteLine("--- Preparando pincel ---");
        Console.WriteLine("Configurando pincel con color Verde...");
        Pincel pincel = new Pincel();
        pincel.SetColor(Color.Verde);
        Console.WriteLine("Pincel preparado con color Verde");
        Console.WriteLine();

        Console.WriteLine("--- Pintando área ---");
        Console.WriteLine("Calculando área del círculo...");
        float area = circulo.Area();
        Console.WriteLine($"Área: {area:F2} cm²");
        pincel.Pinta(area);
        Console.WriteLine();

        Console.WriteLine("=== RESUMEN DE LA SESIÓN ===");
        Console.WriteLine($"Figura creada: Círculo de radio 3,5 cm");
        Console.WriteLine($"Perímetro rotulado: {perimetro:F2} cm (color {colorRotulador})");
        Console.WriteLine($"Área pintada: {area:F2} cm² (color Verde)");
        Console.WriteLine("Herramientas utilizadas: Compás, Rotulador, Pincel");
        Console.WriteLine("¡Dibujo completado con éxito!");
        Console.WriteLine("Presiona cualquier tecla para salir...");
        Console.ReadKey();
    }
}
