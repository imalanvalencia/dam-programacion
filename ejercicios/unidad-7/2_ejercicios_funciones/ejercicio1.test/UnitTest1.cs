using System;
using System.IO;
using Xunit;

namespace ejercicio1.test;

public class UnitTest1
{
    [Fact]
    public void Lee_DeberiaLeerDatosCorrectos()
    {
        // Arrange
        var input = "5\n15,50\n40\n";
        Console.SetIn(new StringReader(input));

        // Act
        var (numeroDepartamento, costePorHora, horasTrabajadas) = Program.Lee();

        // Assert
        Assert.Equal(5, numeroDepartamento);
        Assert.Equal(15.50f, costePorHora);
        Assert.Equal(40f, horasTrabajadas);
    }

    [Fact]
    public void Salario_CalculoBasico_DeberiaRetornarResultadoCorrecto()
    {
        // Arrange
        float costePorHora = 10.0f;
        float horasTrabajadas = 8.0f;

        // Act
        float resultado = Program.Salario(costePorHora, horasTrabajadas);

        // Assert
        Assert.Equal(80.0f, resultado);
    }

    [Fact]
    public void Salario_ConDecimales_DeberiaRetornarResultadoCorrecto()
    {
        // Arrange
        float costePorHora = 15.75f;
        float horasTrabajadas = 20.5f;

        // Act
        float resultado = Program.Salario(costePorHora, horasTrabajadas);

        // Assert
        Assert.Equal(322.875f, resultado, 3); // Precisión de 3 decimales
    }

    [Fact]
    public void Salario_ConCero_DeberiaRetornarCero()
    {
        // Arrange
        float costePorHora = 10.0f;
        float horasTrabajadas = 0.0f;

        // Act
        float resultado = Program.Salario(costePorHora, horasTrabajadas);

        // Assert
        Assert.Equal(0.0f, resultado);
    }

    [Fact]
    public void Muestra_DeberiaGenerarSalidaCorrecta()
    {
        // Arrange
        var output = new StringWriter();
        Console.SetOut(output);

        float salario = 800.0f;
        int numeroDepartamento = 3;
        float costePorHora = 20.0f;
        float horasTrabajadas = 40.0f;

        // Act
        Program.Muestra(salario, numeroDepartamento, costePorHora, horasTrabajadas);

        // Assert
        var result = output.ToString();
        Assert.Contains("INFORMACIÓN DEL EMPLEADO", result);
        Assert.Contains("Número de departamento: 3", result);
        Assert.Contains("Coste por hora:", result);
        Assert.Contains("Horas trabajadas: 40", result);
        Assert.Contains("Salario semanal:", result);
    }

    [Fact]
    public void Muestra_ConDepartamentoCero_DeberiaMotrarCero()
    {
        // Arrange
        var output = new StringWriter();
        Console.SetOut(output);

        float salario = 0.0f;
        int numeroDepartamento = 0;
        float costePorHora = 0.0f;
        float horasTrabajadas = 0.0f;

        // Act
        Program.Muestra(salario: salario, numeroDepartamento: numeroDepartamento, costePorHora: costePorHora, horasTrabajadas: horasTrabajadas);

        // Assert
        var result = output.ToString();
        Assert.Contains("Número de departamento: 0", result);
        Assert.Contains("Horas trabajadas: 0", result);
    }
}
