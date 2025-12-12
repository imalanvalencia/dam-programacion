using Xunit;
using System.Text.RegularExpressions;

namespace ejercicio1.Tests
{
    public class PatronesTests
    {
        // ==================== TESTS TARJETA DE CRÉDITO ====================
        [Theory]
        [InlineData("1234 5678 9012 3456", true)]
        [InlineData("1234567890123456", true)]
        [InlineData("1234 5678 9012 3456", true)]
        [InlineData("9999 9999 9999 9999", true)]
        [InlineData("0000000000000000", true)]
        [InlineData("12345678901234", false)]  // Solo 14 dígitos
        [InlineData("123456789012345678", false)]  // 18 dígitos
        [InlineData("1234 5678 9012 345", false)]  // Falta un dígito
        [InlineData("1234 5678 9012 34567", false)]  // Un dígito extra
        [InlineData("abcd efgh ijkl mnop", false)]  // Letras
        [InlineData("1234-5678-9012-3456", false)]  // Guiones en lugar de espacios
        [InlineData("1234  5678  9012  3456", false)]  // Doble espacio
        public void NumeroTarjetaCredito_ValidaCorrectamente(string entrada, bool esperado)
        {
            bool resultado = Regex.IsMatch(entrada, Program.numeroTarjetaCredito);
            Assert.Equal(esperado, resultado);
        }

        // ==================== TESTS NOMBRE DE USUARIO ====================
        [Theory]
        [InlineData("juan_87", true)]
        [InlineData("maria.rosa", true)]
        [InlineData("Carlos1990", true)]
        [InlineData("user1", true)]  // 5 caracteres (mínimo)
        [InlineData("user12345678901", true)]  // 15 caracteres (máximo)
        [InlineData("a1234", true)]  // Empieza con letra
        [InlineData("User.Name_123", true)]
        [InlineData("123mario", false)]  // Empieza con número
        [InlineData("luis_", false)]  // Termina en guion bajo
        [InlineData(".pepe", false)]  // Empieza con punto
        [InlineData("ana.", false)]  // Termina en punto
        [InlineData("usr", false)]  // Solo 3 caracteres (menos de 5)
        [InlineData("ana-too-long-user", false)]  // Más de 15 caracteres
        [InlineData("user-name", false)]  // Contiene guion
        [InlineData("user name", false)]  // Contiene espacio
        public void NombreUsuario_ValidaCorrectamente(string entrada, bool esperado)
        {
            bool resultado = Regex.IsMatch(entrada, Program.nombreUsuario);
            Assert.Equal(esperado, resultado);
        }

        // ==================== TESTS MATRÍCULA COCHE ====================
        [Theory]
        [InlineData("1234BCD", true)]
        [InlineData("0000ZZZ", true)]
        [InlineData("9999XYZ", true)]
        [InlineData("5678KLM", true)]
        [InlineData("1234AEI", false)]  // Contiene vocales
        [InlineData("1234ABC", false)]  // Contiene vocal A
        [InlineData("1234EFG", false)]  // Contiene vocal E
        [InlineData("1234IJK", false)]  // Contiene vocal I
        [InlineData("1234OPQ", false)]  // Contiene vocal O
        [InlineData("1234UVW", false)]  // Contiene vocal U
        [InlineData("12AB345", false)]  // Formato incorrecto
        [InlineData("123BCD", false)]  // Solo 3 números
        [InlineData("12345BCD", false)]  // 5 números
        [InlineData("1234BC", false)]  // Solo 2 letras
        [InlineData("1234BCDE", false)]  // 4 letras
        [InlineData("1234bcd", false)]  // Minúsculas
        [InlineData("1234 BCD", false)]  // Con espacio
        public void MatriculaCoche_ValidaCorrectamente(string entrada, bool esperado)
        {
            bool resultado = Regex.IsMatch(entrada, Program.matriculaCoche);
            Assert.Equal(esperado, resultado);
        }

        // ==================== TESTS CÓDIGO POSTAL ====================
        [Theory]
        [InlineData("46010", true)]
        [InlineData("28013", true)]
        [InlineData("01000", true)]  // Álava
        [InlineData("52999", true)]  // Melilla (límite superior)
        [InlineData("08001", true)]  // Barcelona
        [InlineData("41001", true)]  // Sevilla
        [InlineData("00000", false)]  // 00 no válido
        [InlineData("00123", false)]  // 00 no válido
        [InlineData("53000", false)]  // 53 excede el límite
        [InlineData("99000", false)]  // 99 muy alto
        [InlineData("523456", false)]  // Más de 5 dígitos
        [InlineData("4601", false)]  // Solo 4 dígitos
        [InlineData("460101", false)]  // 6 dígitos
        [InlineData("4601A", false)]  // Contiene letra
        [InlineData("46 010", false)]  // Con espacio
        public void CodigoPostal_ValidaCorrectamente(string entrada, bool esperado)
        {
            bool resultado = Regex.IsMatch(entrada, Program.codigoPostal);
            Assert.Equal(esperado, resultado);
        }

        // ==================== TEST MÉTODO VALIDAENTRADA ====================
        [Fact]
        public void ValidaEntrada_ConPatronValido_NoLanzaExcepcion()
        {
            // Arrange
            string patron = Program.numeroTarjetaCredito;
            string entradaValida = "1234 5678 9012 3456";
            string entradaInvalida = "abc";

            // Act & Assert - No debe lanzar excepción
            var exception1 = Record.Exception(() => Program.ValidaEntrada(patron, entradaValida));
            var exception2 = Record.Exception(() => Program.ValidaEntrada(patron, entradaInvalida));

            Assert.Null(exception1);
            Assert.Null(exception2);
        }
    }
}
