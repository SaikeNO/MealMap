using MealMap.Domain.Interface;

namespace MealMap.Application.Composite;

public class IngredientComposite : IIngredient
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public string Category { get; set; }
    public double Quantity { get; set; }
    public string Unit { get; set; }

    private List<IIngredient> _children = new();

    public void Add(IIngredient component)
    {
        _children.Add(component);
    }

    public void Remove(IIngredient component)
    {
        _children.Remove(component);
    }

    public IIngredient[] GetChildren()
    {
        return _children.ToArray();
    }

    public void Display()
    {
        Console.WriteLine($"Grupa: {Name}, Ilość: {Quantity}");
        foreach (var child in _children)
        {
            child.Display();
        }
    }
}
