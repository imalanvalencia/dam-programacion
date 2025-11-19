using Xunit;
using Ejercicio3;

namespace Ejercicio3.Test
{
    public class UnitTest1
    {
        [Fact]
        public void EstadoPedido_ValoresNumericos_SonCorrectos()
        {
            // Arrange & Act & Assert
            Assert.Equal(0, (int)EstadoPedido.Pendiente);
            Assert.Equal(1, (int)EstadoPedido.Procesando);
            Assert.Equal(2, (int)EstadoPedido.Enviado);
            Assert.Equal(3, (int)EstadoPedido.Entregado);
            Assert.Equal(4, (int)EstadoPedido.Cancelado);
        }

        [Fact]
        public void CuentaPorEstado_ArrayVacio_RetornaArrayCeros()
        {
            // Arrange
            EstadoPedido[] pedidos = new EstadoPedido[0];

            // Act
            int[] conteos = Program.CuentaPorEstado(pedidos);

            // Assert
            Assert.Equal(5, conteos.Length); // 5 estados diferentes
            Assert.All(conteos, count => Assert.Equal(0, count));
        }

        [Fact]
        public void CuentaPorEstado_UnPedidoCadaEstado_RetornaUnoEnCadaPosicion()
        {
            // Arrange
            EstadoPedido[] pedidos = {
                EstadoPedido.Pendiente,
                EstadoPedido.Procesando,
                EstadoPedido.Enviado,
                EstadoPedido.Entregado,
                EstadoPedido.Cancelado
            };

            // Act
            int[] conteos = Program.CuentaPorEstado(pedidos);

            // Assert
            Assert.Equal(1, conteos[(int)EstadoPedido.Pendiente]);
            Assert.Equal(1, conteos[(int)EstadoPedido.Procesando]);
            Assert.Equal(1, conteos[(int)EstadoPedido.Enviado]);
            Assert.Equal(1, conteos[(int)EstadoPedido.Entregado]);
            Assert.Equal(1, conteos[(int)EstadoPedido.Cancelado]);
        }

        [Fact]
        public void CuentaPorEstado_MultiplesPedidosMismoEstado_CuentaCorrectamente()
        {
            // Arrange
            EstadoPedido[] pedidos = {
                EstadoPedido.Pendiente,
                EstadoPedido.Pendiente,
                EstadoPedido.Procesando,
                EstadoPedido.Enviado,
                EstadoPedido.Enviado,
                EstadoPedido.Enviado
            };

            // Act
            int[] conteos = Program.CuentaPorEstado(pedidos);

            // Assert
            Assert.Equal(2, conteos[(int)EstadoPedido.Pendiente]);
            Assert.Equal(1, conteos[(int)EstadoPedido.Procesando]);
            Assert.Equal(3, conteos[(int)EstadoPedido.Enviado]);
            Assert.Equal(0, conteos[(int)EstadoPedido.Entregado]);
            Assert.Equal(0, conteos[(int)EstadoPedido.Cancelado]);
        }

        [Fact]
        public void ContarPedidosActivos_SoloPedidosActivos_RetornaTodos()
        {
            // Arrange
            EstadoPedido[] pedidos = {
                EstadoPedido.Pendiente,
                EstadoPedido.Procesando,
                EstadoPedido.Enviado
            };

            // Act
            int activos = ContarPedidosActivos(pedidos);

            // Assert
            Assert.Equal(3, activos);
        }

        [Fact]
        public void ContarPedidosActivos_ConEntregadosYCancelados_ExcluyeNoActivos()
        {
            // Arrange
            EstadoPedido[] pedidos = {
                EstadoPedido.Pendiente,
                EstadoPedido.Procesando,
                EstadoPedido.Enviado,
                EstadoPedido.Entregado,
                EstadoPedido.Cancelado
            };

            // Act
            int activos = ContarPedidosActivos(pedidos);

            // Assert
            Assert.Equal(3, activos);
        }

        [Fact]
        public void ContarPedidosActivos_SoloEntregadosYCancelados_RetornaCero()
        {
            // Arrange
            EstadoPedido[] pedidos = {
                EstadoPedido.Entregado,
                EstadoPedido.Cancelado,
                EstadoPedido.Entregado
            };

            // Act
            int activos = ContarPedidosActivos(pedidos);

            // Assert
            Assert.Equal(0, activos);
        }

        // Método auxiliar para contar pedidos activos
        private int ContarPedidosActivos(EstadoPedido[] pedidos)
        {
            int contador = 0;
            for (int i = 0; i < pedidos.Length; i++)
            {
                if (pedidos[i] != EstadoPedido.Entregado && pedidos[i] != EstadoPedido.Cancelado)
                {
                    contador++;
                }
            }
            return contador;
        }
    }
}

