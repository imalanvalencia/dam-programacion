
using Xunit;

namespace ejercicio1.tests;

public class MotorVehiculoTests
{
    [Fact]
    public void Motor_EstadoInicial_Apagado()
    {
        var motor = new Motor(100);
        Assert.False(motor.Encendido);
        Assert.Equal(100, motor.Potencia);
    }

    [Fact]
    public void Motor_Enciende_CambiaEstado()
    {
        var motor = new Motor(120);
        motor.Enciende();
        Assert.True(motor.Encendido);
        motor.Apaga();
        Assert.False(motor.Encendido);
    }

    [Fact]
    public void Vehiculo_Arranca_EnciendeMotor()
    {
        var v = new Vehiculo("Toyota", "Corolla", 120);
        Assert.False(GetMotorEncendido(v));
        v.Arranca();
        Assert.True(GetMotorEncendido(v));
    }

    // Helper para acceder al motor privado usando reflexión
    private bool GetMotorEncendido(Vehiculo v)
    {
        var field = typeof(Vehiculo).GetField("motor", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        var motor = field.GetValue(v);
        return (bool)motor.GetType().GetProperty("Encendido").GetValue(motor);
    }
}
