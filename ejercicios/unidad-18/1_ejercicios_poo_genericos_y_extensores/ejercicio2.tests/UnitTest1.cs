using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace ejercicio2.tests
{
    public class UnitTest1
    {
        // Helper: obtiene el ensamblado objetivo (ejercicio2) buscando entre los ensamblados cargados
        private static Assembly GetTargetAssembly()
        {
            var asm = AppDomain.CurrentDomain.GetAssemblies()
                .FirstOrDefault(a => string.Equals(a.GetName().Name, "ejercicio2", StringComparison.OrdinalIgnoreCase));
            if (asm != null) return asm;

            // fallback: intentar cargar desde el directorio base (cuando se ejecuta con dotnet test)
            var path = Path.Combine(AppContext.BaseDirectory, "ejercicio2.dll");
            if (File.Exists(path))
                return Assembly.LoadFrom(path);

            throw new InvalidOperationException("No se pudo localizar el ensamblado 'ejercicio2' para las pruebas.");
        }

        [Fact]
        public void Enciende_PoneEncendidaTrue()
        {
            var asm = GetTargetAssembly();
            var alarmaTypeOpen = asm.GetType("Alarma`1") ?? throw new Exception("Tipo Alarma`1 no encontrado");
            var sensorType = asm.GetType("SensorBasico") ?? throw new Exception("SensorBasico no encontrado");

            var alarmaIntType = alarmaTypeOpen.MakeGenericType(typeof(int));
            var sensor = Activator.CreateInstance(sensorType, nonPublic: true);

            var ctor = alarmaIntType.GetConstructors(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                .First(c => c.GetParameters().Length == 2);
            var alarma = ctor.Invoke(new object[] { 50, sensor })!;

            var enciende = alarmaIntType.GetMethod("Enciende", BindingFlags.Public | BindingFlags.Instance)!;
            enciende.Invoke(alarma, null);

            var campoEncendida = alarmaIntType.GetField("encendida", BindingFlags.NonPublic | BindingFlags.Instance)!;
            var valor = (bool)campoEncendida.GetValue(alarma)!;
            Assert.True(valor, "Después de Enciende la alarma debe tener encendida = true");
        }

        [Fact]
        public void Apaga_PoneEncendidaFalse()
        {
            var asm = GetTargetAssembly();
            var alarmaTypeOpen = asm.GetType("Alarma`1") ?? throw new Exception("Tipo Alarma`1 no encontrado");
            var sensorType = asm.GetType("SensorBasico") ?? throw new Exception("SensorBasico no encontrado");

            var alarmaIntType = alarmaTypeOpen.MakeGenericType(typeof(int));
            var sensor = Activator.CreateInstance(sensorType, nonPublic: true);
            var ctor = alarmaIntType.GetConstructors(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                .First(c => c.GetParameters().Length == 2);
            var alarma = ctor.Invoke(new object[] { 50, sensor })!;

            var apaga = alarmaIntType.GetMethod("Apaga", BindingFlags.Public | BindingFlags.Instance)!;
            apaga.Invoke(alarma, null);

            var campoEncendida = alarmaIntType.GetField("encendida", BindingFlags.NonPublic | BindingFlags.Instance)!;
            var valor = (bool)campoEncendida.GetValue(alarma)!;
            Assert.False(valor, "Después de Apaga la alarma debe tener encendida = false");
        }

        [Fact]
        public void Activa_ImprimeACTIVA()
        {
            var asm = GetTargetAssembly();
            var alarmaTypeOpen = asm.GetType("Alarma`1") ?? throw new Exception("Tipo Alarma`1 no encontrado");
            var sensorType = asm.GetType("SensorBasico") ?? throw new Exception("SensorBasico no encontrado");

            var alarmaIntType = alarmaTypeOpen.MakeGenericType(typeof(int));
            var sensor = Activator.CreateInstance(sensorType, nonPublic: true);
            var ctor = alarmaIntType.GetConstructors(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                .First(c => c.GetParameters().Length == 2);
            var alarma = ctor.Invoke(new object[] { 50, sensor })!;

            var sw = new StringWriter();
            var originalOut = Console.Out;
            try
            {
                Console.SetOut(sw);
                var activa = alarmaIntType.GetMethod("Activa", BindingFlags.Public | BindingFlags.Instance)!;
                activa.Invoke(alarma, null);
            }
            finally
            {
                Console.SetOut(originalOut);
            }

            var salida = sw.ToString();
            Assert.Contains("ACTIVA", salida);
        }

        [Fact]
        public void Desactiva_ImprimeDESACTIVA()
        {
            var asm = GetTargetAssembly();
            var alarmaTypeOpen = asm.GetType("Alarma`1") ?? throw new Exception("Tipo Alarma`1 no encontrado");
            var sensorType = asm.GetType("SensorBasico") ?? throw new Exception("SensorBasico no encontrado");

            var alarmaIntType = alarmaTypeOpen.MakeGenericType(typeof(int));
            var sensor = Activator.CreateInstance(sensorType, nonPublic: true);
            var ctor = alarmaIntType.GetConstructors(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                .First(c => c.GetParameters().Length == 2);
            var alarma = ctor.Invoke(new object[] { 50, sensor })!;

            var sw = new StringWriter();
            var originalOut = Console.Out;
            try
            {
                Console.SetOut(sw);
                var desactiva = alarmaIntType.GetMethod("Desactiva", BindingFlags.Public | BindingFlags.Instance)!;
                desactiva.Invoke(alarma, null);
            }
            finally
            {
                Console.SetOut(originalOut);
            }

            var salida = sw.ToString();
            Assert.Contains("DESACTIVA", salida);
        }

        [Fact]
        public async Task Comprueba_RealizaAlMenosUnaLectura()
        {
            var asm = GetTargetAssembly();
            var alarmaTypeOpen = asm.GetType("Alarma`1") ?? throw new Exception("Tipo Alarma`1 no encontrado");
            var sensorType = asm.GetType("SensorBasico") ?? throw new Exception("SensorBasico no encontrado");

            var alarmaIntType = alarmaTypeOpen.MakeGenericType(typeof(int));
            var sensor = Activator.CreateInstance(sensorType, nonPublic: true);
            var ctor = alarmaIntType.GetConstructors(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                .First(c => c.GetParameters().Length == 2);
            var alarma = ctor.Invoke(new object[] { 50, sensor })!;

            var enciende = alarmaIntType.GetMethod("Enciende", BindingFlags.Public | BindingFlags.Instance)!;
            var comprueba = alarmaIntType.GetMethod("Comprueba", BindingFlags.Public | BindingFlags.Instance)!;
            var apaga = alarmaIntType.GetMethod("Apaga", BindingFlags.Public | BindingFlags.Instance)!;

            var sw = new StringWriter();
            var originalOut = Console.Out;
            try
            {
                Console.SetOut(sw);
                enciende.Invoke(alarma, null);

                var t = Task.Run(() => comprueba.Invoke(alarma, null));
                await Task.Delay(700);
                apaga.Invoke(alarma, null);
                // esperar a que termine con timeout
                var finished = await Task.WhenAny(t, Task.Delay(2000));
                if (finished != t)
                {
                    throw new XunitException("Comprueba no finalizó en el tiempo esperado");
                }
            }
            finally
            {
                Console.SetOut(originalOut);
            }

            var salida = sw.ToString();
            Assert.Contains("Valor leído:", salida);
        }

        [Fact]
        public void FormateaValor_FormateaFloatConDosDecimales()
        {
            var asm = GetTargetAssembly();
            var alarmaTypeOpen = asm.GetType("Alarma`1") ?? throw new Exception("Tipo Alarma`1 no encontrado");
            var alarmaFloatType = alarmaTypeOpen.MakeGenericType(typeof(float));

            var metodo = alarmaFloatType.GetMethod("FormateaValor", BindingFlags.NonPublic | BindingFlags.Static)!;
            var resultado = metodo.Invoke(null, new object[] { 12.345f });
            Assert.Equal("12.35", resultado);
        }

        [Fact]
        public void SensorBasico_ValorEnRango()
        {
            var asm = GetTargetAssembly();
            var sensorType = asm.GetType("SensorBasico") ?? throw new Exception("SensorBasico no encontrado");
            var sensor = Activator.CreateInstance(sensorType, nonPublic: true);
            var prop = sensorType.GetProperty("ValorActual", BindingFlags.Public | BindingFlags.Instance)!;
            var valor = (int)prop.GetValue(sensor)!;
            Assert.InRange(valor, 0, 100);
        }

        [Fact]
        public void SensorPreciso_ValorEnRango()
        {
            var asm = GetTargetAssembly();
            var sensorType = asm.GetType("SensorPreciso") ?? throw new Exception("SensorPreciso no encontrado");
            var sensor = Activator.CreateInstance(sensorType, nonPublic: true);
            var prop = sensorType.GetProperty("ValorActual", BindingFlags.Public | BindingFlags.Instance)!;
            var valor = (float)prop.GetValue(sensor)!;
            Assert.InRange(valor, 0f, 100f);
        }

        [Fact]
        public void GestionAlarma_ExisteMetodoEstatico()
        {
            var asm = GetTargetAssembly();
            var progType = asm.GetType("Program") ?? throw new Exception("Tipo Program no encontrado");
            var metodo = progType.GetMethod("GestionAlarma", BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Public);
            Assert.NotNull(metodo);
        }
    }
}
                
