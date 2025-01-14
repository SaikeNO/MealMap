namespace MealMap.Domain.Interface;

public interface IIngredient
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; } // np. Warzywa i owoce, Nabiał
    public double Quantity { get; set; }
    public string Unit { get; set; } // np. gramy, litry

    void Display();
}
