
using System.Text;
using System.Collections.Generic;

//TODO: Incluye el código necesario para implementar las entidades que se piden en el ejercicio
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
        Console.ReadKey(true);
    }
}