using MealMap.Domain.Interface;

namespace MealMap.Application.ShoppingListExporter.Exporters;

public class TextExportStrategy : IListExportStrategy
{
    public void Export(List<IIngredient> ingredients)
    {
        Console.WriteLine("Exporting as Text:");
        ingredients.ForEach(ingredient => ingredient.Display());
    }
}
