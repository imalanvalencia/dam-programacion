class DABRadio: IMedia
{
    const float SEEK_STEP = 0.5f;
    const float MAX_FREQUENCY = 108f;
    const float MIN_FREQUENCY = 87.5f;
    private float Frequency { get; set; }
    private MediaState State { get; set; }

    public string MessageToDisplay
    {
        get
        {
            if (State == MediaState.Stopped) return "… RADIO OFF";
            if (State == MediaState.Paused) return $"PAUSED - BUFFERING... FM – {Frequency} MHz";
            return $"HEARING... FM – {Frequency} MHz";
        }
    }

    public DABRadio()
    {
        Frequency = MIN_FREQUENCY;
        State = MediaState.Stopped;
    }


    public void Play()
    {
        if(State == MediaState.Stopped)
        {
            Frequency = MIN_FREQUENCY;
            State = MediaState.Playing;
        }

        State = MediaState.Playing;
    }

    public void Stop() => State = MediaState.Stopped;

    public void Pause()
    {
        if (State == MediaState.Paused) State = MediaState.Playing;
        else State = State == MediaState.Playing ? MediaState.Paused : State;
    }

    public void Next()
    {
        if (State != MediaState.Stopped)
        {
            Frequency += SEEK_STEP;
            if (Frequency > MAX_FREQUENCY) Frequency = MIN_FREQUENCY;
            State = MediaState.Playing;
        }
    }

    public void Previous()
    {
        if (State != MediaState.Stopped)
        {
            Frequency -= SEEK_STEP;
            if (Frequency < MIN_FREQUENCY) Frequency = MAX_FREQUENCY;
            State = MediaState.Playing;
        }
    }
}