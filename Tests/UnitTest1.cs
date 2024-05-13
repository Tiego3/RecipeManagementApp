using NUnit.Framework;
using RecipeManagementApp;

namespace RecipeManagementApp.Tests
{
    public class UnitTest1
    {

        //This test case checks whether the CalculateTotalCalories method correctly returns total calories
        [Test]
        public void CalculateTotalCalories_ReturnsCorrectTotalCalories()
        {
            // Arrange
            var ingredients = new List<Ingredients>
            {
                new Ingredients { Name = "Test 1", Quantity = 1, Unit = "unit", Calories = 100 },
                new Ingredients { Name = "Test Ingredient 2", Quantity = 2, Unit = "units", Calories = 200 },
                new Ingredients { Name = "Test Ingredient 3", Quantity = 4, Unit = "units", Calories = 300 }
            };

            var recipe = new Recipe
            {
                Ingredients = ingredients
            };

            // Act
            double totalCalories = Recipe.CalculateTotalCalories(recipe.Ingredients);

            // Assert
            Assert.AreEqual(600, totalCalories);
        }


        //This test case checks whether the CalculateTotalCalories method correctly returns zero when the ingredients list is empty
        [Test]
        public void CalculateTotalCalories__ReturnsZeroWhenEmpty()
        {
            // Arrange
            var ingredients = new List<Ingredients>();

            // Act
            double totalCalories = Recipe.CalculateTotalCalories(ingredients);

            // Assert
            Assert.AreEqual(0, totalCalories);
        }

        //This test case checks whether the CalculateTotalCalories method correctly handles negative calorie values for ingredients by throwing an exeption
        [Test]       
        public void CalculateTotalCalories_NegativeThrowsArgumentException()
        {
            // Arrange
            var ingredients = new List<Ingredients>
            {   
                new Ingredients { Name = "Ingredient 1", Quantity = 1, Unit = "unit", Calories = 100 },
                new Ingredients { Name = "Ingredient 2", Quantity = 2, Unit = "units", Calories = -200 },
                new Ingredients { Name = "Ingredient 3", Quantity = 3, Unit = "units", Calories = 300 }
            };

            // Act and Assert
            Assert.Throws<System.Exception>(() => Recipe.CalculateTotalCalories(ingredients));
        }

        //This test case checks whether the CalculateTotalCalories method correctly throws an ArgumentNullException when the ingredients list is null.
        [Test]
        public void CalculateTotalCalories_NullIngredientsList_ThrowsArgumentNullException()
        {
            // Arrange
            List<Ingredients> ingredients = null;

            // Act
            Assert.Throws<System.NullReferenceException>(() => Recipe.CalculateTotalCalories(ingredients));
        }
    }
}