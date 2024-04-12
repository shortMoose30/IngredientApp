

using System;

// Class to represent an ingredient in a recipe
class Ingredient
{
    public string Name { get; set; } // Name of the ingredient
    public double Quantity { get; set; } // Quantity of the ingredient
    public string Unit { get; set; } // Unit of measurement for the ingredientyuu
}

// Class to represent a step in a recipe
class Step
{
    public string Description { get; set; } // Description of the step
}

// Class to manage recipe details and operations
class RecipeApp
{
    private Ingredient[] ingredients; // Array to store ingredients
    private Step[] steps; // Array to store steps

    // Method to enter recipe details
    public void EnterRecipeDetails()
    {
        Console.Write("Enter the number of ingredients: ");
        int numIngredients = Convert.ToInt32(Console.ReadLine());
        ingredients = new Ingredient[numIngredients]; // Initialize ingredients array

        // Loop to input details for each ingredient
        for (int i = 0; i < numIngredients; i++)
        {
            ingredients[i] = new Ingredient(); // Initialize new ingredient object

            // Prompt user for ingredient name, quantity, and unit
            Console.Write($"Enter the name of ingredient {i + 1}: ");
            ingredients[i].Name = Console.ReadLine();

            Console.Write($"Enter the quantity of {ingredients[i].Name}: ");
            ingredients[i].Quantity = Convert.ToDouble(Console.ReadLine());

            Console.Write($"Enter the unit of measurement for {ingredients[i].Name}: ");
            ingredients[i].Unit = Console.ReadLine();
        }

        Console.Write("Enter the number of steps: ");
        int numSteps = Convert.ToInt32(Console.ReadLine());
        steps = new Step[numSteps]; // Initialize steps array

        // Loop to input details for each step
        for (int i = 0; i < numSteps; i++)
        {
            steps[i] = new Step(); // Initialize new step object

            // Prompt user for step description
            Console.Write($"Enter step {i + 1}: ");
            steps[i].Description = Console.ReadLine();
        }
    }

    // Method to display the recipe
    public void DisplayRecipe()
    {
        Console.WriteLine("\nRecipe:");
        Console.WriteLine("Ingredients:");

        // Display each ingredient with its quantity and unit
        foreach (Ingredient ingredient in ingredients)
        {
            Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name}");
        }
        Console.WriteLine("\nSteps:");

        // Display each step
        for (int i = 0; i < steps.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {steps[i].Description}");
        }
    }
    // Method to scale the recipe by a given factor
    public void ScaleRecipe(double factor)
    {
        // Scale the quantity of each ingredient
        foreach (Ingredient ingredient in ingredients)
        {
            ingredient.Quantity *= factor;
        }
    }
    // Method to reset ingredient quantities by re-entering details
    public void ResetQuantities()
    {
        EnterRecipeDetails();
    }

    // Method to clear all data
    public void ClearData()
    {
        ingredients = null; // Clear ingredients array
        steps = null; // Clear steps array
    }
}

// Main program class
class Program
{
    // Main method
    static void Main(string[] args)
    {
        RecipeApp recipeApp = new RecipeApp(); // Initialize RecipeApp object
        bool running = true














