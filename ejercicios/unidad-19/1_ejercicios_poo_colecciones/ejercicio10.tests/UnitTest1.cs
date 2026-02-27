using Xunit;
using ejercicio10;
using System.Collections.Generic;

namespace ejercicio10.tests
{
    public class UnitTest1
    {
        [Fact]
        public void Pila_GetEnumerator_RecorreEnOrdenInverso()
        {
            var p = new Pila<int>();
            p.Push(1);
            p.Push(2);
            p.Push(3);

            var lista = new List<int>();
            foreach (var item in p)
            {
                lista.Add(item);
            }

            Assert.Equal(new List<int> { 3, 2, 1 }, lista);
        }
    }
}
