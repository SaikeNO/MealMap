namespace MealMap.Domain.Models;

public class ShoppingList
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime GeneratedDate { get; set; }
    public List<ShoppingItem> Items { get; set; }
}
