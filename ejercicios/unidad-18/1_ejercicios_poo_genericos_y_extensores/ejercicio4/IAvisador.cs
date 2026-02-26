namespace Ejercicio4;

public interface IAvisador
{
    bool Estado { get; set; }
    void Activa();
    void Desactiva();
}