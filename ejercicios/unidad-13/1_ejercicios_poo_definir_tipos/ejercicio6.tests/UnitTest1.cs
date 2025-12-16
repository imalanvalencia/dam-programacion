using System;
using Xunit;


namespace ejercicio6.tests;
public class PrecioTests
{
    [Fact]
    public void Constructor_DeberiaAsignarPropiedades()
    {
        var precio = new Precio(100.50m, "USD");
        Assert.Equal(100.50m, precio.Valor);
        Assert.Equal("USD", precio.Moneda);
    }

    [Fact]
    public void ToString_DeberiaFormatearCorrectamente()
    {
        var precio = new Precio(99.99m, "EUR");
        Assert.Equal("99,99 EUR", precio.ToString());
    }
}

public class ColorTests
{
    [Fact]
    public void Constructor_DeberiaAsignarPropiedades()
    {
        var color = new Color(10, 20, 30);
        Assert.Equal((byte)10, color.R);
        Assert.Equal((byte)20, color.G);
        Assert.Equal((byte)30, color.B);
    }

    [Fact]
    public void ToHex_DeberiaDevolverHexCorrecto()
    {
        var color = new Color(255, 0, 0);
        Assert.Equal("FF0000", color.ToHex());
        var color2 = new Color(0, 255, 255);
        Assert.Equal("00FFFF", color2.ToHex());
    }
}

public class ProductoTests
{
    [Fact]
    public void Constructor_DeberiaAsignarPropiedades()
    {
        var id = Guid.NewGuid();
        var precio = new Precio(50.0m, "EUR");
        var producto = new Producto(id, "Teclado", precio);
        Assert.Equal(id, producto.Id);
        Assert.Equal("Teclado", producto.Nombre);
        Assert.Equal(precio, producto.Precio);
    }

    [Fact]
    public void ActualizarPrecio_DeberiaCambiarPrecio()
    {
        var producto = new Producto(Guid.NewGuid(), "Monitor", new Precio(200m, "EUR"));
        var nuevoPrecio = new Precio(180m, "EUR");
        producto.ActualizarPrecio(nuevoPrecio);
        Assert.Equal(nuevoPrecio, producto.Precio);
    }
}
