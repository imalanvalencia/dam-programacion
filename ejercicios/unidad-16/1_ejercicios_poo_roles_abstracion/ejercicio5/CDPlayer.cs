public class CDPlayer : IMedia
{
    public string MessageToDisplay
    {
        get
        {
            if (!MediaIn) return "STATE: NO DISC inserted. Press '7' to insert a CD.";
            if (CD == null) return "STATE: ERROR - No CD detected. Please insert (press '7') a CD.";
            if (State == MediaState.Playing) return $"STATE: PLAYING... {CD} Track {Track + 1} - {CD?.NombreCancion(Track)}";
            if (State == MediaState.Stopped) return "STATE: CD stopped.";
            return $"STATE: PAUSED... {CD} - {CD?.NombreCancion(Track)}";
        }
    }

    private ushort Track { get; set; }
    private MediaState State { get; set; }
    public Disc? CD { get; private set; }
    public bool MediaIn => CD != null;



    public CDPlayer()
    {
        CD = null;
    }

    public void InsertMedia(Disc media)
    {
        if (MediaIn) throw new InvalidProgramException("STATE: ERROR - There is a CD detected. Please extract and try again (press '8') a CD.");
        CD = media;
    }

    public bool ExtractMedia() => MediaIn ? (CD = null) == null : false;

    public void Play()
    {
        if (State == MediaState.Stopped) Track = 0;

        State = MediaIn ? MediaState.Playing : State;
    }
    
    public void Pause()
    {
        if (State == MediaState.Paused) State = MediaState.Playing;
        else State = MediaIn ? MediaState.Paused : State;
    }

    public void Stop() => State = MediaIn ? MediaState.Stopped : State;

    public void Next()
    {
        if (MediaIn)
        {
            Track = (ushort)((Track + 1) % CD.NumTracks);
            State = MediaState.Playing;
        }
    }

    public void Previous()
    {
        if (MediaIn)
        {
            Track = (ushort)((Track - 1 + CD.NumTracks) % CD.NumTracks);
            State = MediaState.Playing;
        }

    }
}