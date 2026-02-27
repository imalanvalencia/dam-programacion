using Xunit;
using ejercicio2;
using System.Collections.Generic;

namespace ejercicio2.tests
{
    public class UnitTest1
    {
        [Fact]
        public void Automovil_ToString_DevuelveFormatoCorrecto()
        {
            var auto = new Automovil("Ford", "Focus", 2000, 2020, Color.Rojo);
            Assert.Equal("Ford Focus - 2000cc - 2020 - Rojo", auto.ToString());
        }

        [Fact]
        public void Program_AñadeAutomovil_AgregaALaLista()
        {
            var lista = new List<Automovil>();
            var auto = new Automovil("A", "B", 1, 2000, Color.Blanco);
            Program.AñadeAutomovil(lista, auto);
            Assert.Single(lista);
        }

        [Fact]
        public void Program_EliminaAutomovil_EliminaPorIndice()
        {
            var lista = new List<Automovil> { 
                new Automovil("A", "B", 1, 2000, Color.Blanco),
                new Automovil("C", "D", 2, 2001, Color.Negro)
            };
            Program.EliminaAutomovil(lista, 0);
            Assert.Single(lista);
            Assert.Equal("C", lista[0].Marca);
        }

        [Fact]
        public void Program_AutomovilesPorAñoFabricacion_FiltraCorrectamente()
        {
            var lista = new List<Automovil> { 
                new Automovil("A", "B", 1, 2020, Color.Blanco),
                new Automovil("C", "D", 2, 2021, Color.Negro)
            };
            var resultado = Program.AutomovilesPorAñoFabricacion(lista, 2020);
            Assert.Single(resultado);
            Assert.Equal("A", resultado[0].Marca);
        }

        [Fact]
        public void Program_AutomovilesPorAñoFabricacionYColor_FiltraCorrectamente()
        {
            var lista = new List<Automovil> { 
                new Automovil("A", "B", 1, 2020, Color.Blanco),
                new Automovil("C", "D", 2, 2020, Color.Negro),
                new Automovil("E", "F", 3, 2021, Color.Blanco)
            };
            var resultado = Program.AutomovilesPorAñoFabricacionYColor(lista, 2020, Color.Blanco);
            Assert.Single(resultado);
            Assert.Equal("A", resultado[0].Marca);
        }
    }
}
