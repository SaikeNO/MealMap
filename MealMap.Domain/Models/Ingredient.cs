namespace MealMap.Domain.Models;

public class Ingredient
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public string Category { get; set; } // np. Warzywa i owoce, Nabiał
    public double Quantity { get; set; }
    public string Unit { get; set; } // np. gramy, litry
}
