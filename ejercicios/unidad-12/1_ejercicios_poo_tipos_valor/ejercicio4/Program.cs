using System;

public class Program
{
    public static void UsoGuid()
    {
        Console.WriteLine("Generando identificadores únicos ...\n");

        // Generar array de 3 GUIDs únicos
        Guid[] usuarios = new Guid[3];
        for (int i = 0; i < usuarios.Length; i++)
        {
            usuarios[i] = Guid.NewGuid();
        }

        // Mostrar usuarios del sistema
        Console.WriteLine("--- Usuarios del sistema ---");
        for (int i = 0; i < usuarios.Length; i++)
        {
            Console.WriteLine($"Usuario {i + 1}: {usuarios[i]}");
        }
        Console.WriteLine();

        // Mostrar información del primer GUID
        Console.WriteLine("--- Información del primer GUID ---");
        Guid primerGuid = usuarios[0];
        Console.WriteLine($"GUID analizado: {primerGuid}");
        Console.WriteLine($"Versión: {primerGuid.Version}");
        Console.WriteLine($"Variante: {(int)primerGuid.Variant}");
        Console.WriteLine($"Formato sin guiones: {primerGuid.ToString("N")}");
        Console.WriteLine($"Formato con llaves: {primerGuid.ToString("B")}");
        Console.WriteLine($"Formato con paréntesis: {primerGuid.ToString("P")}");
        Console.WriteLine();

        // Verificación de duplicados
        Console.WriteLine("--- Verificación de duplicados ---");
        Console.WriteLine($"¿Usuario 1 y Usuario 2 tienen el mismo ID? {usuarios[0] == usuarios[1]}");
        
        bool todosUnicos = true;
        for (int i = 0; i < usuarios.Length - 1; i++)
        {
            for (int j = i + 1; j < usuarios.Length; j++)
            {
                if (usuarios[i] == usuarios[j])
                {
                    todosUnicos = false;
                    break;
                }
            }
            if (!todosUnicos) break;
        }
        Console.WriteLine($"¿Todos los IDs son únicos? {todosUnicos}");
        Console.WriteLine();

        // Conversión desde texto
        Console.WriteLine("--- Conversión desde texto ---");
        string textoValido = "12345678-9abc-def0-1234-56789abcdef0";
        string textoInvalido = "texto-no-valido";

        try
        {
            Guid guidParse = Guid.Parse(textoValido);
            Console.WriteLine($"ID desde texto válido: {textoValido} -> Convertido correctamente");
        }
        catch
        {
            Console.WriteLine($"ID desde texto válido: {textoValido} -> Error en conversión");
        }

        if (Guid.TryParse(textoInvalido, out Guid guidTryParse))
        {
            Console.WriteLine($"ID desde texto inválido: {textoInvalido} -> Convertido correctamente");
        }
        else
        {
            Console.WriteLine($"ID desde texto inválido: {textoInvalido} -> Error en conversión");
        }
    }

    private static void Main(string[] args)
    {
        Console.WriteLine("Ejercicio 4: Sistema de identificadores únicos con GUID\n");

        UsoGuid();
        Console.WriteLine("\nPulsa una tecla para acabar...");
        try
        {
            Console.ReadKey();
        }
        catch (InvalidOperationException)
        {
            // Console input redirected - just exit
        }
    }
}