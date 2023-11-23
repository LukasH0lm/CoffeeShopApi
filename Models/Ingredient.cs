﻿namespace Models;

public class Ingredient
{
    public Guid IngredientID { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public decimal QuantityInStock { get; set; }
}