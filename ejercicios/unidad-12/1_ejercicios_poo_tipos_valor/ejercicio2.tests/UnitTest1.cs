using System;
using System.Globalization;
using System.IO;

namespace ejercicio2.tests;

public class UnitTest2
{
    [Fact]
    public void CalculaEdad_CalculaDiasVividosCorrectamente()
    {
        // Arrange
        DateTime fechaNacimiento = new DateTime(1995, 3, 15);
        var originalOut = Console.Out;
        
        try
        {
            using (var stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                
                // Act
                Program.CalculaEdad(fechaNacimiento);
                string output = stringWriter.ToString();
                
                // Assert
                Assert.Contains("CÁLCULOS CON DATETIME", output);
                Assert.Contains("15/03/1995", output);
                Assert.Contains("Días vividos", output);
                Assert.Contains("Años completos", output);
                Assert.Contains("Próximo cumpleaños", output);
                Assert.Contains("miércoles", output); // día de la semana que nació
            }
        }
        finally
        {
            Console.SetOut(originalOut);
        }
    }

    [Fact]
    public void CalculaJornadaLaboral_CalculaHorasTrabajadasCorrectamente()
    {
        // Arrange
        var originalOut = Console.Out;
        var originalIn = Console.In;
        
        try
        {
            using (var stringWriter = new StringWriter())
            using (var stringReader = new StringReader("08:30\n17:45\n14:00\n30\n"))
            {
                Console.SetOut(stringWriter);
                Console.SetIn(stringReader);
                
                // Act
                Program.CalculaJornadaLaboral();
                string output = stringWriter.ToString();
                
                // Assert
                Assert.Contains("=== CÁLCULOS CON TimeOnly ===", output);
                Assert.Contains("8:30", output); // hora inicio
                Assert.Contains("17:45", output); // hora fin
                Assert.Contains("9:15", output); // duración jornada
                Assert.Contains("14:00", output); // hora inicio descanso
                Assert.Contains("30", output); // duración descanso
                Assert.Contains("14:30", output); // hora fin descanso
                Assert.Contains("8:45", output); // tiempo efectivo
                Assert.Contains("43:45:00", output); // horas semanales
            }
        }
        finally
        {
            Console.SetOut(originalOut);
            Console.SetIn(originalIn);
        }
    }

    [Fact]
    public void MuestraComparaciones_RealizaComparacionesTemporalesCorrectamente()
    {
        // Arrange
        var originalOut = Console.Out;
        
        try
        {
            using (var stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                
                // Act
                Program.MuestraComparaciones();
                string output = stringWriter.ToString();
                
                // Assert
                Assert.Contains("COMPARACIONES TEMPORALES", output);
                Assert.Contains("¿El 15 de marzo es antes que el 31 de julio? True", output);
                Assert.Contains("¿Las 08:30 es antes que las 17:45? True", output);
                Assert.Contains("¿Quedan más de 100 días para fin de año?", output);
            }
        }
        finally
        {
            Console.SetOut(originalOut);
        }
    }
}
