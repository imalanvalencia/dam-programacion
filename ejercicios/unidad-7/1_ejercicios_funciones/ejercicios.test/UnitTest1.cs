using System;
using System.IO;
using System.Globalization;

namespace ejercicios.test;

public class UnitTest1
{
    [Fact]
    public void MuestraInformacion_DatosCompletos()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("Juan\nGarcía\n25\nAlicante"));
        Console.SetOut(output);

        Program.MuestraInformacion();

        var result = output.ToString();
        Assert.Contains("=== INFORMACIÓN PERSONAL ===", result);
        Assert.Contains("Nombre completo: Juan García", result);
        Assert.Contains("Edad: 25 años", result);
        Assert.Contains("Ciudad de residencia: Alicante", result);
        Assert.Contains("==========================", result);
    }

    [Fact]
    public void VolumenEsfera_Radio3()
    {
        var output = new StringWriter();
        Console.SetOut(output);

        Program.VolumenEsfera(3.0);

        var result = output.ToString();
        Assert.Contains("El volumen de la esfera es: 113,10", result);
    }

    [Fact]
    public void VolumenEsfera_Radio1()
    {
        var output = new StringWriter();
        Console.SetOut(output);

        Program.VolumenEsfera(1.0);

        var result = output.ToString();
        Assert.Contains("El volumen de la esfera es: 4,19", result);
    }

    [Fact]
    public void VolumenEsfera_Radio0()
    {
        var output = new StringWriter();
        Console.SetOut(output);

        Program.VolumenEsfera(0.0);

        var result = output.ToString();
        Assert.Contains("El volumen de la esfera es: 0,00", result);
    }

    [Fact]
    public void Mayor_PrimeroEsMayor()
    {
        var output = new StringWriter();
        Console.SetOut(output);

        Program.Mayor(15, 8, 10);

        var result = output.ToString();
        Assert.Contains("El mayor de los tres números es: 15", result);
    }

    [Fact]
    public void Mayor_SegundoEsMayor()
    {
        var output = new StringWriter();
        Console.SetOut(output);

        Program.Mayor(15, 23, 8);

        var result = output.ToString();
        Assert.Contains("El mayor de los tres números es: 23", result);
    }

    [Fact]
    public void Mayor_TerceroEsMayor()
    {
        var output = new StringWriter();
        Console.SetOut(output);

        Program.Mayor(8, 15, 20);

        var result = output.ToString();
        Assert.Contains("El mayor de los tres números es: 20", result);
    }

    [Fact]
    public void Mayor_TodosIguales()
    {
        var output = new StringWriter();
        Console.SetOut(output);

        Program.Mayor(10, 10, 10);

        var result = output.ToString();
        Assert.Contains("El mayor de los tres números es: 10", result);
    }

    [Fact]
    public void Mayor_NumerosNegativos()
    {
        var output = new StringWriter();
        Console.SetOut(output);

        Program.Mayor(-5, -2, -8);

        var result = output.ToString();
        Assert.Contains("El mayor de los tres números es: -2", result);
    }

    [Fact]
    public void FormateaFecha_RetornaFormatoCorrecto()
    {
        string fechaFormateada = Program.FormateaFecha();
        
        // Verificamos que contiene los elementos esperados
        Assert.Contains("Hoy estamos a", fechaFormateada);
        Assert.Contains("de", fechaFormateada);
        
        // Verificamos que contiene un mes válido
        string[] meses = {"Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio",
                         "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"};
        bool contieneUnMes = false;
        foreach (string mes in meses)
        {
            if (fechaFormateada.Contains(mes))
            {
                contieneUnMes = true;
                break;
            }
        }
        Assert.True(contieneUnMes);
    }

    [Fact]
    public void EsBisiesto_AñoBisiesto2024()
    {
        bool resultado = Program.EsBisiesto(2024);
        Assert.True(resultado);
    }

    [Fact]
    public void EsBisiesto_AñoBisiesto2000()
    {
        bool resultado = Program.EsBisiesto(2000);
        Assert.True(resultado);
    }

    [Fact]
    public void EsBisiesto_AñoNoBisiesto2023()
    {
        bool resultado = Program.EsBisiesto(2023);
        Assert.False(resultado);
    }

    [Fact]
    public void EsBisiesto_AñoNoBisiesto1900()
    {
        bool resultado = Program.EsBisiesto(1900);
        Assert.False(resultado);
    }

    [Fact]
    public void EsBisiesto_AñoBisiesto1600()
    {
        bool resultado = Program.EsBisiesto(1600);
        Assert.True(resultado);
    }

    [Fact]
    public void GeneraContraseña_SoloLetras()
    {
        string contraseña = Program.GeneraContraseña(8, false, false);
        
        Assert.Equal(8, contraseña.Length);
        // Verificar que contiene solo letras
        foreach (char c in contraseña)
        {
            Assert.True(char.IsLetter(c));
        }
    }

    [Fact]
    public void GeneraContraseña_ConNumeros()
    {
        string contraseña = Program.GeneraContraseña(12, true, false);
        
        Assert.Equal(12, contraseña.Length);
        // Verificar que contiene solo letras y números
        foreach (char c in contraseña)
        {
            Assert.True(char.IsLetterOrDigit(c));
        }
    }

    [Fact]
    public void GeneraContraseña_ConSimbolos()
    {
        string contraseña = Program.GeneraContraseña(10, false, true);
        
        Assert.Equal(10, contraseña.Length);
        // Verificar que contiene letras o símbolos válidos
        string simbolosValidos = "!@#$%&*";
        foreach (char c in contraseña)
        {
            Assert.True(char.IsLetter(c) || simbolosValidos.Contains(c));
        }
    }

    [Fact]
    public void GeneraContraseña_ConTodo()
    {
        string contraseña = Program.GeneraContraseña(15, true, true);
        
        Assert.Equal(15, contraseña.Length);
        // Verificar que contiene caracteres válidos
        string simbolosValidos = "!@#$%&*";
        foreach (char c in contraseña)
        {
            Assert.True(char.IsLetter(c) || char.IsDigit(c) || simbolosValidos.Contains(c));
        }
    }

    [Fact]
    public void CalculaPrestamo_Prestamo10000()
    {
        var resultado = Program.CalculaPrestamo(10000, 5, 3);
        
        // Verificar que los valores están en el rango esperado
        Assert.True(resultado.pagoMensual > 290 && resultado.pagoMensual < 310);
        Assert.True(resultado.totalPagar > 10700 && resultado.totalPagar < 10900);
        Assert.True(resultado.interesesTotales > 700 && resultado.interesesTotales < 900);
    }

    [Fact]
    public void CalculaPrestamo_PrestamoSimple()
    {
        var resultado = Program.CalculaPrestamo(1000, 12, 1);
        
        // Verificar que los valores son positivos y coherentes
        Assert.True(resultado.pagoMensual > 0);
        Assert.True(resultado.totalPagar > 1000);
        Assert.True(resultado.interesesTotales > 0);
        Assert.Equal(resultado.totalPagar, resultado.pagoMensual * 12, 2);
    }

    [Fact]
    public void Distancia_PuntosConocidos()
    {
        double resultado = Program.Distancia((1, 2), (4, 6));
        
        Assert.Equal(5.0, resultado, 2);
    }

    [Fact]
    public void Distancia_PuntosIguales()
    {
        double resultado = Program.Distancia((3, 4), (3, 4));
        
        Assert.Equal(0.0, resultado, 2);
    }

    [Fact]
    public void Distancia_PuntosEjeX()
    {
        double resultado = Program.Distancia((0, 0), (3, 0));
        
        Assert.Equal(3.0, resultado, 2);
    }

    [Fact]
    public void Distancia_PuntosEjeY()
    {
        double resultado = Program.Distancia((0, 0), (0, 4));
        
        Assert.Equal(4.0, resultado, 2);
    }

    [Fact]
    public void TiempoASegundos_SoloMinutos()
    {
        int resultado = Program.TiempoASegundos(5);
        
        Assert.Equal(300, resultado);
    }

    [Fact]
    public void TiempoASegundos_HorasYMinutos()
    {
        int resultado = Program.TiempoASegundos(2, 30);
        
        Assert.Equal(9000, resultado); // 2*3600 + 30*60 = 7200 + 1800 = 9000
    }

    [Fact]
    public void TiempoASegundos_DiasHorasMinutos()
    {
        int resultado = Program.TiempoASegundos(1, 2, 30);
        
        Assert.Equal(95400, resultado); // 1*86400 + 2*3600 + 30*60 = 86400 + 7200 + 1800 = 95400
    }

    [Fact]
    public void TiempoASegundos_Ceros()
    {
        int resultado = Program.TiempoASegundos(0, 0, 0);
        
        Assert.Equal(0, resultado);
    }

    [Fact]
    public void LeeEnteroEnRango_NumeroValido()
    {
        Console.SetIn(new StringReader("50"));
        
        int resultado = Program.LeeEnteroEnRango(1, 100);
        
        Assert.Equal(50, resultado);
    }

    [Fact]
    public void LeeEnteroEnRango_NumeroInvalidoLuegoValido()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("150\n-5\n75"));
        Console.SetOut(output);
        
        int resultado = Program.LeeEnteroEnRango(1, 100);
        
        Assert.Equal(75, resultado);
        var outputText = output.ToString();
        Assert.Contains("Número fuera de rango", outputText);
    }

    [Fact]
    public void LeeEnteroEnRango_EntradaNoNumerica()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("abc\n50"));
        Console.SetOut(output);
        
        int resultado = Program.LeeEnteroEnRango(1, 100);
        
        Assert.Equal(50, resultado);
        var outputText = output.ToString();
        Assert.Contains("Número fuera de rango", outputText);
    }

    [Fact]
    public void LeeEnteroEnRango_LimitesDelRango()
    {
        Console.SetIn(new StringReader("1"));
        
        int resultado = Program.LeeEnteroEnRango(1, 100);
        
        Assert.Equal(1, resultado);
    }

    [Fact]
    public void LeeEnteroEnRango_LimiteSuperior()
    {
        Console.SetIn(new StringReader("100"));
        
        int resultado = Program.LeeEnteroEnRango(1, 100);
        
        Assert.Equal(100, resultado);
    }

    // Tests para los métodos principales de ejercicios
    [Fact]
    public void Ejercicio1_FuncionamientoCompleto()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("Ana\nMartínez\n30\nValencia"));
        Console.SetOut(output);

        Program.Ejercicio1();

        var result = output.ToString();
        Assert.Contains("Ejercicio 1. Función sin parámetros de entrada y sin retorno", result);
        Assert.Contains("Nombre completo: Ana Martínez", result);
    }

    [Fact]
    public void Ejercicio2_VolumenEsfera()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("3"));
        Console.SetOut(output);

        Program.Ejercicio2();

        var result = output.ToString();
        Assert.Contains("Ejercicio 2. Función sin parámetros de entrada y sin retorno", result);
        Assert.Contains("El volumen de la esfera es: 113,10", result);
    }

    [Fact]
    public void Ejercicio3_Mayor()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("15\n23\n8"));
        Console.SetOut(output);

        Program.Ejercicio3();

        var result = output.ToString();
        Assert.Contains("Ejercicio 3: Función con múltiples parámetros y sin retorno", result);
        Assert.Contains("El mayor de los tres números es: 23", result);
    }

    [Fact]
    public void Ejercicio5_EsBisiesto()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("2024"));
        Console.SetOut(output);

        Program.Ejercicio5();

        var result = output.ToString();
        Assert.Contains("Ejercicio 5: Función de validación", result);
        Assert.Contains("El año 2024 es bisiesto", result);
    }

    [Fact]
    public void Ejercicio5_NoEsBisiesto()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("2023"));
        Console.SetOut(output);

        Program.Ejercicio5();

        var result = output.ToString();
        Assert.Contains("El año 2023 no es bisiesto", result);
    }

    [Fact]
    public void Ejercicio6_GeneracionContraseña()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("12\ns\nn"));
        Console.SetOut(output);

        Program.Ejercicio6();

        var result = output.ToString();
        Assert.Contains("Ejercicio 6. Función generadora de contraseñas", result);
        Assert.Contains("Contraseña generada:", result);
    }

    [Fact]
    public void Ejercicio8_DistanciaPuntos()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("1\n2\n4\n6"));
        Console.SetOut(output);

        Program.Ejercicio8();

        var result = output.ToString();
        Assert.Contains("Ejercicio 8. Función con parámetros de entrada complejos", result);
        Assert.Contains("La distancia entre los puntos es: 5,00", result);
    }

    [Fact]
    public void Ejercicio9_TiempoASegundos()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("1\n2\n30"));
        Console.SetOut(output);

        Program.Ejercicio9();

        var result = output.ToString();
        Assert.Contains("Ejercicio 9. Sobrecarga para cálculos de tiempo", result);
        Assert.Contains("Tiempo total en segundos: 95400", result);
    }

    [Fact]
    public void Ejercicio10_ValidacionEntrada()
    {
        var output = new StringWriter();
        Console.SetIn(new StringReader("150\n-5\n50"));
        Console.SetOut(output);

        Program.Ejercicio10();

        var result = output.ToString();
        Assert.Contains("Ejercicio 10. Función con validación de entrada", result);
        Assert.Contains("Número válido introducido: 50", result);
        Assert.Contains("Número fuera de rango", result);
    }
}
