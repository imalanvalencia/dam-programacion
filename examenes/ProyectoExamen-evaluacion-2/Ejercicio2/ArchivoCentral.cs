using System.Text;

public class ArchivoCentral
{
    public List<Artefacto> Hallazgos { get; }

    public ArchivoCentral()
    {
        Hallazgos = [];
    }

    public bool RegistraArtefacto(Artefacto a)
    {

        Hallazgos.Add(a);
        return true;
    }

    private Artefacto GeneraArtefacto(string[] partesArtefacto, string[] coordenada)
    {
        DateTime fecha = DateTime.Parse(partesArtefacto[2]);
        int cuadrante = int.Parse(coordenada[1]);
        bool siEsEso = bool.Parse(partesArtefacto[5]);

        CoordenadaGalactica coordenadas = new(coordenada[0], cuadrante, coordenada[2]);

        if (partesArtefacto[0] == "Holocron") return new Holocron(partesArtefacto[1], fecha, coordenadas, Enum.Parse<Holocron.Color>(partesArtefacto[4]), siEsEso);

        if (partesArtefacto[0] == "PergaminoAntiguo") return new PergaminoAntiguo(partesArtefacto[1], fecha, coordenadas, partesArtefacto[4], siEsEso);

        throw new ArgumentException("No existe eso");
    }

    public string ProcesaCajaDeRecursos(List<string> lineas)
    {
        int procesados = 0;
        int ignorados = 0;


        for (int i = 0; i < lineas.Count; i++)
        {
            string[] artefatoString = lineas[i].Split(';');
            string[] cordenada = artefatoString[3].Split('|');


            try
            {
                RegistraArtefacto(GeneraArtefacto(artefatoString, cordenada));
                procesados++;
            }
            catch (Exception)
            {
                Console.Write("linea ignorada por formato incorrecto: " + string.Join(";", artefatoString) + "\n");
                ignorados++;
            }

        }

        return $"Procesados: {procesados} | Ignorados: {ignorados}";
    }


    (string, int)[] Ordena((string, int)[] array)
    {
        (string, int)[] arrayOrdenado = array[..];
        for (int i = 0; i < arrayOrdenado.Length; i++)
        {
            for (int j = 0; j < arrayOrdenado.Length - 1 - i; j++)
            {
                if (arrayOrdenado[j].Item2 < arrayOrdenado[j + 1].Item2)
                {
                    (string, int) auxiliar = arrayOrdenado[j];
                    arrayOrdenado[j] = arrayOrdenado[j + 1];
                    arrayOrdenado[j + 1] = auxiliar;
                }
            }
        }
        return arrayOrdenado;
    }

    public string ListaRanking(IEvaluadorImportancia estrategia)
    {
        (string, int)[] ranking = [];

        for (int i = 0; i < Hallazgos.Count; i++)
        {
            ranking = [.. ranking, ($"{Hallazgos[i].Titulo}", estrategia.Calcular(Hallazgos[i]))];
        }

        (string, int)[] rankingOrdenado = Ordena(ranking);

        StringBuilder sb = new();


        for (int i = 0; i < rankingOrdenado.Length; i++)
        {
            sb.Append($"Titulo: {rankingOrdenado[i].Item1} Puntos:{rankingOrdenado[i].Item2}\n");
        }

        return sb.ToString();
    }

    public List<Artefacto> ObtieneInventarioOrdenado()
    {
        Artefacto[] artefactosOrdenados = [..Hallazgos];

        Array.Sort(artefactosOrdenados);

        return [.. artefactosOrdenados];
    }


}
