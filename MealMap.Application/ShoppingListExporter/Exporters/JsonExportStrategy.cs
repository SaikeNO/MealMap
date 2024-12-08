using MealMap.Domain.Models;

namespace MealMap.Application.ShoppingListExporter.Exporters;

public class JsonExportStrategy : IListExportStrategy
{
    public void Export(List<Ingredient> ingredients)
    {
        Console.WriteLine("Exporting as JSON:");
        Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(ingredients));
    }
}
