using System.Text;
using MealMap.Application.Builder;
using MealMap.Application.Decorator;
using MealMap.Application.RecipeCreator.Creators;
using MealMap.Application.RecipeCreator;
using MealMap.Application.ShoppingListExporter;
using MealMap.Application.ShoppingListExporter.Exporters;
using MealMap.Domain.Interface;
using MealMap.Domain.Models;
using MealMap.Domain.Singleton;

// Rejestracja kodowania do obsługi emoji
Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
Console.OutputEncoding = Encoding.UTF8;

// Pobranie instancji bazy danych (Singleton)
var database = MealDatabase.Instance();

// Menu główne aplikacji
while (true)
{
    Console.Clear();
    Console.WriteLine("========== MealMap ==========");
    Console.WriteLine("1. Dodaj przepis");
    Console.WriteLine("2. Wyświetl wszystkie przepisy");
    Console.WriteLine("3. Utwórz plan posiłków");
    Console.WriteLine("4. Eksportuj listę zakupów");
    Console.WriteLine("5. Wyświetl listę planów posiłków");
    Console.WriteLine("6. Wyjście");
    Console.Write("Wybierz opcję: ");
    var choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            AddRecipe(database);
            break;
        case "2":
            DisplayRecipes(database.Recipes);
            break;
        case "3":
            CreateMealPlan(database);
            break;
        case "4":
            ExportShoppingList(database);
            break;
        case "5":
            DisplayMealPlans(database.MealPlans);
            break;
        case "6":
            Console.WriteLine("Zamykanie aplikacji...");
            return;
        default:
            Console.WriteLine("Nieprawidłowy wybór. Spróbuj ponownie.");
            break;
    }

    Console.WriteLine("\nNaciśnij dowolny klawisz, aby kontynuować...");
    Console.ReadKey();
}

static void AddRecipe(MealDatabase database)
{
    Console.Clear();
    Console.WriteLine("========== Dodawanie przepisu ==========");

    Console.Write("Nazwa przepisu: ");
    var name = Console.ReadLine();

    Console.WriteLine("Wybierz kategorię przepisu: ");
    Console.WriteLine("1. Śniadanie");
    Console.WriteLine("2. Obiad");
    Console.WriteLine("3. Deser");
    Console.Write("Twój wybór: ");
    var categoryChoice = Console.ReadLine();

    // Wybór odpowiedniej fabryki na podstawie kategorii
    RecipeCreator recipeCreator = categoryChoice switch
    {
        "1" => new BreakfastRecipeCreator(),
        "2" => new LunchRecipeCreator(),
        "3" => new DessertRecipeCreator(),
        _ => throw new InvalidOperationException("Nieprawidłowy wybór kategorii.")
    };

    // Tworzenie przepisu za pomocą wybranej fabryki
    var recipe = recipeCreator.CreateRecipe(name);

    Console.Write("Opis: ");
    recipe.Description = Console.ReadLine();

    Console.Write("Kalorie: ");
	recipe.Calories = int.TryParse(Console.ReadLine(), out int calories) ? calories : 0;

	Console.Write("Białko (g): ");
	recipe.Protein = double.TryParse(Console.ReadLine(), out double protein) ? protein : 0.0;

	Console.Write("Węglowodany (g): ");
	recipe.Carbs = double.TryParse(Console.ReadLine(), out double carbs) ? carbs : 0.0;

	Console.Write("Tłuszcz (g): ");
	recipe.Fat = double.TryParse(Console.ReadLine(), out double fat) ? fat : 0.0;

	Console.WriteLine("Dodawanie składników (wpisz 'koniec', aby zakończyć):");
	while (true)
	{
		Console.Write("Nazwa składnika: ");
		var ingredientName = Console.ReadLine();
		if (ingredientName?.ToLower() == "koniec") break;

		Console.Write("Ilość: ");
		var quantity = double.TryParse(Console.ReadLine(), out double result) ? result : 0.0;

		Console.Write("Jednostka: ");
        var unit = Console.ReadLine();

        recipe.AddIngredient(new Ingredient
        {
            Name = ingredientName,
            Quantity = quantity,
            Unit = unit
        });
    }

    Console.Write("Instrukcje: ");
    recipe.Instructions = Console.ReadLine();

    // Dodanie dekoratora
    Console.WriteLine("\nDodaj etykiety (1 - ulubiony, 2 - wegański, 3 - bezglutenowy, 4 - bezlaktozowy, 5 - pikantny, 0 - zakończ):");
    while (true)
    {
        Console.Write("Wybór: ");
        var decoratorChoice = Console.ReadLine();
        switch (decoratorChoice)
        {
            case "1":
                recipe = new FavouriteRecipe(recipe);
                break;
            case "2":
                recipe = new VeganRecipe(recipe);
                break;
            case "3":
                recipe = new GlutenFreeRecipe(recipe);
                break;
            case "4":
                recipe = new LactoseFreeRecipe(recipe);
                break;
            case "5":
                recipe = new SpicyRecipe(recipe);
                break;
            case "0":
                goto Done;
            default:
                Console.WriteLine("Nieprawidłowy wybór. Spróbuj ponownie.");
                break;
        }
    }

Done:
    database.AddRecipe(recipe);
}


static void DisplayRecipes(List<IRecipe> recipes)
{
    Console.Clear();
    Console.WriteLine("========== Lista przepisów ==========");
    foreach (var recipe in recipes)
    {
        Console.WriteLine(recipe.ToString());
        Console.WriteLine($"Opis: {recipe.Description}");
        Console.WriteLine($"Kategoria: {recipe.Category}");
        Console.WriteLine($"Składniki:");
        foreach (var ingredient in recipe.Ingredients)
        {
            ingredient.Display();
        }
        Console.WriteLine($"Instrukcje: {recipe.Instructions}");
        Console.WriteLine($"Kalorie: {recipe.Calories}, Białko: {recipe.Protein}g, Węglowodany: {recipe.Carbs}g, Tłuszcz: {recipe.Fat}g");
        Console.WriteLine(new string('-', 40));
    }
}

static void CreateMealPlan(MealDatabase database)
{
    Console.Clear();
    Console.WriteLine("========== Tworzenie planu posiłków ==========");
    Console.Write("Pora posiłku: ");
    var mealTime = Console.ReadLine();

    Console.Write("Data (YYYY-MM-DD): ");
    var date = DateTime.Parse(Console.ReadLine() ?? DateTime.Now.ToString());

    var mealPlanBuilder = new MealPlanBuilder();
    var mealPlan = mealPlanBuilder
        .SetMealTime(mealTime)
        .SetDateTime(date.ToString("yyyy-MM-dd"))
        .Build();

    Console.WriteLine("Dodawanie posiłków (wpisz 'koniec', aby zakończyć):");
    while (true)
    {
        Console.Write("Nazwa przepisu: ");
        var recipeName = Console.ReadLine();
        if (recipeName?.ToLower() == "koniec") break;

        var recipe = database.Recipes.FirstOrDefault(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
        if (recipe != null)
        {
            mealPlan.AddMeal(recipe);
        }
        else
        {
            Console.WriteLine("Nie znaleziono przepisu o podanej nazwie.");
        }
    }

    database.AddMealPlan(mealPlan);
}

static void ExportShoppingList(MealDatabase database)
{
    Console.Clear();
    Console.WriteLine("========== Eksportowanie listy zakupów ==========");
    Console.WriteLine("Wybierz format eksportu (1 - Tekst, 2 - JSON): ");
    var exportChoice = Console.ReadLine();

    IListExportStrategy exportStrategy = exportChoice switch
    {
        "1" => new TextExportStrategy(),
        "2" => new JsonExportStrategy(),
        _ => throw new InvalidOperationException("Nieprawidłowy wybór.")
    };

    var exporter = new ShoppingListExporter(exportStrategy);

    Console.WriteLine("Wybierz przepis do eksportu (wpisz nazwę): ");
    var recipeName = Console.ReadLine();
    var recipe = database.Recipes.FirstOrDefault(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));

    if (recipe != null)
    {
        exporter.Export(recipe.Ingredients);
        Console.WriteLine("Lista zakupów została wyeksportowana.");
    }
    else
    {
        Console.WriteLine("Nie znaleziono przepisu o podanej nazwie.");
    }
}
static void DisplayMealPlans(List<MealPlan> mealPlans)
{
    Console.Clear();
    Console.WriteLine("========== Lista planów posiłków ==========");

    if (!mealPlans.Any())
    {
        Console.WriteLine("Brak zapisanych planów posiłków.");
        return;
    }

    foreach (var mealPlan in mealPlans)
    {
        Console.WriteLine($"Data: {mealPlan.DateTime}");
        Console.WriteLine($"Pora posiłku: {mealPlan.MealTime}");
        Console.WriteLine("Posiłki:");

        foreach (var meal in mealPlan.Meals)
        {
            Console.WriteLine($"- {meal.Name} (Kategoria: {meal.Category})");
            Console.WriteLine($"  Kalorie: {meal.Calories}, Białko: {meal.Protein}g, Węglowodany: {meal.Carbs}g, Tłuszcz: {meal.Fat}g");
            Console.WriteLine("  Składniki:");
            foreach (var ingredient in meal.Ingredients)
            {
                ingredient.Display();
            }
            Console.WriteLine("  Instrukcje:");
            Console.WriteLine($"    {meal.Instructions}");
        }

        Console.WriteLine(new string('-', 40));
    }
}
