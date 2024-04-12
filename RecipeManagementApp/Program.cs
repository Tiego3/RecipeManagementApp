/*ST10102873
 * PROG6211_PT1
 * An Application to manage and organise recipes*/

using RecipeManagementApp;

Console.WriteLine("------------------------------\nRECIPE MANAGEMENT!\n------------------------------");

try
{
    bool exit = false;
    Recipe recipe = null;

    while (!exit)
    {
        //Call Display Menu
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
                if (recipe != null)
                {
                    Console.WriteLine("Are you sure you want to clear previous recipe and enter new one," +
                        "\n(enter 'y' for Yes  and 'n' for No:)");
                    string ans = Console.ReadLine();
                    if (ans.Equals("y", StringComparison.CurrentCultureIgnoreCase))
                    {
                        recipe = Recipe.AddNewRecipe();
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
                recipe = Recipe.AddNewRecipe();
                break;
            case 2:
                if (recipe != null)
                    // Call DisplayRecipe method
                    Recipe.DisplayRecipe(recipe); 
                else
                    Console.WriteLine("No recipe added yet.");
                break;
            case 3:
                if (recipe != null)
                {                   
                    Recipe.ChangeScale(recipe); 
                }
                else
                    Console.WriteLine("No recipe added yet.");
                break;
            case 4:
                // Call ResetToOriginalValues method
                if (recipe != null)
                    recipe.ResetToOriginalValues();  
                else
                    Console.WriteLine("No recipe added yet.");
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
   
//Method for Display Menu
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



