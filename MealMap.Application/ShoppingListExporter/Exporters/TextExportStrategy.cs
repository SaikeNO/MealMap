using MealMap.Domain.Models;

namespace MealMap.Application.ShoppingListExporter.Exporters;

public class TextExportStrategy : IListExportStrategy
{
    public void Export(List<Ingredient> ingredients)
    {
        Console.WriteLine("Exporting as Text:");
        ingredients.ForEach(ingredient => Console.WriteLine($"{ingredient.Name}: {ingredient.Quantity} {ingredient.Unit}"));
    }
}
