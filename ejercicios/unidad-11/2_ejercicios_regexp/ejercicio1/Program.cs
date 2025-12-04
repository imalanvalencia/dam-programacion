using System;
using System.Text.RegularExpressions;

public class Program
{

    public static string[] ExtraerEtiquetas(string input)
    {
        var matches = Regex.Matches(input, @"<(?<tag>\w+)>(?<content>.*?)</\k<tag>>", RegexOptions.Singleline);
        var results = new string[matches.Count];
        for (int i = 0; i < matches.Count; i++)
        {
            results[i] = matches[i].Groups["content"].Value;
        }
        return results;
    }

    static void Main()
    {
        string tag = "<p>Hola mundo</p><p>¿Qué tal estás?</p>";

        Console.WriteLine("ExtraeEtiquetas(\"" + tag + "\")");
        Console.WriteLine("Devuelve: " + string.Join(", ", ExtraerEtiquetas(tag)));
        Console.ReadLine();
    }
}