internal class Program
{

    static int GeneradorAleatorio(int min, int max) => new Random().Next(min, max + 1);

    static string InputUser(string message)
    {
        Console.Write(message);
        return Console.ReadLine() ?? "";
    }

    static (string tipoCasa, int dulce) GeneraTipoCasa()
    {


        int tipo = GeneradorAleatorio(1, 3);
        int dulces;

        switch (tipo)
        {
            case 1:
                dulces = GeneradorAleatorio(3, 7);
                return ("Tenebrosa", dulces);
            case 2:
                dulces = GeneradorAleatorio(1, 15);
                return ("Misteriosa", dulces);
            case 3:
                dulces = GeneradorAleatorio(10, 20);
                return ("Encantada", dulces);

            default: return ("", 0);
        }


    }


    static (int nivelEnergiaActual, int dulcesRecogidos) VisitaCasa(int nivelEnergia)
    {
        int dulcesRecogidos = 0;
        int nivelEnergiaActual = nivelEnergia;


        var (tipoCasa, dulces) = GeneraTipoCasa();


        if (tipoCasa == "Tenebrosa") dulcesRecogidos += dulces;

        else if (tipoCasa == "Encantada")
        {
            if (GeneradorAleatorio(1, 100) == 30) dulcesRecogidos += dulces;
        }

        else
        {
            nivelEnergiaActual -= 1;
            dulcesRecogidos += dulces;
        }

        nivelEnergiaActual -= 1;

        Console.WriteLine(
            $"\nVas a tocar a la puerta de una casa [{tipoCasa}]\n" +
            $"- Has recibido {dulcesRecogidos} dulces en esta casa. Te quedan {nivelEnergiaActual} de energía."
        );


        return (nivelEnergiaActual, dulcesRecogidos);
    }

    static int InicioVisitas(string nombre, int nivelEnergia)
    {

        int cantidadAVisitar = GeneradorAleatorio(5, 7);
        int totalDulces = 0;
        int nivelEnergiaAqui = nivelEnergia;

        Console.WriteLine($"\nHola {nombre} vas a comenzar la visita por este barrio que tiene {cantidadAVisitar}");

        while (cantidadAVisitar != 0 && nivelEnergiaAqui > 0)
        {
            var (nivelEnergiaActual, dulcesRecogidos) = VisitaCasa(nivelEnergia);

            nivelEnergiaAqui = nivelEnergiaActual;

            nivelEnergia -= 1;
            cantidadAVisitar--;
            totalDulces += dulcesRecogidos;
        }

        return totalDulces;

    }

    static string MuestraClasificacion(int totalDulces)
    {
        return totalDulces switch
        {
            > 60 => "¡Halloween Épico!",
            >= 30 => "!Buena Recolección¡",
            >= 11 => "Noche Decente",
            _ => "¡Mejor suerte el próximo año!"
        };
    }




    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        const int TOTAL_NIÑOS = 4;

        string nombre;
        string ganador = "";
        int dulcesGanador = 0;

        for (int jugador = 1; jugador <= TOTAL_NIÑOS; jugador++)
        {
            nombre = InputUser("Introduce nombre del niñ@: ");
            int nivelEnergia;
            bool nivelEnergiaValido;

            do
            {
                nivelEnergiaValido = int.TryParse(InputUser("Introduce nivel de energia del niñ@ (5-20): "), out nivelEnergia);

                if (!nivelEnergiaValido)
                {
                    Console.WriteLine("Error: Debes introducir un número válido.\n");
                }
                else if (nivelEnergia < 5 || nivelEnergia > 20)
                {
                    Console.WriteLine("Nivel fuera de rango: el valor debe estar entre 5 y 20.\n");
                }

            } while (!nivelEnergiaValido || nivelEnergia < 5 || nivelEnergia > 20);


            int totalDulces = InicioVisitas(nombre: nombre, nivelEnergia: nivelEnergia);
            string clasificacion = MuestraClasificacion(totalDulces);

            Console.WriteLine($"\nEl niñ@ {nombre} ha recibido {totalDulces} dulces, durante la visita al barrios\n {clasificacion}");

            if (totalDulces > dulcesGanador)
            {
                ganador = nombre;
                dulcesGanador = totalDulces;
            }

        }


        Console.WriteLine($"\n\"Despues de esta noche terrorífica\" \n Del grupo de amigos que ha recorrido el barrio\nEl ganador es {ganador} con {dulcesGanador} dulces recolectados");


        Console.ReadLine();
    }
}