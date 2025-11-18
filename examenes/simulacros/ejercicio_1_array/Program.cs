class Program
{
    /* 
    Nebulosa de Nutrientes: Una nube de gas espacial rica en minerales.
    Tiene el código 1 en el menú y cuesta 15 créditos intergalácticos en todos los planetas.

    Estrella Enana a la Parrilla: Ideal para paladares que disfrutan de sabores intensos.
    Tiene el código 2 en el menú y cuesta 40 créditos intergalácticos en los planetas Ganimedes y Raticulin y
    30 créditos intergalácticos en el resto.

    Agujero Negro con Salsa de Singularidad: ¡No apto para estómagos sensibles!
    Tiene el código 3 en el menú y cuesta 45 créditos intergalácticos en el planeta Pandora, 50 en el planeta
    Acheron y 60 en el resto.
    */
    static string InputUser(string mensaje, string defaultValue = "")
    {
        Console.Write(mensaje);
        return Console.ReadLine() ?? defaultValue;
    }


    public static void Main(string[] args)
    {



        Console.WriteLine("\nPulsa cualquier tecla para salir");
        Console.ReadLine();
    }
}