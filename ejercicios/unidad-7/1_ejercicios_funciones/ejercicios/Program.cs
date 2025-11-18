using System;
using System.Diagnostics;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

public class Program
{

    static string InputUser(string message)
    {
        Console.Write(message);
        return Console.ReadLine() ?? "";
    }

    public static void MuestraInformacion()
    {
        string name = InputUser("Introduce tu nombre: ");
        string lastname = InputUser("Introduce tu apellido: ");
        int yearsOld = int.Parse(InputUser("Introduce tu edad: "));
        string city = InputUser("Introduce tu ciudad: ");
        string completeName = $"{name} {lastname}";

        Console.WriteLine($"=== INFORMACIÓN PERSONAL ===\nNombre completo: {completeName}\nEdad: {yearsOld} años\nCiudad de residencia: {city}\n==========================");
    }


    public static void Ejercicio1()
    {
        Console.WriteLine("Ejercicio 1. Función sin parámetros de entrada y sin retorno");

        MuestraInformacion();
    }


    public static void VolumenEsfera(double radio)
    {
        // 4 / 3 division enteros -> dara 1 (y el resto 1 se pierde)
        // al menos uno tiene que ser double para que te de correcto (1.333333...)
        // (double)4 / 3 tranforma 4 en double


        double volume = (double)4 / 3 * Math.PI * Math.Pow(radio, 3);

        Console.WriteLine($"El volumen de la esfera es: {volume:F2}");
    }

    public static void Ejercicio2()
    {
        Console.WriteLine("\nEjercicio 2. Función sin parámetros de entrada y sin retorno");
        int radioSphere = int.Parse(InputUser("Introduce el radio de la esfera: "));
        VolumenEsfera(radioSphere);

    }


    public static void Mayor(int a, int b, int c)
    {
        int mayor = (a > b) ? (a > c ? a : c) : (b > c ? b : c);
        Console.WriteLine($"El mayor de los tres números es: {mayor}");
    }

    public static void Ejercicio3()
    {
        Console.WriteLine("\nEjercicio 3: Función con múltiples parámetros y sin retorno");
        int firstNumber = int.Parse(InputUser("Introduce el primer número: "));
        int secondNumber = int.Parse(InputUser("Introduce el segundo número: "));
        int thirdNumber = int.Parse(InputUser("Introduce el tercer número: "));

        Mayor(firstNumber, secondNumber, thirdNumber);
    }

    public static string FormateaFecha()
    {
        DateTime today = DateTime.Now;

        string month = today.ToString("MMMM");
        month = char.ToUpper(month[0]) + month[1..];

        return $"Hoy estamos a {today.Day} de {month} de {today.Year}";
    }

    public static void Ejercicio4()
    {
        Console.WriteLine("\nEjercicio 4. Función que retorna la fecha actual formateada");

        string today = FormateaFecha();
        Console.WriteLine(today);
    }


    public static bool EsBisiesto(int año)
    {
        bool isDivisibleFor4 = año % 4 == 0;
        bool isNotDivisibleFor100 = año % 100 != 0;
        bool isDivisibleFor400 = año % 400 == 0;

        return isDivisibleFor4 && (isNotDivisibleFor100 || isDivisibleFor400);
    }


    public static void Ejercicio5()
    {
        Console.WriteLine("\nEjercicio 5: Función de validación");
        int año = int.Parse(InputUser("Introduce un año: "));

        if (EsBisiesto(año)) Console.WriteLine($"El año {año} es bisiesto");
        else Console.WriteLine($"El año {año} no es bisiesto");
    }


    public static string GeneraContraseña(int length, bool includeNumber, bool includeSymbol)
    {
        Random random = new Random();
        string password = "";

        for (int i = 0; i < length; i++)
        {
            int ascii;

            int tipo = random.Next(
                includeNumber && includeSymbol ? 4 :
                includeNumber || includeSymbol ? 3 : 2);

            switch (tipo)
            {
                case 0: // Mayúsculas (A–Z)
                    ascii = random.Next(65, 91);
                    break;

                case 1: // Minúsculas (a–z)
                    ascii = random.Next(97, 123);
                    break;

                case 2: // Números (0–9)
                    ascii = includeNumber ? random.Next(48, 58) : random.Next(65, 91);
                    break;

                default: // Símbolos (!@#$%&*)
                    if (includeSymbol)
                    {
                        // Mezclamos símbolos de diferentes zonas ASCII
                        int code = random.Next(8);
                        ascii = code switch
                        {
                            < 6 => 33 + code, // ! " # $ % &
                            6 => 42,          // *
                            7 => 64,          // @
                            _ => 33           // es igual a ! solo que no quiero que salte el warning nunca entra
                        };
                    }
                    else
                    {
                        ascii = random.Next(97, 123);
                    }
                    break;
            }

            password += (char)ascii;
        }

        return password;
    }

    public static void Ejercicio6()
    {
        Console.WriteLine("\nEjercicio 6. Función generadora de contraseñas");

        int length = int.Parse(InputUser("Introduce la longitud deseada: "));
        bool includeNumber = InputUser("¿Incluir números? (s/n): ").ToLower().Equals("s", StringComparison.CurrentCultureIgnoreCase);
        bool includeSymbol = InputUser("¿Incluir números? (s/n): ").ToLower().Equals("s", StringComparison.CurrentCultureIgnoreCase);

        string passwordGenerated = GeneraContraseña(length, includeNumber, includeSymbol);

        Console.WriteLine("Contraseña generada: " + passwordGenerated);
    }



    public static (double pagoMensual, double totalPagar, double interesesTotales) CalculaPrestamo(double totalAmount, double annualInterestRate, int years)
    {

        Debug.Assert(totalAmount > 0 && annualInterestRate > 0 && years > 0, "Todos los valores deben ser positivos");

        double monthlyInterest = annualInterestRate / 12 / 100;
        int months = years * 12;



        double monthlyPayment = totalAmount * (monthlyInterest * Math.Pow(1 + monthlyInterest, months)) / (Math.Pow(1 + monthlyInterest, months) - 1);
        double totalToPay = monthlyPayment * months;
        double totalInterests = totalToPay - totalAmount;

        return (monthlyPayment, totalToPay, totalInterests);
    }

    public static void Ejercicio7()
    {
        Console.WriteLine("\nEjercicio 7. Calculadora de préstamos");


        double monto = double.Parse(InputUser("Introduce el monto del préstamo: "));
        double tasaAnual = double.Parse(InputUser("Introduce la tasa de interés anual (%): "));
        int años = int.Parse(InputUser("Introduce el plazo en años: "));

        var (pagoMensual, totalPagar, interesesTotales) = CalculaPrestamo(monto, tasaAnual, años);

        int numeroMeses = años * 12;

        Console.WriteLine("=== DETALLES DEL PRÉSTAMO ===");
        Console.WriteLine("Monto: {0:C2}", monto);
        Console.WriteLine("Tasa anual: {0:F2}%", tasaAnual);
        Console.WriteLine("Plazo: {0} años ({1} meses)", años, numeroMeses);
        Console.WriteLine("Pago mensual: {0:C2}", pagoMensual);
        Console.WriteLine("Total a pagar: {0:C2}", totalPagar);
        Console.WriteLine("Intereses totales: {0:C2}", interesesTotales);
        Console.WriteLine("============================");
    }

    public static double Distancia((double x, double y) p1, (double x, double y) p2)
    {
        double distance = Math.Sqrt(
            Math.Pow(p1.x - p2.x, 2) + Math.Pow(p1.y - p2.y, 2)
        );

        return Math.Round(distance, 2);
    }
    public static void Ejercicio8()
    {
        Console.WriteLine("\nEjercicio 8. Función con parámetros de entrada complejos");

        Console.WriteLine("Introduce las coordenadas del primer punto:");
        double x1 = double.Parse(InputUser("X1: "));
        double x2 = double.Parse(InputUser("X2: "));

        Console.WriteLine("Introduce las coordenadas del segundo punto:");
        double y1 = double.Parse(InputUser("Y1: "));
        double y2 = double.Parse(InputUser("Y2: "));

        double result = Distancia((x1, x2), (y1, y2));

        Console.WriteLine("La distancia entre los puntos es: {0:F2}", result);
    }

    public static int TiempoASegundos(int minutes)
    {
        int minutesToSeconds = minutes * 60;
        return minutesToSeconds;
    }
    public static int TiempoASegundos(int hours, int minutes)
    {
        int minutesToSeconds = minutes * 60;
        int hoursToSeconds = hours * 3600;

        return minutesToSeconds + hoursToSeconds;
    }
    public static int TiempoASegundos(int days, int hours, int minutes)
    {
        int minutesToSeconds = minutes * 60;
        int hoursToSeconds = hours * 3600;
        int daysToSeconds = days * 86400;

        return minutesToSeconds + hoursToSeconds + daysToSeconds;
    }

    public static void Ejercicio9()
    {
        Console.WriteLine("\nEjercicio 9. Sobrecarga para cálculos de tiempo");
        int days = int.Parse(InputUser("Introduce los días: "));
        int hours = int.Parse(InputUser("Introduce los horas: "));
        int minutes = int.Parse(InputUser("Introduce los segundos: "));

        Console.WriteLine($"Tiempo total en segundos: {TiempoASegundos(days: days, hours, minutes)}");
    }


    public static int LeeEnteroEnRango(int min, int max)
    {
        int number;
        bool isValid;

        do
        {
            string entrada = InputUser($"Introduce un número entre {min} y {max}: ");

            isValid = int.TryParse(entrada, out number);

            if (!isValid || number < min || number > max)
            {
                Console.WriteLine("Número fuera de rango.");
                isValid = false; // para seguir en el bucle
            }

        } while (!isValid);

        return number;
    }


    public static void Ejercicio10()
    {
        Console.WriteLine("\nEjercicio 10. Función con validación de entrada");

        int numberValid = LeeEnteroEnRango(1, 100);
        Console.WriteLine($"Número válido introducido: {numberValid}");
    }


    public static void Main(string[] args)
    {
        Thread.CurrentThread.CurrentCulture = new CultureInfo("es-ES");
        Ejercicio1();
        Ejercicio2();
        Ejercicio3();
        Ejercicio4();
        Ejercicio5();
        Ejercicio6();
        Ejercicio7();
        Ejercicio8();
        Ejercicio9();
        Ejercicio10();

        Console.WriteLine("\nPresiona cualquier tecla para salir...");
        Console.ReadLine();
    }
}