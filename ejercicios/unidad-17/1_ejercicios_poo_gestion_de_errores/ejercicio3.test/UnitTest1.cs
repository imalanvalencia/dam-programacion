using Xunit;

namespace Ej03_CuentaBancaria
{
    public class CuentaBancariaTests
    {
        [Fact]
        public void CrearCuenta_NumeroCorrecto_CuentaCreada()
        {
            var cuenta = new Cuenta("2085 0103 92 0300731702", "Ana");
            Assert.NotNull(cuenta);
        }

        [Fact]
        public void CrearCuenta_NumeroIncorrecto_LanzaNumeroCuentaIncorrectoException()
        {
            Assert.Throws<NumeroCuentaIncorrectoException>(() =>
                new Cuenta("1234 5678 90 1234567890", "Ana"));
        }

        [Fact]
        public void Reintegro_SaldoInsuficiente_LanzaSaldoInsuficienteException()
        {
            var cuenta = new Cuenta("2085 0103 92 0300731702", "Ana");
            Assert.Throws<SaldoInsuficienteException>(() => cuenta.Reintegro(1000));
        }

        [Fact]
        public void IngresoYReintegro_OperacionCorrecta()
        {
            var cuenta = new Cuenta("2085 0103 92 0300731702", "Ana");
            cuenta.Ingreso(500);
            cuenta.Reintegro(200);
            Assert.Equal(300, cuenta.GetSaldo());
        }
    }
}