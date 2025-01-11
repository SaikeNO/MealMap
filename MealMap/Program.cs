using MealMap.Application.ShoppingListExporter.Exporters;
using MealMap.Application.ShoppingListExporter;
using MealMap.Application.Composite;
using MealMap.Domain.Models;
using MealMap.Application.Composite;
using MealMap.Application.Decorator;
using MealMap.Application.Builder;
//do emoji
System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
Console.OutputEncoding = System.Text.Encoding.UTF8;
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
    new() { Name = "Pomidor", Quantity = 2, Unit = "szt." },
    new() { Name = "Sałata", Quantity = 1, Unit = "szt." }
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

Console.WriteLine("\n\n");

var recipes = new List<IRecipe> { 
 new Recipe
{
    Name = "Sałatka Cezar",
    Description = "Klasyczna sałatka Cezar z chrupiącą sałatą, parmezanem i grzankami.",
    Category = "Obiad",
    Ingredients = new List<Ingredient>
    {
        new () { Name = "Sałata", Quantity = 1, Unit = "główka" },
        new () { Name = "Grzanki", Quantity = 100, Unit = "g" },
        new () { Name = "Ser Parmezan", Quantity = 50, Unit = "g" },
        new () { Name = "Sos Cezar", Quantity = 100, Unit = "ml" }
    },
    Instructions = "1. Pokrój sałatę. 2. Wymieszaj z grzankami i serem. 3. Dodaj sos i wymieszaj.",
    Calories = 350,
    Protein = 10,
    Carbs = 30,
    Fat = 20
},
new Recipe
{
     Name = "Zupa Pomidorowa",
     Description = "Ciepła i kremowa zupa pomidorowa z bazylią.",
     Category = "Kolacja",
     Ingredients = new List<Ingredient>
     {
        new () { Name = "Pomidory", Quantity = 500, Unit = "g" },
        new () { Name = "Cebula", Quantity = 1, Unit = "szt." },
        new () { Name = "Czosnek", Quantity = 2, Unit = "ząbki" },
        new () { Name = "Śmietanka", Quantity = 100, Unit = "ml" }
     },
     Instructions = "1. Podsmaż cebulę i czosnek. 2. Dodaj pomidory i gotuj. 3. Zblenduj i dodaj śmietankę.",
     Calories = 250,
     Protein = 5,
     Carbs = 20,
     Fat = 15
}
};


recipes[0].AddIngredient(new Ingredient { Name = "Oliwki", Quantity = 50, Unit = "g" });
recipes[0].EditIngredient(new Ingredient { Name = "Grzanki", Quantity = 120, Unit = "g" });
recipes[0].RemoveIngredient(new Ingredient { Name = "Sos Cezar" });

recipes[0] = new FavouriteRecipe(recipes[0]);

recipes[1] = new FavouriteRecipe(
    new SpicyRecipe(
        new VeganRecipe(recipes[1])
    )
);
// Wyświetlenie listy przepisów
Console.WriteLine("\nLista przepisów:");
foreach (var recipe in recipes)
{
    Console.WriteLine(recipe.ToString());
    Console.WriteLine($"  Opis: {recipe.Description}");
    Console.WriteLine($"  Kategoria: {recipe.Category}");
    Console.WriteLine("  Składniki:");
    foreach (var ingredient in recipe.GetIngredients())
    {
        Console.WriteLine($"    - {ingredient.Name}: {ingredient.Quantity} {ingredient.Unit}");
    }
    Console.WriteLine($"  Instrukcje: {recipe.Instructions}");
    Console.WriteLine($"  Kalorie: {recipe.Calories}");
    Console.WriteLine($"  Białko: {recipe.Protein}g");
    Console.WriteLine($"  Węglowodany: {recipe.Carbs}g");
    Console.WriteLine($"  Tłuszcz: {recipe.Fat}g");
    Console.WriteLine(new string('-', 40));
}

// Przykładowe przepisy
var recipe1 = new Recipe
{
    Name = "Spaghetti Bolognese",
    Description = "Klasyczne włoskie spaghetti z sosem bolognese",
    Category = "Obiad",
    Ingredients = new List<Ingredient>
                {
                    new Ingredient { Name = "Makaron", Quantity = 100, Unit = "g" },
                    new Ingredient { Name = "Sos pomidorowy", Quantity = 150, Unit = "ml" },
                    new Ingredient { Name = "Mięso mielone", Quantity = 200, Unit = "g" }
                },
    Instructions = "Ugotuj makaron. Przygotuj sos z mięsem mielonym i pomidorami.",
    Calories = 650,
    Protein = 35,
    Carbs = 85,
    Fat = 18
};

var recipe2 = new Recipe
{
    Name = "Sałatka z kurczakiem",
    Description = "Lekka sałatka z kawałkami kurczaka",
    Category = "Kolacja",
    Ingredients = new List<Ingredient>
                {
                    new Ingredient { Name = "Sałata", Quantity = 150, Unit = "g" },
                    new Ingredient { Name = "Kurczak grillowany", Quantity = 100, Unit = "g" },
                    new Ingredient { Name = "Sos vinaigrette", Quantity = 50, Unit = "ml" }
                },
    Instructions = "Połącz wszystkie składniki i polej sosem.",
    Calories = 350,
    Protein = 25,
    Carbs = 10,
    Fat = 20
};

// Tworzenie planu posiłków za pomocą buildera
IMealPlanBuilder builder = new MealPlanBuilder();
MealPlan mealPlan = builder
    .SetMealTime("Obiad")
    .SetDateTime("2025-01-12")
    .AddMeal(recipe1)
    .AddMeal(recipe2)
    .Build();

// Wyświetlenie planu posiłków
Console.WriteLine(mealPlan);
   
puffPastry.Display();
exporter.Export(ingredients);

Console.WriteLine("\n");

database.DisplayRecipes();
Console.WriteLine("\n");
database.DisplayMealPlans();
