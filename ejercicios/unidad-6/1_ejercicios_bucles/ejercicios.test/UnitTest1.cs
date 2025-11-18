using System;
using System.IO;

namespace ejercicios.test;

public class UnitTest1
{
    [Fact]
    public void ContadorDeNumeros_VariosPositivosYNegativos()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("10\n-5\n2\n4\n-7\n-9\n-3\n-6\n0"));
        Console.SetOut(output);

        Program.ContadorDeNumeros();

        var result = output.ToString();
        Assert.Contains("Números positivos introducidos: 3", result);
        Assert.Contains("Números negativos introducidos: 5", result);
    }

    [Fact]
    public void ContadorDeNumeros_SoloPositivos()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("1\n2\n3\n0"));
        Console.SetOut(output);

        Program.ContadorDeNumeros();

        var result = output.ToString();
        Assert.Contains("Números positivos introducidos: 3", result);
        Assert.Contains("Números negativos introducidos: 0", result);
    }

    [Fact]
    public void ContadorDeNumeros_SoloNegativos()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("-1\n-2\n-3\n0"));
        Console.SetOut(output);

        Program.ContadorDeNumeros();

        var result = output.ToString();
        Assert.Contains("Números positivos introducidos: 0", result);
        Assert.Contains("Números negativos introducidos: 3", result);
    }

    [Fact]
    public void ContadorDeNumeros_SoloCero()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("0"));
        Console.SetOut(output);

        Program.ContadorDeNumeros();

        var result = output.ToString();
        Assert.Contains("Números positivos introducidos: 0", result);
        Assert.Contains("Números negativos introducidos: 0", result);
    }

    [Fact]
    public void SumaYProducto_PrimerosDiezNumeros()
    {
        var output = new StringWriter();
        Console.SetOut(output);

        Program.SumaYProducto();

        var result = output.ToString();
        Assert.Contains("SUMA: 55", result);
        Assert.Contains("PRODUCTO: 3628800", result);
    }

    [Fact]
    public void ContadorNumerosPares_Numero10()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("10"));
        Console.SetOut(output);

        Program.ContadorNumerosPares();

        var result = output.ToString();
        Assert.Contains("Entre 1 y 10 hay 5 números pares", result);
    }

    [Fact]
    public void ContadorNumerosPares_Numero1()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("1"));
        Console.SetOut(output);

        Program.ContadorNumerosPares();

        var result = output.ToString();
        Assert.Contains("Entre 1 y 1 hay 0 números pares", result);
    }

    [Fact]
    public void ContadorNumerosPares_Numero20()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("20"));
        Console.SetOut(output);

        Program.ContadorNumerosPares();

        var result = output.ToString();
        Assert.Contains("Entre 1 y 20 hay 10 números pares", result);
    }

    [Fact]
    public void SumaDeNumeros_VariosPositivos()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("5\n3\n7\n0"));
        Console.SetOut(output);

        Program.SumaDeNumeros();

        var result = output.ToString();
        Assert.Contains("La suma total es: 15", result);
    }

    [Fact]
    public void SumaDeNumeros_UnSoloNumero()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("10\n-1"));
        Console.SetOut(output);

        Program.SumaDeNumeros();

        var result = output.ToString();
        Assert.Contains("La suma total es: 10", result);
    }

    [Fact]
    public void SumaDeNumeros_NingunPositivo()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("0"));
        Console.SetOut(output);

        Program.SumaDeNumeros();

        var result = output.ToString();
        Assert.Contains("La suma total es: 0", result);
    }

    [Fact]
    public void ProductoMedianteSumas_NumerosPositivos()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("4\n3"));
        Console.SetOut(output);

        Program.ProductoMedianteSumas();

        var result = output.ToString();
        Assert.Contains("Sumando....", result);
        Assert.Contains(" 4 x 3 = 12", result);
    }

    [Fact]
    public void ProductoMedianteSumas_NumeroNegativo()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("-1\n5"));
        Console.SetOut(output);

        Program.ProductoMedianteSumas();

        var result = output.ToString();
        Assert.Contains("ERROR: Sólo se permiten números positivos", result);
    }

    [Fact]
    public void ProductoMedianteSumas_NumeroCero()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("0\n5"));
        Console.SetOut(output);

        Program.ProductoMedianteSumas();

        var result = output.ToString();
        Assert.Contains("ERROR: Sólo se permiten números positivos", result);
    }

    [Fact]
    public void ValidacionDeEntrada_NumeroValido()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("7"));
        Console.SetOut(output);

        Program.ValidacionDeEntrada();

        var result = output.ToString();
        Assert.Contains("Número válido: 7", result);
    }

    [Fact]
    public void ValidacionDeEntrada_NumeroInvalidoLuegoValido()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("15\n-3\n7"));
        Console.SetOut(output);

        Program.ValidacionDeEntrada();

        var result = output.ToString();
        Assert.Contains("Número inválido", result);
        Assert.Contains("Número válido: 7", result);
    }

    [Fact]
    public void ValidacionDeEntrada_LimitesDelRango()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("1"));
        Console.SetOut(output);

        Program.ValidacionDeEntrada();

        var result = output.ToString();
        Assert.Contains("Número válido: 1", result);
    }

    [Fact]
    public void DivisionMedianteRestas_DivisionExacta()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("10\n2"));
        Console.SetOut(output);

        Program.DivisionMedianteRestas();

        var result = output.ToString();
        Assert.Contains("10 / 2 = 5", result);
        Assert.Contains("Resto: 0", result);
    }

    [Fact]
    public void DivisionMedianteRestas_ConResto()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("10\n3"));
        Console.SetOut(output);

        Program.DivisionMedianteRestas();

        var result = output.ToString();
        Assert.Contains("10 / 3 = 3", result);
        Assert.Contains("Resto: 1", result);
    }

    [Fact]
    public void DivisionMedianteRestas_DivisorNegativo()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("10\n-2"));
        Console.SetOut(output);

        Program.DivisionMedianteRestas();

        var result = output.ToString();
        Assert.Contains("ERROR: Sólo se permiten números positivos", result);
    }

    [Fact]
    public void DivisionMedianteRestas_DividendoCero()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("0\n2"));
        Console.SetOut(output);

        Program.DivisionMedianteRestas();

        var result = output.ToString();
        Assert.Contains("ERROR: Sólo se permiten números positivos", result);
    }

    [Fact]
    public void MaximoYMinimo_CincoNumeros()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("23\n45\n12\n67\n34"));
        Console.SetOut(output);

        Program.MaximoYMinimo();

        var result = output.ToString();
        Assert.Contains("El número mayor es: 67", result);
        Assert.Contains("El número menor es: 12", result);
    }

    [Fact]
    public void MaximoYMinimo_TodosIguales()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("5\n5\n5\n5\n5"));
        Console.SetOut(output);

        Program.MaximoYMinimo();

        var result = output.ToString();
        Assert.Contains("El número mayor es: 5", result);
        Assert.Contains("El número menor es: 5", result);
    }

    [Fact]
    public void MaximoYMinimo_NumerosNegativos()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("-10\n-5\n-20\n-3\n-15"));
        Console.SetOut(output);

        Program.MaximoYMinimo();

        var result = output.ToString();
        Assert.Contains("El número mayor es: -3", result);
        Assert.Contains("El número menor es: -20", result);
    }

    [Fact]
    public void SecuenciaFibonacci_OchoNumeros()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("8"));
        Console.SetOut(output);

        Program.SecuenciaFibonacci();

        var result = output.ToString();
        Assert.Contains("0, 1, 1, 2, 3, 5, 8, 13", result);
    }

    [Fact]
    public void SecuenciaFibonacci_UnNumero()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("1"));
        Console.SetOut(output);

        Program.SecuenciaFibonacci();

        var result = output.ToString();
        Assert.Contains("0", result);
        Assert.DoesNotContain(",", result);
    }

    [Fact]
    public void SecuenciaFibonacci_DosNumeros()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("2"));
        Console.SetOut(output);

        Program.SecuenciaFibonacci();

        var result = output.ToString();
        Assert.Contains("0, 1", result);
    }

    [Fact]
    public void SecuenciaFibonacci_NumeroNegativo()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("-1"));
        Console.SetOut(output);

        Program.SecuenciaFibonacci();

        var result = output.ToString();
        Assert.Contains("El número debe ser positivo.", result);
    }

    [Fact]
    public void SecuenciaFibonacci_Cero()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("0"));
        Console.SetOut(output);

        Program.SecuenciaFibonacci();

        var result = output.ToString();
        Assert.Contains("El número debe ser positivo.", result);
    }

    [Fact]
    public void AdivinaNumero_TestDeterministico()
    {
        var output = new StringWriter();
        // Usando semilla 123, Random genera el número 99 con Next(1, 101)
        Console.SetIn(new StringReader("50\n100\n99"));
        Console.SetOut(output);

        // Usamos semilla determinística para que el número a adivinar sea predecible
        Program.AdivinaNumero(123);

        var result = output.ToString();
        Assert.Contains("Adivina el número entre 1 y 100", result);
        Assert.Contains("El número es mayor", result); // Para 50
        Assert.Contains("El número es menor", result); // Para 100
        Assert.Contains("¡Correcto! Has adivinado el número en 3 intentos", result);
    }

    [Fact]
    public void AdivinaNumero_PrimerIntento()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("99"));
        Console.SetOut(output);

        Program.AdivinaNumero(123);

        var result = output.ToString();
        Assert.Contains("¡Correcto! Has adivinado el número en 1 intentos", result);
    }
}
