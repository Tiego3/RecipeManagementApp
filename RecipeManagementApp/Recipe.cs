using RecipeManagementApp;
using System;

namespace RecipeManagementApp
{
    internal class Recipe
    {
        public Ingredients[] Ingredients { get; set; }
        public RecipeSteps[] Steps { get; set; }
        public double[] OriginalQuantities { get; set; }

        //Method to add full recipe
        public static Recipe AddNewRecipe()
        {
            int numOfIngredients = GetNumberOfItems("Ingredients ");
            Ingredients[] ingredients = GetIngredients(numOfIngredients);

            int numSteps = GetNumberOfItems("Steps ");
            RecipeSteps[] steps = GetSteps(numSteps);

            var recipe = new Recipe { Ingredients = ingredients, Steps = steps };
            recipe.OriginalQuantities = new double[numOfIngredients];

            // Store original quantities
            for (int i = 0; i < ingredients.Length; i++)
            {
                recipe.OriginalQuantities[i] = ingredients[i].Quantity;
            }

            return recipe;
        }

        //This method gets the number of items (ingredients or steps) from the user
        //and checks if the value is valid (value is not text and not a negetive value)
        public static int GetNumberOfItems(string itemType)
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
        public static Ingredients[] GetIngredients(int numIngredients)
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
        public static RecipeSteps[] GetSteps(int numSteps)
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

        //This method gets the value (quantity or scale) from the user
        //and checks if the value is valid (value is not text and not a negetive value)
        public static double GetValueDouble(string itemType)
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
        public static void ChangeScale(Recipe recipe)
        {
            double scaleFactor;
            scaleFactor = GetValueDouble("Scale: ");
            for (int i = 0; i < recipe.Ingredients.Length; i++)
            {

                recipe.Ingredients[i].Quantity *= scaleFactor;
            }
            Console.WriteLine("\nQuantities adjusted successfully.");
        }

        //This method Reset the quantity to the original value
        public void ResetToOriginalValues()
        {
            for (int i = 0; i < Ingredients.Length; i++)
            {
                Ingredients[i].Quantity = OriginalQuantities[i];
            }
            Console.WriteLine("\nQuantities reset to original values successfully.");
        }




        //This method displays the full Recipe(Ingredients & Steps) to the User
        public static void DisplayRecipe(Recipe recipe)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n------------------------------\nRECIPE\n------------------------------");

            // Display Ingredients
            Console.WriteLine("Ingredients:");
            for (int i = 0; i < recipe.Ingredients.Length; i++)
            {
                var ingredient = recipe.Ingredients[i];
                Console.WriteLine($"- {ingredient.Quantity} {ingredient.Unit} of {ingredient.Name}");
            }

            // Display steps
            Console.WriteLine("\nSteps:");
            for (int i = 0; i < recipe.Steps.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {recipe.Steps[i].StepsDescription}");
            }
        }

    }
}
