using MealMap.Domain.Interface;

namespace MealMap.Domain.Models;

public class Ingredient : IIngredient
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public string Category { get; set; } // np. Warzywa i owoce, Nabiał
    public double Quantity { get; set; }
    public string Unit { get; set; } // np. gramy, litry

    public void Display()
    {
        Console.WriteLine($"Składnik: {Name} - {Quantity} {Unit}");
    }

    public void EditUnit(string unit)
    {
        Unit = unit;
    }

    public void EditQuantity(double quantity)
    {
        Quantity = (double)quantity;
    }
}
