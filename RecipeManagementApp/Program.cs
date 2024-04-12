/*ST10102873
 * PROG6211_PT1
 * An Application to manage and organise recipes*/

using RecipeManagementApp;
using System.Diagnostics.Metrics;

Console.WriteLine("RECIPE MANAGEMENT!\n\n");

try
{
    //Declarations & intialising
    int numOfIngredients = 0;

    //Calling method to promt user to enter number of ingredients    
    numOfIngredients = GetNumberOfItems("Enter the Number Ingredients: ");

    //Calling method to promt user to enter details of each the ingredient
    Ingredients[] ingredients = GetIngredients(numOfIngredients);

    //temp print
    //Console.WriteLine("Ingredients:");
    //for (int i = 0; i < ingredients.Length; i++)
    //{
    //    Console.WriteLine($"{ingredients[i].Quantity} {ingredients[i].Unit} of {ingredients[i].Name}");
    //}

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
        Console.Write($"{itemType}: ");
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

