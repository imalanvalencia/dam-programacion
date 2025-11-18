using System;

public class Program
{
    static string InputUser(string message)
    {
        Console.Write(message);
        return Console.ReadLine() ?? "";
    }

    public static void PresentaJuego()
    {
        Console.WriteLine("Reglas del juego:\n* Cada participante tira 3 veces un dado (valores 1-100)\n* Se suman las puntuaciones según estas reglas:\n* Múltiplo de 3 o 5: +10 pts\n* Múltiplo de 4 o 6: +5 pts\n* Mayor de 80: +2 pts\n* Mayor de 50: +1 pts\n* Menor de 50: -2 pts\n* Menor de 20: -1 pts\n* Gana quien obtenga mayor puntuación total\n");
    }

    public static int PideNumeroParticipantes()
    {
        int numeroParticipantes;
        bool entradaUsuarioCorrecto;


        do
        {
            entradaUsuarioCorrecto =int.TryParse(InputUser("Introduce el número de participantes: "), out numeroParticipantes);

            if(numeroParticipantes <= 1) Console.Write("número válido mayor que 0");
            
        } while (!entradaUsuarioCorrecto ||  numeroParticipantes <= 1);

        return numeroParticipantes;
    }

    public static int TiraDado() => new Random().Next(1, 101);

    public static int CalculaPuntos(int valorDado)
    {
        int puntos = 0;

        // Reglas de múltiplos
        if (valorDado % 3 == 0 || valorDado % 5 == 0)
            puntos += 10;

        if (valorDado % 4 == 0 || valorDado % 6 == 0)
            puntos += 5;


        // Reglas de rango
        if (valorDado > 80)
            puntos += 2;

        if (valorDado > 50)
            puntos += 1;

        if (valorDado < 50)
            puntos -= 2;

        if (valorDado < 20)
            puntos -= 1;

        return puntos;
    }

    public static int JuegoParticipante(int numeroParticipante)
    {

        Console.WriteLine($"\n--- PARTICIPANTE {numeroParticipante} ---");
        
        int puntuacionTotal = 0;

        for (int tiradas = 1; tiradas <= 3; ++tiradas)
        {
            int dado = TiraDado();
            int puntos = CalculaPuntos(dado);
            puntuacionTotal += puntos;


            Console.Write($"\nTirada {tiradas}: Dado = {dado}, Puntos = {(puntos >= 0 ? "+" : "")}{puntos}");

        }

        Console.WriteLine($"\nPuntuación total del participante {numeroParticipante}: {puntuacionTotal}");
        
        return puntuacionTotal;

    }

    public static void MuestraGanador(int ganador, int puntos)
    {
        Console.WriteLine("=== RESULTADO FINAL ===\n¡El ganador es el PARTICIPANTE {0} con {1} puntos!", ganador, puntos);
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Ejercicio 3: Proyecto juego");
        //TODO: Implementa el código necesario

        PresentaJuego();

        int numeroParticipantes = PideNumeroParticipantes();
        int puntuacionMaxima = int.MinValue;
        int participanteGana = 0;

        for (int numeroParticipante = 1; numeroParticipante <= numeroParticipantes; ++numeroParticipante)
        {
            int puntuacionTotal = JuegoParticipante(numeroParticipante);

            if (puntuacionTotal > puntuacionMaxima)
            {
                puntuacionMaxima = puntuacionTotal;
                participanteGana = numeroParticipante;
            }
        }

        MuestraGanador(participanteGana, puntuacionMaxima);

        Console.WriteLine(CalculaPuntos(45));

        Console.WriteLine("\nPresiona cualquier tecla para salir...");
        Console.ReadKey();
    }
}