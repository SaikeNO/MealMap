using MealMap.Domain.Interface;

namespace MealMap.Application.ShoppingListExporter.Exporters;

public class JsonExportStrategy : IListExportStrategy
{
    public void Export(List<IIngredient> ingredients)
    {
        Console.WriteLine("Exporting as JSON:");
        Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(ingredients));
    }
}
