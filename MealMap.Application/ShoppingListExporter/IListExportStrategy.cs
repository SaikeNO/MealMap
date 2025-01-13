using MealMap.Domain.Interface;

namespace MealMap.Application.ShoppingListExporter;

public interface IListExportStrategy
{
    void Export(List<IIngredient> ingredients);
}
