using System;

public class Program
{
    static string InputUser(string message)
    {
        Console.Write(message);
        return Console.ReadLine() ?? "";
    }

    public static int NumeroAAdivinar()
    {
        return new Random().Next(0, 101);
    }


    public static bool Pista(int aAdivinar)
    {
        int numeroIntroducido = int.Parse(InputUser("Introduce tu número: "));

        if (numeroIntroducido > aAdivinar) Console.WriteLine("El número es menor");
        else if (numeroIntroducido < aAdivinar) Console.WriteLine("El número es mayor");
        else Console.WriteLine("¡Felicidades! Has adivinado el número.");


        return numeroIntroducido == aAdivinar;
    }

    public static int Nivel()
    {
        int level;

        do
        {
            level = int.Parse(InputUser("--- SELECCIONA EL NIVEL ---\n1. Fácil (10 tentativas)\n2. Medio (6 tentativas)\n3. Difícil (4 tentativas)\nElige una opción (1-3): "));


            if (level > 3 || level < 1) Console.WriteLine("Opción no válida. Inténtalo de nuevo.\n");

        } while (level > 3 || level < 1);

        int tentativas = level switch
        {
            1 => 10,
            2 => 6,
            3 => 4,
            _ => 0
        };

        return tentativas;
    }

    public static void Juego()
    {
        int tentativas = Nivel();
        int aAdivinar = NumeroAAdivinar();
        bool hasAdivinado = false;
        int intentos = 1;

        Console.WriteLine("¡Adivina el número entre 0 y 100!\nTienes {0} tentativas.", tentativas);

        do
        {
            Console.WriteLine("\nTentativa {0} de {1}:", intentos, tentativas);
            hasAdivinado = Pista(aAdivinar);

            if (hasAdivinado) Console.WriteLine("¡Excelente! Has adivinado el número en {0} tentativas.", intentos);
            else Console.WriteLine("Te quedan {0} tentativas.", intentos);

            Console.WriteLine("");

            intentos++;

        } while (intentos <= tentativas && !hasAdivinado);

    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Ejercicio 2: Juego de Adivinanza");
        //TODO: Implementa el código necesaro
        bool seguirJugando = true;

        while (seguirJugando)
        {
            bool opcionValida = false;
            string userOption;


            Juego();


            do
            {
                userOption = InputUser("¿Quieres seguir jugando? (S/N): ").Trim();
                if (userOption.Equals("S", StringComparison.OrdinalIgnoreCase))
                {
                    opcionValida = true;
                }
                else if (userOption.Equals("N", StringComparison.OrdinalIgnoreCase))
                {
                    opcionValida = true;
                    seguirJugando = false;
                }
                else
                {
                    Console.WriteLine("Respuesta no válida. Por favor, responde S o N.\n");
                }

            } while (!opcionValida);
        }

        Console.WriteLine("¡Gracias por jugar!");
        Console.WriteLine("Presiona cualquier tecla para salir...");
        Console.ReadKey();
    }
}