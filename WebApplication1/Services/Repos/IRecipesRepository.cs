﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public interface IRecipesRepository :IDisposable
    {
        IEnumerable<Recipe> GetRecipes();
        Recipe GetRecipeById(int id);
        void AddOrUpdateRecipe(Recipe recipe);
        void DeleteRecipe(Recipe recipe);
        void Save();
    }
}
