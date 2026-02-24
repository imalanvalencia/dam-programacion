using System.Text;
using System.Collections.Generic;

public enum TipoIngrediente
{
    Proteina,
    Carbohidrato,
    Grasa,
    Vegetal,
    Fruta,
    Especia,
    Liquido
}

public record Ingrediente(string Nombre, string Unidad, TipoIngrediente Tipo, double CaloriasPorGramo)
{
    public override string ToString() => Nombre;
}

public record IngredienteReceta(string Nombre, string Unidad, TipoIngrediente Tipo, double CaloriasPorGramo, int CantidadUsada, double CaloriasTotales);

public static class IngredienteExtension
{
    public static IngredienteReceta ToIngrediente(this Ingrediente ingrediente, int cantidadUsada)
    {
        double caloricasTotales = cantidadUsada * ingrediente.CaloriasPorGramo;
        return new IngredienteReceta(
            ingrediente.Nombre,
            ingrediente.Unidad,
            ingrediente.Tipo,
            ingrediente.CaloriasPorGramo,
            cantidadUsada,
            caloricasTotales
        );
    }
}

public static class IngredienteRecetaExtension
{
    public static Ingrediente ToIngrediente(this IngredienteReceta receta)
    {
        return new Ingrediente(receta.Nombre, receta.Unidad, receta.Tipo, receta.CaloriasPorGramo);
    }
}

public class Receta
{
    public string Nombre { get; }
    public List<IngredienteReceta> Ingredientes { get; } = new List<IngredienteReceta>();

    public Receta(string nombre)
    {
        Nombre = nombre;
    }

    public void AgregaIngrediente(Ingrediente ingrediente, int cantidadUsada)
    {
        IngredienteReceta ir = ingrediente.ToIngrediente(cantidadUsada);
        Ingredientes.Add(ir);
    }

    public List<Ingrediente> ListaIngredientes()
    {
        return Ingredientes.Select(ir => ir.ToIngrediente()).ToList();
    }

    public double CaloriasTotales()
    {
        return Ingredientes.Sum(ir => ir.CaloriasTotales);
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Receta: {Nombre}");
        sb.AppendLine("Ingredientes:");
        foreach (var ing in Ingredientes)
        {
            sb.AppendLine($"    - {ing.CantidadUsada} {ing.Unidad} de {ing.Nombre} ({ing.CaloriasTotales:F2} calorías)");
        }
        sb.AppendLine($"Calorías totales: {CaloriasTotales():F2}");
        return sb.ToString();
    }
}

public class Program
{
    private static void Main(string[] args)
    {

        Console.WriteLine("Ejercicio 5: Recetas e ingredientes con métodos de extensión\n");
        var ing1 = new Ingrediente("Harina", "gramo", TipoIngrediente.Carbohidrato, 0.58);
        var ing2 = new Ingrediente("Azúcar", "gramo", TipoIngrediente.Carbohidrato, 0.98);
        var ing3 = new Ingrediente("Mantequilla", "gramo", TipoIngrediente.Grasa, 7.2);
        var ing4 = new Ingrediente("Huevo", "unidad", TipoIngrediente.Proteina, 1.5);

        var receta = new Receta("Bizcocho ejemplo");
        receta.AgregaIngrediente(ing1, 200);
        receta.AgregaIngrediente(ing2, 80);
        receta.AgregaIngrediente(ing3, 50);
        receta.AgregaIngrediente(ing4, 2);

        Console.WriteLine(receta.ToString());

        Console.WriteLine("Esta deliciosa receta está compuesta por la siguiente lista de ingredientes:");
        foreach (var ing in receta.ListaIngredientes())
        {
            Console.WriteLine(ing);
        }
        Console.WriteLine("Presiona una tecla para finalizar...");
    }
}
