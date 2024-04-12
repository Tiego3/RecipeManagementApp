using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeManagementApp
{
    internal class Recipe
    {
        public Ingredients[] Ingredients { get; set; }
        public RecipeSteps[] Steps { get; set; }
    }
}
