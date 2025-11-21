using System.Drawing;
using System.Text;

public class Program
{

    public static void ConfigurarConsola()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.CursorVisible = false;
        int anchoMaximoVentana = Console.LargestWindowWidth;
        int altoMaximoVentana = Console.LargestWindowHeight;
        int anchoDeseadoVentana = 140;
        int altoDeseadoVentana = 30;



        // Configurar la ventana, ajustándola si es necesario
        int anchoVentana = Math.Min(anchoDeseadoVentana, anchoMaximoVentana);
        int altoVentana = Math.Min(altoDeseadoVentana, altoMaximoVentana);

        // El buffer debe ser al menos tan ancho como la ventana
        Console.SetBufferSize(anchoVentana, altoVentana);
        Console.SetWindowSize(anchoVentana, altoVentana);
    }
    //TODO: Método para generar un color aleatorio
    public static ConsoleColor GeneraColor() => (ConsoleColor)new Random().Next(Enum.GetNames<ConsoleColor>().Length);


    public static int RecogeCoordenada(int maximo)
    {
        int coordenada;
        do
        {
            int.TryParse(Console.ReadLine(), out coordenada);
            if (coordenada < 2 || coordenada > maximo)
            {
                Console.SetCursorPosition(1, 1);
                Console.WriteLine($"Coordenada debe estar entre 2 y {maximo}.");
            }
            Console.SetCursorPosition(1, 1);
            Console.WriteLine("                                                                                            ");
        } while (coordenada < 2 || coordenada > maximo);

        return coordenada;
    }
    public static Point EstableceCoordenadas()
    {
        // Usar las dimensiones actuales de la ventana, no las máximas del sistema
        int altoVentana = Console.WindowHeight;
        int anchoVentana = Console.WindowWidth;
        int coordenadaY, coordenadaX;
        Console.SetCursorPosition(1, 1);
        Console.Write($"Introduce coordenada X (2-{anchoVentana}):");
        coordenadaX = RecogeCoordenada(anchoVentana);
        Console.SetCursorPosition(1, 1);
        Console.Write($"Introduce coordenada Y (2-{altoVentana}):");
        coordenadaY = RecogeCoordenada(altoVentana);
        Console.SetCursorPosition(1, 1);
        Console.WriteLine("                                                                                            ");

        //TODO: Crea un objeto Point con las coordenadas introducidas
        return new Point(coordenadaX, coordenadaY);
    }


    private static void Main(string[] args)
    {
        ConfigurarConsola();
        ConsoleKeyInfo tecla = new ConsoleKeyInfo();
        ConsoleColor backgroundColor = GeneraColor();
        Console.BackgroundColor = backgroundColor;
        Console.Clear();
        do
        {

            ConsoleColor foregroundColor = GeneraColor();
            // Asegurar que los colores sean diferentes para visibilidad
            while (backgroundColor == foregroundColor)
            {
                foregroundColor = GeneraColor();
            }
            Console.ForegroundColor = foregroundColor;
            Point coordenadas = EstableceCoordenadas();
            Console.SetCursorPosition(coordenadas.X, coordenadas.Y);

            Console.Write("☺");

            Console.SetCursorPosition(1, 1);
            Console.WriteLine("Presiona 'Escape' para salir o cualquier otra tecla para cambiar el tamaño de la ventana .");
            tecla = Console.ReadKey(true);
            Console.SetCursorPosition(1, 1);
            Console.WriteLine("                                                                                            ");
        } while (tecla.Key != ConsoleKey.Escape);
        Console.ResetColor();
        Console.Clear();
        Console.ReadLine();
    }
}