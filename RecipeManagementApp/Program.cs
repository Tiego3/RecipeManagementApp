/*ST10102873
 * PROG6211_PT1
 * An Application to manage and organise recipes*/
using RecipeManagementApp;

Console.WriteLine("RECIPE MANAGEMENT!");

//Declarations & intialising ==
int numOfIngredients = 0;

//Prompting user to enter number of ingredients:
Console.Write("Enter number of ingredients:");
numOfIngredients = Convert.ToInt32(Console.ReadLine());

//An array to store ingredients
Ingredients[] ingredients = new Ingredients[numOfIngredients];

//Prompt user to enter details for each ingredient
for (int i = 0; i < numOfIngredients; i++)
{
    Console.WriteLine($"\nEnter Ingredient (Name, Quantity, Unit) #{i + 1}:");
    Console.Write("Name: ");
    string name = Console.ReadLine();
    Console.Write("Quantity: ");
    double quantity = double.Parse(Console.ReadLine());
    Console.Write("Unit: ");
    string unit = Console.ReadLine();

    //Ingredient object
    ingredients[i] = new Ingredients { Name = name, Quantity = quantity, Unit = unit };
}

//temp print
//Console.WriteLine("Ingredients:");
//for (int i = 0; i < ingredients.Length; i++)
//{
//    Console.WriteLine($"{ingredients[i].Quantity} {ingredients[i].Unit} of {ingredients[i].Name}");
//}


