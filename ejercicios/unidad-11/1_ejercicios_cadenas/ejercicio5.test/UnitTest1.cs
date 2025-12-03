using Xunit;
using System.Text;

namespace ejercicio5.Tests
{
    public class ProgramTests
    {
        // Tests para EstaLetraEnLetras
        [Fact]
        public void EstaLetraEnLetras_LetraPresente_DebeRetornarTrue()
        {
            // Arrange
            char letra = 'A';
            string letras = "ABCDE";

            // Act
            bool resultado = Program.EstaLetraEnLetras(letra, letras);

            // Assert
            Assert.True(resultado);
        }

        [Fact]
        public void EstaLetraEnLetras_LetraAusente_DebeRetornarFalse()
        {
            // Arrange
            char letra = 'Z';
            string letras = "ABCDE";

            // Act
            bool resultado = Program.EstaLetraEnLetras(letra, letras);

            // Assert
            Assert.False(resultado);
        }

        [Fact]
        public void EstaLetraEnLetras_CadenaVacia_DebeRetornarFalse()
        {
            // Arrange
            char letra = 'A';
            string letras = "";

            // Act
            bool resultado = Program.EstaLetraEnLetras(letra, letras);

            // Assert
            Assert.False(resultado);
        }

        [Fact]
        public void EstaLetraEnLetras_LetraEnMedio_DebeRetornarTrue()
        {
            // Arrange
            char letra = 'C';
            string letras = "ABCDEF";

            // Act
            bool resultado = Program.EstaLetraEnLetras(letra, letras);

            // Assert
            Assert.True(resultado);
        }

        // Tests para AñadeLetraALetrasPalabraAMostrar
        [Fact]
        public void AñadeLetraALetrasPalabraAMostrar_LetraUnica_DebeAñadirLetra()
        {
            // Arrange
            string palabraAAdivinar = "HOLA";
            char letra = 'H';
            StringBuilder palabraParcialmenteAdivinada = new StringBuilder("____");

            // Act
            Program.AñadeLetraALetrasPalabraAMostrar(palabraAAdivinar, letra, palabraParcialmenteAdivinada);

            // Assert
            Assert.Equal("H___", palabraParcialmenteAdivinada.ToString());
        }

        [Fact]
        public void AñadeLetraALetrasPalabraAMostrar_LetraRepetida_DebeAñadirTodasLasOcurrencias()
        {
            // Arrange
            string palabraAAdivinar = "ALABAMA";
            char letra = 'A';
            StringBuilder palabraParcialmenteAdivinada = new StringBuilder("_______");

            // Act
            Program.AñadeLetraALetrasPalabraAMostrar(palabraAAdivinar, letra, palabraParcialmenteAdivinada);

            // Assert
            Assert.Equal("A_A_A_A", palabraParcialmenteAdivinada.ToString());
        }

        [Fact]
        public void AñadeLetraALetrasPalabraAMostrar_LetraNoPresente_NoDebeModificar()
        {
            // Arrange
            string palabraAAdivinar = "HOLA";
            char letra = 'Z';
            StringBuilder palabraParcialmenteAdivinada = new StringBuilder("____");

            // Act
            Program.AñadeLetraALetrasPalabraAMostrar(palabraAAdivinar, letra, palabraParcialmenteAdivinada);

            // Assert
            Assert.Equal("____", palabraParcialmenteAdivinada.ToString());
        }

        [Fact]
        public void AñadeLetraALetrasPalabraAMostrar_LetraAlFinal_DebeAñadirLetra()
        {
            // Arrange
            string palabraAAdivinar = "HOLA";
            char letra = 'A';
            StringBuilder palabraParcialmenteAdivinada = new StringBuilder("____");

            // Act
            Program.AñadeLetraALetrasPalabraAMostrar(palabraAAdivinar, letra, palabraParcialmenteAdivinada);

            // Assert
            Assert.Equal("___A", palabraParcialmenteAdivinada.ToString());
        }

        // Tests para FinDeJuego
        [Fact]
        public void FinDeJuego_MaximoFallosAlcanzado_DebeRetornarTrue()
        {
            // Arrange
            int numFallos = 5;
            int maxFallos = 5;
            string palabraAAdivinar = "HOLA";
            string palabraParcialmenteAdivinada = "H_LA";

            // Act
            bool resultado = Program.FinDeJuego(numFallos, maxFallos, palabraAAdivinar, palabraParcialmenteAdivinada, out string mensajeSiFin);

            // Assert
            Assert.True(resultado);
            Assert.Contains("máximo de fallos", mensajeSiFin);
            Assert.Contains("HOLA", mensajeSiFin);
        }

        [Fact]
        public void FinDeJuego_PalabraAdivinada_DebeRetornarTrue()
        {
            // Arrange
            int numFallos = 2;
            int maxFallos = 5;
            string palabraAAdivinar = "HOLA";
            string palabraParcialmenteAdivinada = "HOLA";

            // Act
            bool resultado = Program.FinDeJuego(numFallos, maxFallos, palabraAAdivinar, palabraParcialmenteAdivinada, out string mensajeSiFin);

            // Assert
            Assert.True(resultado);
            Assert.Contains("ENHORABUENA", mensajeSiFin);
        }

        [Fact]
        public void FinDeJuego_JuegoContinua_DebeRetornarFalse()
        {
            // Arrange
            int numFallos = 2;
            int maxFallos = 5;
            string palabraAAdivinar = "HOLA";
            string palabraParcialmenteAdivinada = "H_LA";

            // Act
            bool resultado = Program.FinDeJuego(numFallos, maxFallos, palabraAAdivinar, palabraParcialmenteAdivinada, out string mensajeSiFin);

            // Assert
            Assert.False(resultado);
            Assert.Equal("", mensajeSiFin);
        }

        [Fact]
        public void FinDeJuego_CeroFallos_DebeRetornarFalse()
        {
            // Arrange
            int numFallos = 0;
            int maxFallos = 5;
            string palabraAAdivinar = "HOLA";
            string palabraParcialmenteAdivinada = "____";

            // Act
            bool resultado = Program.FinDeJuego(numFallos, maxFallos, palabraAAdivinar, palabraParcialmenteAdivinada, out string mensajeSiFin);

            // Assert
            Assert.False(resultado);
            Assert.Equal("", mensajeSiFin);
        }

        [Fact]
        public void FinDeJuego_FallosSuperanMaximo_DebeRetornarTrue()
        {
            // Arrange
            int numFallos = 6;
            int maxFallos = 5;
            string palabraAAdivinar = "HOLA";
            string palabraParcialmenteAdivinada = "H___";

            // Act
            bool resultado = Program.FinDeJuego(numFallos, maxFallos, palabraAAdivinar, palabraParcialmenteAdivinada, out string mensajeSiFin);

            // Assert
            Assert.True(resultado);
            Assert.Contains("máximo de fallos", mensajeSiFin);
        }
    }

}