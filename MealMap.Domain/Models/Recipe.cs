using MealMap.Application.Decorator;
using System.Text;

namespace MealMap.Domain.Models;

public class Recipe: IRecipe
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

    public Recipe() { }

	public Recipe(string name, string category)
	{
		Name = name;
		Category = category;
		Ingredients = new List<Ingredient>();
	}

	public void AddIngredient(Ingredient ingredient)
    {
        if (!Ingredients.Contains(ingredient))
        {
            Ingredients.Add(ingredient);
            Console.WriteLine($"Dodano składnik: {ingredient.Name}");
        }
        else
            Console.WriteLine($"Składnik {ingredient.Name} już jest na liście.");
    }
    public void RemoveIngredient(Ingredient ingredient)
    {
        var ingredientToRemove = Ingredients.FirstOrDefault(i => i.Name == ingredient.Name);
        if (ingredientToRemove != null)
        {
            Ingredients.Remove(ingredientToRemove);
            Console.WriteLine($"Usunięto składnik: {ingredient.Name}");
        }
        else
            Console.WriteLine($"Nie znaleziono składnika {ingredient.Name}.");
    }
    public void EditIngredient( Ingredient ingredient)
    {
        var ingredientToEdit = Ingredients.FirstOrDefault(i => i.Name == ingredient.Name);
        if (ingredientToEdit != null)
        {
            ingredientToEdit.Quantity = ingredient.Quantity;
            ingredientToEdit.Unit = ingredient.Unit;
            Console.WriteLine($"Zaktualizowano składnik: {ingredient.Name}");
        }
        else
            Console.WriteLine($"Nie znaleziono składnika {ingredient.Name} do edycji.");
    }
    public List<Ingredient> GetIngredients() => Ingredients;
   
}