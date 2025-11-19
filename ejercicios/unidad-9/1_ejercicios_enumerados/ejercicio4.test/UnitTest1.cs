using Xunit;
using Ejercicio4;
using System.Collections.Generic;

namespace Ejercicio4.Test
{
    public class UnitTest1
    {
        [Fact]
        public void DiaSemana_ValoresNumericos_SonCorrectos()
        {
            // Arrange & Act & Assert
            Assert.Equal(0, (int)Program.DiaSemana.Lunes);
            Assert.Equal(1, (int)Program.DiaSemana.Martes);
            Assert.Equal(2, (int)Program.DiaSemana.Miercoles);
            Assert.Equal(3, (int)Program.DiaSemana.Jueves);
            Assert.Equal(4, (int)Program.DiaSemana.Viernes);
            Assert.Equal(5, (int)Program.DiaSemana.Sabado);
            Assert.Equal(6, (int)Program.DiaSemana.Domingo);
        }

        [Fact]
        public void PlatoVegetariano_TieneValoresCorrectos()
        {
            // Arrange & Act & Assert
            Assert.Equal(0, (int)Program.PlatoVegetariano.EnsaladaDeQuinoa);
            Assert.Equal(1, (int)Program.PlatoVegetariano.CurryDeGarbanzos);
            Assert.Equal(2, (int)Program.PlatoVegetariano.HamburguesaVegetal);
            Assert.Equal(17, (int)Program.PlatoVegetariano.BerenjenasAlHornoConQueso);
        }

        [Fact]
        public void CaloriasPlatos_TieneValoresCorrectos()
        {
            // Arrange & Act & Assert
            Assert.Equal(350, Program.caloriasPlatos[0]); // EnsaladaDeQuinoa
            Assert.Equal(400, Program.caloriasPlatos[1]); // CurryDeGarbanzos
            Assert.Equal(300, Program.caloriasPlatos[2]); // HamburguesaVegetal
            Assert.Equal(250, Program.caloriasPlatos[3]); // SopaDeLentejas
            Assert.Equal(18, Program.caloriasPlatos.Length);
        }

        [Fact]
        public void GeneraDietaSemana_Genera7Platos()
        {
            // Arrange & Act
            var dieta = Program.GeneraDietaSemana();

            // Assert
            Assert.NotNull(dieta);
            Assert.Equal(7, dieta.Length);
        }

        [Fact]
        public void GeneraDietaSemana_PlatosUnicos()
        {
            // Arrange & Act
            var dieta = Program.GeneraDietaSemana();

            // Assert - Verificar que no hay platos repetidos
            var platosUnicos = new HashSet<Program.PlatoVegetariano>(dieta);
            Assert.Equal(7, platosUnicos.Count);
        }

        [Fact]
        public void CaloriasDieta_DietaConocida_CalculaCorrectamente()
        {
            // Arrange
            var dieta = new Program.PlatoVegetariano[]
            {
                Program.PlatoVegetariano.EnsaladaDeQuinoa,    // 350
                Program.PlatoVegetariano.CurryDeGarbanzos,    // 400
                Program.PlatoVegetariano.HamburguesaVegetal,  // 300
                Program.PlatoVegetariano.SopaDeLentejas,      // 250
                Program.PlatoVegetariano.PastaConPesto,       // 450
                Program.PlatoVegetariano.FalafelConEnsalada,  // 400
                Program.PlatoVegetariano.TortillaDeEspinacas  // 200
            };

            // Act
            int totalCalorias = Program.CaloriasDieta(dieta);

            // Assert
            Assert.Equal(2350, totalCalorias);
        }

        [Fact]
        public void PromedioCaloriasDiarias_DietaConocida_CalculaCorrectamente()
        {
            // Arrange
            var dieta = new Program.PlatoVegetariano[]
            {
                Program.PlatoVegetariano.EnsaladaDeQuinoa,    // 350
                Program.PlatoVegetariano.CurryDeGarbanzos,    // 400
                Program.PlatoVegetariano.HamburguesaVegetal,  // 300
                Program.PlatoVegetariano.SopaDeLentejas,      // 250
                Program.PlatoVegetariano.PastaConPesto,       // 450
                Program.PlatoVegetariano.FalafelConEnsalada,  // 400
                Program.PlatoVegetariano.TortillaDeEspinacas  // 200
            };

            // Act
            double promedio = Program.PromedioCaloriasDiarias(dieta);

            // Assert
            Assert.Equal(335.714, promedio, 3);
        }

        [Fact]
        public void DiaConMenosCalorias_DietaConocida_RetornaDiaCorrecto()
        {
            // Arrange
            var dieta = new Program.PlatoVegetariano[]
            {
                Program.PlatoVegetariano.PastaConPesto,       // Lunes: 450
                Program.PlatoVegetariano.CurryDeGarbanzos,    // Martes: 400
                Program.PlatoVegetariano.HamburguesaVegetal,  // Miércoles: 300
                Program.PlatoVegetariano.SopaDeLentejas,      // Jueves: 250
                Program.PlatoVegetariano.TortillaDeEspinacas, // Viernes: 200 <- Menor
                Program.PlatoVegetariano.FalafelConEnsalada,  // Sábado: 400
                Program.PlatoVegetariano.EnsaladaDeQuinoa     // Domingo: 350
            };

            // Act
            var diaMenor = Program.DiaConMenosCalorias(dieta);

            // Assert
            Assert.Equal(Program.DiaSemana.Viernes, diaMenor);
        }

        [Fact]
        public void DiaConMasCalorias_DietaConocida_RetornaDiaCorrecto()
        {
            // Arrange
            var dieta = new Program.PlatoVegetariano[]
            {
                Program.PlatoVegetariano.TortillaDeEspinacas, // Lunes: 200
                Program.PlatoVegetariano.CurryDeGarbanzos,    // Martes: 400
                Program.PlatoVegetariano.HamburguesaVegetal,  // Miércoles: 300
                Program.PlatoVegetariano.SopaDeLentejas,      // Jueves: 250
                Program.PlatoVegetariano.PastaConPesto,       // Viernes: 450 <- Mayor
                Program.PlatoVegetariano.FalafelConEnsalada,  // Sábado: 400
                Program.PlatoVegetariano.EnsaladaDeQuinoa     // Domingo: 350
            };

            // Act
            var diaMayor = Program.DiaConMasCalorias(dieta);

            // Assert
            Assert.Equal(Program.DiaSemana.Viernes, diaMayor);
        }

        [Fact]
        public void DiaConMenosCalorias_PrimeroEsMenor_RetornaLunes()
        {
            // Arrange
            var dieta = new Program.PlatoVegetariano[]
            {
                Program.PlatoVegetariano.CremaDeCalabaza,     // Lunes: 150 <- Menor
                Program.PlatoVegetariano.CurryDeGarbanzos,    // Martes: 400
                Program.PlatoVegetariano.HamburguesaVegetal,  // Miércoles: 300
                Program.PlatoVegetariano.SopaDeLentejas,      // Jueves: 250
                Program.PlatoVegetariano.PastaConPesto,       // Viernes: 450
                Program.PlatoVegetariano.FalafelConEnsalada,  // Sábado: 400
                Program.PlatoVegetariano.EnsaladaDeQuinoa     // Domingo: 350
            };

            // Act
            var diaMenor = Program.DiaConMenosCalorias(dieta);

            // Assert
            Assert.Equal(Program.DiaSemana.Lunes, diaMenor);
        }

        [Fact]
        public void DiaConMasCalorias_UltimoEsMayor_RetornaDomingo()
        {
            // Arrange
            var dieta = new Program.PlatoVegetariano[]
            {
                Program.PlatoVegetariano.TortillaDeEspinacas, // Lunes: 200
                Program.PlatoVegetariano.SopaDeLentejas,      // Martes: 250
                Program.PlatoVegetariano.HamburguesaVegetal,  // Miércoles: 300
                Program.PlatoVegetariano.EnsaladaDeQuinoa,    // Jueves: 350
                Program.PlatoVegetariano.CurryDeGarbanzos,    // Viernes: 400
                Program.PlatoVegetariano.FalafelConEnsalada,  // Sábado: 400
                Program.PlatoVegetariano.SushiVegetariano     // Domingo: 500 <- Mayor
            };

            // Act
            var diaMayor = Program.DiaConMasCalorias(dieta);

            // Assert
            Assert.Equal(Program.DiaSemana.Domingo, diaMayor);
        }

        [Fact]
        public void CaloriasDieta_DietaVacia_Retorna0()
        {
            // Arrange
            var dieta = new Program.PlatoVegetariano[0];

            // Act
            int totalCalorias = Program.CaloriasDieta(dieta);

            // Assert
            Assert.Equal(0, totalCalorias);
        }

        [Fact]
        public void PromedioCaloriasDiarias_DietaBajaCalorias_CalculaCorrectamente()
        {
            // Arrange - Usar platos con las calorías más bajas
            var dieta = new Program.PlatoVegetariano[]
            {
                Program.PlatoVegetariano.CremaDeCalabaza,     // 150
                Program.PlatoVegetariano.TortillaDeEspinacas, // 200
                Program.PlatoVegetariano.SmoothieVerde,       // 200
                Program.PlatoVegetariano.SopaDeLentejas,      // 250
                Program.PlatoVegetariano.BerenjenasAlHornoConQueso, // 250
                Program.PlatoVegetariano.HamburguesaVegetal,  // 300
                Program.PlatoVegetariano.WrapDeVerdurasYHummus // 300
            };

            // Act
            double promedio = Program.PromedioCaloriasDiarias(dieta);

            // Assert
            Assert.Equal(235.714, promedio, 3);
        }
    }
}
