using ejercicio4;

namespace ejercicio4.tests;

public class ContactoTests
{
    [Fact]
    public void Constructor_CreatesContactoWithCorrectProperties()
    {
        // Arrange
        string nombre = "María García";
        string telefono = "987654321";
        
        // Act
        var contacto = new Contacto(nombre, telefono);
        
        // Assert
        Assert.Equal(nombre, contacto.Nombre);
        Assert.Equal(telefono, contacto.Telefono);
    }
}

public class PropietarioTests
{
    [Fact]
    public void Constructor_CreatesPropietarioWithCorrectProperties()
    {
        // Arrange
        string dni = "12345678A";
        string nombre = "Juan Pérez";
        var fechaNacimiento = new DateOnly(1990, 5, 15);
        
        // Act
        var propietario = new Propietario(dni, nombre, fechaNacimiento);
        
        // Assert
        Assert.Equal(dni, propietario.Dni);
        Assert.Equal(nombre, propietario.Nombre);
        Assert.Equal(fechaNacimiento, propietario.FechaNacimiento);
    }

    [Fact]
    public void ACadena_ReturnsCorrectFormat()
    {
        // Arrange
        var propietario = new Propietario("12345678A", "Juan Pérez", new DateOnly(1990, 5, 15));
        string expected = "Juan Pérez\nDNI: 12345678A\nFecha de nacimiento: 15/05/1990";
        
        // Act
        string result = propietario.ACadena();
        
        // Assert
        Assert.Equal(expected, result);
    }
}

public class CompañiaTelefonicaTests
{
    [Fact]
    public void Constructor_CreatesCompañiaWithCorrectProperties()
    {
        // Arrange
        string codigo = "ES001";
        string nombre = "Movistar";
        
        // Act
        var compañia = new CompañiaTelefonica(codigo, nombre);
        
        // Assert
        Assert.Equal(codigo, compañia.Codigo);
        Assert.Equal(nombre, compañia.Nombre);
        Assert.NotEqual(Guid.Empty, compañia.Id);
        Assert.Equal(0, compañia.CantidadTelefonosRegistrados);
    }

    [Fact]
    public void RegistraTelefono_WithValidTelefono_IncrementsCount()
    {
        // Arrange
        var compañia = new CompañiaTelefonica("ES001", "Movistar");
        var propietario = new Propietario("12345678A", "Juan", new DateOnly(1990, 5, 15));
        var telefono = new Telefono("123456789", "iPhone", "15 Pro", new DateOnly(2025, 1, 1), propietario, compañia);
        
        // Act
        compañia.RegistraTelefono(telefono);
        
        // Assert
        Assert.Equal(1, compañia.CantidadTelefonosRegistrados);
    }

    [Fact]
    public void ACadena_ReturnsCorrectFormat()
    {
        // Arrange
        var compañia = new CompañiaTelefonica("ES001", "Movistar");
        string expected = "Compañía: Movistar (ES001)\nTeléfonos registrados: 0";
        
        // Act
        string result = compañia.ACadena();
        
        // Assert
        Assert.Equal(expected, result);
    }
}

public class TelefonoTests
{
    [Fact]
    public void Constructor_CreatesTelefonoWithCorrectProperties()
    {
        // Arrange
        string numero = "123456789";
        string marca = "iPhone";
        string modelo = "15 Pro";
        var fechaCompra = new DateOnly(2025, 1, 1);
        var propietario = new Propietario("12345678A", "Juan", new DateOnly(1990, 5, 15));
        var compañia = new CompañiaTelefonica("ES001", "Movistar");
        
        // Act
        var telefono = new Telefono(numero, marca, modelo, fechaCompra, propietario, compañia);
        
        // Assert
        Assert.Equal(numero, telefono.Numero);
        Assert.Equal(marca, telefono.Marca);
        Assert.Equal(modelo, telefono.Modelo);
        Assert.Equal(fechaCompra, telefono.FechaCompra);
        Assert.Equal(propietario, telefono.Propietario);
        Assert.Equal(compañia, telefono.Compañia);
    }

    [Fact]
    public void AñadeContacto_AddsContactoToList()
    {
        // Arrange
        var propietario = new Propietario("12345678A", "Juan", new DateOnly(1990, 5, 15));
        var compañia = new CompañiaTelefonica("ES001", "Movistar");
        var telefono = new Telefono("123456789", "iPhone", "15 Pro", new DateOnly(2025, 1, 1), propietario, compañia);
        var contacto = new Contacto("María García", "987654321");
        
        // Act
        telefono.AñadeContacto(contacto);
        
        // Assert
        string result = telefono.ACadena();
        Assert.Contains("María García: 987654321", result);
    }

    [Fact]
    public void ACadena_WithoutContacts_ReturnsCorrectFormat()
    {
        // Arrange
        var propietario = new Propietario("12345678A", "Juan Pérez", new DateOnly(1990, 5, 15));
        var compañia = new CompañiaTelefonica("ES001", "Movistar");
        var telefono = new Telefono("123456789", "iPhone", "15 Pro", new DateOnly(2025, 1, 1), propietario, compañia);
        
        // Act
        string result = telefono.ACadena();
        
        // Assert
        Assert.Contains("Teléfono ID: 123456789", result);
        Assert.Contains("Marca: iPhone, Modelo: 15 Pro", result);
        Assert.Contains("Fecha de compra: 01/01/2025", result);
        Assert.Contains("Propietario: Juan Pérez (DNI: 12345678A)", result);
        Assert.Contains("Compañía: Movistar (ES001)", result);
        Assert.Contains("Contactos almacenados: 0", result);
    }

    [Fact]
    public void ACadena_WithContacts_ReturnsCorrectFormat()
    {
        // Arrange
        var propietario = new Propietario("12345678A", "Juan", new DateOnly(1990, 5, 15));
        var compañia = new CompañiaTelefonica("ES001", "Movistar");
        var telefono = new Telefono("123456789", "iPhone", "15 Pro", new DateOnly(2025, 1, 1), propietario, compañia);
        var contacto1 = new Contacto("María García", "987654321");
        var contacto2 = new Contacto("Pedro López", "456789123");
        
        // Act
        telefono.AñadeContacto(contacto1);
        telefono.AñadeContacto(contacto2);
        string result = telefono.ACadena();
        
        // Assert
        Assert.Contains("Contactos almacenados: 2", result);
        Assert.Contains("- María García: 987654321", result);
        Assert.Contains("- Pedro López: 456789123", result);
    }
}
