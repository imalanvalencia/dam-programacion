using System;

namespace ejercicio1
{
    public class Program
    {
        //TODO: Implementar los métodos necesarios



        public static bool SoloNumeros(string contraseña) => int.TryParse(contraseña, out _);

        public static bool SoloLetras(string contraseña)
        {
            foreach (var character in contraseña)
            {
                if (!(character is >= 'A' and <= 'Z' or >= 'a' and <= 'z')) return false;
            }
            return true;
        }

        // CREA METODOS ContieneLetras, ContieneNumeros y ContieneEspeciales 
        public static bool ContieneLetras(string contraseña)
        {
            foreach (var character in contraseña)
            {
                if (character is >= 'A' and <= 'Z' or >= 'a' and <= 'z') return true;
            }
            return false;
        }


        public static bool ContieneNumeros(string contraseña)
        {
            foreach (var character in contraseña)
            {
                if (character is >= '0' and <= '9') return true;
            }
            return false;
        }
        public static bool ContieneEspeciales(string contraseña)
        {
            foreach (var character in contraseña)
            {
                if (!(character is >= 'A' and <= 'Z' or >= 'a' and <= 'z' or >= '0' and <= '9')) return true;
            }
            return false;
        }

        public static string NivelSeguridad(string contraseña) => contraseña switch
        {
            _ when SoloNumeros(contraseña) || contraseña.Length < 8 => "Muy débil",
            _ when ContieneLetras(contraseña) && ContieneNumeros(contraseña) && ContieneEspeciales(contraseña) => "Muy fuerte",
            _ when ContieneLetras(contraseña) && ContieneNumeros(contraseña) => "Fuerte",
            _ when SoloLetras(contraseña) => "Débil",
            _ => "Ultra fuerte?"
        };

        static void Main(string[] args)
        {
            //TODO: Implementar la lógica necesaria. Fíjate en la salida por pantalla.
            Console.Write("Introduce una contraseña: ");
            string contraseña = Console.ReadLine() ?? "";
            Console.WriteLine($"Nivel de seguridad: {NivelSeguridad(contraseña)}");

            Console.ReadLine();
        }

    }

}