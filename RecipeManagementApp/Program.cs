/*ST10102873
 * PROG6211_PT1
 * An Application to manage and organise recipes*/

using RecipeManagementApp;
using System.Diagnostics.Metrics;
using System.Numerics;

Console.WriteLine("------------------------------\nRECIPE MANAGEMENT!\n------------------------------");

try
{
    bool exit = false;
    Recipe recipe = null;

    while (!exit)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\nChoose an option:" +
            "\n1. Add a recipe" +
            "\n2. Display recipe" +
            "\n3. Change scale" +
            "\n4. Exit");

        Console.Write("\nEnter your choice: ");
        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                recipe = AddRecipe();
                break;
            case 2:
                if (recipe != null)
                    DisplayRecipe(recipe);
                else
                    Console.WriteLine("No recipe added yet.");
                break;
            case 3:
                if (recipe != null)
                    ChangeScale(recipe);
                else
                    Console.WriteLine("No recipe added yet.");
                break;
            case 4:
                exit = true;
                break;
            default:
                Console.WriteLine("Invalid choice. Please choose again.");
                break;
        }
    }
}
catch (Exception ex)
{
    Console.WriteLine($"An unexpected error occurred: {ex.Message}");
}

static Recipe AddRecipe()
{
    //Declarations & intialising
    int numOfIngredients = 0, numSteps = 0;
        
    //Calling method to promt user to enter number of ingredients    
    numOfIngredients = GetNumberOfItems("Ingredients ");

    //Calling method to promt user to enter details of each the ingredient
    Ingredients[] ingredients = GetIngredients(numOfIngredients);

    //Calling method to promt user to enter number of Steps
    numSteps = GetNumberOfItems("Steps ");

    //Calling method to promt user to enter steps for the Recipe
    RecipeSteps[] steps = GetSteps(numSteps);

    return new Recipe { Ingredients = ingredients, Steps = steps };

    //Calling method to display full Recipe
    //DisplayRecipe(ingredients, steps);

    //ChangeScale(ingredients, steps);
}

//This method gets the number of items (ingredients or steps) from the user
//and checks if the value is valid (value is not text and not a negetive value)
static int GetNumberOfItems(string itemType)
{
    int numItems;
    do
    {
        Console.Write($"\nEnter the Number of {itemType}: ");
        if (!int.TryParse(Console.ReadLine(), out numItems) || numItems <= 0)
        {
            Console.WriteLine("Invalid input. Please enter a valid positive number.");
        }
    } while (numItems <= 0);
    return numItems;
}

//This method gets the details of each the ingredient from user (Name of ingredient, quantity and the unit)
//Prompting user to enter details for each ingredient,
//iterating based on the value entered by user
static Ingredients[] GetIngredients(int numIngredients)
{
    Ingredients[] ingredients = new Ingredients[numIngredients];
    for (int i = 0; i < numIngredients; i++)
    {        
        Console.WriteLine($"\nEnter details  (Name, Quantity, Unit) for Ingredient #{i + 1}:");
        Console.Write("Name: ");
        string name = Console.ReadLine();

        double quantity;
        quantity = GetValueDouble("Quantity: ");       

        Console.Write("Unit: ");
        string unit = Console.ReadLine();

        ingredients[i] = new Ingredients { Name = name, Quantity = quantity, Unit = unit };
    }
    return ingredients;
}

//This method gets the details of the steps(description) for the Recipe
//Prompting user to enter the steps(description),
//iterating based on the value entered by user
static RecipeSteps[] GetSteps(int numSteps)
{
    RecipeSteps[] steps = new RecipeSteps[numSteps];
    for (int i = 0; i < numSteps; i++)
    {
        Console.WriteLine($"\nStep #{i + 1}:");
        string description = Console.ReadLine();
        steps[i] = new RecipeSteps { StepsDescription = description };
    }
    return steps;
}

//This method displays the full Recipe(Ingredients & Steps) to the User
static void DisplayRecipe(Recipe recipe)
{
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine("\n------------------------------\nRECIPE\n------------------------------");

    //Display Ingredients
    Console.WriteLine("Ingredients:");    
    for (int i = 0; i < recipe.Ingredients.Length; i++)
    {
        var ingredient = recipe.Ingredients[i];
        Console.WriteLine($"- {ingredient.Quantity} {ingredient.Unit} of {ingredient.Name}");
    }

    //Display steps
    Console.WriteLine("\nSteps:");
    for (int i = 0; i < recipe.Steps.Length; i++)
    {
        Console.WriteLine($"{i + 1}. {recipe.Steps[i].StepsDescription}");
    }
}

//This method gets the value (quantity or scale) from the user
//and checks if the value is valid (value is not text and not a negetive value)
static double GetValueDouble(string itemType)
{
    double value;
    do
    {
        Console.Write(itemType);
        if (!double.TryParse(Console.ReadLine(), out value) || value <= 0)
        {
            Console.WriteLine("Invalid input. Please enter a valid positive number.");
        }
    } while (value <= 0);
    return value;
}

//This method changes the Scale Factor for the quantity of ingredients
static void ChangeScale(Recipe recipe)
{
    double scaleFactor;
    scaleFactor = GetValueDouble("Scale: ");
    for (int i = 0; i < recipe.Ingredients.Length; i++)
    {
        recipe.Ingredients[i].Quantity *= scaleFactor;
    }
    Console.WriteLine("\nQuantities adjusted successfully.");
}




