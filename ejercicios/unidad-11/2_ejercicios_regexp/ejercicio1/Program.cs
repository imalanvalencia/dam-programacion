using System;
using System.Text.RegularExpressions;

public class Program
{

    public static string[] ExtraerEtiquetas(string entrada)
    {
        MatchCollection matchea = Regex.Matches(entrada, @"<(?<tag>\w+)>(?<content>.*?)</\k<tag>>", RegexOptions.Singleline);
        var resultado = new string[matchea.Count];

        for (int i = 0; i < matchea.Count; i++)
        {
            resultado[i] = matchea[i].Groups["content"].Value;
        }
        return resultado;
    }

    static void Main()
    {
        string etiqueta = "<p>Hola mundo</p><p>¿Qué tal estás?</p>";

        Console.WriteLine("ExtraeEtiquetas(\"" + etiqueta + "\")");
        Console.WriteLine("Devuelve: " + string.Join(", ", ExtraerEtiquetas(etiqueta)));
        Console.ReadLine();
    }
}