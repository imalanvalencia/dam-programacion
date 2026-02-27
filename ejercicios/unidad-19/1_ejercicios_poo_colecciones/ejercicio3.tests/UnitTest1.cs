using Xunit;
using ejercicio3;
using System.Collections.Generic;
using System;

namespace ejercicio3.tests
{
    public class UnitTest1
    {
        [Fact]
        public void Publicacion_Equals_ComparaPorId()
        {
            var dt = DateTime.Now;
            var p1 = new Publicacion(dt, new Usuario("u", "n", DateOnly.MinValue), "c", 0);
            var p2 = new Publicacion(dt, new Usuario("u2", "n2", DateOnly.MinValue), "c2", 1);
            Assert.True(p1.Equals(p2));
        }

        [Fact]
        public void Program_EstaPublicación_EncuentraElemento()
        {
            var dt = DateTime.Now;
            var p1 = new Publicacion(dt, new Usuario("u", "n", DateOnly.MinValue), "c", 0);
            var lista = new List<Publicacion> { p1 };
            
            var busqueda = new Publicacion(dt, new Usuario("x", "x", DateOnly.MinValue), "x", 0);
            Assert.True(Program.EstaPublicación(lista, busqueda));
        }

        [Fact]
        public void Program_EstaUsuario_EncuentraUsuario()
        {
            var u1 = new Usuario("user1", "Nombre", DateOnly.MinValue);
            var lista = new List<Usuario> { u1 };
            var busqueda = new Usuario("user1", "Nombre", DateOnly.MinValue);
            Assert.True(Program.EstaUsuario(lista, busqueda));
        }

        [Fact]
        public void Program_BuscaPublicación_EncuentraIndiceBinarySearch()
        {
            var dt1 = DateTime.Now.AddDays(-1);
            var dt2 = DateTime.Now;
            var p1 = new Publicacion(dt1, new Usuario("u", "n", DateOnly.MinValue), "c", 0);
            var p2 = new Publicacion(dt2, new Usuario("u", "n", DateOnly.MinValue), "c", 0);
            var lista = new List<Publicacion> { p1, p2 }; // Ya ordenada
            
            var busqueda = new Publicacion(dt2, new Usuario("x", "x", DateOnly.MinValue), "x", 0);
            int index = Program.BuscaPublicación(lista, busqueda);
            Assert.Equal(1, index);
        }
        
        [Fact]
        public void Program_BuscaPublicacionIComparer_EncuentraIndice()
        {
             var dt1 = DateTime.Now.AddDays(-1);
            var dt2 = DateTime.Now;
            var p1 = new Publicacion(dt1, new Usuario("u", "n", DateOnly.MinValue), "c", 0);
            var p2 = new Publicacion(dt2, new Usuario("u", "n", DateOnly.MinValue), "c", 0);
            var lista = new List<Publicacion> { p1, p2 };
            
            var busqueda = new Publicacion(dt2, new Usuario("x", "x", DateOnly.MinValue), "x", 0);
            int index = Program.BuscaPublicacionIComparer(lista, busqueda, new PublicacionComparer());
            Assert.Equal(1, index);
        }
    }
}
