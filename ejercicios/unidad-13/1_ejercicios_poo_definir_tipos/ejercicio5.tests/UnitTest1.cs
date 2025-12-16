
using System;
using Xunit;

namespace ejercicio5.tests;

public class JugueteTests
{
	[Fact]
	public void Constructor_DeberiaAsignarPropiedades()
	{
		var juguete = new Juguete("Pelota", 15.50);
		Assert.Equal("Pelota", juguete.Nombre);
		Assert.Equal(15.50, juguete.Precio, 2);
	}

	[Fact]
	public void CalculaDescuento_DeberiaReducirPrecio()
	{
		var juguete = new Juguete("Pelota", 20.00);
		var jugueteDescuento = juguete.CalculaDescuento(25); // 25% descuento
		Assert.Equal(15.00, jugueteDescuento.Precio, 2);
		Assert.Equal("Pelota", jugueteDescuento.Nombre);
	}

	[Fact]
	public void With_DeberiaCrearNuevoJugueteConNombre()
	{
		var juguete = new Juguete("Pelota", 10.0);
		var renombrado = juguete with { Nombre = "Pelota Roja" };
		Assert.Equal("Pelota Roja", renombrado.Nombre);
		Assert.Equal(10.0, renombrado.Precio, 2);
	}
}

public class TemperaturaTests
{
	[Fact]
	public void Constructor_DeberiaAsignarPropiedadesValidas()
	{
		var temp = new Temperatura(22.5, EscalaTemperatura.Celsius);
		Assert.Equal(22.5, temp.Grados, 2);
		Assert.Equal(EscalaTemperatura.Celsius, temp.Escala);
	}

	[Fact]
	public void Constructor_DeberiaCorregirBajoCeroAbsoluto()
	{
		var tempC = new Temperatura(-300, EscalaTemperatura.Celsius);
		Assert.Equal(-273.15, tempC.Grados, 2);
		var tempF = new Temperatura(-500, EscalaTemperatura.Fahrenheit);
		Assert.Equal(-459.67, tempF.Grados, 2);
		var tempK = new Temperatura(-10, EscalaTemperatura.Kelvin);
		Assert.Equal(0.0, tempK.Grados, 2);
	}

	[Fact]
	public void ConvierteA_DeberiaConvertirCorrectamente()
	{
		var tempC = new Temperatura(100, EscalaTemperatura.Celsius);
		var tempF = tempC.ConvierteA(EscalaTemperatura.Fahrenheit);
		Assert.Equal(212.0, tempF.Grados, 2);
		Assert.Equal(EscalaTemperatura.Fahrenheit, tempF.Escala);
		var tempK = tempC.ConvierteA(EscalaTemperatura.Kelvin);
		Assert.Equal(373.15, tempK.Grados, 2);
		Assert.Equal(EscalaTemperatura.Kelvin, tempK.Escala);
	}

	[Fact]
	public void ConvierteA_DeberiaConvertirFahrenheitACelsius()
	{
		var tempF = new Temperatura(32, EscalaTemperatura.Fahrenheit);
		var tempC = tempF.ConvierteA(EscalaTemperatura.Celsius);
		Assert.Equal(0.0, tempC.Grados, 2);
		Assert.Equal(EscalaTemperatura.Celsius, tempC.Escala);
	}
}
