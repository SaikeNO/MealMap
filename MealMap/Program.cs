using MealMap.Application.Builder;
using MealMap.Application.Composite;
using MealMap.Application.Decorator;
using MealMap.Application.RecipeCreator.Creators;
using MealMap.Application.ShoppingListExporter;
using MealMap.Application.ShoppingListExporter.Exporters;
using MealMap.Domain.Interface;
using MealMap.Domain.Models;
using MealMap.Domain.Singleton;

// Ustawienie kodowania dla obsługi emoji
System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
Console.OutputEncoding = System.Text.Encoding.UTF8;

// Singleton: Utworzenie bazy danych
var database = MealDatabase.Instance();

// Dodanie przepisów do bazy danych
var saladRecipe = new Recipe
{
    Name = "Sałatka Cezar",
    Description = "Klasyczna sałatka z chrupiącą sałatą, parmezanem i grzankami.",
    Category = "Obiad",
    Ingredients =
    [
        new Ingredient { Name = "Sałata", Quantity = 1, Unit = "główka", Category = "Warzywa" },
        new Ingredient { Name = "Grzanki", Quantity = 100, Unit = "g", Category = "Pieczywo" },
        new Ingredient { Name = "Parmezan", Quantity = 50, Unit = "g", Category = "Sery" }
    ],
    Instructions = "Pokrój sałatę, wymieszaj z grzankami i parmezanem. Dodaj sos.",
    Calories = 350,
    Protein = 10,
    Carbs = 20,
    Fat = 15
};
database.AddRecipe(saladRecipe);

var spaghettiRecipe = new Recipe
{
    Name = "Spaghetti Bolognese",
    Description = "Klasyczne włoskie spaghetti z sosem bolognese.",
    Category = "Obiad",
    Ingredients =
    [
        new Ingredient() { Name = "Makaron spaghetti", Quantity = 200, Unit = "g", Category = "Makarony" },
        new Ingredient() { Name = "Mięso mielone", Quantity = 300, Unit = "g", Category = "Mięso" },
        new Ingredient() { Name = "Sos pomidorowy", Quantity = 250, Unit = "ml", Category = "Przetwory" }
    ],
    Instructions = "Ugotuj makaron. Przygotuj sos z mięsa mielonego i pomidorów.",
    Calories = 650,
    Protein = 35,
    Carbs = 75,
    Fat = 20
};
database.AddRecipe(spaghettiRecipe);

// Tworzenie planu posiłków za pomocą wzorca Builder
IMealPlanBuilder builder = new MealPlanBuilder();
var mealPlan = builder
    .SetMealTime("Obiad")
    .SetDateTime("2025-01-12")
    .AddMeal(saladRecipe)
    .AddMeal(spaghettiRecipe)
    .Build();

Console.WriteLine("\nPlan posiłków:");
Console.WriteLine(mealPlan);

// Wyświetlenie przepisów z użyciem Composite
Console.WriteLine("\nLista przepisów ze składnikami:");
foreach (var recipe in database.Recipes)
{
    var composite = new IngredientComposite { Name = recipe.Name, Quantity = 1 };
    foreach (var ingredient in recipe.Ingredients)
    {
        composite.Add(new IngredientComposite
        {
            Name = ingredient.Name,
            Quantity = ingredient.Quantity
        });
    }

    Console.WriteLine($"Przepis: {recipe.Name}");
    Console.WriteLine($"Opis: {recipe.Description}");
    composite.Display();
    Console.WriteLine(new string('-', 40));
}

// Eksport listy składników za pomocą Strategy
var exporter = new ShoppingListExporter(new TextExportStrategy());
exporter.Export(database.Recipes[0].Ingredients);

exporter.SetStrategy(new JsonExportStrategy());
exporter.Export(database.Recipes[1].Ingredients);

// Composite: Składniki na ciasto francuskie
var flour = new Ingredient
{
    Name = "Mąka",
    Category = "Sypkie produkty",
    Quantity = 500,
    Unit = "gramy"
};
var butter = new Ingredient
{
    Name = "Masło",
    Category = "Nabiał",
    Quantity = 250,
    Unit = "gramy"
};
var water = new Ingredient
{
    Name = "Woda",
    Category = "Płyny",
    Quantity = 200,
    Unit = "mililitry"
};
var salt = new Ingredient
{
    Name = "Sól",
    Category = "Przyprawy",
    Quantity = 5,
    Unit = "gramy"
};

var puffPastry = new IngredientComposite
{
    Name = "Składniki na ciasto francuskie",
    Quantity = 1
};
puffPastry.Add(flour);
puffPastry.Add(butter);
puffPastry.Add(water);
puffPastry.Add(salt);

Console.WriteLine("\nSkładniki na ciasto francuskie:");
puffPastry.Display();

// Modyfikacja ilości wody
water.Quantity = 250;
Console.WriteLine("\nPo modyfikacji ilości wody:");
puffPastry.Display();

var recipes = new List<IRecipe> {
 new Recipe
{
    Name = "Sałatka Cezar",
    Description = "Klasyczna sałatka Cezar z chrupiącą sałatą, parmezanem i grzankami.",
    Category = "Obiad",
    Ingredients =
    [
        new Ingredient() { Name = "Sałata", Quantity = 1, Unit = "główka" },
        new Ingredient() { Name = "Grzanki", Quantity = 100, Unit = "g" },
        new Ingredient() { Name = "Ser Parmezan", Quantity = 50, Unit = "g" },
        new Ingredient() { Name = "Sos Cezar", Quantity = 100, Unit = "ml" }
    ],
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
     Ingredients =
     [
        new Ingredient () { Name = "Pomidory", Quantity = 500, Unit = "g" },
        new Ingredient() { Name = "Cebula", Quantity = 1, Unit = "szt." },
        new Ingredient() { Name = "Czosnek", Quantity = 2, Unit = "ząbki" },
        new Ingredient() { Name = "Śmietanka", Quantity = 100, Unit = "ml" }
     ],
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
    foreach (var ingredient in recipe.Ingredients)
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

// Dodawanie przepisów za pomocą Factory Method
Console.WriteLine("\nDodawanie przepisów za pomocą Factory Method:");
var breakfastFactory = new BreakfastRecipeCreator();
var lunchFactory = new LunchRecipeCreator();
var dessertFactory = new DessertRecipeCreator();

var pancakes = breakfastFactory.CreateRecipe("Naleśniki");
var spaghetti = lunchFactory.CreateRecipe("Spaghetti");
var cake = dessertFactory.CreateRecipe("Ciasto czekoladowe");

pancakes.AddIngredient(new Ingredient { Name = "Mąka", Quantity = 500, Unit = "g" });
pancakes.AddIngredient(new Ingredient { Name = "Mleko", Quantity = 150, Unit = "ml" });

spaghetti.AddIngredient(new Ingredient { Name = "Makaron", Quantity = 550, Unit = "g" });
spaghetti.AddIngredient(new Ingredient { Name = "Sos pomidorowy", Quantity = 350, Unit = "ml" });

cake.AddIngredient(new Ingredient { Name = "Mąka", Quantity = 400, Unit = "g" });
cake.AddIngredient(new Ingredient { Name = "Cukier", Quantity = 150, Unit = "g" });

var recipes2 = new List<IRecipe> { pancakes, spaghetti, cake };
foreach (var recipe in recipes2)
{
    Console.WriteLine($"Przepis: {recipe.Name}");
    Console.WriteLine($"Kategoria: {recipe.Category}");
    Console.WriteLine("Składniki:");
    foreach (var ingredient in recipe.Ingredients)
    {
        Console.WriteLine($"- {ingredient.Name}: {ingredient.Quantity} {ingredient.Unit}");
    }
    Console.WriteLine(new string('-', 40));
}
