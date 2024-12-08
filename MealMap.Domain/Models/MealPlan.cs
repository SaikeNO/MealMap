namespace MealMap.Domain.Models;

public class MealPlan
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string PlanName { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public List<Meal> Meals { get; set; }
}