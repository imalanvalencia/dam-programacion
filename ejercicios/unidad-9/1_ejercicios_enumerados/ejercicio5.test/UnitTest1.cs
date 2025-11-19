using Xunit;
using Ejercicio5;
using System.IO;
using System;

namespace Ejercicio5.Test
{
    public class UnitTest1
    {
        [Fact]
        public void TurnoTrabajo_ValoresBinarios_SonCorrectos()
        {
            // Arrange & Act & Assert
            Assert.Equal(0b_0000_0000, (int)Program.TurnoTrabajo.Ninguno);
            Assert.Equal(0b_0000_0001, (int)Program.TurnoTrabajo.Mañana);
            Assert.Equal(0b_0000_0010, (int)Program.TurnoTrabajo.Tarde);
            Assert.Equal(0b_0000_0100, (int)Program.TurnoTrabajo.Noche);
            Assert.Equal(0b_0000_1000, (int)Program.TurnoTrabajo.FinDeSemana);
        }

        [Fact]
        public void TurnoTrabajo_EsFlags_PermiteCombinaciones()
        {
            // Arrange & Act
            var combinacion = Program.TurnoTrabajo.Mañana | Program.TurnoTrabajo.Tarde;

            // Assert
            Assert.Equal(3, (int)combinacion); // 1 + 2 = 3
        }

        [Fact]
        public void ParseaTurnos_EntradaVacia_RetornaNinguno()
        {
            // Arrange
            string input = "";

            // Act
            var resultado = Program.ParseaTurnos(input);

            // Assert
            Assert.Equal(Program.TurnoTrabajo.Ninguno, resultado);
        }

        [Fact]
        public void ParseaTurnos_SoloMañana_RetornaMañana()
        {
            // Arrange
            string input = "M";

            // Act
            var resultado = Program.ParseaTurnos(input);

            // Assert
            Assert.Equal(Program.TurnoTrabajo.Mañana, resultado);
        }

        [Fact]
        public void ParseaTurnos_MañanaYTarde_RetornaCombinacion()
        {
            // Arrange
            string input = "MT";

            // Act
            var resultado = Program.ParseaTurnos(input);

            // Assert
            Assert.Equal(Program.TurnoTrabajo.Mañana | Program.TurnoTrabajo.Tarde, resultado);
        }

        [Fact]
        public void ParseaTurnos_TodosLosTurnos_RetornaCombinacionCompleta()
        {
            // Arrange
            string input = "MTNF";

            // Act
            var resultado = Program.ParseaTurnos(input);

            // Assert
            var esperado = Program.TurnoTrabajo.Mañana | Program.TurnoTrabajo.Tarde | 
                          Program.TurnoTrabajo.Noche | Program.TurnoTrabajo.FinDeSemana;
            Assert.Equal(esperado, resultado);
        }

        [Fact]
        public void ParseaTurnos_MinusculasYMayusculas_FuncionaIgual()
        {
            // Arrange
            string inputMayusculas = "MTN";
            string inputMinusculas = "mtn";

            // Act
            var resultadoMayusculas = Program.ParseaTurnos(inputMayusculas);
            var resultadoMinusculas = Program.ParseaTurnos(inputMinusculas);

            // Assert
            Assert.Equal(resultadoMayusculas, resultadoMinusculas);
        }

        [Fact]
        public void ParseaTurnos_CaracteresInvalidos_SonIgnorados()
        {
            // Arrange
            string input = "MX2TNZ";

            // Act
            var resultado = Program.ParseaTurnos(input);

            // Assert
            var esperado = Program.TurnoTrabajo.Mañana | Program.TurnoTrabajo.Tarde | Program.TurnoTrabajo.Noche;
            Assert.Equal(esperado, resultado);
        }

        [Fact]
        public void TieneTurno_TieneMañana_RetornaTrue()
        {
            // Arrange
            var turnos = Program.TurnoTrabajo.Mañana | Program.TurnoTrabajo.Tarde;

            // Act
            bool resultado = Program.TieneTurno(turnos, Program.TurnoTrabajo.Mañana);

            // Assert
            Assert.True(resultado);
        }

        [Fact]
        public void TieneTurno_NoTieneNoche_RetornaFalse()
        {
            // Arrange
            var turnos = Program.TurnoTrabajo.Mañana | Program.TurnoTrabajo.Tarde;

            // Act
            bool resultado = Program.TieneTurno(turnos, Program.TurnoTrabajo.Noche);

            // Assert
            Assert.False(resultado);
        }

        [Fact]
        public void TieneTurno_Ninguno_RetornaFalse()
        {
            // Arrange
            var turnos = Program.TurnoTrabajo.Ninguno;

            // Act
            bool resultado = Program.TieneTurno(turnos, Program.TurnoTrabajo.Mañana);

            // Assert
            Assert.False(resultado);
        }

        [Fact]
        public void CalculaHorasSemanales_SoloMañana_Retorna8()
        {
            // Arrange
            var turnos = Program.TurnoTrabajo.Mañana;

            // Act
            int horas = Program.CalculaHorasSemanales(turnos);

            // Assert
            Assert.Equal(8, horas);
        }

        [Fact]
        public void CalculaHorasSemanales_MañanaYTarde_Retorna16()
        {
            // Arrange
            var turnos = Program.TurnoTrabajo.Mañana | Program.TurnoTrabajo.Tarde;

            // Act
            int horas = Program.CalculaHorasSemanales(turnos);

            // Assert
            Assert.Equal(16, horas);
        }

        [Fact]
        public void CalculaHorasSemanales_SoloFinDeSemana_Retorna10()
        {
            // Arrange
            var turnos = Program.TurnoTrabajo.FinDeSemana;

            // Act
            int horas = Program.CalculaHorasSemanales(turnos);

            // Assert
            Assert.Equal(10, horas);
        }

        [Fact]
        public void CalculaHorasSemanales_TodosLosTurnos_Retorna34()
        {
            // Arrange
            var turnos = Program.TurnoTrabajo.Mañana | Program.TurnoTrabajo.Tarde | 
                        Program.TurnoTrabajo.Noche | Program.TurnoTrabajo.FinDeSemana;

            // Act
            int horas = Program.CalculaHorasSemanales(turnos);

            // Assert
            Assert.Equal(34, horas); // 8 + 8 + 8 + 10 = 34
        }

        [Fact]
        public void CalculaHorasSemanales_Ninguno_Retorna0()
        {
            // Arrange
            var turnos = Program.TurnoTrabajo.Ninguno;

            // Act
            int horas = Program.CalculaHorasSemanales(turnos);

            // Assert
            Assert.Equal(0, horas);
        }

        [Fact]
        public void CalculaSalario_SoloMañana_Retorna80()
        {
            // Arrange
            var turnos = Program.TurnoTrabajo.Mañana;

            // Act
            double salario = Program.CalculaSalario(turnos);

            // Assert
            Assert.Equal(80.0, salario); // 8 horas × €10/hora = €80
        }

        [Fact]
        public void CalculaSalario_SoloNoche_Retorna120()
        {
            // Arrange
            var turnos = Program.TurnoTrabajo.Noche;

            // Act
            double salario = Program.CalculaSalario(turnos);

            // Assert
            Assert.Equal(120.0, salario); // 8 horas × €15/hora = €120
        }

        [Fact]
        public void CalculaSalario_SoloFinDeSemana_Retorna200()
        {
            // Arrange
            var turnos = Program.TurnoTrabajo.FinDeSemana;

            // Act
            double salario = Program.CalculaSalario(turnos);

            // Assert
            Assert.Equal(200.0, salario); // 10 horas × €20/hora = €200
        }

        [Fact]
        public void CalculaSalario_MañanaYTarde_Retorna160()
        {
            // Arrange
            var turnos = Program.TurnoTrabajo.Mañana | Program.TurnoTrabajo.Tarde;

            // Act
            double salario = Program.CalculaSalario(turnos);

            // Assert
            Assert.Equal(160.0, salario); // (8×€10) + (8×€10) = €160
        }

        [Fact]
        public void CalculaSalario_TodosLosTurnos_Retorna480()
        {
            // Arrange
            var turnos = Program.TurnoTrabajo.Mañana | Program.TurnoTrabajo.Tarde | 
                        Program.TurnoTrabajo.Noche | Program.TurnoTrabajo.FinDeSemana;

            // Act
            double salario = Program.CalculaSalario(turnos);

            // Assert
            Assert.Equal(480.0, salario); // €80 + €80 + €120 + €200 = €480
        }

        [Fact]
        public void AñadeTurno_AñadirMañanaANinguno_RetornaMañana()
        {
            // Arrange
            var turnosActuales = Program.TurnoTrabajo.Ninguno;
            var nuevoTurno = Program.TurnoTrabajo.Mañana;

            // Act
            var resultado = Program.AñadeTurno(turnosActuales, nuevoTurno);

            // Assert
            Assert.Equal(Program.TurnoTrabajo.Mañana, resultado);
        }

        [Fact]
        public void AñadeTurno_AñadirTardeAMañana_RetornaMañanaYTarde()
        {
            // Arrange
            var turnosActuales = Program.TurnoTrabajo.Mañana;
            var nuevoTurno = Program.TurnoTrabajo.Tarde;

            // Act
            var resultado = Program.AñadeTurno(turnosActuales, nuevoTurno);

            // Assert
            var esperado = Program.TurnoTrabajo.Mañana | Program.TurnoTrabajo.Tarde;
            Assert.Equal(esperado, resultado);
        }

        [Fact]
        public void QuitaTurno_QuitarMañanaDeMañanaYTarde_RetornaTarde()
        {
            // Arrange
            var turnosActuales = Program.TurnoTrabajo.Mañana | Program.TurnoTrabajo.Tarde;
            var turnoAQuitar = Program.TurnoTrabajo.Mañana;

            // Act
            var resultado = Program.QuitaTurno(turnosActuales, turnoAQuitar);

            // Assert
            Assert.Equal(Program.TurnoTrabajo.Tarde, resultado);
        }

        [Fact]
        public void QuitaTurno_QuitarTurnoQueNoTiene_NoAfecta()
        {
            // Arrange
            var turnosActuales = Program.TurnoTrabajo.Mañana | Program.TurnoTrabajo.Tarde;
            var turnoAQuitar = Program.TurnoTrabajo.Noche;

            // Act
            var resultado = Program.QuitaTurno(turnosActuales, turnoAQuitar);

            // Assert
            Assert.Equal(turnosActuales, resultado);
        }

        [Fact]
        public void CaracterATurno_M_RetornaMañana()
        {
            // Arrange
            char caracter = 'M';

            // Act
            var resultado = Program.CaracterATurno(caracter);

            // Assert
            Assert.Equal(Program.TurnoTrabajo.Mañana, resultado);
        }

        [Fact]
        public void CaracterATurno_Minuscula_FuncionaIgual()
        {
            // Arrange
            char caracter = 't';

            // Act
            var resultado = Program.CaracterATurno(caracter);

            // Assert
            Assert.Equal(Program.TurnoTrabajo.Tarde, resultado);
        }

        [Fact]
        public void CaracterATurno_CaracterInvalido_RetornaNinguno()
        {
            // Arrange
            char caracter = 'X';

            // Act
            var resultado = Program.CaracterATurno(caracter);

            // Assert
            Assert.Equal(Program.TurnoTrabajo.Ninguno, resultado);
        }

        [Fact]
        public void MuestraInformacion_TurnosMañanaYTarde_MuestraCorrectamente()
        {
            // Arrange
            var output = new StringWriter();
            Console.SetOut(output);
            string nombre = "Ana García";
            var turnos = Program.TurnoTrabajo.Mañana | Program.TurnoTrabajo.Tarde;

            // Act
            Program.MuestraInformacion(nombre, turnos);

            // Assert
            var result = output.ToString();
            Assert.Contains("Empleado: Ana García", result);
            Assert.Contains("Turnos: Mañana, Tarde", result);
            Assert.Contains("Horas semanales: 16", result);
            Assert.Contains("Salario base: 160,00€", result);
        }

        [Fact]
        public void MuestraInformacion_TurnoNinguno_MuestraNinguno()
        {
            // Arrange
            var output = new StringWriter();
            Console.SetOut(output);
            string nombre = "Pedro López";
            var turnos = Program.TurnoTrabajo.Ninguno;

            // Act
            Program.MuestraInformacion(nombre, turnos);

            // Assert
            var result = output.ToString();
            Assert.Contains("Empleado: Pedro López", result);
            Assert.Contains("Turnos: Ninguno", result);
            Assert.Contains("Horas semanales: 0", result);
            Assert.Contains("Salario base: 0,00€", result);
        }

        [Fact]
        public void MuestraInformacion_TodosLosTurnos_MuestraCompleto()
        {
            // Arrange
            var output = new StringWriter();
            Console.SetOut(output);
            string nombre = "María Rodríguez";
            var turnos = Program.TurnoTrabajo.Mañana | Program.TurnoTrabajo.Tarde | 
                        Program.TurnoTrabajo.Noche | Program.TurnoTrabajo.FinDeSemana;

            // Act
            Program.MuestraInformacion(nombre, turnos);

            // Assert
            var result = output.ToString();
            Assert.Contains("Empleado: María Rodríguez", result);
            Assert.Contains("Turnos: Mañana, Tarde, Noche, FinDeSemana", result);
            Assert.Contains("Horas semanales: 34", result);
            Assert.Contains("Salario base: 480,00€", result);
        }
    }
}
