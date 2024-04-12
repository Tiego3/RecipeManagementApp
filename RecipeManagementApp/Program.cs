/*ST10102873
 * PROG6211_PT1
 * An Application to manage and organise recipes*/

using RecipeManagementApp;
using System.Diagnostics.Metrics;

Console.WriteLine("------------------------------\nRECIPE MANAGEMENT!\n------------------------------");

try
{
    //Declarations & intialising
    int numOfIngredients = 0, numSteps = 0;

    //Calling method to promt user to enter number of ingredients    
    numOfIngredients = GetNumberOfItems("Ingredients: ");

    //Calling method to promt user to enter details of each the ingredient
    Ingredients[] ingredients = GetIngredients(numOfIngredients);

    //Calling method to promt user to enter number of Steps
    numSteps = GetNumberOfItems("Steps: ");

    //Calling method to promt user to enter steps for the Recipe
    RecipeSteps[] steps = GetSteps(numSteps);    

    //Calling method to display full Recipe
    DisplayRecipe(ingredients, steps);
}
catch (Exception ex)
{
    Console.WriteLine($"An unexpected error occurred: {ex.Message}");
}

//This method gets the number of items (ingredients or steps) from the user
//and checks if the value is valid (value is not text and not a negetive value)
static int GetNumberOfItems(string itemType)
{
    int numItems;
    do
    {
        Console.Write($"\nEnter the Number {itemType}: ");
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
        do
        {
            Console.Write("Quantity: ");
            if (!double.TryParse(Console.ReadLine(), out quantity) || quantity <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a valid positive number.");
            }
        } while (quantity<=0);

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
static void DisplayRecipe(Ingredients[] ingredients, RecipeSteps[] steps)
{
    Console.WriteLine("\n------------------------------\nRECIPE\n------------------------------");

    //Display Ingredients
    Console.WriteLine("Ingredients:");    
    for (int i = 0; i < ingredients.Length; i++)
    {
        var ingredient = ingredients[i];
        Console.WriteLine($"- {ingredient.Quantity} {ingredient.Unit} of {ingredient.Name}");
    }

    //Display steps
    Console.WriteLine("\nSteps:");
    for (int i = 0; i < steps.Length; i++)
    {
        Console.WriteLine($"{i + 1}. {steps[i].StepsDescription}");
    }
}