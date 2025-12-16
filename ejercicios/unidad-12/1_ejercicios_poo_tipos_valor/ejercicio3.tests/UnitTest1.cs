using System;
using System.Globalization;
using System.IO;

namespace ejercicio3.tests;

public class UnitTest3
{
    [Fact]
    public void MuestraFormatosPersonalizados_MuestraTodosLosFormatosCorrectamente()
    {
        // Arrange
        var originalOut = Console.Out;
        
        try
        {
            using (var stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                
                // Act
                Program.MuestraFormatosPersonalizados();
                string output = stringWriter.ToString();
                
                // Assert
                Assert.Contains("FORMATOS PERSONALIZADOS", output);
                Assert.Contains("Formato corto:", output);
                Assert.Contains("Formato largo:", output);
                Assert.Contains("Formato ISO 8601:", output);
                Assert.Contains("Formato americano:", output);
                Assert.Contains("Formato europeo:", output);
                Assert.Contains("Formato personalizado:", output);
                
                // Verificar formatos específicos (usando DateTime.Now que usa el método)
                Assert.Contains("/", output); // formato corto
                Assert.Contains("T", output); // ISO 8601
                Assert.Contains(".", output); // formato europeo
            }
        }
        finally
        {
            Console.SetOut(originalOut);
        }
    }

    [Fact]
    public void ConvierteAZonasHorarias_ConvierteCorrectamenteEntreZonas()
    {
        // Arrange
        DateTime fechaLocal = new DateTime(2025, 2, 4, 14, 30, 25);
        var originalOut = Console.Out;
        
        try
        {
            using (var stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                
                // Act
                Program.ConvierteAZonasHorarias(fechaLocal);
                string output = stringWriter.ToString();
                
                // Assert
                Assert.Contains("CONVERSIONES DE ZONA HORARIA", output);
                Assert.Contains("Hora local (Madrid): 04/02/2025 14:30:25", output);
                Assert.Contains("En Londres (UTC+0): 04/02/2025 13:30:25", output);
                Assert.Contains("En Nueva York (UTC-5): 04/02/2025 08:30:25", output);
                Assert.Contains("En Tokio (UTC+9): 04/02/2025 22:30:25", output);
            }
        }
        finally
        {
            Console.SetOut(originalOut);
        }
    }

    [Fact]
    public void PruebaParsing_ValidaFormatosDeFechaCorrectamente()
    {
        // Arrange
        var originalOut = Console.Out;
        var originalIn = Console.In;
        
        try
        {
            using (var stringWriter = new StringWriter())
            using (var stringReader = new StringReader("25/12/2025\n07-15-2025\n32/13/2025\n"))
            {
                Console.SetOut(stringWriter);
                Console.SetIn(stringReader);
                
                // Act
                Program.PruebaParsing();
                string output = stringWriter.ToString();
                
                // Assert
                Assert.Contains("PARSING DE FECHAS", output);
                Assert.Contains("Introduce fecha en formato dd/MM/yyyy:", output);
                Assert.Contains("Fecha parseada: 25/12/2025 00:00:00", output);
                Assert.Contains("¿Es válida? True", output);
                
                Assert.Contains("Introduce fecha en formato MM-dd-yyyy:", output);
                Assert.Contains("Fecha parseada: 15/07/2025 00:00:00", output);
                
                Assert.Contains("Introduce fecha en formato inválido:", output);
                Assert.Contains("¿Es válida? False", output);
                Assert.Contains("Error: El formato de fecha no es válido.", output);
            }
        }
        finally
        {
            Console.SetOut(originalOut);
            Console.SetIn(originalIn);
        }
    }
}
