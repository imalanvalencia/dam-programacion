using ejercicio5;

namespace ejercicio5.tests;

public class AnimalTests
{
    [Fact]
    public void Constructor_CreatesAnimalWithCorrectProperties()
    {
        // Arrange
        string nombre = "Fido";
        string especie = "Perro";
        int edad = 5;

        // Act
        var animal = new Animal(nombre, especie, edad);

        // Assert
        Assert.Equal(nombre, animal.Nombre);
        Assert.Equal(especie, animal.Especie);
        Assert.Equal(edad, animal.Edad);
        Assert.False(animal.EstaAsignado());
        Assert.NotEqual(Guid.Empty, animal.Id);
    }

    [Fact]
    public void Asigna_SetsAsignadoToTrue()
    {
        // Arrange
        var animal = new Animal("Fido", "Perro", 5);

        // Act
        animal.Asigna();

        // Assert
        Assert.True(animal.EstaAsignado());
    }

    [Fact]
    public void Libera_SetsAsignadoToFalse()
    {
        // Arrange
        var animal = new Animal("Fido", "Perro", 5);
        animal.Asigna();

        // Act
        animal.Libera();

        // Assert
        Assert.False(animal.EstaAsignado());
    }

    [Fact]
    public void ACadena_ReturnsCorrectFormat()
    {
        // Arrange
        var animal = new Animal("Fido", "Perro", 5);
        string expected = "Animal: Fido (Perro) - 5 años\n  Estado: No asignado";

        // Act
        string result = animal.ACadena();

        // Assert
        Assert.Equal(expected, result);
    }
}

public class CuidadorTests
{
    [Fact]
    public void Constructor_CreatesCuidadorWithCorrectProperties()
    {
        // Arrange
        string dni = "11111111A";
        string nombre = "Ana López";
        int maxMascotas = 5;
        string especialidad = "Veterinaria";

        // Act
        var cuidador = new Cuidador(dni, nombre, maxMascotas, especialidad);

        // Assert
        Assert.Equal(dni, cuidador.Dni);
        Assert.Equal(nombre, cuidador.Nombre);
        Assert.Equal(maxMascotas, cuidador.NumeroMaximoMascotas);
        Assert.Equal(especialidad, cuidador.Especialidad);
        Assert.Equal(0, cuidador.NumeroMascotasAsignadas);
    }

    [Fact]
    public void Disponible_WhenNotFull_ReturnsTrueAndIncrementsCount()
    {
        // Arrange
        var cuidador = new Cuidador("11111111A", "Ana", 2, "Veterinaria");

        // Act
        bool result1 = cuidador.AsignaMascotaSiDisponible();
        Assert.True(result1);
        Assert.Equal(1, cuidador.NumeroMascotasAsignadas);
        bool result2 = cuidador.AsignaMascotaSiDisponible();
        Assert.True(result2);
        Assert.Equal(2, cuidador.NumeroMascotasAsignadas);
    }

    [Fact]
    public void Disponible_WhenFull_ReturnsFalse()
    {
        // Arrange
        var cuidador = new Cuidador("11111111A", "Ana", 1, "Veterinaria");
        cuidador.AsignaMascotaSiDisponible(); // Asigna una mascota

        // Act
        bool result = cuidador.AsignaMascotaSiDisponible();

        // Assert
        Assert.False(result);
        Assert.Equal(1, cuidador.NumeroMascotasAsignadas);
    }

    [Fact]
    public void ACadena_ReturnsCorrectFormat()
    {
        // Arrange
        var cuidador = new Cuidador("11111111A", "Ana López", 5, "Veterinaria");
        string expected = "Cuidador: Ana López (Veterinaria)\n  Mascotas asignadas: 0/5\n  Disponible para más asignaciones: Sí";

        // Act
        string result = cuidador.ACadena();

        // Assert
        Assert.Equal(expected, result);
    }
}

public class RefugioTests
{
    [Fact]
    public void Constructor_CreatesRefugioWithCorrectProperties()
    {
        // Arrange
        string nombre = "Hogar Feliz";

        // Act
        var refugio = new Refugio(nombre);

        // Assert
        Assert.Equal(nombre, refugio.Nombre);
        Assert.NotEqual(Guid.Empty, refugio.Id);
    }

    [Fact]
    public void AñadeCuidador_AddsCuidadorToList()
    {
        // Arrange
        var refugio = new Refugio("Hogar Feliz");
        var cuidador = new Cuidador("11111111A", "Ana", 5, "Veterinaria");

        // Act
        refugio.AñadeCuidador(cuidador);

        // Assert
        string result = refugio.ACadena();
        Assert.Contains("Ana", result);
    }

    [Fact]
    public void AñadeAnimal_AddsAnimalToList()
    {
        // Arrange
        var refugio = new Refugio("Hogar Feliz");
        var animal = new Animal("Fido", "Perro", 5);

        // Act
        refugio.AñadeAnimal(animal);

        // Assert
        string result = refugio.ACadena();
        Assert.Contains("Fido (Perro)", result);
    }

    [Fact]
    public void AsignaAnimalACuidador_WithValidData_AssignsCorrectly()
    {
        // Arrange
        var refugio = new Refugio("Hogar Feliz");
        var animal = new Animal("Fido", "Perro", 5);
        var cuidador = new Cuidador("11111111A", "Ana", 5, "Veterinaria");
        refugio.AñadeAnimal(animal);
        refugio.AñadeCuidador(cuidador);

        // Act
        refugio.AsignaAnimalACuidador(animal, cuidador);

        // Assert
        Assert.True(animal.EstaAsignado());
        Assert.Equal(1, cuidador.NumeroMascotasAsignadas);
    }

    [Fact]
    public void AsignaAnimalACuidador_WhenCuidadorFull_DoesNotAssign()
    {
        // Arrange
        var refugio = new Refugio("Hogar Feliz");
        var animal1 = new Animal("Fido", "Perro", 5);
        var animal2 = new Animal("Misi", "Gato", 3);
        var cuidador = new Cuidador("11111111A", "Ana", 1, "Veterinaria");
        refugio.AñadeAnimal(animal1);
        refugio.AñadeAnimal(animal2);
        refugio.AñadeCuidador(cuidador);

        // Act
        refugio.AsignaAnimalACuidador(animal1, cuidador);
        refugio.AsignaAnimalACuidador(animal2, cuidador);

        // Assert
        Assert.True(animal1.EstaAsignado());
        Assert.False(animal2.EstaAsignado());
    }

    [Fact]
    public void ACadena_ReturnsCorrectFormat()
    {
        // Arrange
        var refugio = new Refugio("Hogar Feliz");
        var animal = new Animal("Fido", "Perro", 5);
        var cuidador = new Cuidador("11111111A", "Ana López", 5, "Veterinaria");
        refugio.AñadeAnimal(animal);
        refugio.AñadeCuidador(cuidador);
        refugio.AsignaAnimalACuidador(animal, cuidador);

        // Act
        string result = refugio.ACadena();

        // Assert
        Assert.Contains("Refugio: Hogar Feliz", result);
        Assert.Contains("--- Información de animales ---", result);
        Assert.Contains("Animal: Fido (Perro) - 5 años", result);
        Assert.Contains("Estado: Asignado", result);
        Assert.Contains("--- Información de cuidadores ---", result);
        Assert.Contains("Cuidador: Ana López (Veterinaria)", result);
        Assert.Contains("--- Resumen del refugio ---", result);
        Assert.Contains("Detalle de asignaciones:", result);
        Assert.Contains("- Fido ↔ Ana López", result);
    }
}
