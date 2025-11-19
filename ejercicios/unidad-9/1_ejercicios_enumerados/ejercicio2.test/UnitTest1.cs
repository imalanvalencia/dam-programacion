using Xunit;
using Ejercicio2;

namespace Ejercicio2.Test
{
    public class UnitTest1
    {
        [Fact]
        public void TipoAbono_ValoresNumericos_SonCorrectos()
        {
            // Arrange & Act & Assert
            Assert.Equal(70, (int)TipoAbono.QuinceDias);
            Assert.Equal(60, (int)TipoAbono.TreintaDias);
            Assert.Equal(50, (int)TipoAbono.FamiliasNumerosas);
            Assert.Equal(30, (int)TipoAbono.TerceraEdad);
            Assert.Equal(20, (int)TipoAbono.Discapacidad);
            Assert.Equal(65, (int)TipoAbono.Juvenil);
            Assert.Equal(35, (int)TipoAbono.Infantil);
            Assert.Equal(90, (int)TipoAbono.Turistico);
        }

        [Fact]
        public void EsAbonoFijo_QuinceDias_RetornaTrue()
        {
            // Arrange
            TipoAbono abono = TipoAbono.QuinceDias;

            // Act
            bool resultado = Program.EsAbonoFijo(abono);

            // Assert
            Assert.True(resultado);
        }

        [Fact]
        public void EsAbonoFijo_TreintaDias_RetornaTrue()
        {
            // Arrange
            TipoAbono abono = TipoAbono.TreintaDias;

            // Act
            bool resultado = Program.EsAbonoFijo(abono);

            // Assert
            Assert.True(resultado);
        }

        [Fact]
        public void EsAbonoFijo_Juvenil_RetornaFalse()
        {
            // Arrange
            TipoAbono abono = TipoAbono.Juvenil;

            // Act
            bool resultado = Program.EsAbonoFijo(abono);

            // Assert
            Assert.False(resultado);
        }

        [Fact]
        public void CalculaCosteTotal_QuinceDias()
        {
            // Arrange
            TipoAbono abono = TipoAbono.QuinceDias;
            int dias = 15;

            // Act
            var (costeTotal, diasFinales) = Program.CalculaCosteTotal(abono, dias);

            // Assert
            Assert.Equal(10.50, costeTotal, 2);
            Assert.Equal(15, diasFinales);
        }

        [Fact]
        public void CalculaCosteTotal_Juvenil_15Dias()
        {
            // Arrange
            TipoAbono abono = TipoAbono.Juvenil;
            int dias = 15;

            // Act
            var (costeTotal, diasFinales) = Program.CalculaCosteTotal(abono, dias);

            // Assert
            Assert.Equal(9.75, costeTotal, 2); // 0.65 * 15 = 9.75
            Assert.Equal(15, diasFinales);
        }

        [Fact]
        public void CalculaCosteTotal_TerceraEdad_30Dias()
        {
            // Arrange
            TipoAbono abono = TipoAbono.TerceraEdad;
            int dias = 30;

            // Act
            var (costeTotal, diasFinales) = Program.CalculaCosteTotal(abono, dias);

            // Assert
            Assert.Equal(9.00, costeTotal, 2); // 0.30 * 30 = 9.00
            Assert.Equal(30, diasFinales);
        }

        [Fact]
        public void CalculaCosteTotal_Discapacidad_7Dias()
        {
            // Arrange
            TipoAbono abono = TipoAbono.Discapacidad;
            int dias = 7;

            // Act
            var (costeTotal, diasFinales) = Program.CalculaCosteTotal(abono, dias);

            // Assert
            Assert.Equal(1.40, costeTotal, 2); // 0.20 * 7 = 1.40
            Assert.Equal(7, diasFinales);
        }

        [Fact]
        public void CalculaCosteTotal_Turistico_60Dias()
        {
            // Arrange
            TipoAbono abono = TipoAbono.Turistico;
            int dias = 60;

            // Act
            var (costeTotal, diasFinales) = Program.CalculaCosteTotal(abono, dias);

            // Assert
            Assert.Equal(54.00, costeTotal, 2); // 0.90 * 60 = 54.00
            Assert.Equal(60, diasFinales);
        }
    }
}
