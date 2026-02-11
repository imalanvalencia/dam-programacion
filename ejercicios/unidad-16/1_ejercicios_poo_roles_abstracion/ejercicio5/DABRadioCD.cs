public class DABRadioCD : IMedia
{
    private IMedia ActiveDevice { get; set; }
    public Disc InsertCD
    {
        set
        {
            try
            {
                CDPlayer.InsertMedia(value);
                SwitchMode(CDPlayer);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Error al insertar el CD: {ex.Message}");
            }
        }
    }
    private DABRadio Radio { get; set; }
    private CDPlayer CDPlayer { get; set; }



    public string MessageToDisplay
    {
        get
        {
            return $"MODO: {(ActiveDevice is DABRadio ? "DAB" : "CD")} {ActiveDevice.MessageToDisplay} [1]Play [2]Pause [3]Stop [4]Prev [5]Next [6]Switch [7]Insert CD [8]Extract CD, [ESC]Turn off";
        }
    }

    public DABRadioCD()
    {
        Radio = new DABRadio();
        CDPlayer = new CDPlayer();

        ActiveDevice = Radio;
    }


    public void Play() => ActiveDevice.Play();
    public void Stop() => ActiveDevice.Stop();
    public void Pause() => ActiveDevice.Pause();
    public void Next() => ActiveDevice.Next();
    public void Previous() => ActiveDevice.Previous();

    public void ExtractCD()
    {
        CDPlayer.ExtractMedia();
        SwitchMode(Radio);
    }


    public void SwitchMode()
    {
        Pause();
        if (ActiveDevice is DABRadio) ActiveDevice = CDPlayer;
        else ActiveDevice = Radio;
        Play();
    }

    public void SwitchMode(IMedia modo)
    {
        if (modo is CDPlayer) ActiveDevice = CDPlayer;
        else if (modo is DABRadio) ActiveDevice = Radio;
    }
}
