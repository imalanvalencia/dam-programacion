using Xunit;
using ejercicio8;
using System;
using System.Collections.Generic;

namespace ejercicio8.tests
{
    public class UnitTest1
    {
        [Fact]
        public void Plato_DeberiaAlmacenarPropiedadesCorrectamente()
        {
            var plato = new Plato("Test Plato", 10.5m, Categoria.Principal);
            Assert.Equal("Test Plato", plato.Nombre);
            Assert.Equal(10.5m, plato.Precio);
            Assert.Equal(Categoria.Principal, plato.Categoria);
        }

        [Fact]
        public void Restaurante_AgregaPlato_DeberiaAnadirPlato()
        {
            var restaurante = new Restaurante();
            var plato = new Plato("Test Plato", 10.5m, Categoria.Principal);
            
            restaurante.AgregaPlato(plato);
            
            var retrieved = restaurante.PlatoDe("Test Plato");
            Assert.NotNull(retrieved);
            Assert.Equal(plato, retrieved);
        }

        [Fact]
        public void Restaurante_PlatoDe_DeberiaDevolverNull_CuandoPlatoNoEncontrado()
        {
            var restaurante = new Restaurante();
            var retrieved = restaurante.PlatoDe("NonExistent");
            Assert.Null(retrieved);
        }

        [Fact]
        public void Pedido_Total_DeberiaCalcularCorrectamente()
        {
            var p1 = new Plato("P1", 10m, Categoria.Entrante);
            var p2 = new Plato("P2", 20m, Categoria.Principal);
            var pedido = new Pedido(1, new List<Plato> { p1, p2 }, DateTime.Now);

            Assert.Equal(30m, pedido.Total);
        }

        [Fact]
        public void Cliente_Estadisticas_DeberiaCalcularCorrectamente()
        {
            var cliente = new Cliente("Test Client");
            var p1 = new Plato("P1", 10m, Categoria.Entrante);
            var pedido1 = new Pedido(1, new List<Plato> { p1 }, DateTime.Now); // Total 10
            var pedido2 = new Pedido(1, new List<Plato> { p1, p1 }, DateTime.Now); // Total 20

            cliente.HistorialPedidos.Add(pedido1);
            cliente.HistorialPedidos.Add(pedido2);

            Assert.Equal(2, cliente.NumeroVisitas);
            Assert.Equal(15m, cliente.GastoPromedio); // (10 + 20) / 2 = 15
        }

        [Fact]
        public void Restaurante_AnadeCliente_DeberiaAlmacenarCliente()
        {
            var restaurante = new Restaurante();
            var cliente = new Cliente("Test Client");
            
            restaurante.AñadeCliente(cliente);
            
            Assert.True(restaurante.Clientes.ContainsKey("Test Client"));
            Assert.Equal(cliente, restaurante.Clientes["Test Client"]);
        }
    }
}
