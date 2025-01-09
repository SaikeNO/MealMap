using MealMap.Application.ShoppingListExporter.Exporters;
using MealMap.Application.ShoppingListExporter;
using MealMap.Domain.Models;
using MealMap.Application.Composite;

var ingredients = new List<Ingredient>
{
    new() { Name = "Tomato", Quantity = 2, Unit = "szt." },
    new() { Name = "Lettuce", Quantity = 1, Unit = "szt." }
};

var exporter = new ShoppingListExporter(new TextExportStrategy());
exporter.Export(ingredients);

exporter.SetStrategy(new JsonExportStrategy());
exporter.Export(ingredients);

Console.WriteLine("\n");

//Composite
Ingredient flour = new Ingredient
{
    Name = "Mąka",
    Category = "Sypkie produkty",
    Quantity = 500,
    Unit = "gramy"
};

Ingredient butter = new Ingredient
{
    Name = "Masło",
    Category = "Nabiał",
    Quantity = 250,
    Unit = "gramy"
};

Ingredient water = new Ingredient
{
    Name = "Woda",
    Category = "Płyny",
    Quantity = 200,
    Unit = "mililitry"
};

Ingredient salt = new Ingredient
{
    Name = "Sól",
    Category = "Przyprawy",
    Quantity = 5,
    Unit = "gramy"
};

IngredientComposite puffPastry = new IngredientComposite
{
    Name = "Składniki na ciasto francuskie",
    Quantity = 1
};

puffPastry.Add(flour);
puffPastry.Add(butter);
puffPastry.Add(water);
puffPastry.Add(salt);

Console.WriteLine("Składniki na ciasto francuskie:");
puffPastry.Display();

water.EditQuantity(250);
Console.WriteLine("\nPo modyfikacji ilości wody:");
puffPastry.Display();