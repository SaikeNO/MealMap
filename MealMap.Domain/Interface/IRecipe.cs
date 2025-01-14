namespace MealMap.Domain.Interface;

public interface IRecipe
{
    string Name { get; set; }
    string Description { get; set; }
    string Category { get; set; }
    List<IIngredient> Ingredients { get; set; }
    string Instructions { get; set; }
    int Calories { get; set; }
    double Protein { get; set; }
    double Carbs { get; set; }
    double Fat { get; set; }

    void AddIngredient(IIngredient ingredient);
    void RemoveIngredient(IIngredient ingredient);
    void EditIngredient(IIngredient ingredient);
}
