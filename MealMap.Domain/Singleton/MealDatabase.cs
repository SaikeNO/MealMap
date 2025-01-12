using System.Collections.Generic;
using MealMap.Domain.Models;

namespace MealMap.Domain.Singleton
{
    public class MealDatabase
    {
        private static MealDatabase _instance;
        private static readonly object LockObject = new();

        public List<Recipe> Recipes { get; private set; }
        public List<MealPlan> MealPlans { get; private set; }

        private MealDatabase()
        {
            Recipes = new List<Recipe>();
            MealPlans = new List<MealPlan>();
        }

        public static MealDatabase Instance()
        {
            if (_instance == null)
            {
                lock (LockObject)
                {
                    if (_instance == null)
                    {
                        _instance = new MealDatabase();
                    }
                }
            }
            return _instance;
        }

        public void AddRecipe(Recipe recipe)
        {
            if (recipe != null)
            {
                Recipes.Add(recipe);
                Console.WriteLine($"Przepis {recipe.Name} został dodany do bazy danych.");
            }
        }

        public void AddMealPlan(MealPlan mealPlan)
        {
            if (mealPlan != null)
            {
                MealPlans.Add(mealPlan);
                Console.WriteLine($"Plan posiłków {mealPlan.MealTime} na dzień {mealPlan.DateTime.ToShortDateString()} został dodany do bazy danych.");
            }
        }
    }
}
