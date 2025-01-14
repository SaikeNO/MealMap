using MealMap.Domain.Interface;
using MealMap.Domain.Models;

namespace MealMap.Domain.Singleton
{
    public class MealDatabase
    {
        private static MealDatabase _instance;
        private static readonly object LockObject = new();

        public List<IRecipe> Recipes { get; private set; }
        public List<MealPlan> MealPlans { get; private set; }

        private MealDatabase()
        {
            Recipes = new List<IRecipe>();
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

        public void AddRecipe(IRecipe recipe)
        {
            if (recipe != null)
            {
                Recipes.Add(recipe);
                Console.WriteLine($"Przepis {recipe.Name} został dodany.");
            }
        }

        public void AddMealPlan(MealPlan mealPlan)
        {
            if (mealPlan != null)
            {
                MealPlans.Add(mealPlan);
                Console.WriteLine($"Plan posiłków {mealPlan.MealTime} na dzień {mealPlan.DateTime.ToShortDateString()} został dodany.");
            }
        }
    }
}
