namespace FicheroCsv
{
  public class Csv
  {
    public static List<string[]> LeeCsv(string rutaFichero)
    {
      List<string[]> data = [];

      try
      {
        using (StreamReader sr = new(rutaFichero))
        {
          string line;
          while ((line = sr.ReadLine()) != null)
          {
            string[] fields = line.Split(',');
            data.Add(fields);
          }
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine("Error de lectura del fichero CSV: " + ex.Message);
      }

      return data;
    }

    public static void MuestraCsv(string rutaFichero)
    {
      List<string[]> data = LeeCsv(rutaFichero);


      foreach (var row in data)
      {
        Console.WriteLine(string.Join(", ", row));
      }
    }
  }
}