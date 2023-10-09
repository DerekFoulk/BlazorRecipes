﻿using BlazorRecipes.Shared.Recipes;

namespace BlazorRecipes.Client.Services
{
    public interface IRecipeService
    {
        Task<IEnumerable<Recipe>?> GetAllRecipesAsync();
    }
}