namespace MealMap.Domain.Models;

public class Meal
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } // np. Śniadanie
    public DateTime Date { get; set; }
    public string TimeOfDay { get; set; } // np. Poranek, Południe
    public List<Recipe> Recipes { get; set; }
}
