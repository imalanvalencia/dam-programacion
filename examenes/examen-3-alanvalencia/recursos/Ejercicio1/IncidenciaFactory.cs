public static class IncidenciaFactory
{

    public static IIncidencia Crea(string tipo, string dispositivo, float dato)
    {
        string tipoNormalizado = tipo.Trim().ToUpperInvariant();

        return tipoNormalizado switch
        {
            "CPU_ALTA" => new CPUAlta(dispositivo, dato),
            "TEMPERATURA_ALTA" => new TemperaturAlta(dispositivo, dato),
            _ => throw new IncidenciaException("Tipo de incidencia no soportado.")
        };
    }
}

