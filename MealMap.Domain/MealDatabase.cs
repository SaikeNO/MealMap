using System.Collections.Generic;
using MealMap.Domain.Models;

namespace MealMap.Domain
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
            }
        }

        public void AddMealPlan(MealPlan mealPlan)
        {
            if (mealPlan != null)
            {
                MealPlans.Add(mealPlan);
            }
        }



        // Metody testowe do wyświetlania przepisów i planów
        public void DisplayRecipes()
        {
            foreach (var recipe in Recipes)
            {
                Console.WriteLine($"Recipe: {recipe.Name}, Category: {recipe.Category}, Calories: {recipe.Calories}, Instructions: {recipe.Instructions}");
                foreach (var ingredient in recipe.Ingredients)
                {
                    Console.WriteLine($"  Ingredient: {ingredient.Name}, Quantity: {ingredient.Quantity} {ingredient.Unit}");
                }
            }
        }
        public void DisplayMealPlans()
        {
            foreach (var mealPlan in MealPlans)
            {
                Console.WriteLine($"Meal Plan: {mealPlan.PlanName}, Start Date: {mealPlan.StartDate}, End Date: {mealPlan.EndDate}");
                foreach (var meal in mealPlan.Meals)
                {
                    Console.WriteLine($"  Meal: {meal.Name}, Date: {meal.Date}, Time of Day: {meal.TimeOfDay}");
                    foreach (var recipe in meal.Recipes)
                    {
                        Console.WriteLine($"    Recipe: {recipe.Name}");
                    }
                }
            }
        }
    }
}
