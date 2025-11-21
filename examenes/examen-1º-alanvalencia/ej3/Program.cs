internal class Program
{
    /* 

       Jugador tira N dados 
       -- N == >= 2 <= 4

       C (caras dados) = >= 1 <=6


       Si
        primera-tirada = suma == tirada o tirada-base ?? jugador -> gana
        primera tirada = suma == crap1 | crap2 | crap3 ?? jugador -> pierde
       No 
           nueva-tirada = tirar-de-nuevo()
           nueva-tirada = suma == tirada o tirada-base ?? jugador -> gana
           nueva tirada = suma == crap1 | crap2 | crap3 ?? jugador -> pierde

       Si gana
           puntuacion = (carasdado * 100) / turnosGastados
       No 
           puntuacion = 0

       */

    const int NUMERO_TOTAL_CARAS = 6;
    enum EstadoJugador
    {
        Ganador,
        Perdedor,
        Jugando
    }


    public static string EntradaUsuario(string message)
    {
        Console.Write(message);

        return Console.ReadLine() ?? "";
    }

    public static int TiradaDado() => new Random().Next(NUMERO_TOTAL_CARAS + 1);

    public static int PuntosTirada(int numeroDados)
    {
        int puntos = 0;

        Console.WriteLine("Tiramos el Dado.....");
        for (int i = 0; i < numeroDados; i++)
        {
            puntos += TiradaDado();
        }

        return puntos;
    }

    public static (int craps1, int craps2, int craps3, int tiradaPaGanar, int tiradaBase) CalculaPuntosPartida(int numeroDados)
    {
        int craps1 = numeroDados;
        int craps2 = numeroDados + 1;
        int craps3 = numeroDados * NUMERO_TOTAL_CARAS;

        int tiradaBase = numeroDados * (NUMERO_TOTAL_CARAS / 2) + 1;
        int tirada = (numeroDados - 1) * NUMERO_TOTAL_CARAS + NUMERO_TOTAL_CARAS - 1;

        return (craps1, craps2, craps3, tirada, tiradaBase);
    }


    public static void MuestraEstadoJuego(int puntos, int tirada)
    {
        Console.WriteLine("Los punto obtenidos son {0} en turno {1}", puntos, tirada);
    }



    public static (int puntos, bool haGanado) JugadaJugador(int numeroDados)
    {
        int tirada = 1;
        var datos = CalculaPuntosPartida(numeroDados);
        EstadoJugador jugador;
        do
        {
            int dadosPuntos = PuntosTirada(numeroDados);

            if (tirada == 1)
            {
                if (dadosPuntos == datos.tiradaPaGanar || dadosPuntos == datos.tiradaBase) jugador = EstadoJugador.Ganador;

                else if (dadosPuntos == datos.craps1 || dadosPuntos == datos.craps2 || dadosPuntos == datos.craps3) jugador = EstadoJugador.Perdedor;

                else jugador = EstadoJugador.Jugando;
            }
            else
            {
                if (dadosPuntos == datos.tiradaPaGanar) jugador = EstadoJugador.Ganador;

                else if (dadosPuntos == datos.tiradaBase) jugador = EstadoJugador.Perdedor;

                else jugador = EstadoJugador.Jugando;
            }

            MuestraEstadoJuego(dadosPuntos, tirada);
            tirada++;
        }
        while (jugador == EstadoJugador.Jugando);

        int puntos = jugador == EstadoJugador.Perdedor ? 0 : (NUMERO_TOTAL_CARAS * 100) / tirada;

        return (puntos, jugador == EstadoJugador.Ganador);

    }

    public static void InformaPuntosPartida(int numeroDados)
    {
        (int craps1, int craps2, int craps3, int tirada, int tiradaBase) datos = CalculaPuntosPartida(numeroDados);


        Console.WriteLine("\nEsta partida se juega con {0} dados y con {1} caras cada dado\nLas puntuaciones para que ocurra CRAPS son {2} - {3} - {4}\nLas puntuacion base es {5} y la tirada que gana en inicio es {6}\n",
        numeroDados,
        NUMERO_TOTAL_CARAS,
        datos.craps1,
        datos.craps2,
        datos.craps3,
        datos.tiradaBase,
        datos.tirada);
    }

    public static void MuestraPuntuacionFinal(int puntos, bool ganador)
    {
        Console.WriteLine("\nHas {0}\nLos puntos obtenidos son {1}", ganador ? "ganado" : "perdido", puntos);
    }

    private static void Main(string[] args)
    {
        bool numeroValido;
        int numeroDados;
        do
        {
            numeroValido = int.TryParse(EntradaUsuario("Introduce un numero de dados a usar entre 2 y 4: "), out numeroDados);
            if (!numeroValido || numeroDados > 4 || numeroDados < 2) Console.Write("Numero invalido.");

        } while (!numeroValido || numeroDados > 4 || numeroDados < 2);

        InformaPuntosPartida(numeroDados);

        (int puntos, bool haGanado) = JugadaJugador(numeroDados);

        MuestraPuntuacionFinal(puntos, haGanado);

        Console.ReadLine();
    }
}





































































































































































































































































































// init: XC-MA