using Xunit;
using ejercicio9;
using System;

namespace ejercicio9.tests
{
    public class UnitTest1
    {
        [Fact]
        public void Pila_Push_AgregaElemento()
        {
            var p = new Pila<int>();
            p.Push(1);
            Assert.Equal(1, p.Count);
            Assert.False(p.EstaVacia());
        }

        [Fact]
        public void Pila_Pop_DevuelveYEliminaUltimo()
        {
            var p = new Pila<int>();
            p.Push(1);
            p.Push(2);
            var val = p.Pop();
            Assert.Equal(2, val);
            Assert.Equal(1, p.Count);
        }

        [Fact]
        public void Pila_Peek_DevuelveSinEliminar()
        {
            var p = new Pila<int>();
            p.Push(1);
            var val = p.Peek();
            Assert.Equal(1, val);
            Assert.Equal(1, p.Count);
        }

        [Fact]
        public void Pila_Pop_LanzaExcepcionSiVacia()
        {
            var p = new Pila<int>();
            Assert.Throws<InvalidOperationException>(() => p.Pop());
        }
    }
}
