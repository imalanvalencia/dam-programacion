namespace ejercicio3.test;

using System.Runtime.InteropServices;
using System.Text;
using Xunit;

public class UnitTest1
{
    [Fact]
    public void IntroduceNotas_ListaNotas()
    {
        // Simulamos la entrada del usuario (con algún dato inválido incluido)
        StringBuilder input = new StringBuilder();
        input.AppendLine("8");// válido
        input.AppendLine("9");
        input.AppendLine("10");
        input.AppendLine("11");// inválido
        input.AppendLine("5");
        input.AppendLine("-6");// inválido
        input.AppendLine("7");
        input.AppendLine("4");
        input.AppendLine("3");


        using var reader = new StringReader(input.ToString());
        using var writer = new StringWriter();

        Console.SetIn(reader);
        Console.SetOut(writer);

        List<int> notas = Program.IntroduceNotas(5);

        Assert.Equal(5, notas.Count); // solo se deben considerar las válidas
        Assert.Contains(8, notas);
        Assert.Contains(9, notas);
        Assert.DoesNotContain(11, notas);
        Assert.DoesNotContain(-6, notas);
    }
    [Fact]
    public void IntroduceNombresModulos_ListaNombres()
    {
        StringBuilder input = new StringBuilder();
        input.AppendLine("");
        input.AppendLine("Programación");
        input.AppendLine("Sistemas Informáticos");
        input.AppendLine(" ");
        input.AppendLine("Lenguaje de Marcas");
        input.AppendLine("Inglés");
        input.AppendLine("Bases de Datos");
        input.AppendLine("Entornos de Desarrollo");
        input.AppendLine("Proyecto Intermodular");
        input.AppendLine("Itinerario Personal Empleabilidad");


        using var reader = new StringReader(input.ToString());
        using var writer = new StringWriter();

        Console.SetIn(reader);
        Console.SetOut(writer);

        List<string> nombres = Program.IntroduceNombresModulos(5);

        Assert.Equal(5, nombres.Count);
        Assert.Contains("Programación", nombres);
        Assert.DoesNotContain("", nombres);
        Assert.DoesNotContain(" ", nombres);
    }

    [Theory]
    [InlineData(18)]
    [InlineData(25)]
    [InlineData(99)]
    public void CompruebaEdad_EsValida(int edad)
    {
        bool resultado = Program.CompruebaEdad(edad);
        Assert.True(resultado);
    }

    [Theory]
    [InlineData(110)]
    [InlineData(-12)]
    [InlineData(17)]
    public void CompruebaEdad_NoEsValida(int edad)
    {
        bool resultado = Program.CompruebaEdad(edad);
        Assert.False(resultado);
    }


    [Theory]
    [InlineData(new int[] { 7, 8, 9 })]
    [InlineData(new int[] { 10, 10, 10 })]
    [InlineData(new int[] { 6, 7, 5 })]
    [InlineData(new int[] { 6, 6, 6 })]
    public void ModuloAprobado_ValidaNotasAprobado(int[] notas)
    {
        bool resultado = Program.ModuloAprobado(new List<int>(notas));
        Assert.True(resultado);
    }


    [Theory]
    [InlineData(new int[] { 5, 5, 5 })]
    [InlineData(new int[] { 2, 4, 8 })]
    [InlineData(new int[] { 0, 0, 0 })]
    public void ModuloAprobado_ValidaNotasSuspenso(int[] notas)
    {
        bool resultado = Program.ModuloAprobado(new List<int>(notas));
        Assert.False(resultado);
    }


    [Fact]
    public void SalidaCorrectaMensajeBienvenida()
    {
        string expected = "Bienvenidos a la programación, futuros programadores!";
        string actual = Program.MensajeBienvenida();
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Main_FlujoCompletoConModulosAprobadosYSuspensos()
    {
        // Simulamos toda la entrada del usuario para el Main
        StringBuilder input = new StringBuilder();

        // Edad válida
        input.AppendLine("20");

        // Cantidad de módulos
        input.AppendLine("2");

        // Nombres de los módulos
        input.AppendLine("Programación");
        input.AppendLine("Bases de Datos");

        // Primer módulos
        input.AppendLine("3"); // cantidad de notas
        // Notas del primer módulo
        input.AppendLine("8");
        input.AppendLine("7");
        input.AppendLine("9");

        // Segundo módulo
        input.AppendLine("3"); // cantidad de notas
        // Notas del segundo módulo
        input.AppendLine("4");
        input.AppendLine("5");
        input.AppendLine("3");

        using var reader = new StringReader(input.ToString());
        using var writer = new StringWriter();

        Console.SetIn(reader);
        Console.SetOut(writer);

        // Ejecutamos el Main
        Program.Main();

        string output = writer.ToString();

        // Verificamos que contiene los mensajes esperados
        Assert.Contains("Bienvenidos a la programación, futuros programadores!", output);
        Assert.Contains("Edad válida.", output);
        Assert.Contains("Módulo aprobado.", output); // Para Programación
        Assert.Contains("Módulo no aprobado: promedio menor a 6.", output); // Para Bases de Datos
    }

    [Fact]
    public void Main_EdadInvalida()
    {
        StringBuilder input = new StringBuilder();

        // Edad inválida
        input.AppendLine("15");

        // Resto de datos para que no falle
        input.AppendLine("1");
        input.AppendLine("Programación");
        input.AppendLine("3");
        input.AppendLine("8");
        input.AppendLine("7");
        input.AppendLine("9");

        using var reader = new StringReader(input.ToString());
        using var writer = new StringWriter();

        Console.SetIn(reader);
        Console.SetOut(writer);

        Program.Main();

        string output = writer.ToString();

        Assert.Contains("Bienvenidos a la programación, futuros programadores!", output);
        Assert.Contains("Edad no válida.", output);
    }

    [Fact]
    public void Main_ModuloConMenosDeTresNotas()
    {
        StringBuilder input = new StringBuilder();

        input.AppendLine("25"); // Edad válida
        input.AppendLine("1");  // Un módulo
        input.AppendLine("Inglés");
        input.AppendLine("2");  // Solo 2 notas (menos de 3)
        input.AppendLine("8");
        input.AppendLine("9");

        using var reader = new StringReader(input.ToString());
        using var writer = new StringWriter();

        Console.SetIn(reader);
        Console.SetOut(writer);

        Program.Main();

        string output = writer.ToString();

        Assert.Contains("Bienvenidos a la programación, futuros programadores!", output);
        Assert.Contains("Edad válida.", output);
        Assert.Contains("Módulo no aprobado: menos de 3 notas.", output);
    }
}
