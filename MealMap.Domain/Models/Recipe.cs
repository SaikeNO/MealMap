namespace MealMap.Domain.Models;

public class Recipe
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public string Description { get; set; }
    public string Category { get; set; } // np. Śniadanie, Obiad
    public List<Ingredient> Ingredients { get; set; }
    public string Instructions { get; set; }
    public int Calories { get; set; }
    public double Protein { get; set; }
    public double Carbs { get; set; }
    public double Fat { get; set; }
}
