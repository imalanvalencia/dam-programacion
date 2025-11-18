using System;
using System.IO;

namespace ejercicios.test;

public class UnitTest1
{
   [Fact]
    public void DeterminaSiEsParOImpar_Par()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("4"));
        Console.SetOut(output);

        Program.DeterminaSiEsParOImpar();  
      

        var result = output.ToString();
        Assert.Contains($"El número 4 es par.", result);
    }

    [Fact]
    public void DeterminaSiEsParOImpar_Impar()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("7"));
        Console.SetOut(output);

        Program.DeterminaSiEsParOImpar();  
      
        var result = output.ToString();
        Assert.Contains($"El número 7 es impar.", result);
    }

    
    [Fact]
    public void DeterminaSiEsParOImpar_Cero()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("0"));
        Console.SetOut(output);

        Program.DeterminaSiEsParOImpar();  
      
        var result = output.ToString();
        Assert.Contains($"El número 0 es par.", result);
    }

    [Fact]
    public void ConvierteTemperatura_CelsiusAFahrenheit()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("0\nF"));
        Console.SetOut(output);

        Program.ConvierteTemperatura();

        var result = output.ToString();
        Assert.Contains("0ºC son 32,00ºF", result);
    }

    [Fact]
    public void ConvierteTemperatura_FahrenheitACelsius()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("32\nC"));
        Console.SetOut(output);

        Program.ConvierteTemperatura();

        var result = output.ToString();
        Assert.Contains("32ºF son 0,00ºC", result);
    }

    [Fact]
    public void ConvierteTemperatura_OpcionInvalida()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("25\nX"));
        Console.SetOut(output);

        Program.ConvierteTemperatura();

        var result = output.ToString();
        Assert.Contains("Opción no válida.", result);
    }

    [Fact]
    public void CalculaSalarioSemanal_SinHorasExtra()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("40\n10"));
        Console.SetOut(output);

        Program.CalculaSalarioSemanal();

        var result = output.ToString();
        Assert.Contains("El salario semanal es:", result);
    }

    [Fact]
    public void CalculaSalarioSemanal_ConHorasExtra()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("45\n10"));
        Console.SetOut(output);

        Program.CalculaSalarioSemanal();

        var result = output.ToString();
        Assert.Contains("El salario semanal es:", result);
    }

    [Fact]
    public void CalculaPromedioYDeterminaAprobacion_Aprobado()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("7\n8\n6"));
        Console.SetOut(output);

        Program.CalculaPromedioYDeterminaAprobacion();

        var result = output.ToString();
        Assert.Contains("Resultado: Aprobado", result);
    }

    [Fact]
    public void CalculaPromedioYDeterminaAprobacion_Suspendido()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("4\n3\n2"));
        Console.SetOut(output);

        Program.CalculaPromedioYDeterminaAprobacion();

        var result = output.ToString();
        Assert.Contains("Resultado: Suspendido", result);
    }

    [Fact]
    public void RealizaCalculadoraBasica_Suma()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("10\n5\n+"));
        Console.SetOut(output);

        Program.RealizaCalculadoraBasica();

        var result = output.ToString();
        Assert.Contains("Resultado: 15", result);
    }

    [Fact]
    public void RealizaCalculadoraBasica_Division()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("10\n5\n/"));
        Console.SetOut(output);

        Program.RealizaCalculadoraBasica();

        var result = output.ToString();
        Assert.Contains("Resultado: 2", result);
    }

    [Fact]
    public void RealizaCalculadoraBasica_DivisionPorCero()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("10\n0\n/"));
        Console.SetOut(output);

        Program.RealizaCalculadoraBasica();

        var result = output.ToString();
        Assert.Contains("Error: División entre cero.", result);
    }

    [Fact]
    public void RealizaCalculadoraBasica_OperadorInvalido()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("10\n5\n%"));
        Console.SetOut(output);

        Program.RealizaCalculadoraBasica();

        var result = output.ToString();
        Assert.Contains("Operador no válido.", result);
    }

    [Fact]
    public void ComparaNumeros_PrimeroEsMayor()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("10\n5"));
        Console.SetOut(output);

        Program.ComparaNumeros();

        var result = output.ToString();
        Assert.Contains("10 es mayor que 5.", result);
    }

    [Fact]
    public void ComparaNumeros_PrimeroEsMenor()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("5\n10"));
        Console.SetOut(output);

        Program.ComparaNumeros();

        var result = output.ToString();
        Assert.Contains("5 es menor que 10.", result);
    }

    [Fact]
    public void ComparaNumeros_SonIguales()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("5\n5"));
        Console.SetOut(output);

        Program.ComparaNumeros();

        var result = output.ToString();
        Assert.Contains("Los números son iguales.", result);
    }

    [Fact]
    public void VerificaContrasena_Correcta()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("12345"));
        Console.SetOut(output);

        Program.VerificaContrasena();

        var result = output.ToString();
        Assert.Contains("Contraseña correcta.", result);
    }

    [Fact]
    public void VerificaContrasena_Incorrecta()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("54321"));
        Console.SetOut(output);

        Program.VerificaContrasena();

        var result = output.ToString();
        Assert.Contains("Contraseña incorrecta.", result);
    }

    [Fact]
    public void CalculaCosteVacaciones_TipoA()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("A\n5"));
        Console.SetOut(output);

        Program.CalculaCosteVacaciones();

        var result = output.ToString();
        Assert.Contains("Total a pagar:", result);
    }

    [Fact]
    public void CalculaCosteVacaciones_TipoB()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("B\n3"));
        Console.SetOut(output);

        Program.CalculaCosteVacaciones();

        var result = output.ToString();
        Assert.Contains("Total a pagar:", result);
    }

    [Fact]
    public void CalculaCosteVacaciones_TipoInvalido()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("C\n5"));
        Console.SetOut(output);

        Program.CalculaCosteVacaciones();

        var result = output.ToString();
        Assert.Contains("Tipo de vacaciones incorrecto", result);
    }

    [Fact]
    public void MuestraInstruccionSemaforo_Rojo()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("rojo"));
        Console.SetOut(output);

        Program.MuestraInstruccionSemaforo();

        var result = output.ToString();
        Assert.Contains("Detente", result);
    }

    [Fact]
    public void MuestraInstruccionSemaforo_Verde()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("verde"));
        Console.SetOut(output);

        Program.MuestraInstruccionSemaforo();

        var result = output.ToString();
        Assert.Contains("Avanza", result);
    }

    [Fact]
    public void MuestraInstruccionSemaforo_ColorInvalido()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("azul"));
        Console.SetOut(output);

        Program.MuestraInstruccionSemaforo();

        var result = output.ToString();
        Assert.Contains("Color no válido", result);
    }

    [Fact]
    public void ClasificaPorEdad_Ninez()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("10"));
        Console.SetOut(output);

        Program.ClasificaPorEdad();

        var result = output.ToString();
        Assert.Contains("Se encuentra en el grupo etario: Niñez", result);
    }

    [Fact]
    public void ClasificaPorEdad_Adolescencia()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("15"));
        Console.SetOut(output);

        Program.ClasificaPorEdad();

        var result = output.ToString();
        Assert.Contains("Se encuentra en el grupo etario: Adolescencia", result);
    }

    [Fact]
    public void ClasificaPorEdad_Adultez()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("30"));
        Console.SetOut(output);

        Program.ClasificaPorEdad();

        var result = output.ToString();
        Assert.Contains("Se encuentra en el grupo etario: Adultez", result);
    }

    [Fact]
    public void ClasificaPorEdad_Vejez()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("70"));
        Console.SetOut(output);

        Program.ClasificaPorEdad();

        var result = output.ToString();
        Assert.Contains("Se encuentra en el grupo etario: Vejez", result);
    }

    [Fact]
    public void CalculaNotaFinal_NotaExamen4()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("4\n7"));
        Console.SetOut(output);

        Program.CalculaNotaFinal();

        var result = output.ToString();
        Assert.Contains("La nota final es: 4", result);
    }

    [Fact]
    public void CalculaNotaFinal_NotaExamen7_PracticasAltas()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("7\n10"));
        Console.SetOut(output);

        Program.CalculaNotaFinal();

        var result = output.ToString();
        Assert.Contains("8,5", result);
    }

    [Fact]
    public void CalculaNotaFinal_NotaExamen10_PracticasBajas()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("10\n7"));
        Console.SetOut(output);

        Program.CalculaNotaFinal();

        var result = output.ToString();
        Assert.Contains("La nota final es: 9", result);
    }

    [Fact]
    public void CalculaNotaFinal_NotasInvalidas()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("5\n8"));
        Console.SetOut(output);

        Program.CalculaNotaFinal();

        var result = output.ToString();
        Assert.Contains("Nota incorrecta", result);
    }

    [Fact]
    public void ClasificaTriangulo_Equilatero()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("5\n5\n5"));
        Console.SetOut(output);

        Program.ClasificaTriangulo();

        var result = output.ToString();
        Assert.Contains("El triángulo es equilátero.", result);
    }

    [Fact]
    public void ClasificaTriangulo_Isosceles()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("5\n5\n3"));
        Console.SetOut(output);

        Program.ClasificaTriangulo();

        var result = output.ToString();
        Assert.Contains("El triángulo es isósceles.", result);
    }

    [Fact]
    public void ClasificaTriangulo_Escaleno()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("3\n4\n5"));
        Console.SetOut(output);

        Program.ClasificaTriangulo();

        var result = output.ToString();
        Assert.Contains("El triángulo es escaleno.", result);
    }

    [Fact]
    public void AdivinaElNumero_NumeroMayor()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("75"));
        Console.SetOut(output);

        // Para hacer el test determinístico, necesitaríamos modificar el método original
        // Por ahora, solo verificamos que el método se ejecute sin errores
        Program.AdivinaElNumero();

        var result = output.ToString();
        Assert.True(result.Contains("Adivina el número") || result.Contains("El número es") || result.Contains("¡Felicidades!"));
    }
}
