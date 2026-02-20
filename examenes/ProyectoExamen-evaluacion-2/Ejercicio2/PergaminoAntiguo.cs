public class PergaminoAntiguo : Artefacto
{
    string Material { get; }
    bool EsLegible { get; }

    public PergaminoAntiguo(string titulo, DateTime fechaIngreso, CoordenadaGalactica ubicacion, string material, bool legible) : base(titulo, fechaIngreso, ubicacion)
    {
        Material = material;
        EsLegible = legible;
    }

    public PergaminoAntiguo(PergaminoAntiguo copia) : base(copia)
    {
        Material = copia.Material;
        EsLegible = copia.EsLegible;
    }

    public override string Investiga() => EsLegible ? "Contenido decifrado [...]" : "Escritura borrosa, ilegible";
}
