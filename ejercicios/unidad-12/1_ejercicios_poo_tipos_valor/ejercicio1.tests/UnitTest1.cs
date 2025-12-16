using System;
using System.IO;
using System.Text;

namespace ejercicio1.tests;

public class UnitTest1
{
    [Fact]
    public void DemuestraTipoValor_FechasIndependientesEnMemoria()
    {
        // Arrange
        var originalOut = Console.Out;
        
        try
        {
            using (var stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                
                // Act
                Program.DemuestraTipoValor();
                string output = stringWriter.ToString();
                
                // Assert
                Assert.Contains("DateTime (tipo valor)", output);
                Assert.Contains("25/12/2025", output);
                Assert.Contains("30/12/2025", output);
                
                // Verificar que demuestra el comportamiento de tipos valor
                Assert.Contains("Modificando fecha copiada", output);
            }
        }
        finally
        {
            Console.SetOut(originalOut);
        }
        
        // Además verificar el comportamiento directamente
        DateTime fechaOriginal = new DateTime(2025, 12, 25, 10, 30, 0);
        DateTime fechaCopiada = fechaOriginal;
        fechaCopiada = fechaCopiada.AddDays(5);
        
        // Los tipos valor son independientes
        Assert.NotEqual(fechaOriginal, fechaCopiada);
        Assert.Equal(new DateTime(2025, 12, 25, 10, 30, 0), fechaOriginal);
        Assert.Equal(new DateTime(2025, 12, 30, 10, 30, 0), fechaCopiada);
    }

    [Fact]
    public void DemuestraTipoReferencia_ObjetosCompartenMemoria()
    {
        // Arrange
        var originalOut = Console.Out;
        
        try
        {
            using (var stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                
                // Act
                Program.DemuestraTipoReferencia();
                string output = stringWriter.ToString();
                
                // Assert
                Assert.Contains("StringBuilder (tipo referencia)", output);
                Assert.Contains("Hola mundo", output);
                Assert.Contains("Hola mundo!!!", output);
                
                // Verificar que demuestra el comportamiento de tipos referencia
                Assert.Contains("Modificando texto copiado", output);
            }
        }
        finally
        {
            Console.SetOut(originalOut);
        }
        
        // Además verificar el comportamiento directamente
        StringBuilder textoOriginal = new StringBuilder("Hola mundo");
        StringBuilder textoCopiado = textoOriginal;
        textoCopiado.Append("!!!");
        
        // Los tipos referencia comparten memoria
        Assert.Equal(textoOriginal.ToString(), textoCopiado.ToString());
        Assert.Equal("Hola mundo!!!", textoOriginal.ToString());
        Assert.True(ReferenceEquals(textoOriginal, textoCopiado));
    }

    [Fact]
    public void ModificaTipoValor_NoDeberiaAfectarOriginal()
    {
        // Arrange
        DateTime fechaOriginal = new DateTime(2025, 1, 1, 12, 0, 0);
        DateTime fechaAntes = fechaOriginal;
        
        // Act
        Program.ModificaTipoValor(fechaOriginal);
        
        // Assert
        Assert.Equal(fechaAntes, fechaOriginal);
    }

    [Fact]
    public void ModificaTipoReferencia_DeberiaAfectarOriginal()
    {
        // Arrange
        StringBuilder textoOriginal = new StringBuilder("Inicial");
        string textoAntes = textoOriginal.ToString();
        
        // Act
        Program.ModificaTipoReferencia(textoOriginal);
        
        // Assert
        Assert.NotEqual(textoAntes, textoOriginal.ToString());
        Assert.Contains("Modificado en método", textoOriginal.ToString());
    }

    [Fact]
    public void TiposValor_AsignacionIndependiente()
    {
        // Arrange
        DateTime fecha1 = new DateTime(2025, 12, 25, 10, 30, 0);
        DateTime fecha2 = fecha1;
        
        // Act
        fecha2 = fecha2.AddDays(5);
        
        // Assert
        Assert.NotEqual(fecha1, fecha2);
        Assert.Equal(new DateTime(2025, 12, 25, 10, 30, 0), fecha1);
        Assert.Equal(new DateTime(2025, 12, 30, 10, 30, 0), fecha2);
    }

    [Fact]
    public void TiposReferencia_AsignacionCompartida()
    {
        // Arrange
        StringBuilder texto1 = new StringBuilder("Hola mundo");
        StringBuilder texto2 = texto1;
        
        // Act
        texto2.Append("!!!");
        
        // Assert
        Assert.Equal(texto1.ToString(), texto2.ToString());
        Assert.Equal("Hola mundo!!!", texto1.ToString());
        Assert.True(ReferenceEquals(texto1, texto2));
    }

    
}
