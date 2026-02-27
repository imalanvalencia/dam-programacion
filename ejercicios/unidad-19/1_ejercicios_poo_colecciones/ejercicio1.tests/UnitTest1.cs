using Xunit;
using ejercicio1;
using System.Collections.Generic;
using System;
using System.IO;

namespace ejercicio1.tests
{
    public class UnitTest1
    {
        [Fact]
        public void Plato_Equals_SonIgualesSiNombreYPrecioCoinciden()
        {
            var p1 = new Plato("Pasta", 10m, Categoria.Principal);
            var p2 = new Plato("Pasta", 10m, Categoria.Entrante);
            Assert.True(p1.Equals(p2));
            Assert.True(p1 == p2);
        }

        [Fact]
        public void Plato_ToString_DevuelveFormatoCorrecto()
        {
            var p = new Plato("Pasta", 10m, Categoria.Principal);
            Assert.Equal("Pasta - 10 - Principal", p.ToString());
        }

        [Fact]
        public void Program_AñadePlato_AgregaElementoALaLista()
        {
            var lista = new List<Plato>();
            var p = new Plato("Test", 1m, Categoria.Postre);
            Program.AñadePlato(lista, p);
            Assert.Single(lista);
            Assert.Equal(p, lista[0]);
        }

        [Fact]
        public void Program_EliminaPlato_EliminaElementoPorIndice()
        {
            var lista = new List<Plato> { new Plato("A", 1, Categoria.Entrante), new Plato("B", 2, Categoria.Principal) };
            Program.EliminaPlato(lista, 0);
            Assert.Single(lista);
            Assert.Equal("B", lista[0].Nombre);
        }

        [Fact]
        public void Program_BuscaPlato_ImprimeMensajeEncontrado()
        {
            var lista = new List<Plato> { new Plato("A", 1, Categoria.Entrante) };
            var p = new Plato("A", 1, Categoria.Entrante);
            
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                Program.BuscaPlato(lista, p);
                var result = sw.ToString();
                Assert.Contains("Plato encontrado", result);
            }
        }
    }
}
