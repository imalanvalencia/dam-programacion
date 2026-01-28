
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace Ejercicio4
{
    //TODO: Implementa las clases necesarias para cumplimentar el ejercicio4

    public class Herramienta
    {
        Guid Id = new();
        public string Nombre { get; }
        public string Marca { get; }
        public double Peso { get; }
        public virtual double Precio { get; }

        public Herramienta(string nombre, string marca, double peso, double precioBase)
        {
            Nombre = nombre;
            Marca = marca;
            Peso = peso;
            Precio = precioBase;
        }

        public virtual string Usa() => "Depende de la herramienta.";
        public virtual string ACadena() => $"{Nombre}, Marca: {Marca}, Peso: {Peso:0.#}, Precio: {Precio:0.##}";

    }

    public class Taladro : Herramienta
    {
        public int Potencia { get; }
        public int VelocidadMaxima { get; }

        public Taladro(string nombre, string marca, double peso, double precioBase, int potencia, int velocidadMaxima) : base(nombre, marca, peso, precioBase)
        {
            Potencia = potencia;
            VelocidadMaxima = velocidadMaxima;
        }


        public override double Precio => base.Precio - base.Precio * .15;

        public override string Usa() => "Perfora materiales duros a alta velocidad.";

        public override string ACadena() => base.ACadena() + $", Potencia: {Potencia}, Velocidad Máxima: {VelocidadMaxima}";

        public string Perfora(int diametroMm, int profundidadMm) => $"Perforar {diametroMm}mm diámetro, {profundidadMm}mm profundidad OK";
    }

    public class SierraElectrica : Herramienta
    {
        public int PotenciaW { get; }
        public int DiametroHojaMm { get; }

        public SierraElectrica(string nombre, string marca, double peso, double precioBase, int potencia, int diametroHojaMm) : base(nombre, marca, peso, precioBase)
        {
            PotenciaW = potencia;
            DiametroHojaMm = diametroHojaMm;
        }


        public override double Precio => PotenciaW > 1300 ? base.Precio * 1.10 : base.Precio;

        public override string Usa() => "Realiza cortes rectos en madera y tableros.";

        public override string ACadena() => base.ACadena() + $", Potencia: {PotenciaW}, Hoja: {DiametroHojaMm}mm";

        public string Corta(string material, string grosorMm) => $"Cortar(\"{material}\", {grosorMm}) OK";
    }

    public class Lijadora : Herramienta
    {
        public int Rpm { get; }
        public int DiametroDiscoMm { get; }

        public Lijadora(string nombre, string marca, double peso, double precioBase, int rpm, int diametroDiscoMm) : base(nombre, marca, peso, precioBase)
        {
            Rpm = rpm;
            DiametroDiscoMm = diametroDiscoMm;
        }


        public override double Precio => Rpm < 10000 ? base.Precio - base.Precio * .10 : base.Precio;

        public override string Usa() => "Lija y suaviza superficies de madera.";

        public override string ACadena() => base.ACadena() + $", RPM: {Rpm}, Disco: {DiametroDiscoMm}mm";

        public double Pule(double superficieM2) => Math.Round(superficieM2 * 60 / (Rpm * 0.012), 2);
    }


    public class Program
    {
        //TODO: Crea el método GestionHerramientasPolimorfismo

        public static void GestionHerramientasPolimorfismo()
        {
            Console.WriteLine("Creando inventario...");

            Herramienta martillo = new Herramienta("Martillo", "Stanley", .5, 25);
            Taladro taladro = new("Taladro Percutor", "Bosch", 2.3, 105, 750, 3000);
            SierraElectrica sierraCircular = new("Sierra Circular", "Makita", 4.1, 120, 1400, 185);
            Lijadora lijadoraOrbital = new("Lijadora Orbital", "Dewalt", 1.8, 54, 9000, 125);

            Console.WriteLine(
            $"""
            Creando herramientas ....

            {martillo.ACadena()}
            {taladro.ACadena()}
            {sierraCircular.ACadena()}
            {lijadoraOrbital.ACadena()}

            Mostrando usos...
            {martillo.Usa()}
            {taladro.Usa()}
            {sierraCircular.Usa()}
            {lijadoraOrbital.Usa()}

            Accediendo a métodos específicos:

            
            Taladro Percutor => {taladro.Perfora(8, 60)}
            Sierra Circular => {sierraCircular.Corta("Madera", "18mm")}
            Lijadora Orbital => Pulir(2.5 m2) tarda {lijadoraOrbital.Pule(2.5)}fs
            """);
        }

        static void Main(string[] args)
        {
            GestionHerramientasPolimorfismo();
            Console.WriteLine("\nPresiona cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
