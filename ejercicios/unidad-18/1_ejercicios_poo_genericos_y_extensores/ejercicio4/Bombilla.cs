namespace Ejercicio4;

public class Bombilla : IAvisador
{
    ConsoleColor ColorBombilla;
    public bool Estado { get;  set; }

    public Bombilla(ConsoleColor color)
    {
        ColorBombilla = color;
    }

    private string Bombilla => """
        ___,-----.___
    ,--'             `--.
   /                     \
  /                       \
 |                         |
|                           |
|        |~~~~~~~~~|        |
|        \         /        |
 |        \       /        |
  \        \     /        /
   \        |   |        /
    \       |   |       /
     \      |   |      /
      \     |   |     /
       \____|___| ___/
       )___,-----'___(
       )___,-----'___(
       )___,-----'___(
       )___,-----'___(
       \_____________/
            \___/
""";




    public void Activa()
    {
        Estado = true;
        Bombilla.Gris();
        Console.WriteLine("LUZ ON... Luz encendida ...");
        Console.ForegroundColor = ConsoleColor.White;
    }

    public void Desactiva()
    {
        Estado = false;
        Console.WriteLine("LUZ OFF (apagada)");
        Console.ForegroundColor = ConsoleColor.White;
    }
}