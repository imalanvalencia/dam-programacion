using Xunit;

namespace ejercicio2.Tests
{
    public class Ejercicio2Tests
    {
        [Theory]
        [InlineData("Anita lava la tina", true)]
        [InlineData("A mamá Roma le aviva el amor a mamá", true)]
        [InlineData("Hola mundo", false)]
        [InlineData("Dábale arroz a la zorra el abad", true)]
        [InlineData("", true)]
        [InlineData("12321", true)]
        [InlineData("12345", false)]
        public void EsPalindroma_DevuelveCorrecto(string frase, bool esperado)
        {
            Assert.Equal(esperado, Program.EsPalindroma(frase));
        }
    }
}