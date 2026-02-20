public interface IEvaluadorImportancia
{
    int Calcular(Artefacto a);

    /*
    ImportanciaHistorica
    Artefacto.Edad = fecha de ingreso -
    Si Artefacto.Edad > 1000 = 100
    Si Artefacto.Edad > 500 = 50
    else = 10

    ImportanciaPeligrosa
    Artefacto.Oscuro = fecha de ingreso -
    Si Artefacto.Oscuro = 500
    Si !Artefacto.Oscuro = 100
    Si Artefacto is PergaminoAntiguo = 0
    */
}


public class ImportanciaHistorica : IEvaluadorImportancia
{

    public int Calcular(Artefacto a) =>
        (DateTime.Today.Year - a.FechaIngreso.Year) switch
        {
            > 1000 => 100,
            > 500 => 50,
            _ => 10
        };
}

public class ImportanciaPeligrosidad : IEvaluadorImportancia
{
    public int Calcular(Artefacto a)
    {
        if (a is Holocron aH) return aH.EsLadoOscuro ? 500 : 100;
        if (a is PergaminoAntiguo) return 0;
        return 0;
    }
}