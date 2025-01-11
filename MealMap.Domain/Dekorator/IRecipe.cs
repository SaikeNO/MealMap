using MealMap.Domain.Models;

namespace MealMap.Application.Decorator
{
    public interface IRecipe
    {
        string Name { get; set; }
        string Description { get; set; }
        string Category { get; set; }
        List<Ingredient> Ingredients { get; set; }
        string Instructions { get; set; }
        int Calories { get; set; }
        double Protein { get; set; }
        double Carbs { get; set; }
        double Fat { get; set; }

        void AddIngredient(Ingredient ingredient);
        void RemoveIngredient(Ingredient ingredient);
        void EditIngredient(Ingredient ingredient);
        List<Ingredient> GetIngredients();
    }
}
