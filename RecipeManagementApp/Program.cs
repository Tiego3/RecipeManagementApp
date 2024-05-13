/*ST10102873
 * PROG6211_PT1
 * An Application to manage and organise recipes*/

using RecipeManagementApp;
using System.Collections.Generic;

List<Recipe> recipes = new List<Recipe>();
int indexVal = 0;

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
            choice = Recipe.GetIntValue("\nEnter your choice: ");
            
        } while (choice <= 0);

        switch (choice)
        {
            case 1:
                recipes.Add(Recipe.AddNewRecipe());
                break;
            case 2:
                if (recipes.Count > 0)
                {
                    indexVal = GetRecipeIndex("Select a recipe to display:", recipes);
                    Recipe.DisplayRecipe(recipes[indexVal].Name, recipes[indexVal]);
                }
                else
                {
                    Console.WriteLine("No recipes added yet.");
                }
                break;
            case 3:
                if (recipes.Count > 0)
                {
                    indexVal = GetRecipeIndex("Select a recipe to change scale:", recipes);
                    Recipe.ChangeScale(recipes[indexVal]);                
                }
                else
                {
                    Console.WriteLine("No recipes added yet.");
                }
                break;
            case 4:
                if (recipes.Count > 0)
                {
                    indexVal = GetRecipeIndex("Select a recipe to reset to original values:", recipes);
                    Recipe.ResetToOriginalValues(recipes[indexVal]);
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
        indexVal = 0;
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

   // Console.Write("\nEnter your choice: ");
}

static int GetRecipeIndex(string prompt, List<Recipe> recipes)
{
    int recipeIndex;
    do
    {
        Console.WriteLine(prompt);
        //Ordering Recipes in alphabetic order 
        var sortedRecipes = recipes.OrderBy(r => r.Name).ToList();
        for (int i = 0; i < sortedRecipes.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {sortedRecipes[i].Name}");
        }
        Console.Write(">> ");
        if (!int.TryParse(Console.ReadLine(), out recipeIndex) || recipeIndex < 1 || recipeIndex > sortedRecipes.Count)
        {
            Console.WriteLine("Invalid input. Please enter a valid recipe number.");
        }
    } while (recipeIndex < 1 || recipeIndex > recipes.Count);

    return recipeIndex - 1;
}