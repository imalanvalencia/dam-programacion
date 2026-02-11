//TODO: Añade el código necesario para implementar los requisitos del ejercicio
public interface IMedia
{
    string MessageToDisplay { get; }
    void Play();
    void Stop();
    void Pause();
    void Next();
    void Previous();
}

public enum MediaState
{
    Playing,
    Stopped,
    Paused
}

public class Program
{
    public static void Main()
    {
        string[] canciones = {
                "Wanna Be Startin' Somethin",
                "Baby Be Mine",
                "The Girl Is Mine",
                "Thriller",
                "Beat It",
                "Billie Jean",
                "Human Nature",
                "P.Y.T. (Pretty Young Thing)",
                "The Lady in My Life"
            };
        Disc thriller = new Disc("Thriller", "Michael Jackson", canciones);
        DABRadioCD radioCD = new DABRadioCD();
        ConsoleKeyInfo tecla = new ConsoleKeyInfo();
        do
        {
            try
            {
                Console.WriteLine(radioCD.MessageToDisplay);
                tecla = Console.ReadKey(true);
                Console.Clear();

                switch (tecla.KeyChar)
                {
                    //TODO: Añade los casos necesarios para implementar los requisitos del ejercicio
                    case '1':
                        radioCD.Play();
                        break;

                    case '2':
                        radioCD.Pause();
                        break;
                    
                    case '3':
                        radioCD.Stop();
                        break;
                    
                    case '4':
                        radioCD.Previous();
                        break;
                    
                    case '5':
                        radioCD.Next();
                        break;
                        
                    case '6':
                        radioCD.SwitchMode();
                        break;

                    case '7':
                        radioCD.InsertCD = thriller;
                        break;

                    case '8':
                        radioCD.ExtractCD();
                        break;

                    default:
                        break;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        } while (tecla.Key != ConsoleKey.Escape);
    }

    // Método auxiliar para pruebas: muestra cabecera y estado inicial sin requerir interacción
    public static void MostrarInterfazInicial()
    {
        Console.WriteLine("Ejercicio 5: Sistema Multimedia");
        DABRadioCD radioCD = new DABRadioCD();
        Console.WriteLine(radioCD.MessageToDisplay);
    }
}
