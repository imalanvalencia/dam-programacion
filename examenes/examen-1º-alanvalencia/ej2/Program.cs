internal class Program
{
    enum Casillas { Nada, Mina, Regalo, Vida };
    static Casillas[][] GeneraIslaVacia(int filas, int maximoColumnas)
    {
        Casillas[][] isla = new Casillas[filas][];
        Random generador = new();

        for (int i = 0; i < isla.Length; i++)
        {
            int aleatorio = generador.Next(1, maximoColumnas + 1);

            isla[i] = new Casillas[aleatorio];
        }

        return isla;
    }


    static void MuestraIsla(Casillas[][] isla)
    {
        foreach (var columna in isla)
        {
            foreach (var casilla in columna)
            {
                string casillaMostrar = casilla switch
                {
                    Casillas.Mina => "X",
                    Casillas.Regalo => "R",
                    Casillas.Vida => "V"
                };
                
                Console.Write("[" + casillaMostrar + "]");
            }

            Console.WriteLine();
        }
    }


    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}






































































































































































































































































































// init: XC-MA