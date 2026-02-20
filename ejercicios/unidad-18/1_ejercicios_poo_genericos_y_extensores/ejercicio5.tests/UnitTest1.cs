using System;
using System.Collections.Generic;
using Xunit;

namespace ejercicio5.tests
{
    public class UnitTest1
    {
        [Fact]
        public void Ingrediente_ToString_DevuelveNombre()
        {
            var ing = new Ingrediente("Harina", "gramo", TipoIngrediente.Carbohidrato, 0.58);
            Assert.Equal("Harina", ing.ToString());
        }

        [Fact]
        public void IngredienteExtension_ToIngrediente_CreaIngredienteRecetaCorrecto()
        {
            var ing = new Ingrediente("Azúcar", "gramo", TipoIngrediente.Carbohidrato, 0.98);
            var ingReceta = ing.ToIngrediente(100);
            Assert.Equal("Azúcar", ingReceta.Nombre);
            Assert.Equal(100, ingReceta.CantidadUsada);
            Assert.Equal(98, ingReceta.CaloriasTotales);
        }

        [Fact]
        public void IngredienteRecetaExtension_ToIngrediente_CreaIngredienteCorrecto()
        {
            var ingReceta = new IngredienteReceta("Mantequilla", "gramo", TipoIngrediente.Grasa, 7.2, 50, 360);
            var ing = ingReceta.ToIngrediente();
            Assert.Equal("Mantequilla", ing.Nombre);
            Assert.Equal("gramo", ing.Unidad);
            Assert.Equal(TipoIngrediente.Grasa, ing.Tipo);
            Assert.Equal(7.2, ing.CaloriasPorGramo);
        }

        [Fact]
        public void Receta_AgregaIngrediente_AgregaCorrectamente()
        {
            var receta = new Receta("Tarta");
            var ing = new Ingrediente("Huevo", "unidad", TipoIngrediente.Proteina, 1.5);
            receta.AgregaIngrediente(ing, 2);
            Assert.Single(receta.Ingredientes);
            Assert.Equal("Huevo", receta.Ingredientes[0].Nombre);
            Assert.Equal(2, receta.Ingredientes[0].CantidadUsada);
        }

        [Fact]
        public void Receta_ListaIngredientes_DevuelveListaCorrecta()
        {
            var receta = new Receta("Tarta");
            var ing = new Ingrediente("Huevo", "unidad", TipoIngrediente.Proteina, 1.5);
            receta.AgregaIngrediente(ing, 2);
            var lista = receta.ListaIngredientes();
            Assert.Single(lista);
            Assert.Equal("Huevo", lista[0].Nombre);
        }

        [Fact]
        public void Receta_CaloriasTotales_DevuelveSumaCorrecta()
        {
            var receta = new Receta("Tarta");
            receta.AgregaIngrediente(new Ingrediente("Harina", "gramo", TipoIngrediente.Carbohidrato, 0.58), 100);
            receta.AgregaIngrediente(new Ingrediente("Azúcar", "gramo", TipoIngrediente.Carbohidrato, 0.98), 50);
            double esperado = 100 * 0.58 + 50 * 0.98;
            Assert.Equal(esperado, receta.CaloriasTotales(), 2);
        }

        [Fact]
        public void Receta_ToString_DevuelveFormatoEsperado()
        {
            var receta = new Receta("Tarta");
            receta.AgregaIngrediente(new Ingrediente("Harina", "gramo", TipoIngrediente.Carbohidrato, 0.58), 100);
            var texto = receta.ToString();
            Assert.Contains("Receta: Tarta", texto);
            Assert.Contains("Harina", texto);
            Assert.Contains("Calorías totales", texto);
        }
    }
}
