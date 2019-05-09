using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RecipeManager.Pages.Recipes
{
    public class IndexModel : PageModel
    {
        public List<Recipe> Recipes { get; set; }
        private RecipeRepository recipeRepository;

        public IndexModel()
        {
            recipeRepository = new RecipeRepository();
        }

        public void OnGet()
        {
            Recipes = recipeRepository.GetAllRecipesWithIngredients();
        }

        public IActionResult OnGetDelete(int id)
        {
            recipeRepository.DeleteRecipe(id);

            return Redirect("/Recipes/Index");
        }
    }
}