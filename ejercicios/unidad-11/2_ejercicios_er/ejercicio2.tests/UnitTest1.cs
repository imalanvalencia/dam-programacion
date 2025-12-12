using Xunit;
using System.Text.RegularExpressions;
using System;
using System.IO;

namespace ejercicio2.Tests
{
    public class CIFTests
    {
        // ==================== TESTS PATRÓN CIF ====================

        [Theory]
        [InlineData("A-1234567-B", true)]  // Con guiones
        [InlineData("B2812345C", true)]  // Tipo B
        [InlineData("G4698765J", true)]  // Tipo G, control J
        [InlineData("W08111223", true)]  // Control numérico
        [InlineData("A00000001", true)]  // Provincia 00, control numérico
        [InlineData("A99999990", true)]  // Provincia 99
        [InlineData("K 4612345 5", true)]  // Tipo K con espacios
        [InlineData("S-2898765-H", true)]  // Tipo S con guiones
        public void PatronCIF_CasosValidos_DevuelveTrue(string cif, bool esperado)
        {
            bool resultado = Regex.IsMatch(cif, Program.patronCIF);
            Assert.Equal(esperado, resultado);
        }

        [Theory]
        [InlineData("X12345678B", false)]  // Tipo X no válido
        [InlineData("A123456789B", false)]  // 9 dígitos en secuencial
        [InlineData("A1234567890", false)]  // Demasiados dígitos
        [InlineData("12345678B", false)]  // Sin letra de tipo
        [InlineData("A12345678K", false)]  // Control K no válido
        [InlineData("A12345678L", false)]  // Control L no válido
        [InlineData("a12345678B", false)]  // Tipo en minúscula
        [InlineData("A.12.345678.B", false)]  // Separador con punto
        [InlineData("A 12-345678 B", false)]  // Separadores mixtos
        [InlineData("", false)]  // Cadena vacía
        [InlineData("ABC123", false)]  // Formato totalmente incorrecto
        public void PatronCIF_CasosInvalidos_DevuelveFalse(string cif, bool esperado)
        {
            bool resultado = Regex.IsMatch(cif, Program.patronCIF);
            Assert.Equal(esperado, resultado);
        }

        // ==================== TESTS GRUPOS NOMBRADOS ====================
        
        [Fact]
        public void PatronCIF_ExtraeGrupoTipo_Correcto()
        {
            string cif = "A1234567B";
            Match match = Regex.Match(cif, Program.patronCIF);
            
            Assert.True(match.Success);
            Assert.Equal("A", match.Groups["tipo"].Value);
        }

        [Fact]
        public void PatronCIF_ExtraeGrupoProvincia_Correcto()
        {
            string cif = "B2812346C";
            Match match = Regex.Match(cif, Program.patronCIF);
            
            Assert.True(match.Success);
            Assert.Equal("28", match.Groups["provincia"].Value);
        }

        [Fact]
        public void PatronCIF_ExtraeGrupoSecuencial_Correcto()
        {
            string cif = "G4698765J";
            Match match = Regex.Match(cif, Program.patronCIF);
            
            Assert.True(match.Success);
            Assert.Equal("98765", match.Groups["secuencial"].Value);
        }

        [Fact]
        public void PatronCIF_ExtraeGrupoControl_Correcto()
        {
            string cif = "W08111223";
            Match match = Regex.Match(cif, Program.patronCIF);
            
            Assert.True(match.Success);
            Assert.Equal("3", match.Groups["control"].Value);
        }

        [Fact]
        public void PatronCIF_ConEspacios_ExtraeGruposCorrectamente()
        {
            string cif = "K 4612345 5";
            Match match = Regex.Match(cif, Program.patronCIF);
            
            Assert.True(match.Success);
            Assert.Equal("K", match.Groups["tipo"].Value);
            Assert.Equal("46", match.Groups["provincia"].Value);
            Assert.Equal("12345", match.Groups["secuencial"].Value);
            Assert.Equal("5", match.Groups["control"].Value);
        }

        [Fact]
        public void PatronCIF_ConGuiones_ExtraeGruposCorrectamente()
        {
            string cif = "S-2898765-H";
            Match match = Regex.Match(cif, Program.patronCIF);
            
            Assert.True(match.Success);
            Assert.Equal("S", match.Groups["tipo"].Value);
            Assert.Equal("28", match.Groups["provincia"].Value);
            Assert.Equal("98765", match.Groups["secuencial"].Value);
            Assert.Equal("H", match.Groups["control"].Value);
        }

        // ==================== TESTS MÉTODO COMPRUEBACIF ====================
        
        [Fact]
        public void CompruebaCif_ConCIFValido_MuestraFormatoValido()
        {
            // Arrange
            string cifValido = "A1234678B";
            var output = new StringWriter();
            Console.SetOut(output);
            
            // Act
            Program.CompruebaCif(cifValido);
            
            // Assert
            string resultado = output.ToString();
            Assert.Contains("CIF válido:", resultado);
            Assert.Contains("A1234678B", resultado);
            Assert.Contains("Tipo de organización: A", resultado);
            Assert.Contains("Código provincial: 12", resultado);
            Assert.Contains("Numeración secuencial: 34678", resultado);
            Assert.Contains("Dígito de control: B", resultado);
        }

        [Fact]
        public void CompruebaCif_ConCIFValidoConEspacios_ExtraeInformacionCorrecta()
        {
            // Arrange
            string cifValido = "B 2812345 6";
            var output = new StringWriter();
            Console.SetOut(output);
            
            // Act
            Program.CompruebaCif(cifValido);
            
            // Assert
            string resultado = output.ToString();
            Assert.Contains("CIF válido", resultado);
            Assert.Contains("Tipo de organización: B", resultado);
            Assert.Contains("Código provincial: 28", resultado);
            Assert.Contains("Numeración secuencial: 12345", resultado);
            Assert.Contains("Dígito de control: 6", resultado);
        }

        [Fact]
        public void CompruebaCif_ConCIFValidoConGuiones_ExtraeInformacionCorrecta()
        {
            // Arrange
            string cifValido = "G-4698765-J";
            var output = new StringWriter();
            Console.SetOut(output);
            
            // Act
            Program.CompruebaCif(cifValido);
            
            // Assert
            string resultado = output.ToString();
            Assert.Contains("CIF válido", resultado);
            Assert.Contains("Tipo de organización: G", resultado);
            Assert.Contains("Código provincial: 46", resultado);
            Assert.Contains("Numeración secuencial: 98765", resultado);
            Assert.Contains("Dígito de control: J", resultado);
        }

        [Fact]
        public void CompruebaCif_ConCIFInvalido_MuestraMensajeError()
        {
            // Arrange
            string cifInvalido = "X12346758B";
            var output = new StringWriter();
            Console.SetOut(output);
            
            // Act
            Program.CompruebaCif(cifInvalido);
            
            // Assert
            string resultado = output.ToString();
            Assert.Contains("CIF no válido", resultado);
            Assert.Contains("X12346758B", resultado);
        }

        [Fact]
        public void CompruebaCif_ConFormatoIncorrecto_MuestraMensajeError()
        {
            // Arrange
            string cifInvalido = "ABC123";
            var output = new StringWriter();
            Console.SetOut(output);
            
            // Act
            Program.CompruebaCif(cifInvalido);
            
            // Assert
            string resultado = output.ToString();
            Assert.Contains("CIF no válido", resultado);
        }

        [Fact]
        public void CompruebaCif_ConCadenaVacia_MuestraMensajeError()
        {
            // Arrange
            string cifInvalido = "";
            var output = new StringWriter();
            Console.SetOut(output);
            
            // Act
            Program.CompruebaCif(cifInvalido);
            
            // Assert
            string resultado = output.ToString();
            Assert.Contains("CIF no válido", resultado);
        }

        [Fact]
        public void CompruebaCif_ConTodosLosTiposValidos_Funciona()
        {
            // Arrange
            string[] tiposValidos = { "A", "B", "C", "D", "E", "F", "G", "H", "K", "L", "M", "N", "P", "Q", "S", "U", "V", "W" };
            
            foreach (string tipo in tiposValidos)
            {
                var output = new StringWriter();
                Console.SetOut(output);
                string cif = $"{tipo}1234567A";
                
                // Act
                Program.CompruebaCif(cif);
                
                // Assert
                string resultado = output.ToString();
                Assert.Contains("CIF válido", resultado);
                Assert.Contains($"Tipo de organización: {tipo}", resultado);
            }
        }

        [Fact]
        public void CompruebaCif_ConControlesLetrasValidas_Funciona()
        {
            // Arrange
            string[] controlesValidos = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };
            
            foreach (string control in controlesValidos)
            {
                var output = new StringWriter();
                Console.SetOut(output);
                string cif = $"A1234567{control}";
                
                // Act
                Program.CompruebaCif(cif);
                
                // Assert
                string resultado = output.ToString();
                Assert.Contains("CIF válido", resultado);
                Assert.Contains($"Dígito de control: {control}", resultado);
            }
        }

        [Fact]
        public void CompruebaCif_ConControlesNumericos_Funciona()
        {
            // Arrange
            for (int i = 0; i <= 9; i++)
            {
                var output = new StringWriter();
                Console.SetOut(output);
                string cif = $"A1234567{i}";
                
                // Act
                Program.CompruebaCif(cif);
                
                // Assert
                string resultado = output.ToString();
                Assert.Contains("CIF válido", resultado);
                Assert.Contains($"Dígito de control: {i}", resultado);
            }
        }

        [Fact]
        public void CompruebaCif_NoLanzaExcepcion()
        {
            // Act & Assert
            var exception1 = Record.Exception(() => Program.CompruebaCif("A12345678B"));
            var exception2 = Record.Exception(() => Program.CompruebaCif("INVALIDO"));
            
            Assert.Null(exception1);
            Assert.Null(exception2);
        }
    }
}
