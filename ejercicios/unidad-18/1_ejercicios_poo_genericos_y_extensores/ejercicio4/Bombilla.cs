namespace Ejercicio4;
using StringExtensions;

public class Bombilla : IAvisador
{
    ConsoleColor ColorBombilla {get;}
    public bool Estado { get;  set; }

    public Bombilla(ConsoleColor color)
    {
        ColorBombilla = color;
    }

    private string BombillaStr => """
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
        BombillaStr.Color(ColorBombilla);
        Console.WriteLine("LUZ ON... Luz encendida ...");
    }

    public void Desactiva()
    {
        Estado = false;
        "LUZ OFF (apagada)".Gris();
    }
}
