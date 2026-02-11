using System;

namespace ejercicio3.tests;

public class TestsFormularios
{
    [Fact(DisplayName = "Estudiante con estudios inválidos produce error")]
    public void EstudianteEstudiosInvalidos()
    {
        var est = new Estudiante ("12345678A", "Ana", DateTime.Today.AddYears(-15), "Informática" );
        Assert.IsType<Validacion.Error>(est.Validacion);
    }

    [Fact(DisplayName = "Profesor correcto valida Exito")]
    public void ProfesorValido()
    {
        var prof = new Profesor ("87654321B", "Luis", new DateTime(1980,11,20), "Matemáticas", "INFO");
        Assert.IsType<Validacion.Exito>(prof.Validacion);
    }

    [Fact(DisplayName = "DNI vacío da error")]
    public void DniVacioError()
    {
        var est = new Estudiante ("", "Pedro", DateTime.Today.AddYears(-15), "DAM");
        Assert.IsType<Validacion.Error>(est.Validacion);
    }

    [Fact(DisplayName = "GestionaFormularios imprime resultados de validación")]
    public void GestionaFormularios_MuestraInformacion()
    {
        using var sw = new StringWriter();
        var original = Console.Out;
        Console.SetOut(sw);
        Program.GestionaFormularios();
        Console.SetOut(original);
        var salida = sw.ToString();
        Assert.Contains("Ejercicio 3: Validación de formularios", salida);
        Assert.Contains("Estudiante", salida);
        Assert.Contains("Profesor", salida);
        Assert.Contains("CORRECTO", salida);
        Assert.Contains("INCORRECTO", salida);
    }
}
