/*ST10102873
 * PROG6211_PT1
 * An Application to manage and organise recipes*/

using RecipeManagementApp;

List<Recipe> recipes = new List<Recipe>();
Console.WriteLine("------------------------------\nRECIPE MANAGEMENT!\n------------------------------");

try
{
    bool exit = false;

    while (!exit)
    {
        // Call Display Menu
        DisplayMenu();

        int choice;
        do
        {
            if (!int.TryParse(Console.ReadLine(), out choice) || choice <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a valid positive number: ");
            }
        } while (choice <= 0);

        switch (choice)
        {
            case 1:
                recipes.Add(Recipe.AddNewRecipe());
                break;
            case 2:
                if (recipes.Count > 0)
                {
                    Console.WriteLine("Select a recipe to display:");
                    for (int i = 0; i < recipes.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {recipes[i].Name}");
                    }
                    int recipeIndex;
                    do
                    {
                        if (!int.TryParse(Console.ReadLine(), out recipeIndex) || recipeIndex < 1 || recipeIndex > recipes.Count)
                        {
                            Console.WriteLine("Invalid input. Please enter a valid recipe number.");
                        }
                    } while (recipeIndex < 1 || recipeIndex > recipes.Count);
                    Recipe.DisplayRecipe(recipes[recipeIndex - 1].Name, recipes[recipeIndex - 1]);
                }
                else
                {
                    Console.WriteLine("No recipes added yet.");
                }
                break;
            case 3:
                if (recipes.Count > 0)
                {
                    Console.WriteLine("Select a recipe to change scale:");
                    for (int i = 0; i < recipes.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {recipes[i].Name}");
                    }
                    int recipeIndex;
                    do
                    {
                        if (!int.TryParse(Console.ReadLine(), out recipeIndex) || recipeIndex < 1 || recipeIndex > recipes.Count)
                        {
                            Console.WriteLine("Invalid input. Please enter a valid recipe number.");
                        }
                    } while (recipeIndex < 1 || recipeIndex > recipes.Count);
                    Recipe.ChangeScale(recipes[recipeIndex - 1]);
                }
                else
                {
                    Console.WriteLine("No recipes added yet.");
                }
                break;
            case 4:
                if (recipes.Count > 0)
                {
                    Console.WriteLine("Select a recipe to reset to original values:");
                    for (int i = 0; i < recipes.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {recipes[i].Name}");
                    }
                    int recipeIndex;
                    do
                    {
                        if (!int.TryParse(Console.ReadLine(), out recipeIndex) || recipeIndex < 1 || recipeIndex > recipes.Count)
                        {
                            Console.WriteLine("Invalid input. Please enter a valid recipe number.");
                        }
                    } while (recipeIndex < 1 || recipeIndex > recipes.Count);
                    recipes[recipeIndex - 1].ResetToOriginalValues();
                }
                else
                {
                    Console.WriteLine("No recipes added yet.");
                }
                break;

            case 5:
                exit = true;
                break;
            default:
                Console.WriteLine("Invalid choice. Please choose again.");
                break;
        }
        Console.WriteLine("\nPress any key to continue...\n------------------------------");
        Console.ReadKey(true);
    }
}
catch (Exception ex)
{
    Console.WriteLine($"An unexpected error occurred: {ex.Message}");
}
        

        // Method for Display Menu
static void DisplayMenu()
{
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("\nChoose an option:" +
        "\n1. Add a recipe" +
        "\n2. Display recipe" +
        "\n3. Change scale" +
        "\n4. Reset to Original Value" +
        "\n5. Exit");

    Console.Write("\nEnter your choice: ");
}

