using FicheroCsv;
using Spectre.Console;

public class Program
{
  public static void Main(string[] args)
  {
    const string RUTA_FICHERO = "datos.csv";
    Console.WriteLine("Hello, World!");

    Csv.MuestraCsv(RUTA_FICHERO);
    List<string[]> datos = Csv.LeeCsv(RUTA_FICHERO);

    Table tabla = new();


    tabla.AddColumns(datos[0]);
    datos.GetRange(1, datos.Count - 1).ForEach((datos) => tabla.AddRow(datos));

    AnsiConsole.Write(tabla);
  }
}