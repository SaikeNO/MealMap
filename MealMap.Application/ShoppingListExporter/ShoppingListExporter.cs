using MealMap.Domain.Interface;

namespace MealMap.Application.ShoppingListExporter;

public class ShoppingListExporter(IListExportStrategy strategy)
{
    private IListExportStrategy _strategy = strategy;

    public void SetStrategy(IListExportStrategy strategy) => _strategy = strategy;

    public void Export(List<IIngredient> ingredients) => _strategy.Export(ingredients);
}
