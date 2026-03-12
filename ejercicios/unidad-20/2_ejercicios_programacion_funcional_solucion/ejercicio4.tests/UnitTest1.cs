using Xunit;
using System;
using System.Collections.Generic;
using Ejercicio4;

namespace ejercicio4.tests
{
    public class UnitTest1
    {
        [Fact]
        public void VolumenEsfera_CalculaVolumenCorrectamente()
        {
            var calculo = Program.VolumenEsfera();
            // Code performs: 4/3 * PI * r^2
            // Since 4/3 in integer math is 1, the code calculates 1 * PI * r^2
            double expected = 1.0 * Math.PI * Math.Pow(4, 2); 
            Assert.Equal(expected, calculo(4), 4);
        }

        [Fact]
        public void EsCapitular_DevuelveTrueSiEmpiezaPorMayuscula()
        {
            var check = Program.EsCapitular();
            Assert.True(check("Hola"));
        }

        [Fact]
        public void EsCapitular_DevuelveFalseSiEmpiezaPorMinuscula()
        {
             var check = Program.EsCapitular();
             Assert.False(check("hola"));
        }

        [Fact]
        public void DiccionarioDePalabras_CreaDiccionarioCorrectamente()
        {
            var funcionDic = Program.DiccionarioDePalabras();
            var dic = funcionDic("Hola mundo mundo");
            
            Assert.True(dic.ContainsKey("Hola"));
            Assert.True(dic.ContainsKey("mundo"));
            Assert.Equal(4, dic["Hola"]);
            Assert.Equal(5, dic["mundo"]);
        }
    }
}
