using System;
using Ejercicio3;

namespace ejercicio3.tests;

public class UnitTest1
{
    [Fact]
    public void CreaUris_DebeCrearArrayDeTamañoCorrecto()
    {
        // Arrange
        using var stringReader = new StringReader("https://www.google.com\nhttps://www.example.com\nhttp://localhost\nhttp://test.com\n");
        Console.SetIn(stringReader);
        using var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        
        // Act
        Uri[] uris = Program.CreaUris(4);
        
        // Assert
        Assert.Equal(4, uris.Length);
        Assert.All(uris, uri => Assert.NotNull(uri));
    }

    [Theory]
    [InlineData("https://www.google.com/search?q=csharp")]
    [InlineData("ftp://files.example.com:21/documents/file.txt")]
    [InlineData("mailto:info@example.com")]
    public void MuestraInformacion_DebeAceptarUrisValidas(string uriString)
    {
        // Arrange
        Uri uri = new Uri(uriString);
        using var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        
        // Act & Assert
        var exception = Record.Exception(() => Program.MuestraInformacion(uri));
        Assert.Null(exception);
        
        string output = stringWriter.ToString();
        Assert.Contains("URI completa:", output);
        Assert.Contains("Esquema:", output);
        Assert.Contains("¿Es absoluta?:", output);
    }

    [Fact]
    public void MuestraInformacion_DebeDetectarPropiedadesHTTPS()
    {
        // Arrange
        Uri uri = new Uri("https://www.google.com/search?q=csharp");
        using var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        
        // Act
        Program.MuestraInformacion(uri);
        
        // Assert
        string output = stringWriter.ToString();
        Assert.Contains("Esquema: https", output);
        Assert.Contains("Host: www.google.com", output);
        Assert.Contains("Puerto: 443", output);
        Assert.Contains("Ruta: /search", output);
        Assert.Contains("Query: ?q=csharp", output);
        Assert.Contains("¿Es absoluta?: True", output);
    }

    [Fact]
    public void MuestraInformacion_DebeDetectarPropiedadesFTP()
    {
        // Arrange
        Uri uri = new Uri("ftp://files.example.com:21/documents/file.txt");
        using var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        
        // Act
        Program.MuestraInformacion(uri);
        
        // Assert
        string output = stringWriter.ToString();
        Assert.Contains("Esquema: ftp", output);
        Assert.Contains("Host: files.example.com", output);
        Assert.Contains("Puerto: 21", output);
        Assert.Contains("Ruta: /documents/file.txt", output);
        Assert.Contains("¿Es absoluta?: True", output);
    }

    [Fact]
    public void MuestraInformacion_DebeDetectarPropiedadesMailto()
    {
        // Arrange
        Uri uri = new Uri("mailto:info@example.com");
        using var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        
        // Act
        Program.MuestraInformacion(uri);
        
        // Assert
        string output = stringWriter.ToString();
        Assert.Contains("Esquema: mailto", output);
        Assert.Contains("mailto:info@example.com", output);
        Assert.Contains("¿Es absoluta?: True", output);
    }

    [Theory]
    [InlineData("https://www.google.com", "https://www.example.com", false)]
    [InlineData("https://www.google.com", "http://www.google.com", false)]
    [InlineData("ftp://files.example.com", "ftp://files.example.com", true)]
    public void ComparaUris_DebeCompararCorrectamente(string uri1String, string uri2String, bool esperado)
    {
        // Arrange
        Uri uri1 = new Uri(uri1String);
        Uri uri2 = new Uri(uri2String);
        
        // Act
        bool resultado = Program.ComparaUris(uri1, uri2);
        
        // Assert
        Assert.Equal(esperado, resultado);
    }

    [Fact]
    public void ComparaUris_MismoHost_DiferenteEsquema_DebeRetornarFalse()
    {
        // Arrange
        Uri uri1 = new Uri("https://www.google.com");
        Uri uri2 = new Uri("http://www.google.com");
        
        // Act
        bool resultado = Program.ComparaUris(uri1, uri2);
        
        // Assert
        Assert.False(resultado);
    }

    [Fact]
    public void ComparaUris_DiferenteHost_MismoEsquema_DebeRetornarFalse()
    {
        // Arrange
        Uri uri1 = new Uri("https://www.google.com");
        Uri uri2 = new Uri("https://www.example.com");
        
        // Act
        bool resultado = Program.ComparaUris(uri1, uri2);
        
        // Assert
        Assert.False(resultado);
    }

    [Fact]
    public void ComparaUris_UrisIdenticas_DebeRetornarTrue()
    {
        // Arrange
        Uri uri1 = new Uri("https://www.google.com/search?q=test");
        Uri uri2 = new Uri("https://www.google.com/search?q=test");
        
        // Act
        bool resultado = Program.ComparaUris(uri1, uri2);
        
        // Assert
        Assert.True(resultado);
    }

    

   

    [Theory]
    [InlineData("invalid-url-format")]
    [InlineData("not-a-uri")]
    [InlineData("://missing-scheme")]
    public void Uri_TryCreate_DebeRechazarUrisInvalidas(string uriInvalida)
    {
        // Act
        bool esValida = Uri.TryCreate(uriInvalida, UriKind.Absolute, out Uri? uri);
        
        // Assert
        Assert.False(esValida);
        Assert.Null(uri);
    }

    

    [Fact]
    public void Uri_PropiedadesBasicas_DebenSerAccesibles()
    {
        // Arrange
        Uri uri = new Uri("https://www.example.com:8080/path/to/resource?param=value#fragment");
        
        // Act & Assert
        Assert.Equal("https", uri.Scheme);
        Assert.Equal("www.example.com", uri.Host);
        Assert.Equal(8080, uri.Port);
        Assert.Equal("/path/to/resource", uri.AbsolutePath);
        Assert.Equal("?param=value", uri.Query);
        Assert.True(uri.IsAbsoluteUri);
        Assert.False(uri.IsFile);
        Assert.False(uri.IsUnc);
    }
}
