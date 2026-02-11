public class Disc
{
    private string Album { get; }
    private string Artist { get; }
    private List<string> Songs { get; }
    public virtual int NumTracks => Songs.Count;
    public Disc(string title, string artist, string[] songs)
    {
        Album = title;
        Artist = artist;
        Songs = [.. songs];
    }

    public string NombreCancion(int index) => Songs[index];

    public override string ToString() => $"Album: {Album} Artist: {Artist}";
}
