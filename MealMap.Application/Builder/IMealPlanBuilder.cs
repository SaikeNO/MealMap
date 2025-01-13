using MealMap.Domain.Models;

namespace MealMap.Application.Builder
{
    public interface IMealPlanBuilder
    {
        IMealPlanBuilder SetMealTime(string time); // np. Śniadanie, Obiad
        IMealPlanBuilder SetDateTime(string date); // Data planu
        IMealPlanBuilder AddMeal(Recipe recipe);  // Dodanie przepisu
        MealPlan Build(); // Zbudowanie obiektu MealPlan
    }
}
