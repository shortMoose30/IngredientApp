

using System;

class Ingredient
{
    public string Name { get; set; }
    public double Quantity { get; set; }
    public string Unit { get; set; }
}

class Step
{
    public string Description { get; set; }
}

class RecipeApp
{
    private Ingredient[] ingredients;
    private Step[] steps;

    public void EnterRecipeDetails()
    {
        Console.Write("Enter the number of ingredients: ");
        int numIngredients = Convert.ToInt32(Console.ReadLine());
        ingredients = new Ingredient[numIngredients];

        for (int i = 0; i < numIngredients; i++)
        {
            ingredients[i] = new Ingredient();

            Console.Write($"Enter the name of ingredient {i + 1}: ");
            ingredients[i].Name = Console.ReadLine();

            Console.Write($"Enter the quantity of {ingredients[i].Name}: ");
            ingredients[i].Quantity = Convert.ToDouble(Console.ReadLine());

            Console.Write($"Enter the unit of measurement for {ingredients[i].Name}: ");
            ingredients[i].Unit = Console.ReadLine();
        }

        Console.Write("Enter the number of steps: ");
        int numSteps = Convert.ToInt32(Console.ReadLine());
        steps = new Step[numSteps];

        for (int i = 0; i < numSteps; i++)
        {
            steps[i] = new Step();

            Console.Write($"Enter step {i + 1}: ");
            steps[i].Description = Console.ReadLine();
        }
    }

  
