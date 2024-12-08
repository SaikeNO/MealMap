namespace MealMap.Domain.Models;

public class ShoppingItem
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string IngredientName { get; set; }
    public double Quantity { get; set; }
    public string Unit { get; set; }
    public string Category { get; set; }
}