namespace Ejercicio4;

public class Timbre : IAvisador
{
    int DuracionTimbre { get; }
    string Sonido { get; }
    public bool Estado { get; set; }

    public Timbre(int duracion, string sonido)
    {
        DuracionTimbre = duracion;
        Sonido = sonido;
    }



    public void Activa()
    {
        Estado = true;
        Console.WriteLine($"ACTIVANDO TIMBRE... Timbre sonando {Sonido} (duración {DuracionTimbre} ms) ...");
    }

    public void Desactiva()
    {
        Estado = false;
        Console.WriteLine("Desactivando Timbre (detenido)");
    }

}