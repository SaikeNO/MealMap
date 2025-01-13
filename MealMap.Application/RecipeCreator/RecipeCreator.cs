using MealMap.Domain.Interface;

namespace MealMap.Application.RecipeCreator
{
    public abstract class RecipeCreator
    {
        public abstract IRecipe CreateRecipe(string name);
    }
}
