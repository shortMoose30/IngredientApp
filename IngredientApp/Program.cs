﻿

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








