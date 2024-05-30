using System;
using System.Collections.Generic;
using System.Linq;

namespace RecipeApp
{
    // Ingredient class to store ingredient details
    class Ingredient
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public double Calories { get; set; }
        public string FoodGroup { get; set; }
        private double OriginalQuantity { get; set; }

        public Ingredient(string name, double quantity, string unit, double calories, string foodGroup)
        {
            Name = name;
            Quantity = quantity;
            Unit = unit;
            Calories = calories;
            FoodGroup = foodGroup;
            OriginalQuantity = quantity;
        }

        public void Scale(double factor)
        {
            Quantity = OriginalQuantity * factor;
        }

        public void Reset()
        {
            Quantity = OriginalQuantity;
        }

        public override string ToString()
        {
            return $"{Quantity} {Unit} of {Name} ({Calories} cal, {FoodGroup})";
        }
    }

    // Step class to store each step in the recipe
    class Step
    {
        public string Description { get; set; }

        public Step(string description)
        {
            Description = description;
        }

        public override string ToString()
        {
            return Description;
        }
    }

    // Recipe class to store recipe details
    class Recipe
    {
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; private set; }
        public List<Step> Steps { get; private set; }

        public Recipe(string name)
        {
            Name = name;
            Ingredients = new List<Ingredient>();
            Steps = new List<Step>();
        }

        public void AddIngredient(Ingredient ingredient)
        {
            Ingredients.Add(ingredient);
        }

        public void AddStep(Step step)
        {
            Steps.Add(step);
        }

        public void ScaleRecipe(double factor)
        {
            foreach (var ingredient in Ingredients)
            {
                ingredient.Scale(factor);
            }
        }

        public void ResetRecipe()
        {
            foreach (var ingredient in Ingredients)
            {
                ingredient.Reset();
            }
        }

        public double TotalCalories()
        {
            return Ingredients.Sum(i => i.Calories * (i.Quantity + i.Quantity));
        }

        public void Display()
        {
            Console.WriteLine($"Recipe: {Name}");
            Console.WriteLine("Ingredients:");
            foreach (var ingredient in Ingredients)
            {
                Console.WriteLine($"- {ingredient}");
            }
            Console.WriteLine("Steps:");
            for (int i = 0; i < Steps.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Steps[i]}");
            }
            double totalCalories = TotalCalories();
            Console.WriteLine($"Total Calories: {totalCalories}");
            if (totalCalories > 300)
            {
                Console.WriteLine("Warning: Total calories exceed 300!");
            }
        }
    }

    // RecipeManager class to handle multiple recipes
    class RecipeManager
    {
        private List<Recipe> recipes;

        public RecipeManager()
        {
            recipes = new List<Recipe>();
        }

        public void AddRecipe(Recipe recipe)
        {
            recipes.Add(recipe);
            recipes = recipes.OrderBy(r => r.Name).ToList(); // Sort recipes alphabetically by name
        }

        public void DisplayRecipes()
        {
            Console.WriteLine("Available Recipes:");
            for (int i = 0; i < recipes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {recipes[i].Name}");
            }
        }

        public Recipe GetRecipe(int index)
        {
            if (index >= 0 && index < recipes.Count)
            {
                return recipes[index];
            }
            return null;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            RecipeManager recipeManager = new RecipeManager();

            while (true)
            {
                Console.WriteLine("Recipe Management System");
                Console.WriteLine("1. Add a new recipe");
                Console.WriteLine("2. Display all recipes");
                Console.WriteLine("3. Display a specific recipe");
                Console.WriteLine("4. Scale a recipe");
                Console.WriteLine("5. Reset a recipe to original quantities");
                Console.WriteLine("6. Clear all data");
                Console.WriteLine("7. Exit");

                string input = Console.ReadLine();
                int choice;

                if (!int.TryParse(input, out choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 7.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        AddNewRecipe(recipeManager);
                        break;
                    case 2:
                        recipeManager.DisplayRecipes();
                        break;
                    case 3:
                        DisplaySpecificRecipe(recipeManager);
                        break;
                    case 4:
                        ScaleRecipe(recipeManager);
                        break;
                    case 5:
                        ResetRecipe(recipeManager);
                        break;
                    case 6:
                        recipeManager = new RecipeManager();
                        Console.WriteLine("All data cleared.");
                        break;
                    case 7:
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 7.");
                        break;
                }
            }
        }

        static void AddNewRecipe(RecipeManager recipeManager)
        {
            Console.Write("Enter recipe name: ");
            string recipeName = Console.ReadLine();
            Recipe recipe = new Recipe(recipeName);

            Console.Write("Enter the number of ingredients: ");
            int ingredientCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < ingredientCount; i++)
            {
                Console.Write($"Enter the name of ingredient {i + 1}: ");
                string name = Console.ReadLine();
                Console.Write($"Enter the quantity of {name}: ");
                double quantity = double.Parse(Console.ReadLine());
                Console.Write($"Enter the unit of measurement for {name}: ");
                string unit = Console.ReadLine();
                Console.Write($"Enter the calories for {name}: ");
                double calories = double.Parse(Console.ReadLine());
                Console.Write($"Enter the food group for {name}: ");
                string foodGroup = Console.ReadLine();
                Ingredient ingredient = new Ingredient(name, quantity, unit, calories, foodGroup);
                recipe.AddIngredient(ingredient);
            }

            Console.Write("Enter the number of steps: ");
            int stepCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < stepCount; i++)
            {
                Console.Write($"Enter description for step {i + 1}: ");
                string description = Console.ReadLine();
                Step step = new Step(description);
                recipe.AddStep(step);
            }

            recipeManager.AddRecipe(recipe);
            Console.WriteLine("Recipe added successfully!");
        }

        static void DisplaySpecificRecipe(RecipeManager recipeManager)
        {
            recipeManager.DisplayRecipes();
            Console.Write("Enter the number of the recipe to display: ");
            int recipeIndex = int.Parse(Console.ReadLine()) - 1;
            Recipe recipe = recipeManager.GetRecipe(recipeIndex);
            if (recipe != null)
            {
                recipe.Display();
            }
            else
            {
                Console.WriteLine("Invalid recipe number.");
            }
        }

        static void ScaleRecipe(RecipeManager recipeManager)
        {
            recipeManager.DisplayRecipes();
            Console.Write("Enter the number of the recipe to scale: ");
            int recipeIndex = int.Parse(Console.ReadLine()) - 1;
            Recipe recipe = recipeManager.GetRecipe(recipeIndex);
            if (recipe != null)
            {
                Console.WriteLine("Enter scale factor (0.5, 2, or 3): ");
                double factor = double.Parse(Console.ReadLine());
                recipe.ScaleRecipe(factor);
                recipe.Display();
            }
            else
            {
                Console.WriteLine("Invalid recipe number.");
            }
        }

        static void ResetRecipe(RecipeManager recipeManager)
        {
            recipeManager.DisplayRecipes();
            Console.Write("Enter the number of the recipe to reset: ");
            int recipeIndex = int.Parse(Console.ReadLine()) - 1;
            Recipe recipe = recipeManager.GetRecipe(recipeIndex);
            if (recipe != null)
            {
                recipe.ResetRecipe();
                recipe.Display();
            }
            else
            {
                Console.WriteLine("Invalid recipe number.");
            }
        }
    }
}
