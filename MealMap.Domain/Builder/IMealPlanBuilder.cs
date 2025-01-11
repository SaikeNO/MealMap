using MealMap.Application.Decorator;
using MealMap.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
