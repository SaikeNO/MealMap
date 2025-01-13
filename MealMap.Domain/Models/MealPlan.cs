using System.Text;
using MealMap.Domain.Interface;

namespace MealMap.Domain.Models;

public class MealPlan
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string MealTime { get; set; }
    public DateTime DateTime { get; set; }
    public List<IRecipe> Meals { get; private set; } = new List<IRecipe>();

    public void AddMeal(IRecipe recipe)
    {
        Meals.Add(recipe);
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Plan posiłków: {MealTime} na dzień {DateTime.ToShortDateString()}");
        sb.AppendLine("Przepisy:");
        foreach (var meal in Meals)
        {
            sb.AppendLine($"- {meal.Name}: {meal.Calories} kcal, Białko: {meal.Protein}g, Węglowodany: {meal.Carbs}g, Tłuszcze: {meal.Fat}g");
        }
        return sb.ToString();
    }

}