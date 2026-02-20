using System;
using Xunit;

namespace ejercicio3.tests
{
    public class UnitTest1
    {
        [Fact]
        public void Mayor_DevuelveTrueSiElPrimeroEsMayor()
        {
            Assert.True(Comparador.Mayor(5, 3));
            Assert.False(Comparador.Mayor(3, 5));
            Assert.False(Comparador.Mayor(5, 5));
        }

        [Fact]
        public void Menor_DevuelveTrueSiElPrimeroEsMenor()
        {
            Assert.True(Comparador.Menor(3, 5));
            Assert.False(Comparador.Menor(5, 3));
            Assert.False(Comparador.Menor(5, 5));
        }

        [Fact]
        public void CompareTo_DevuelveValorCorrecto()
        {
            var p1 = new Persona("A", 20);
            var p2 = new Persona("B", 25);
            var p3 = new Persona("C", 20);
            Assert.Equal(-1, p1.CompareTo(p2)); // p2.Edad > p1.Edad
            Assert.Equal(1, p2.CompareTo(p1)); // p1.Edad < p2.Edad
            Assert.Equal(0, p1.CompareTo(p3)); // misma edad
        }

        [Fact]
        public void Clone_CreaCopiaCorrecta()
        {
            var p1 = new Persona("A", 20);
            var p2 = (Persona)p1.Clone();
            Assert.NotSame(p1, p2);
            Assert.Equal(p1.ToString(), p2.ToString());
        }

        [Fact]
        public void ToString_DevuelveFormatoEsperado()
        {
            var p = new Persona("Juan", 30);
            var esperado = "Nombre: Juan, Edad: 30 años.";
            Assert.Equal(esperado, p.ToString());
        }

        [Fact]
        public void Mayor_ConPersonas_DevuelveTrueSiElPrimeroEsMayor()
        {
            var p1 = new Persona("A", 30);
            var p2 = new Persona("B", 20);
            Assert.True(Comparador.Mayor(p1, p2));
            Assert.False(Comparador.Mayor(p2, p1));
        }

        [Fact]
        public void Menor_ConPersonas_DevuelveTrueSiElPrimeroEsMenor()
        {
            var p1 = new Persona("A", 20);
            var p2 = new Persona("B", 30);
            Assert.True(Comparador.Menor(p1, p2));
            Assert.False(Comparador.Menor(p2, p1));
        }
    }
}
