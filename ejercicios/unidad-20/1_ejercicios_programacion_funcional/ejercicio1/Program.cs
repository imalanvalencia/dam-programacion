namespace Ejercicio1
{
    ///TODO: crea el código necesario para completar las especificaciones
    
    public delegate int Operacion(int n);
    public static class Calculos
    {
        public static int Cuadrado(int n)
        {
            return n * n;
        }

        public static int Cubo(int n)
        {
            return n * n * n;
        }
    }

    public class Program
    {
        static Operacion? operacion;
        
        public static string TextoMenu()
        {
            return
                "[1] Cuadrado\n" +
                "[2] Cubo\n" +
                "[3] Cambiar número\n" +
                "[4] Salir";
        }

        public static int LeeNumero()
        {
            int n;

            Console.Write("Selecciona número entero: ");
            if (!int.TryParse(Console.ReadLine(), out n))
            {
                Console.WriteLine("Valor incorrecto, se ajustó a 0");
                n = 0;
            }
            return n;
        }

        static void Main()
        {
            ConsoleKeyInfo key;
            bool salir = false;
            Console.WriteLine("Ejercicio 1. Delegado Operación\n");
   
            int n = LeeNumero();

            do
            {
               
                Console.WriteLine(TextoMenu());
                Console.Write("Selecciona una opción: ");
                key = Console.ReadKey(true);
                switch (key.KeyChar)
                {
                    case '1':
                        operacion = Calculos.Cuadrado;
                      
                        break;
                    case '2':
                        operacion = Calculos.Cubo;
                     
                        break;
                    case '3':
                        n = LeeNumero();
                        break;
                    case '4':
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Selección inválida !!!");
                        break;
                }

                if (!salir && operacion != null)
                {
                    Console.Clear();
                    Console.WriteLine($"Resultado: {operacion(n)}");
                }
              
                Console.ReadKey(true);
            } while (!salir);
        }
    }
}
