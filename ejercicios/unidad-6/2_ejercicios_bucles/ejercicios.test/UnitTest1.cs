using System;
using System.IO;

namespace ejercicios.test;

public class UnitTest1
{
    [Fact]
    public void NumerosAmigos_NumerosAmigos220Y284()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("220\n284"));
        Console.SetOut(output);

        Program.NumerosAmigos();

        var result = output.ToString();
        Assert.Contains("Los valores son amigos", result);
    }

    [Fact]
    public void NumerosAmigos_NumerosNoAmigos()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("3\n5"));
        Console.SetOut(output);

        Program.NumerosAmigos();

        var result = output.ToString();
        Assert.Contains("Los valores no son amigos", result);
    }

    [Fact]
    public void NumerosAmigos_NumeroNegativo()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("-3\n5"));
        Console.SetOut(output);

        Program.NumerosAmigos();

        var result = output.ToString();
        Assert.Contains("ERROR: Sólo se permiten números positivos", result);
    }

    [Fact]
    public void MultiplosDe7_RangoCompleto()
    {
        var output = new StringWriter();
        Console.SetOut(output);

        Program.MultiplosDe7();

        var result = output.ToString();
        Assert.Contains("7 14 21 28 35 42 49 56 63 70 77 84 91 98 105 112", result);
    }

    [Fact]
    public void SecuenciaDeNumeros_Numero4()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("4"));
        Console.SetOut(output);

        Program.SecuenciaDeNumeros();

        var result = output.ToString();
        Assert.Contains("1223334444", result);
    }

    [Fact]
    public void SecuenciaDeNumeros_Numero8()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("8"));
        Console.SetOut(output);

        Program.SecuenciaDeNumeros();

        var result = output.ToString();
        Assert.Contains("122333444455555666666777777788888888", result);
    }

    [Fact]
    public void TrianguloDeAsteriscos_Tamaño4()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("4"));
        Console.SetOut(output);

        Program.TrianguloDeAsteriscos();

        var result = output.ToString();
        Assert.Contains("* ", result);
        Assert.Contains("* * ", result);
        Assert.Contains("* * * ", result);
        Assert.Contains("* * * * ", result);
    }

    [Fact]
    public void PiramideDeNumeros_5Filas()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("5"));
        Console.SetOut(output);

        Program.PiramideDeNumeros();

        var result = output.ToString();
        Assert.Contains("1 ", result);
        Assert.Contains("1 2 ", result);
        Assert.Contains("1 2 3 ", result);
        Assert.Contains("1 2 3 4 ", result);
        Assert.Contains("1 2 3 4 5 ", result);
    }

    [Fact]
    public void SumaDeDigitos_Numero1234()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("1234"));
        Console.SetOut(output);

        Program.SumaDeDigitos();

        var result = output.ToString();
        Assert.Contains("Número de dígitos: 4", result);
        Assert.Contains("Suma de dígitos: 10", result);
    }

    [Fact]
    public void SumaDeDigitos_Numero567()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("567"));
        Console.SetOut(output);

        Program.SumaDeDigitos();

        var result = output.ToString();
        Assert.Contains("Número de dígitos: 3", result);
        Assert.Contains("Suma de dígitos: 18", result);
    }

    [Fact]
    public void PiramideDeNumerosDos_5Filas()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("5"));
        Console.SetOut(output);

        Program.PiramideDeNumerosDos();

        var result = output.ToString();
        // Verificar que aparecen los patrones esperados
        Assert.Contains("3 ", result); // Primera fila
        Assert.Contains("5 8 ", result); // Segunda fila
        Assert.Contains("7 0 3 ", result); // Tercera fila (10%10=0, 13%10=3)
        Assert.Contains("9 2 5 8 ", result); // Cuarta fila
    }

    [Fact]
    public void PiramideDeNumerosCompleta_6Filas()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("6"));
        Console.SetOut(output);

        Program.PiramideDeNumerosCompleta();

        var result = output.ToString();
        Assert.Contains("     1", result); // Primera fila con 5 espacios
        Assert.Contains("    232", result); // Segunda fila con 4 espacios
        Assert.Contains("   34543", result); // Tercera fila con 3 espacios
        Assert.Contains("  4567654", result); // Cuarta fila con 2 espacios
        Assert.Contains(" 567898765", result); // Quinta fila con 1 espacio
        Assert.Contains("67890109876", result); // Sexta fila sin espacios
    }

    [Fact]
    public void PiramideDeNumerosCompleta_3Filas()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("3"));
        Console.SetOut(output);

        Program.PiramideDeNumerosCompleta();

        var result = output.ToString();
        Assert.Contains("  1", result);
        Assert.Contains(" 232", result);
        Assert.Contains("34543", result);
    }

    [Fact]
    public void BuscarUbicacionDeNumero_EnLaLista()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("4\n1\n3\n4\n6\n8\n0"));
        Console.SetOut(output);

        Program.BuscarUbicacionDeNumero();

        var result = output.ToString();
        Assert.Contains("En la lista", result);
    }

    [Fact]
    public void BuscarUbicacionDeNumero_FueraIzquierda()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("2\n3\n5\n6\n7\n8\n0"));
        Console.SetOut(output);

        Program.BuscarUbicacionDeNumero();

        var result = output.ToString();
        Assert.Contains("Fuera de lista a la Izquierda", result);
    }

    [Fact]
    public void BuscarUbicacionDeNumero_FueraDerecha()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("8\n1\n3\n5\n7\n0"));
        Console.SetOut(output);

        Program.BuscarUbicacionDeNumero();

        var result = output.ToString();
        Assert.Contains("Fuera de lista a la Derecha", result);
    }

    [Fact]
    public void BuscarUbicacionDeNumero_FueraIntercalado()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("5\n1\n3\n4\n7\n0"));
        Console.SetOut(output);

        Program.BuscarUbicacionDeNumero();

        var result = output.ToString();
        Assert.Contains("Fuera de lista a la Intercalado", result);
    }
}
