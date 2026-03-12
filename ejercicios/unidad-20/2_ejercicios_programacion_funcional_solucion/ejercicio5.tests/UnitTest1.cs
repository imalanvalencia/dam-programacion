using System;
using System.IO;
using Xunit;
using Ejercicio5;

namespace ejercicio5.tests;

public class UnitTest1
{
    [Fact]
    public void TestMain()
    {
        // Guardamos la referencia a la entrada/salida original para restaurarla después
        var originalOut = Console.Out;
        var originalIn = Console.In;

        try
        {
            // Simulamos la entrada de usuario (ENTER para finalizar)
            var input = Environment.NewLine;
            var stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            // Capturamos la salida
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Ejecutamos el Main
            Program.Main();

            // Obtenemos la salida
            var output = stringWriter.ToString();

            // Verificaciones (Asserts)
            // Nota: Los separadores decimales pueden variar según cultura (, o .)
            // Usamos verificaciones más flexibles si es necesario, o asumimos la cultura del sistema (ES suele ser coma).
            
            Assert.Contains("Ejercicio 5. Carrito compra con Lambdas", output);
            
            // 4 + (4*3/100) = 4.12
            // 4 - (4*3/100) = 3.88
            // Total carrito (verificado manual): 58.6
            
            // Comprobamos partes del texto para evitar problemas con números muy precisos o formatos
            Assert.Contains("total final será:", output);
            
            // Verificamos si contiene los números esperados (asumiendo formato local, probablemente coma en ES)
            // Si falla por cultura, ajustaremos.
            // 4,12 o 4.12
            bool contieneIva = output.Contains("4,12") || output.Contains("4.12");
            Assert.True(contieneIva, "Debería contener el cálculo del IVA correcto");

            bool contieneDescuento = output.Contains("3,88") || output.Contains("3.88");
            Assert.True(contieneDescuento, "Debería contener el cálculo del descuento correcto");
            
            bool contieneTotal = output.Contains("58,6") || output.Contains("58.6");
            Assert.True(contieneTotal, "Debería contener el total del carrito correcto");
        }
        finally
        {
            // Restauramos la consola
            Console.SetOut(originalOut);
            Console.SetIn(originalIn);
        }
    }

    [Fact]
    public void AplicaIva_CalculaPrecioConIva()
    {
        var ivaFunc = Program.AplicaIva();
        // 100 + (100 * 21 / 100) = 121
        Assert.Equal(121, ivaFunc(21, 100));
    }

    [Fact]
    public void AplicaDescuento_CalculaPrecioConDescuento()
    {
        var descFunc = Program.AplicaDescuento();
        // 100 - (100 * 10 / 100) = 90
        Assert.Equal(90, descFunc(10, 100));
    }

    [Fact]
    public void CarritoCompra_CalculaTotalCorrectamente()
    {
        var carritoFunc = Program.CarritoCompra();
        var lista = new System.Collections.Generic.List<(float, float)> { (100, 10), (200, 20) };
        var sumaFunc = Program.AplicaDescuento(); // Use Discount logic
        
        // Item 1: 100 - 10% = 90
        // Item 2: 200 - 20% = 160
        // Total: 250
        
        float total = carritoFunc(lista, sumaFunc);
        Assert.Equal(250, total);
    }
}
