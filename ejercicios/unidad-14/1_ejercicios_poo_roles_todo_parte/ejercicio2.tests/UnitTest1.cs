using ejercicio2;

namespace ejercicio2.tests;

public class EstudianteTests
{
    [Fact]
    public void Constructor_CreatesEstudianteWithCorrectProperties()
    {
        // Arrange
        string dni = "12345678A";
        string nombre = "Juan Pérez";
        int edad = 20;
        
        // Act
        var estudiante = new Estudiante(dni, nombre, edad);
        
        // Assert
        Assert.Equal(dni, estudiante.Dni);
        Assert.Equal(nombre, estudiante.Nombre);
        Assert.Equal(edad, estudiante.Edad);
    }

    [Fact]
    public void ACadena_ReturnsCorrectFormat()
    {
        // Arrange
        var estudiante = new Estudiante("12345678A", "Juan Pérez", 20);
        string expected = "Juan Pérez (20 años)";
        
        // Act
        string result = estudiante.ACadena();
        
        // Assert
        Assert.Equal(expected, result);
    }
}

public class CursoTests
{
    [Fact]
    public void Constructor_CreatesCursoWithCorrectProperties()
    {
        // Arrange
        string nombre = "Desarrollo de Aplicaciones";
        int creditos = 120;
        int numeroMaximoEstudiantes = 30;
        short edadMinima = 18;
        
        // Act
        var curso = new Curso(nombre, creditos, numeroMaximoEstudiantes, edadMinima);
        
        // Assert
        Assert.Equal(nombre, curso.Nombre);
        Assert.Equal(creditos, curso.Creditos);
        Assert.Equal(numeroMaximoEstudiantes, curso.NumeroMaximoEstudiantes);
        Assert.Equal(edadMinima, curso.EdadMinima);
        Assert.NotEqual(Guid.Empty, curso.Id);
    }

    [Fact]
    public void Matricula_WithValidStudent_ReturnsTrue()
    {
        // Arrange
        var curso = new Curso("Desarrollo", 120, 30, 18);
        var estudiante = new Estudiante("12345678A", "Juan", 20);
        
        // Act
        bool result = curso.Matricula(estudiante);
        
        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Matricula_WithUnderageStudent_ReturnsFalse()
    {
        // Arrange
        var curso = new Curso("Desarrollo", 120, 30, 18);
        var estudiante = new Estudiante("12345678A", "Juan", 17); // Menor de edad
        
        // Act
        bool result = curso.Matricula(estudiante);
        
        // Assert
        Assert.False(result);
    }

    [Fact]
    public void Matricula_WhenCapacityFull_ReturnsFalse()
    {
        // Arrange
        var curso = new Curso("Desarrollo", 120, 1, 18);
        var estudiante1 = new Estudiante("12345678A", "Juan", 20);
        var estudiante2 = new Estudiante("87654321B", "Ana", 21);
        
        // Act
        bool result1 = curso.Matricula(estudiante1);
        bool result2 = curso.Matricula(estudiante2);
        
        // Assert
        Assert.True(result1);
        Assert.False(result2);
    }

    [Fact]
    public void ACadena_ReturnsCorrectFormat()
    {
        // Arrange
        var curso = new Curso("Desarrollo de Aplicaciones", 120, 30, 18);
        var estudiante1 = new Estudiante("12345678A", "Juan", 20);
        var estudiante2 = new Estudiante("87654321B", "Ana", 22);
        curso.Matricula(estudiante1);
        curso.Matricula(estudiante2);
        
        // Act
        string result = curso.ACadena();
        
        // Assert
        Assert.Contains("Curso: Desarrollo de Aplicaciones Créditos: 120 - 2 estudiantes matriculados", result);
        Assert.Contains("Estudiantes:", result);
        Assert.Contains("- Juan (20 años)", result);
        Assert.Contains("- Ana (22 años)", result);
    }
}
