using MealMap.Domain.Interface;
using MealMap.Domain.Models;

namespace MealMap.Application.RecipeCreator.Creators;

public class DessertRecipeCreator : RecipeCreator
{
    public override IRecipe CreateRecipe(string name)
    {
        return new Recipe(name, "Deser");
    }
}
