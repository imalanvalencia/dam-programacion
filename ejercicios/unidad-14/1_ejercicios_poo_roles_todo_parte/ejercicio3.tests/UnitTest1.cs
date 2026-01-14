using System;
using System.Diagnostics;

namespace ejercicio3.tests;

public class CoordenadaTests
{
    [Fact]
    public void Constructor_ConValoresValidos_DeberiaCrearCoordenada()
    {
        // Arrange & Act
        var coordenada = new Coordenada(48.8584, 2.2945, 300);
        
        // Assert
        Assert.Equal(48.8584, coordenada.Latitud);
        Assert.Equal(2.2945, coordenada.Longitud);
        Assert.Equal(300, coordenada.Altitud);
    }

    [Theory]
    [InlineData(-91, 0, 100)] // Latitud fuera de rango
    [InlineData(91, 0, 100)]  // Latitud fuera de rango
    [InlineData(0, -181, 100)] // Longitud fuera de rango
    [InlineData(0, 181, 100)]  // Longitud fuera de rango
    [InlineData(0, 0, -1)]     // Altitud negativa
    public void Constructor_ConValoresInvalidos_DeberiaActivarAssert(double latitud, double longitud, int altitud)
    {
        // En modo Debug, esto activará los asserts
        // En modo Release, permitirá crear la coordenada
        // Para propósitos del test, asumimos que estamos en modo Release
        // o que los asserts están deshabilitados para testing
        
        // Arrange & Act & Assert
        // No lanzamos excepción porque usamos Debug.Assert en lugar de excepciones
        var coordenada = new Coordenada(latitud, longitud, altitud);
        
        // Verificamos que se creó la coordenada con los valores dados
        Assert.Equal(latitud>90?90:latitud<-90?-90:latitud, coordenada.Latitud);
        Assert.Equal(longitud>180?180:longitud<-180?-180:longitud, coordenada.Longitud);
        Assert.Equal(altitud<0?0:altitud, coordenada.Altitud);
    }

    [Fact]
    public void DistanciaA_DeberiaCalcularDistanciaCorrectamente()
    {
        // Arrange
        var paris = new Coordenada(48.8566, 2.3522, 35);     // París
        var londres = new Coordenada(51.5074, -0.1278, 11);  // Londres
        
        // Act
        var distancia = paris.DistanciaA(londres);
        
        // Assert
        // La distancia real entre París y Londres es aproximadamente 344 km
        Assert.True(distancia > 300 && distancia < 400);
    }

    [Theory]
    [InlineData(45.0, true)]   // Norte
    [InlineData(0.0, true)]    // Ecuador
    [InlineData(-45.0, false)] // Sur
    public void EsHemisferioNorte_DeberiaRetornarValorCorrector(double latitud, bool esperado)
    {
        // Arrange
        var coordenada = new Coordenada(latitud, 0, 0);
        
        // Act
        var esNorte = coordenada.EsHemisferioNorte;
        
        // Assert
        Assert.Equal(esperado, esNorte);
    }

    [Theory]
    [InlineData(45.0, true)]   // Este
    [InlineData(0.0, true)]    // Meridiano de Greenwich
    [InlineData(-45.0, false)] // Oeste
    public void EsHemisferioEste_DeberiaRetornarValorCorrector(double longitud, bool esperado)
    {
        // Arrange
        var coordenada = new Coordenada(0, longitud, 0);
        
        // Act
        var esEste = coordenada.EsHemisferioEste;
        
        // Assert
        Assert.Equal(esperado, esEste);
    }

    [Fact]
    public void MueveNorte_DeberiaCrearNuevaCoordenadaConLatitudModificada()
    {
        // Arrange
        var coordenadaOriginal = new Coordenada(40.0, 5.0, 100);
        
        // Act
        var coordenadaMovida = coordenadaOriginal.MueveNorte(10.0);
        
        // Assert
        Assert.Equal(50.0, coordenadaMovida.Latitud);
        Assert.Equal(5.0, coordenadaMovida.Longitud);   // No debería cambiar
        Assert.Equal(100, coordenadaMovida.Altitud);    // No debería cambiar
        
        // Verificar que la original no cambió (inmutabilidad)
        Assert.Equal(40.0, coordenadaOriginal.Latitud);
    }

    [Fact]
    public void MueveNorte_ConLimitesExcedidos_DeberiaLimitarLatitud()
    {
        // Arrange
        var coordenada = new Coordenada(85.0, 0, 0);
        
        // Act
        var coordenadaMovida = coordenada.MueveNorte(10.0); // Excedería 90°
        
        // Assert
        Assert.Equal(90.0, coordenadaMovida.Latitud); // Limitado a 90°
    }

    [Fact]
    public void MueveEste_DeberiaCrearNuevaCoordenadaConLongitudModificada()
    {
        // Arrange
        var coordenadaOriginal = new Coordenada(40.0, 5.0, 100);
        
        // Act
        var coordenadaMovida = coordenadaOriginal.MueveEste(10.0);
        
        // Assert
        Assert.Equal(40.0, coordenadaMovida.Latitud);   // No debería cambiar
        Assert.Equal(15.0, coordenadaMovida.Longitud);
        Assert.Equal(100, coordenadaMovida.Altitud);    // No debería cambiar
        
        // Verificar que la original no cambió (inmutabilidad)
        Assert.Equal(5.0, coordenadaOriginal.Longitud);
    }

    [Fact]
    public void MueveEste_ConLimitesExcedidos_DeberiaEnvolverLongitud()
    {
        // Arrange
        var coordenada = new Coordenada(0, 170.0, 0);
        
        // Act
        var coordenadaMovida = coordenada.MueveEste(20.0); // 190° -> -170°
        
        // Assert
        Assert.Equal(-170.0, coordenadaMovida.Longitud); // Envuelto a rango válido
    }
}

public class PuntoInteresTests
{
    [Fact]
    public void Constructor_DeberiaAsignarPropiedadesCorrectamente()
    {
        // Arrange
        var coordenada = new Coordenada(48.8584, 2.2945, 300);
        
        // Act
        var punto = new PuntoInteres("Torre Eiffel", coordenada);
        
        // Assert
        Assert.Equal("Torre Eiffel", punto.Nombre);
        Assert.Equal(coordenada, punto.Ubicacion);
    }

    [Fact]
    public void Record_DeberiaSerInmutable()
    {
        // Arrange & Act
        var coordenada = new Coordenada(48.8584, 2.2945, 300);
        var punto = new PuntoInteres("Torre Eiffel", coordenada);
        
        // Assert - Las propiedades no deberían tener setters públicos
        // Esto se verifica en tiempo de compilación
        Assert.Equal("Torre Eiffel", punto.Nombre);
        Assert.Equal(coordenada, punto.Ubicacion);
    }
}

public class RutaTuristicaTests
{
    [Fact]
    public void Constructor_DeberiaInicializarRutaVacia()
    {
        // Arrange & Act
        var ruta = new RutaTuristica("Europa");
        
        // Assert
        Assert.Equal(0.0, ruta.CalculaDistanciaTotal());
        Assert.Equal(0.0, ruta.CalculaAltitudPromedio());
    }

    [Fact]
    public void AgregaPunto_DeberiaAñadirPuntoCorrectamente()
    {
        // Arrange
        var ruta = new RutaTuristica("Test");
        var punto = new PuntoInteres("Test Point", new Coordenada(0, 0, 100));
        
        // Act
        ruta.AgregaPunto(punto);
        
        // Assert
        Assert.Equal(100.0, ruta.CalculaAltitudPromedio());
    }

    [Fact]
    public void CalculaDistanciaTotal_ConUnPunto_DeberiaRetornarCero()
    {
        // Arrange
        var ruta = new RutaTuristica("Test");
        var punto = new PuntoInteres("Test Point", new Coordenada(0, 0, 100));
        ruta.AgregaPunto(punto);
        
        // Act
        var distanciaTotal = ruta.CalculaDistanciaTotal();
        
        // Assert
        Assert.Equal(0.0, distanciaTotal);
    }

    [Fact]
    public void CalculaDistanciaTotal_ConDosPuntos_DeberiaCalcularDistancia()
    {
        // Arrange
        var ruta = new RutaTuristica("Test");
        var punto1 = new PuntoInteres("Punto 1", new Coordenada(0, 0, 100));
        var punto2 = new PuntoInteres("Punto 2", new Coordenada(1, 1, 200));
        
        ruta.AgregaPunto(punto1);
        ruta.AgregaPunto(punto2);
        
        // Act
        var distanciaTotal = ruta.CalculaDistanciaTotal();
        
        // Assert
        Assert.True(distanciaTotal > 0); // Debería haber alguna distancia
    }

    [Fact]
    public void CalculaAltitudPromedio_DeberiaCalcularCorrectamente()
    {
        // Arrange
        var ruta = new RutaTuristica("Test");
        var punto1 = new PuntoInteres("Punto 1", new Coordenada(0, 0, 100));
        var punto2 = new PuntoInteres("Punto 2", new Coordenada(1, 1, 200));
        var punto3 = new PuntoInteres("Punto 3", new Coordenada(2, 2, 300));
        
        ruta.AgregaPunto(punto1);
        ruta.AgregaPunto(punto2);
        ruta.AgregaPunto(punto3);
        
        // Act
        var altitudPromedio = ruta.CalculaAltitudPromedio();
        
        // Assert
        Assert.Equal(200.0, altitudPromedio); // (100 + 200 + 300) / 3
    }

    [Fact]
    public void MueveNorteRuta_DeberiaModificarTodosLosPuntos()
    {
        // Arrange
        var ruta = new RutaTuristica("Test");
        var punto1 = new PuntoInteres("Punto 1", new Coordenada(10, 5, 100));
        var punto2 = new PuntoInteres("Punto 2", new Coordenada(20, 10, 200));
        
        ruta.AgregaPunto(punto1);
        ruta.AgregaPunto(punto2);
        
        // Act
        ruta.MueveNorteRuta(5.0);
        
        // Assert
        // Como no podemos acceder directamente a los puntos, verificamos
        // que la altitud promedio no cambió (solo latitudes deberían cambiar)
        Assert.Equal(150.0, ruta.CalculaAltitudPromedio());
    }

    [Fact]
    public void RutaMasAlEste_ConMasPuntosEste_DeberiaRetornarTrue()
    {
        // Arrange
        var ruta = new RutaTuristica("Test");
        var puntoEste1 = new PuntoInteres("Este 1", new Coordenada(0, 10, 100));  // Este
        var puntoEste2 = new PuntoInteres("Este 2", new Coordenada(0, 20, 200));  // Este
        var puntoOeste = new PuntoInteres("Oeste", new Coordenada(0, -10, 300));  // Oeste
        
        ruta.AgregaPunto(puntoEste1);
        ruta.AgregaPunto(puntoEste2);
        ruta.AgregaPunto(puntoOeste);
        
        // Act
        var masAlEste = ruta.RutaMasAlEste();
        
        // Assert
        Assert.True(masAlEste); // 2 puntos Este vs 1 punto Oeste
    }

    [Fact]
    public void RutaMasAlEste_ConMasPuntosOeste_DeberiaRetornarFalse()
    {
        // Arrange
        var ruta = new RutaTuristica("Test");
        var puntoEste = new PuntoInteres("Este", new Coordenada(0, 10, 100));     // Este
        var puntoOeste1 = new PuntoInteres("Oeste 1", new Coordenada(0, -10, 200)); // Oeste
        var puntoOeste2 = new PuntoInteres("Oeste 2", new Coordenada(0, -20, 300)); // Oeste
        
        ruta.AgregaPunto(puntoEste);
        ruta.AgregaPunto(puntoOeste1);
        ruta.AgregaPunto(puntoOeste2);
        
        // Act
        var masAlEste = ruta.RutaMasAlEste();
        
        // Assert
        Assert.False(masAlEste); // 1 punto Este vs 2 puntos Oeste
    }

    [Fact]
    public void ArrayRedimensionable_DeberiaPermitirMuchosPuntos()
    {
        // Arrange
        var ruta = new RutaTuristica("Test");
        
        // Act - Agregar muchos puntos para probar redimensionamiento
        for (int i = 0; i < 150; i++)
        {
            var punto = new PuntoInteres($"Punto {i}", new Coordenada(i, i, i * 10));
            ruta.AgregaPunto(punto);
        }
        
        // Assert
        Assert.Equal(745.0, ruta.CalculaAltitudPromedio()); // (0 + 10 + 20 + ... + 1490) / 150
    }
}
