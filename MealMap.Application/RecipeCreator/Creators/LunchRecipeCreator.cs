using MealMap.Domain.Interface;
using MealMap.Domain.Models;

namespace MealMap.Application.RecipeCreator.Creators;

public class LunchRecipeCreator : RecipeCreator
{
    public override IRecipe CreateRecipe(string name)
    {
        return new Recipe(name, "Obiad");
    }
}
