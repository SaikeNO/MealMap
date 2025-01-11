using MealMap.Application.ShoppingListExporter.Exporters;
using MealMap.Application.ShoppingListExporter;
using MealMap.Domain.Models;
using MealMap.Application.RecipeCreator;
using MealMap.Application.RecipeCreator.Creators;

var ingredients = new List<Ingredient>
{
    new() { Name = "Tomato", Quantity = 2, Unit = "szt." },
    new() { Name = "Lettuce", Quantity = 1, Unit = "szt." }
};

var exporter = new ShoppingListExporter(new TextExportStrategy());
exporter.Export(ingredients);

exporter.SetStrategy(new JsonExportStrategy());
exporter.Export(ingredients);