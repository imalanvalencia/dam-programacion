using System;
using System.Security.Cryptography;

public class Program
{


    public static void DeterminaSiEsParOImpar()
    {
        Console.WriteLine("\nEjercicio 1: Número par o impar ");
        // TODO: Implementa la lógica de este método

        Console.Write("Introduce un número entero: ");

        int inputNumber = int.Parse(Console.ReadLine() ?? "0");

        if (inputNumber < 0) Console.Write($"{inputNumber} es un número invalido");
        if (inputNumber == 0) Console.Write($"El número {inputNumber} es par.");
        else Console.WriteLine((inputNumber % 2 == 0) ? $"El número {inputNumber} es par." : $"El número {inputNumber} es impar.");

    }

    public static void ConvierteTemperatura()
    {
        Console.WriteLine("\nEjercicio 2: Conversión de temperatura ");
        // TODO: Implementa la lógica de este método

        /*  
        to (F)ahrenheit (°F − 32) × 5 / 9 
        to (C)elsius ºC * 9/5 + 32
        */

        float temperatureConverted;

        Console.Write("Introduce la temperatura: ");
        float inputTemperature = float.Parse(Console.ReadLine() ?? "0");

        Console.Write("Convertir a (F)ahrenheit o (C)elsius? ");
        char temperatureUnitToConverte = char.Parse(Console.ReadLine()?.ToUpper() ?? "");



        if (temperatureUnitToConverte == 'C')
        {
            temperatureConverted = (inputTemperature - 32) * 5 / 9;

            Console.WriteLine($"{inputTemperature}ºF son {temperatureConverted.ToString("F2")}º{temperatureUnitToConverte}");

        }

        else if (temperatureUnitToConverte == 'F')
        {

            temperatureConverted = inputTemperature * 9 / 5 + 32;
            Console.WriteLine($"{inputTemperature}ºC son {temperatureConverted.ToString("F2")}º{temperatureUnitToConverte}");
        }

        else
            Console.WriteLine($"Opción no válida.");
    }


    public static void CalculaSalarioSemanal()
    {
        Console.WriteLine("\nEjercicio 3: Calculadora de salario ");
        // TODO: Implementa la lógica de este método


        const int minimunHourWithoutExtra = 40;
        Console.Write("Introduce las horas trabajadas: ");
        float hoursWorked = int.Parse(Console.ReadLine() ?? "");
        Console.Write("Introduce el pago por hora: ");
        float hourlyPayment = int.Parse(Console.ReadLine() ?? "");

        float salary;

        if (hoursWorked > minimunHourWithoutExtra)
        {
            float extraHours = hoursWorked - minimunHourWithoutExtra;
            float extraHoursPrice = (hourlyPayment / 2) + hourlyPayment;
            float extrahourlyPayment = extraHours * extraHoursPrice;

            salary = (minimunHourWithoutExtra * hourlyPayment) + extrahourlyPayment;
        }
        else
        {
            salary = hoursWorked * hourlyPayment;
        }

        Console.WriteLine($"El salario semanal es: {salary.ToString("F2")} ?");
    }

    public static void CalculaPromedioYDeterminaAprobacion()
    {
        Console.WriteLine("\nEjercicio 4: Promedio de calificaciones ");
        // TODO: Implementa la lógica de este método

        Console.Write("Introduce la primera calificación: ");
        float firstNote = float.Parse(Console.ReadLine() ?? "0");

        Console.Write("Introduce la sergunda calificación: ");
        float seondNote = float.Parse(Console.ReadLine() ?? "0");

        Console.Write("Introduce la tercera calificación: ");
        float thirdNote = float.Parse(Console.ReadLine() ?? "0");

        float average = (firstNote * seondNote + thirdNote) / 3;
        Console.WriteLine(average);
        string studentStatus = average > 5 ? "Aprobado" : "Suspendido";

        Console.WriteLine($"El promedio es {average}. Resultado: {studentStatus}");
    }

    public static void RealizaCalculadoraBasica()
    {
        Console.WriteLine("\nEjercicio 5: Calculadora básica ");
        // TODO: Implementa la lógica de este método

        Console.Write("Ingrese el primer número: ");
        float firstNumber = float.Parse(Console.ReadLine() ?? "0");

        Console.Write("Ingrese el segundo número: ");
        float secondNumber = float.Parse(Console.ReadLine() ?? "0");

        Console.Write("Ingrese un operador (+, -, *, /): ");
        char signOperator = char.Parse(Console.ReadLine() ?? "");

        switch (signOperator)
        {
            case '+':
                Console.Write($"Resultado: {firstNumber + secondNumber}");
                break;

            case '-':
                Console.Write($"Resultado: {firstNumber - secondNumber}");
                break;

            case '/' when secondNumber == 0:
                Console.Write("Error: División entre cero.");
                break;

            case '/':
                Console.Write($"Resultado: {firstNumber / secondNumber}");
                break;


            case '*':
                Console.Write($"Resultado: {firstNumber * secondNumber}");
                break;

            default:
                Console.Write("Operador no válido.");
                break;
        }
    }

    public static void ComparaNumeros()
    {
        Console.WriteLine("\nEjercicio 6: Comparación de números ");
        // TODO: Implementa la lógica de este método
        Console.Write("Ingrese el primer número: ");
        float firstNumber = float.Parse(Console.ReadLine() ?? "0");

        Console.Write("Ingrese el segundo número: ");
        float secondNumber = float.Parse(Console.ReadLine() ?? "0");

        if (firstNumber < secondNumber)
            Console.WriteLine($"{firstNumber} es menor que {secondNumber}.");

        else if (firstNumber > secondNumber)
            Console.WriteLine($"{firstNumber} es mayor que {secondNumber}.");
        else
            Console.WriteLine("Los números son iguales.");
    }

    public static void AdivinaElNumero()
    {
        Console.WriteLine("\nEjercicio 7: Adivina el número");
        // TODO: Implementa la lógica de este método

        int randomNumber = new Random().Next(1, 101);

        Console.Write("Adivina el número entre 1 y 100.");
        Console.Write("Ingresa tu número: ");

        int inputNumber = int.Parse(Console.ReadLine() ?? "0");


        if (randomNumber > inputNumber)
            Console.WriteLine("El número es mayor.");

        else if (randomNumber < inputNumber)
            Console.WriteLine("El número es menor.");

        else
            Console.WriteLine("Has adivinado el número.");
    }

    public static void VerificaContrasena()
    {
        Console.WriteLine("\nEjercicio 8: Verificación de contraseña ");
        // TODO: Implementa la lógica de este método
        const string PASSWORD = "12345";

        Console.Write("Ingrese la contraseña: ");
        string input = Console.ReadLine() ?? "";

        if (PASSWORD == input) Console.WriteLine("Contraseña correcta.");
        else Console.WriteLine("Contraseña incorrecta.");
    }

    public static void CalculaCosteVacaciones()
    {
        Console.WriteLine("\nEjercicio 9: Coste de vacaciones ");
        // TODO: Implementa la lógica de este método

        // const costVacation = (A: 250, B: 150);

        Console.Write("Introduce el tipo de vacaciones (A o B): ");
        char inputTypeVacation = char.Parse(Console.ReadLine()?.ToUpper() ?? "");

        // Console.WriteLine(inputTypeVacation, 'A' );

        Console.Write("Introduce el número de días: ");
        float inputDays = float.Parse(Console.ReadLine() ?? "");

        int costVacation = inputTypeVacation == 'A' ? 250 : 150;

        float total = costVacation * inputDays + 50;


        if (inputTypeVacation != 'A' && inputTypeVacation != 'B') Console.WriteLine("Tipo de vacaciones incorrecto");
        else Console.WriteLine($"Total a pagar: {total.ToString("F2")}");
    }

    public static void MuestraInstruccionSemaforo()
    {
        Console.WriteLine("\nEjercicio 10: Semáforo textual ");
        // TODO: Implementa la lógica de este método

        Console.Write("Escriba un color del semáforo (rojo, amarillo, verde): ");
        string inputColor = Console.ReadLine()?.ToLower() ?? "";

        switch (inputColor)
        {
            case "rojo":
                Console.WriteLine("Detente");
                break;

            case "amarillo":
                Console.WriteLine("Precaución");
                break;

            case "verde":
                Console.WriteLine("Avanza");
                break;
            default:
                Console.WriteLine("Color no válido");
                break;
        }

    }

    public static void ClasificaPorEdad()
    {
        Console.WriteLine("\nEjercicio 11: Clasificador de edad ");
        // TODO: Implementa la lógica de este método


        Console.Write("Ingrese su edad: ");
        int yearsOld = int.Parse(Console.ReadLine() ?? "0");

        string ageGroup = yearsOld switch
        {
            >= 0 and < 13 => "Niñez",
            >= 13 and < 20 => "Adolescencia",
            >= 20 and < 65 => "Adultez",
            >= 65 => "Vejez",
            _ => "Edad inválida",
        };

        Console.WriteLine($"Se encuentra en el grupo etario: {ageGroup}");
    }

    public static void CalculaNotaFinal()
    {
        Console.WriteLine("\nEjercicio 12: Calculo de notas ");
        // TODO: Implementa la lógica de este método

        Console.Write("Introduce la nota del examen (4, 7, 10): ");
        float examNote = float.Parse(Console.ReadLine() ?? "0");

        Console.Write("Introduce la nota del prácticas (4, 7, 10): ");
        float practiceNote = float.Parse(Console.ReadLine() ?? "0");

        float finalNote = (examNote, practiceNote) switch
        {
            (4, _) => 4,
            (7, >= 7) => (examNote + practiceNote) / 2,
            (7, 4) => 5,
            (10, <= 7) => 9,
            (10, <= 10) => 11,
            _ => 0
        };

        if (finalNote == 0)
            Console.WriteLine("Nota incorrecta");
        else
            Console.WriteLine($"La nota final es: {finalNote}");
    }

    public static void ClasificaTriangulo()
    {
        Console.WriteLine("\nEjercicio 13: Clasificación de triángulos ");
        // TODO: Implementa la lógica de este método

        Console.Write("Ingrese la longitud del primer lado: ");
        float triangleSide1 = float.Parse(Console.ReadLine() ?? "0");

        Console.Write("Ingrese la longitud del segundo lado: ");
        float triangleSide2 = float.Parse(Console.ReadLine() ?? "0");

        Console.Write("Ingrese la longitud del tercer lado: ");
        float triangleSide3 = float.Parse(Console.ReadLine() ?? "0");



        string triangleType = (triangleSide1, triangleSide2, triangleSide3) switch
        {
            (_, <= 0, _) or (_, _, <= 0) or ( <= 0, _, _) => "No tiene Lados",
            _ when triangleSide1 == triangleSide2 && triangleSide2 == triangleSide3 => "equilátero",
            _ when triangleSide1 == triangleSide2 || triangleSide2 == triangleSide3 || triangleSide3 == triangleSide1 => "isósceles",
            _ => "escaleno",
        };

        Console.WriteLine($"El triángulo es {triangleType}.");

    }

    public static void Main(string[] args)
    {
        DeterminaSiEsParOImpar();
        ConvierteTemperatura();
        CalculaSalarioSemanal();
        CalculaPromedioYDeterminaAprobacion();
        RealizaCalculadoraBasica();
        ComparaNumeros();
        AdivinaElNumero();
        VerificaContrasena();
        CalculaCosteVacaciones();
        MuestraInstruccionSemaforo();
        ClasificaPorEdad();
        CalculaNotaFinal();
        ClasificaTriangulo();

        Console.WriteLine("\nPresiona cualquier tecla para salir...");
        Console.ReadLine();

    }
}


