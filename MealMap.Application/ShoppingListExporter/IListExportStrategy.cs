using MealMap.Domain.Models;

namespace MealMap.Application.ShoppingListExporter;

public interface IListExportStrategy
{
    void Export(List<Ingredient> ingredients);
}
