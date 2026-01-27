
using Ejercicio5;
using System.Collections.Generic;

namespace ejercicio5.tests;

public class AlbergueTests
{
    [Fact]
    public void MostrarEstado_MuestraTodosLosAlbergues()
    {
        var lista = new List<Albergue>
        {
            new AlbergueRural("RuralTest", 10, new Direccion("Ciudad", "Pais"), 20),
            new AlbergueUrbano("UrbanoTest", 15, new Direccion("Ciudad", "Pais"), 22)
        };
        using var sw = new System.IO.StringWriter();
        var originalOut = Console.Out;
        Console.SetOut(sw);
        Program.MuestraEstado(lista);
        Console.SetOut(originalOut);
        var output = sw.ToString();
        Assert.Contains("RuralTest", output);
        Assert.Contains("UrbanoTest", output);
    }

    [Fact]
    public void MostrarInfoComplementaria_MuestraInfoDeCadaAlbergue()
    {
        var lista = new List<Albergue>
        {
            new AlbergueRural("RuralTest", 10, new Direccion("Ciudad", "Pais"), 20),
            new AlbergueCostero("CosteroTest", 12, new Direccion("Ciudad", "Pais"), 25)
        };
        using var sw = new System.IO.StringWriter();
        var originalOut = Console.Out;
        Console.SetOut(sw);
        Program.MuestraInfoComplementaria(lista);
        Console.SetOut(originalOut);
        var output = sw.ToString();
        Assert.Contains("RuralTest", output);
        Assert.Contains("CosteroTest", output);
        Assert.Contains("Clima previsto", output);
        Assert.Contains("Oleaje estimado", output);
    }

    [Fact]
    public void RegistraReserva_RegistraCorrectamenteYActualizaOcupacion()
    {
        var lista = new List<Albergue>
        {
            new AlbergueRural("RuralTest", 10, new Direccion("Ciudad", "Pais"), 20)
        };
        // Simular entrada de consola: índice 0, plazas 2, temporada alta S
        var input = new System.IO.StringReader("0\n2\nS\n");
        var originalIn = Console.In;
        using var sw = new System.IO.StringWriter();
        var originalOut = Console.Out;
        Console.SetIn(input);
        Console.SetOut(sw);
        Program.RegistraReserva(lista);
        Console.SetIn(originalIn);
        Console.SetOut(originalOut);
        Assert.Equal(2, lista[0].PlazasOcupadas);
        var output = sw.ToString();
        Assert.Contains("ACEPTADA", output);
    }

    [Fact]
    public void AlbergueRural_PrecioAltaYOcupacion()
    {
        var rural = new AlbergueRural("RuralTest", 10, new Direccion("Ciudad", "Pais"), 20);
        rural.RegistraReserva(3, true); // alta
        rural.RegistraReserva(1, false);
        Assert.Equal(43, rural.CalculaPrecioActual(), 0);
    }

    [Fact]
    public void AlbergueUrbano_PrecioConOcupacion()
    {
        var urbano = new AlbergueUrbano("UrbanoTest", 10, new Direccion("Ciudad", "Pais"), 20);
        for (int i = 0; i < 6; i++) urbano.RegistraReserva(1, false);
        Assert.Equal(22, urbano.CalculaPrecioActual(), 0);
    }

    [Fact]
    public void AlbergueCostero_ReservaAltaGrande_Rechazada()
    {
        var costero = new AlbergueCostero("CosteroTest", 10, new Direccion("Ciudad", "Pais"), 20);
        bool admitida = costero.RegistraReserva(7, true); // >60% de 10
        Assert.False(admitida);
    }

    [Fact]
    public void Albergue_ReservaNegativa_Rechazada()
    {
        var rural = new AlbergueRural("RuralTest", 10, new Direccion("Ciudad", "Pais"), 20);
        bool admitida = rural.RegistraReserva(-2, false);
        Assert.False(admitida);
    }
}
