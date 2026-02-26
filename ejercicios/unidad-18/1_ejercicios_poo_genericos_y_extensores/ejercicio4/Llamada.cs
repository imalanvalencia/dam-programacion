
namespace Ejercicio4;

public class Llamada : IAvisador
{
    List<string> Numeros;
    public bool Estado { get; set; }

    public Llamada(List<string> numeros)
    {
        Numeros = numeros;
    }


    public void Activa()
    {
        Estado = true;
        foreach (var numero in Numeros)
        {

            Console.WriteLine($"Llamando al {numero}. Alarma código {numero[..3]} ACTIVADA a {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
        }
    }

    public void Desactiva()
    {
        Estado = false;
        Console.WriteLine("Fin de llamadas. Alarma DESACTIVADA.");
    }
}
