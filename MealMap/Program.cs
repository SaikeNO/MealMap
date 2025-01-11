using MealMap.Application.ShoppingListExporter.Exporters;
using MealMap.Application.ShoppingListExporter;
using MealMap.Application.Composite;
using MealMap.Domain.Models;
using MealMap.Domain.Singleton;


var database = MealDatabase.Instance();

// Dodawanie danych do bazy
var saladRecipe = new Recipe
{
    Name = "Sałatka a'la caprese",
    Ingredients = new List<Ingredient>
            {
                new() { Name = "Pomidor", Quantity = 3, Unit = "szt.", Category = "Warzywa" },
                new() { Name = "Mozzarella", Quantity = 125, Unit = "g", Category = "Sery" }
            },
    Category = "Śniadanie",
    Instructions = "Pokrój składniki i ułóż naprzemiennie",
    Calories = 350
};
database.AddRecipe(saladRecipe);
var toastRecipe = new Recipe
{
    Name = "Tost z masłem",
    Ingredients = new List<Ingredient>
    {
        new() { Name = "Chleb tostowy", Quantity = 2, Unit = "szt.", Category = "Pieczywo" },
        new() { Name = "Masło", Quantity = 20, Unit = "g", Category = "Nabiał" }
    },
    Category = "Śniadanie",
    Instructions = "Opiecz kromki chleba, a następnie posmaruj je masłem.",
    Calories = 200
};
database.AddRecipe(toastRecipe);

var lunchRecipe = new Recipe
{
    Name = "Spaghetti Bolognese",
    Ingredients = new List<Ingredient>
            {
                new() { Name = "Makaron spaghetti", Quantity = 250, Unit = "g", Category = "Makarony" },
                new() { Name = "Mięso mielone", Quantity = 300, Unit = "g", Category = "Mięso" },
                new() { Name = "Sos pomidorowy", Quantity = 200, Unit = "ml", Category = "Przetwory" }
            },
    Category = "Obiad",
    Instructions = "Ugotuj makaron, podsmaż mięso, dodaj sos i wymieszaj.",
    Calories = 650
};
database.AddRecipe(lunchRecipe);

database.AddMealPlan(new MealPlan
{
    PlanName = "Plan Tygodniowy",
    StartDate = DateTime.Now,
    EndDate = DateTime.Now.AddDays(7),
    Meals = new List<Meal>
            {
                new Meal
                {
                    Name = "Śniadanie",
                    Date = DateTime.Now,
                    TimeOfDay = "Rano",
                    Recipes = database.Recipes.Where(r => r.Name == "Sałatka a'la caprese" || r.Name == "Tost z masłem").ToList()
                },
                new Meal
                {
                    Name = "Obiad",
                    Date = DateTime.Now,
                    TimeOfDay = "Południe",
                    Recipes = database.Recipes.Where(r => r.Name == "Spaghetti Bolognese").ToList()
                }
            }
});

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
exporter.Export(ingredients);

Console.WriteLine("\n");

database.DisplayRecipes();
Console.WriteLine("\n");
database.DisplayMealPlans();
