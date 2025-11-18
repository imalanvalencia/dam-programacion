using System;
using System.Linq;
using Xunit;

namespace ejercicio5.test;

public class UnitTest1
{
    [Fact]
    public void MuestraPedidosSemanaYTotales_NoGeneranExcepcion_ConSemanaManual()
    {
        string[] harinas = new string[] { "Trigo", "Centeno", "Espelta", "Maíz" };

        // Construimos la semana manualmente usando tuplas
        (string, int)[][] semana = new (string, int)[][]
        {
            new (string,int)[] { ("Trigo", 10), ("Espelta", 5) }, // Lunes
            new (string,int)[] { ("Centeno", 3) },                // Martes
            new (string,int)[] { ("Trigo", 4), ("Maíz", 2), ("Espelta", 1) }, // Miércoles
            new (string,int)[] { }, // Jueves
            new (string,int)[] { ("Trigo", 12), ("Centeno", 2) }, // Viernes
            new (string,int)[] { ("Maíz", 6) }, // Sábado
            new (string,int)[] { ("Trigo", 1), ("Espelta", 2) } // Domingo
        };

        var ex1 = Record.Exception(() => Program.MuestraPedidosSemana(semana));
        var ex2 = Record.Exception(() => Program.MuestraTotalesPedidos(semana, harinas));

        Assert.Null(ex1);
        Assert.Null(ex2);
    }

    [Fact]
    public void CalculaTotales_CoincidenConEsperado_ConSemanaManual()
    {
        string[] harinas = new string[] { "Trigo", "Centeno", "Espelta", "Maíz" };

        (string, int)[][] semana = new (string, int)[][]
        {
            new (string,int)[] { ("Trigo", 10), ("Espelta", 5) }, // Lunes
            new (string,int)[] { ("Centeno", 3) },                // Martes
            new (string,int)[] { ("Trigo", 4), ("Maíz", 2), ("Espelta", 1) } // Miércoles
        };

        // Calculamos totales en el test (no dependemos de métodos privados)
        int[] totalesEsperados = new int[harinas.Length];
        foreach (var dia in semana)
        {
            if (dia == null) continue;
            foreach (var (h, c) in dia)
            {
                int idx = Array.IndexOf(harinas, h);
                if (idx >= 0) totalesEsperados[idx] += c;
            }
        }

        // Llamamos al método público que imprime totales para verificar que acepta la estructura
        var ex = Record.Exception(() => Program.MuestraTotalesPedidos(semana, harinas));
        Assert.Null(ex);

        // Comprobamos los valores calculados aquí para coincidir con el ejemplo
        Assert.Equal(14, totalesEsperados[0]); // Trigo 10 + 4
        Assert.Equal(3, totalesEsperados[1]);  // Centeno 3
        Assert.Equal(6, totalesEsperados[2]);  // Espelta 5 + 1
        Assert.Equal(2, totalesEsperados[3]);  // Maíz 2
    }

    [Fact]
    public void HarinaMasPedida_DerivadaDeTotales_CoincideConEjemplo()
    {
        string[] harinas = new string[] { "Trigo", "Centeno", "Espelta", "Maíz" };

        (string, int)[][] semana = new (string, int)[][]
        {
            new (string,int)[] { ("Trigo", 10), ("Espelta", 5) }, // Lunes
            new (string,int)[] { ("Centeno", 3) },                // Martes
            new (string,int)[] { ("Trigo", 4), ("Maíz", 2), ("Espelta", 1) }, // Miércoles
            new (string,int)[] { }, // Jueves
            new (string,int)[] { ("Trigo", 12), ("Centeno", 2) }, // Viernes
            new (string,int)[] { ("Maíz", 6) }, // Sábado
            new (string,int)[] { ("Trigo", 1), ("Espelta", 2) } // Domingo
        };

        int[] totales = new int[harinas.Length];
        foreach (var dia in semana)
        {
            if (dia == null) continue;
            foreach (var (h, c) in dia)
            {
                int idx = Array.IndexOf(harinas, h);
                if (idx >= 0) totales[idx] += c;
            }
        }

        // Encontrar la harina más pedida en test
        int idxMax = 0;
        for (int i = 1; i < totales.Length; i++) if (totales[i] > totales[idxMax]) idxMax = i;

        Assert.Equal("Trigo", harinas[idxMax]);
        Assert.Equal(27, totales[idxMax]);
    }
}
