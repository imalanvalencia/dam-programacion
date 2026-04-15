namespace IncidenciaExtension
{

    public class IncidenciaExtensionException(string mensaje) : Exception(mensaje);

    public static class IncidenciaExtension
    {
        public static IIncidencia Duplica(this IIncidencia inc)
        {
            // No es asi
            if (inc is CPUAlta cpu) return new CPUAlta(cpu.Dispositivo, cpu.PorcentajeUso);
            // Era asi
            if (inc is TemperaturAlta temp) return IncidenciaFactory.Crea("TEMPERATURA_ALTA", temp.Dispositivo, temp.Grados);

            throw new IncidenciaExtensionException("No se puede duplicar tu objeto");
        }
    }
}