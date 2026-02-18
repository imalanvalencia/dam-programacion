public class Holocron : Artefacto
{
    public enum Color { Azul, Verde, Rojo, Morado };

    Color ColorHolocron { get; }

    public bool EsLadoOscuro { get; }

    public Holocron(string titulo, DateTime fechaIngreso, CoordenadaGalactica ubicacion, Color color, bool ladoOscuro) : base(titulo, fechaIngreso, ubicacion)
    {
        ColorHolocron = color;
        EsLadoOscuro = ladoOscuro;
    }

    public Holocron(Holocron copia) : base(copia)
    {
        ColorHolocron = copia.ColorHolocron;
        EsLadoOscuro = copia.EsLadoOscuro;
    }


    public override string Investiga() => EsLadoOscuro ? "Susurros Sith escuchados" : "Proyeccion holografica activada";
}
