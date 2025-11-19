using Xunit;
using Ejercicio1;

namespace Ejercicio1.Test
{
    public class UnitTest1
    {
        [Fact]
        public void NivelDificultad_ValoresNumericos_SonCorrectos()
        {
            // Arrange & Act & Assert
            Assert.Equal(1, (int)NivelDificultad.Facil);
            Assert.Equal(2, (int)NivelDificultad.Medio);
            Assert.Equal(3, (int)NivelDificultad.Dificil);
            Assert.Equal(4, (int)NivelDificultad.Extremo);
        }

        [Fact]
        public void ObtenVidas_NivelFacil_Retorna10()
        {
            // Arrange
            NivelDificultad nivel = NivelDificultad.Facil;

            // Act
            int vidas = Program.ObtenVidas(nivel);

            // Assert
            Assert.Equal(10, vidas);
        }

        [Fact]
        public void ObtenVidas_NivelMedio_Retorna5()
        {
            // Arrange
            NivelDificultad nivel = NivelDificultad.Medio;

            // Act
            int vidas = Program.ObtenVidas(nivel);

            // Assert
            Assert.Equal(5, vidas);
        }

        [Fact]
        public void ObtenVidas_NivelDificil_Retorna3()
        {
            // Arrange
            NivelDificultad nivel = NivelDificultad.Dificil;

            // Act
            int vidas = Program.ObtenVidas(nivel);

            // Assert
            Assert.Equal(3, vidas);
        }

        [Fact]
        public void ObtenVidas_NivelExtremo_Retorna1()
        {
            // Arrange
            NivelDificultad nivel = NivelDificultad.Extremo;

            // Act
            int vidas = Program.ObtenVidas(nivel);

            // Assert
            Assert.Equal(1, vidas);
        }

        [Fact]
        public void ObtenPuntosPorEnemigo_NivelFacil_Retorna5()
        {
            // Arrange
            NivelDificultad nivel = NivelDificultad.Facil;

            // Act
            int puntos = Program.ObtenPuntosPorEnemigo(nivel);

            // Assert
            Assert.Equal(5, puntos);
        }

        [Fact]
        public void ObtenPuntosPorEnemigo_NivelMedio_Retorna15()
        {
            // Arrange
            NivelDificultad nivel = NivelDificultad.Medio;

            // Act
            int puntos = Program.ObtenPuntosPorEnemigo(nivel);

            // Assert
            Assert.Equal(15, puntos);
        }

        [Fact]
        public void ObtenPuntosPorEnemigo_NivelDificil_Retorna30()
        {
            // Arrange
            NivelDificultad nivel = NivelDificultad.Dificil;

            // Act
            int puntos = Program.ObtenPuntosPorEnemigo(nivel);

            // Assert
            Assert.Equal(30, puntos);
        }

        [Fact]
        public void ObtenPuntosPorEnemigo_NivelExtremo_Retorna50()
        {
            // Arrange
            NivelDificultad nivel = NivelDificultad.Extremo;

            // Act
            int puntos = Program.ObtenPuntosPorEnemigo(nivel);

            // Assert
            Assert.Equal(50, puntos);
        }
    }
}
