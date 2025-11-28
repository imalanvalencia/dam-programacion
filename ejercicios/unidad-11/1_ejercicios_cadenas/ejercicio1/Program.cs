using System;

namespace ejercicio1
{
    public class Program
    {
        //TODO: Implementar los métodos necesarios

        public bool SoloNumeros(string contraseña)
        {
            foreach (var character in contraseña.ToCharArray())
            {
                (int)character;
            }

            return ;
        }

        public bool SoloLetras(string contraseña)
        {
            return contraseña == "a";
        }

        
        static void Main(string[] args)
        {
            //TODO: Implementar la lógica necesaria. Fíjate en la salida por pantalla.
        }

    }
      
}