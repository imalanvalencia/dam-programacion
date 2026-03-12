using System;
using System.IO;
using Xunit;
using Ejercicio2;

namespace ejercicio2.tests;

public class UnitTest1
{
    [Fact]
    public void TestMain()
    {
        // Guardamos la referencia a la entrada/salida original para restaurarla después (buena práctica)
        var originalOut = Console.Out;
        var originalIn = Console.In;

        try
        {
            // Simulate user input: "mesa" followed by newline
            string input = "mesa" + Environment.NewLine;
            var stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            // Capture output
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Run Main
            Principal.Main();

            // Assertions
            var output = stringWriter.ToString();
            
            // Verificamos que se muestra el resultado esperado
            // El Main imprime la lista, pide entrada, y luego imprime resultados de clausura y sin clausura
            // Si buscamos "mesa", deberíamos ver "mesa" en la salida resultado.
            // La salida contiene: "Lista: ...  Buscar coincidencias ... mesa ... Buscar coincidencias ... mesa ..."
            
            Assert.Contains("Introduce una cadena a buscar:", output);
            Assert.Contains("Buscar coincidencias de mesa - Usando Clausuras", output);
            Assert.Contains("mesa", output); 
        }
        finally
        {
            // Restore console
            Console.SetOut(originalOut);
            Console.SetIn(originalIn);
        }
    }

    [Fact]
    public void CoincidenciasCadena_UsandoClausuras_EncuentraCoincidencias()
    {
        var lista = new System.Collections.Generic.List<string> { "casa", "masa", "cosa" };
        var funcionBusqueda = Principal.CoincidenciasCadena_UsandoClausuras(lista);
        var resultado = funcionBusqueda("asa");
        Assert.Contains("casa", resultado);
        Assert.Contains("masa", resultado);
        Assert.DoesNotContain("cosa", resultado);
    }

    [Fact]
    public void CoincidenciasCadena_SinUsarClausuras_EncuentraCoincidencias()
    {
        var lista = new System.Collections.Generic.List<string> { "casa", "masa", "cosa" };
        var resultado = Principal.CoincidenciasCadena_SinUsarClausuras("asa", lista);
        Assert.Contains("casa", resultado);
        Assert.Contains("masa", resultado);
        Assert.DoesNotContain("cosa", resultado);
    }
}
