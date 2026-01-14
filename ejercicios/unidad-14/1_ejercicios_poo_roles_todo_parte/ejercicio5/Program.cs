
using System;
using System.Collections.Generic;
using System.Text;

//TODO: Implementa las clases necesarias y la relación entre ellas para resolver el ejercicio
public class Program
    {
        public static void GestionRefugio()
        {
            Console.WriteLine("Ejercicio 5: Sistema de refugio con agregación múltiple\n");
            Console.WriteLine("Creando refugio...");
            Refugio refugio = new Refugio("Hogar Feliz");
            Console.WriteLine($"Refugio creado: {refugio.Nombre}\n");

            Console.WriteLine("Registrando cuidadores en el refugio...");
            Cuidador ana = new Cuidador("11111111A", "Ana López", 5, "Veterinaria");
            refugio.AñadeCuidador(ana);
            Console.WriteLine("Cuidador añadido: Ana López (Veterinaria) - Máximo 5 mascotas");
            Cuidador carlos = new Cuidador("22222222B", "Carlos Ruiz", 3, "Entrenador");
            refugio.AñadeCuidador(carlos);
            Console.WriteLine("Cuidador añadido: Carlos Ruiz (Entrenador) - Máximo 3 mascotas");
            Cuidador maria = new Cuidador("33333333C", "María Pérez", 2, "Voluntaria");
            refugio.AñadeCuidador(maria);
            Console.WriteLine("Cuidador añadido: María Pérez (Voluntaria) - Máximo 2 mascotas");

            Console.WriteLine("\nRegistrando animales en el refugio...");
            Animal max = new Animal("Max", "Perro", 3);
            refugio.AñadeAnimal(max);
            Console.WriteLine("Animal añadido: Max (Perro) - Edad: 3 años");
            Animal luna = new Animal("Luna", "Gato", 2);
            refugio.AñadeAnimal(luna);
            Console.WriteLine("Animal añadido: Luna (Gato) - Edad: 2 años");

            Console.WriteLine("\nRealizando asignaciones de cuidadores...");
            Console.WriteLine("Asignando Max a Ana López...");
            Console.WriteLine("  - Verificando disponibilidad de Ana López... " + (ana.NumeroMascotasAsignadas < ana.NumeroMaximoMascotas ? "Disponible" : "No disponible"));
            refugio.AsignaAnimalACuidador(max, ana);
            Console.WriteLine("  - Max ha sido asignado correctamente");

            Console.WriteLine("Asignando Max a Carlos Ruiz...");
            Console.WriteLine("  - Verificando disponibilidad de Carlos Ruiz... " + (carlos.NumeroMascotasAsignadas < carlos.NumeroMaximoMascotas ? "Disponible" : "No disponible"));
            refugio.AsignaAnimalACuidador(max, carlos);
            Console.WriteLine("  - Max ha sido asignado correctamente");

            Console.WriteLine("Asignando Luna a Ana López...");
            Console.WriteLine("  - Verificando disponibilidad de Ana López... " + (ana.NumeroMascotasAsignadas < ana.NumeroMaximoMascotas ? "Disponible" : "No disponible"));
            refugio.AsignaAnimalACuidador(luna, ana);
            Console.WriteLine("  - Luna ha sido asignado correctamente");

            Console.WriteLine("Asignando Luna a María Pérez...");
            Console.WriteLine("  - Verificando disponibilidad de María Pérez... " + (maria.NumeroMascotasAsignadas < maria.NumeroMaximoMascotas ? "Disponible" : "No disponible"));
            refugio.AsignaAnimalACuidador(luna, maria);
            Console.WriteLine("  - Luna ha sido asignado correctamente");

            Console.WriteLine("\nEstado actual del refugio:");
            Console.WriteLine(refugio.ACadena());

            Console.WriteLine("\nPresiona cualquier tecla para salir...");
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            GestionRefugio();
        }
    }
