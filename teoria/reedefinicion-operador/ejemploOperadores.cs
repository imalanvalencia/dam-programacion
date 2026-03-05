using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;


class Hijo : Persona
{
    Persona madre, padre;
    public Hijo(string nombre, int edad, Persona madre, Persona padre) : base(nombre, edad)
    {
        this.madre = madre;
        this.padre = padre;
    }
   

}

class Persona
{
    string nombre;
    int edad;
    List<Hijo> hijos;
    public Persona(string nombre, int edad)
    {
        this.nombre = nombre;
        this.edad = edad;
        hijos = new List<Hijo>();
    }
     public Persona(Persona p)
    {
        this.nombre = p.nombre;
        this.edad = p.edad;
        hijos = new List<Hijo>(p.hijos);
    }
    public override bool Equals(object? obj)
    {
        return obj is Persona p && p.edad == this.edad && p.nombre == this.nombre;
    }
    public static bool operator ==(Persona p1, Persona p2)
    {
        return p1.Equals(p2);
    }
    public static bool operator !=(Persona p1, Persona p2)
    {
        return !p1.Equals(p2);
    }
    

    public static Persona operator +(Persona p, Hijo h)
    {
        Persona persona = new (p);
        persona.hijos.Add(h);
        return persona;
    }
    public static Persona operator --(Persona p)
    {
        Persona persona = new (p);
        persona.hijos.RemoveAt(p.hijos.Count-1);
        return persona;
    }

    public static explicit operator int (Persona h)
    {
        return h.edad;
    }
  
}
class Program
{

    public static void Main()
    {
        Persona pepe = new Persona("Pepe", 15);
        Hijo maroa = new Hijo("Pepe", 15, pepe, pepe);
        pepe = pepe + maroa;
        
        pepe = --pepe;
        int edad = (int)pepe;

        if (pepe.Equals(maroa))




            Console.WriteLine("Presione una tecla para finalizar...");
        Console.ReadKey();
    }
}
