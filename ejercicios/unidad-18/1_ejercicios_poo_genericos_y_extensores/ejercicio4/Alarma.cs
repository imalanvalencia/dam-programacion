using System.Globalization;
namespace Ejercicio4;

public class Alarma<T, K> where T : IComparable<T> where K : IAvisador
{
    bool encendida;
    public bool Activada { get; private set; }
    public ISensor<T> Sensor { get; }
    public T Umbral { get; }

    public List<K> Avisadores { get; private set; }

    public Alarma(T umbral, ISensor<T> sensor, K avisador)
    {
        Sensor = sensor;
        Umbral = umbral;
        Avisadores = [avisador];
    }

    public void AñadeAvisador(K avisador) => Avisadores.Add(avisador);


    public void Enciende()
    {
        encendida = true;
        Console.WriteLine("Encendiendo alarma...");
    }

    public void Apaga()
    {
        encendida = false;
        Console.WriteLine("Apagando alarmas.");
    }

    public virtual void Activa()
    {
        Activada = true;

        foreach (var avisador in Avisadores)
        {
            Console.Write($" Activando {EtiquetaAvisador(avisador)} ");
            avisador.Activa();
        }
    }

    public virtual void Desactiva()
    {
        Activada = false;

        foreach (var avisador in Avisadores)
        {
            Console.Write($" Desactivando {EtiquetaAvisador(avisador)} ");
            avisador.Desactiva();
        }
    }

    public void Comprueba()
    {
        while (encendida)
        {
            T valor = Sensor.ValorActual;
            string texto = FormateaValor(valor);

            Console.Write($"Lectura: {texto} => ");

            if (Umbral.CompareTo(valor) < 0)
            {
                if (!Activada)
                {
                    Console.Write("supera umbral => ");
                    Activa();
                }
                else
                {
                    Console.WriteLine("sigue sobre umbral (ya ACTIVA)");
                }
            }
            else if (Umbral.CompareTo(valor) > 0)
            {
                if (Activada)
                {
                    Console.Write("bajo del umbral => ");
                    Desactiva();
                }
                else
                {
                    Console.WriteLine("bajo del umbral (ya desactivada)");
                }
            }

            if (Console.KeyAvailable)
            {
                Console.Write("\n¿Desea apagar la alarma? (S/N): ");
                if (Console.ReadKey(true).Key == ConsoleKey.S) Apaga();
                else Console.WriteLine("Continuando comprobaciones");
            }

            Thread.Sleep(1000);
        }


    }

    static string EtiquetaAvisador(K avisador) => avisador switch
    {
        Timbre => "TIMBRE",
        Bombilla => "LUZ",
        Llamada => "LLAMADA",
        _ => "DESCONOCIDO"
    };

    private static string FormateaValor(T valor)
    {
        if (valor is float f)
        {
            return f.ToString("F2", CultureInfo.InvariantCulture);
        }
        if (valor is double d)
        {
            return d.ToString("F2", CultureInfo.InvariantCulture);
        }
        return valor?.ToString() ?? string.Empty;
    }


}