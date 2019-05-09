using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RecipeManager.Pages.Ingredients
{
    public class IndexModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<Ingredient> IngredientsInRecipe { get; set; }
        [BindProperty]
        public Ingredient Ingredient { get; set; }
        private IngredientRepository ingredientRepository;
        private RecipeRepository recipeRepository;
        private IngredientsInRecipeRepository ingredientsInRecipeRepository;

        public IndexModel()
        {
            ingredientRepository = new IngredientRepository();
            recipeRepository = new RecipeRepository();
            ingredientsInRecipeRepository = new IngredientsInRecipeRepository();
        }

        public void OnGet()
        {
            if (RecipeId == 0)
            {
                Ingredients = ingredientRepository.GetAllIngredients();
            }
            else
            {
                Recipe = recipeRepository.GetRecipe(RecipeId);
                List<Ingredient> ingredients = ingredientRepository.GetAllIngredientsFull();
                Ingredients = new List<Ingredient>();

                foreach (Ingredient ingredient in ingredients)
                {
                    if (ingredient.RecipeId == RecipeId)
                    {
                        Ingredients.Add(ingredient);
                    }
                }
            }
        }

        public IActionResult OnGetDelete(int id)
        {
            ingredientRepository.DeleteIngredient(id);

            return Redirect("/Ingredients/Index");
        }

        public IActionResult OnGetRemove(int id)
        {
            ingredientsInRecipeRepository.RemoveIngredientFromRecipe(id, RecipeId);

            return RedirectToPage("/Ingredients/Index", new { recipeId = RecipeId });
        }
    }
}