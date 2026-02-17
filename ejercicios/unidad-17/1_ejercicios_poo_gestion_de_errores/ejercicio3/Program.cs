using System;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace Ej03_CuentaBancaria
{
    public class SaldoInsuficienteException(string message) : Exception(message);
    public class NumeroCuentaIncorrectoException(string message) : Exception(message);

    public class NumeroCuenta
    {
        /*
        comprobar numero de cuenta
        https://zaguandelainformatica.blogspot.com/2014/07/algoritmo-para-el-calculo-de-los.html

        El primer grupo, de 4 dígitos, corresponde a la entidad bancaria. De ellos el primer dígito corresponde al tipo de entidad financiera: 0 Bancos, 1 Crédito Oficial, 2 Cajas de Ahorros, y 3 Cooperativas de Crédito como las Cajas Rurales.

        El segundo grupo, de 4 dígitos, es el código de sucursal.

        El tercer grupo, de 2 dígitos, es el código de control.

        El cuarto grupo, de 10 dígitos, es el número de cuenta.
        */
        private static readonly int[] Ponderaciones = [1, 2, 4, 8, 5, 10, 9, 7, 3, 6];

        string Entidad { get; set; }
        string Sucursal { get; set; }
        string DcEntSuc { get; set; }
        string DcNumero { get; set; }
        string Cuenta { get; set; }

        public NumeroCuenta(string numero)
        {
            FormatoCorrecto(numero);
        }

        private bool FormatoCorrecto(string numero)
        {
            string cuentaPatron = @"(?<entidad>\d{4})\s(?<sucursal>\d{4})\s(?<digito_control>\d{2})\s(?<cuenta>\d{10})";

            Match match = Regex.Match(numero, cuentaPatron);

            if (match.Success)
            {
                string entidad = match.Groups["entidad"].Value;
                string sucursal = match.Groups["sucursal"].Value;
                string dcEntidadEsperado = match.Groups["digito_control"].Value[0].ToString();
                string dcCuentaEsperado = match.Groups["digito_control"].Value[1].ToString();
                string cuenta = match.Groups["cuenta"].Value;


                bool primerDcOk = DcCorrecto(dcEntidadEsperado, entidad + sucursal, Ponderaciones);
                bool segundoDcOk = DcCorrecto(dcCuentaEsperado, cuenta, Ponderaciones);

                if (!primerDcOk || !segundoDcOk)

                {
                    throw new NumeroCuentaIncorrectoException("Los dígitos de control no coinciden con los datos de la cuenta.");
                }

                Entidad = entidad;
                Sucursal = sucursal;
                DcEntSuc = dcEntidadEsperado;
                DcNumero = dcCuentaEsperado;
                Cuenta = cuenta;

                return match.Success;
            }
            else throw new NumeroCuentaIncorrectoException("Has introducido un formato de cuenta no válido.");
        }
        private bool DcCorrecto(string dcEsperado, string digitos, int[] ponderaciones)
        {
            string numeroCuenta = digitos.PadLeft(10, '0');

            int suma = 0;

            for (int i = 0; i < 10; i++)
            {
                int valorDigito = int.Parse(numeroCuenta[i].ToString());
                suma += valorDigito * ponderaciones[i];
            }

            int resto = suma % 11;
            int resultado;

            if (resto == 0 || resto == 1) resultado = resto;
            else resultado = 11 - resto;


            return resultado.ToString() == dcEsperado;
        }

        public override string ToString() => $"""
        Entidad: {Entidad}
        Sucursal: {Sucursal}
        Digitos de control: {DcEntSuc}{DcNumero}
        Numero de cuenta: {Cuenta}
        """;

    }

    public class Cuenta
    {

        string Titular { get; }
        double Saldo { get; set; }
        NumeroCuenta Numero { get; }

        public Cuenta(string numero, string titular)
        {
            Numero = new(numero);
            Titular = titular;
            Saldo = 0.00;
        }

        public void Ingreso(double cantidad) => Saldo += cantidad;
        public void Reintegro(double cantidad)
        {
            if (cantidad > Saldo) throw new SaldoInsuficienteException("Error: Saldo insuficiente.");

            Saldo -= cantidad;
        }

        public double GetSaldo() => Saldo;

        public override string ToString() => $"""
        Titular: {Titular}
        Saldo: {Saldo}
        Numero: {Numero}
        """;

    }

    public class Ej04_CuentaBancaria
    {
        //TODO: Crea las clases necesarias
        static void Main()
        {
            while (true)
            {
                Console.Write("Introduce el número de cuenta: ");
                string? numCuenta = Console.ReadLine();
                Console.Write("Introduce el titular: ");
                string? titular = Console.ReadLine() ?? "";

                Cuenta cuenta = new Cuenta(numCuenta, titular);
                Console.WriteLine("Cuenta creada correctamente.\n");

                bool salir = false;
                while (!salir)
                {
                    Console.Write("Introduce cantidad a retirar: ");
                    string entrada = Console.ReadLine() ?? "";

                    //TODO: Crea el código necesario
                    try
                    {
                        cuenta.Reintegro(double.Parse(entrada));
                    }
                    catch (SaldoInsuficienteException e)
                    {
                        Console.WriteLine(e);
                    }

                    salir = true;
                }

                    Console.WriteLine();
                    Console.Write("¿Desea introducir otra cuenta? (s/n): ");
                    string respuesta = Console.ReadLine() ?? "";
                    if (respuesta == null || respuesta.ToLower() != "s")
                        break;
                    Console.WriteLine();
                }
            }
        }
    }