using System;

namespace ejercicio1.tests;

public class EmpleadoTests
{
    [Fact]
    public void Constructor_DeberiaAsignarValoresCorrectamente()
    {
        // Arrange & Act
        var empleado = new Empleado("12345678A", "Juan Pérez", 1990);
        
        // Assert
        Assert.Equal("12345678A", empleado.GetDni());
        Assert.Equal("Juan Pérez", empleado.GetNombre());
        Assert.Equal(1990, empleado.GetAñoNacimiento());
        Assert.Equal(Categoria.Subalterno, empleado.GetCategoria());
    }

    [Fact]
    public void ConstructorCopia_DeberiaCrearCopiaExacta()
    {
        // Arrange
        var empleadoOriginal = new Empleado("12345678A", "Juan Pérez", 1990);
        empleadoOriginal.SetCategoria(Categoria.Administrativo);
        
        // Act
        var empleadoCopia = new Empleado(empleadoOriginal);
        
        // Assert
        Assert.Equal(empleadoOriginal.GetDni(), empleadoCopia.GetDni());
        Assert.Equal(empleadoOriginal.GetNombre(), empleadoCopia.GetNombre());
        Assert.Equal(empleadoOriginal.GetAñoNacimiento(), empleadoCopia.GetAñoNacimiento());
        Assert.Equal(empleadoOriginal.GetCategoria(), empleadoCopia.GetCategoria());
    }

    [Fact]
    public void SetCategoria_DeberiaModificarCategoria()
    {
        // Arrange
        var empleado = new Empleado("12345678A", "Juan Pérez", 1990);
        
        // Act
        empleado.SetCategoria(Categoria.Gerente);
        
        // Assert
        Assert.Equal(Categoria.Gerente, empleado.GetCategoria());
    }

    [Fact]
    public void Salario_DeberiaCalcularCorrectamente()
    {
        // Arrange
        var empleado = new Empleado("12345678A", "Juan Pérez", 1990);
        empleado.SetCategoria(Categoria.Administrativo); // 20%
        
        // Act
        var salario = empleado.Salario();
        
        // Assert
        Assert.Equal(1440.0, salario); // 1200 + (1200 * 0.20)
    }

    [Fact]
    public void CalculaEdad_DeberiaCalcularCorrectamente()
    {
        // Arrange
        var empleado = new Empleado("12345678A", "Juan Pérez", 1990);
        var edadEsperada = DateTime.Now.Year - 1990;
        
        // Act
        var edad = empleado.CalculaEdad();
        
        // Assert
        Assert.Equal(edadEsperada, edad);
    }

    [Fact]
    public void TieneMayorSalario_DeberiaCompararCorrectamente()
    {
        // Arrange
        var empleado1 = new Empleado("12345678A", "Juan Pérez", 1990);
        empleado1.SetCategoria(Categoria.Gerente); // 60%
        
        var empleado2 = new Empleado("87654321B", "Ana García", 1985);
        empleado2.SetCategoria(Categoria.Administrativo); // 20%
        
        // Act & Assert
        Assert.True(empleado1.TieneMayorSalario(empleado2));
        Assert.False(empleado2.TieneMayorSalario(empleado1));
    }

    [Fact]
    public void EsMayorCategoria_DeberiaCompararCorrectamente()
    {
        // Arrange
        var empleado1 = new Empleado("12345678A", "Juan Pérez", 1990);
        empleado1.SetCategoria(Categoria.JefeDepartamento); // 40
        
        var empleado2 = new Empleado("87654321B", "Ana García", 1985);
        empleado2.SetCategoria(Categoria.Subalterno); // 10
        
        // Act & Assert
        Assert.True(empleado1.EsMayorCategoria(empleado2));
        Assert.False(empleado2.EsMayorCategoria(empleado1));
    }

    [Fact]
    public void CalculaDiferenciaEdad_DeberiaCalcularCorrectamente()
    {
        // Arrange
        var empleado1 = new Empleado("12345678A", "Juan Pérez", 1990);
        var empleado2 = new Empleado("87654321B", "Ana García", 1985);
        
        // Act
        var diferencia = empleado1.CalculaDiferenciaEdad(empleado2);
        
        // Assert
        Assert.Equal(5, diferencia);
    }

    [Fact]
    public void ACadena_DeberiaContenerInformacionCompleta()
    {
        // Arrange
        var empleado = new Empleado("12345678A", "Juan Pérez", 1990);
        empleado.SetCategoria(Categoria.Administrativo);
        
        // Act
        var cadena = empleado.ACadena();
        
        // Assert
        Assert.Contains("12345678A", cadena);
        Assert.Contains("Juan Pérez", cadena);
        Assert.Contains("1990", cadena);
        Assert.Contains("Administrativo", cadena);
        Assert.Contains("1440", cadena);
    }
}

public class ProgramTests
{
    [Fact]
    public void ParsearCategoria_DeberiaReconocerNombresCompletos()
    {
        // Act & Assert
        Assert.Equal(Categoria.Subalterno, Program.ParseaCategoria("subalterno"));
        Assert.Equal(Categoria.Administrativo, Program.ParseaCategoria("administrativo"));
        Assert.Equal(Categoria.JefeDepartamento, Program.ParseaCategoria("jefedepartamento"));
        Assert.Equal(Categoria.Gerente, Program.ParseaCategoria("gerente"));
    }

    [Fact]
    public void ParsearCategoria_DeberiaReconocerValoresNumericos()
    {
        // Act & Assert
        Assert.Equal(Categoria.Subalterno, Program.ParseaCategoria("10"));
        Assert.Equal(Categoria.Administrativo, Program.ParseaCategoria("20"));
        Assert.Equal(Categoria.JefeDepartamento, Program.ParseaCategoria("40"));
        Assert.Equal(Categoria.Gerente, Program.ParseaCategoria("60"));
    }

    [Fact]
    public void ParsearCategoria_DeberiaRetornarSubalternoPorDefecto()
    {
        // Act & Assert
        Assert.Equal(Categoria.Subalterno, Program.ParseaCategoria("invalido"));
        Assert.Equal(Categoria.Subalterno, Program.ParseaCategoria(""));
        Assert.Equal(Categoria.Subalterno, Program.ParseaCategoria("999"));
    }
}
