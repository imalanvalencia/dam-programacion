
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("=== INICIO DE PRUEBAS DEL ARCHIVO JEDI ===\n");

        ArchivoCentral archivo = new ArchivoCentral();
        Console.WriteLine("1. Archivo Central creado.");
        Console.WriteLine("\n2. Registrando artefactos manualmente...");

        var coord1 = new CoordenadaGalactica("Coruscant", 1, "Sistema Corus");
        var holocron1 = new Holocron("Profecías de Yoda", new DateTime(1990, 5, 20), coord1, Holocron.Color.Verde, false);

        var coord2 = new CoordenadaGalactica("Korriban", 2, "Sistema Horuset");
        var holocronDark = new Holocron("Secretos Sith", new DateTime(1000, 1, 1), coord2, Holocron.Color.Rojo, true);

        var coord3 = new CoordenadaGalactica("Ahch-To", 3, "Sistema Desconocido");
        var pergamino1 = new PergaminoAntiguo("Textos Sagrados Jedi", new DateTime(1500, 3, 15), coord3, "Papiro", true);

        bool r1 = archivo.RegistraArtefacto(holocron1);
        bool r2 = archivo.RegistraArtefacto(holocronDark);
        bool r3 = archivo.RegistraArtefacto(pergamino1);

        Console.WriteLine($"   - Holocron Yoda registrado: {r1}  {holocron1.Investiga()}");
        Console.WriteLine($"   - Holocron Sith registrado: {r2}  {holocronDark.Investiga()}");
        Console.WriteLine($"   - Pergamino Jedi registrado: {r3} {pergamino1.Investiga()}");

        var holocronCopia = new Holocron(holocron1);

        Console.WriteLine("\n3. Intentando registrar duplicado...");
        bool rDuplicate = archivo.RegistraArtefacto(holocronCopia);
        Console.WriteLine($"   - Duplicado registrado: {rDuplicate} (Esperado: False)");

        Console.WriteLine("\n4. Procesando Caja de Recursos...");
        List<string> caja = new List<string>
        {
            // Formato: Tipo;Titulo;Fecha;Sector|Cuad|Sis;Color/Material;Bool
            $"Holocron;Sabiduria Mace Windu;2005-01-01;Sector 4|4|Sistema 4;Morado;false",
            $"PergaminoAntiguo;Mapa a Exegol;1980-12-12;Desconocido|9|Oculto;Cuero;false",
            $"Holocron;Holocron Roto;INVALID-DATE;S|1|S;Rojo;true", // Linea invalida para probar try/catch
            $"PergaminoAntiguo;Profecía Elegido;0050-01-01;Naboo|1|Naboo;Papel;true"
        };

        string reporteCaja = archivo.ProcesaCajaDeRecursos(caja);
        Console.WriteLine($"   Resultados del procesamiento: {reporteCaja}");

        Console.WriteLine("\n5. Ranking por Importancia Histórica:");
        IEvaluadorImportancia evalHistorica = new ImportanciaHistorica();
        Console.WriteLine(archivo.ListaRanking(evalHistorica));

        Console.WriteLine("\n6. Ranking por Peligrosidad:");
        IEvaluadorImportancia evalPeligro = new ImportanciaPeligrosidad();
        Console.WriteLine(archivo.ListaRanking(evalPeligro));

        Console.WriteLine("\n7. Inventario Ordenado por Fecha (Descendiente segun CompareTo):");
        var ordenados = archivo.ObtieneInventarioOrdenado();
        foreach (var art in ordenados)
        {
            Console.WriteLine($"   - {art.FechaIngreso.ToShortDateString()} : {art.Titulo}");
        }

        Console.WriteLine("\n=== FIN DE PRUEBAS ===");

        Console.ReadLine();
    }
}