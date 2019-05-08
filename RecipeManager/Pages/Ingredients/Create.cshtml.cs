using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RecipeManager.Pages.Ingredients
{
    public class CreateModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
        [BindProperty]
        public Ingredient Ingredient { get; set; }
        [BindProperty]
        [Required]
        public int IngredientId { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<Ingredient> IngredientsInRecipe { get; set; }
        public List<Ingredient> IngredientsNotInRecipe { get; set; }
        private IngredientRepository ingredientRepository;
        private IngredientsInRecipeRepository ingredientsInRecipeRepository;
        private RecipeRepository recipeRepository;

        public CreateModel()
        {
            ingredientRepository = new IngredientRepository();
            ingredientsInRecipeRepository = new IngredientsInRecipeRepository();
            recipeRepository = new RecipeRepository();
        }

        public void OnGet()
        {
            if (RecipeId == 0)
            {
                Ingredients = ingredientRepository.GetAllIngredients();
            }
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                ingredientRepository.NewIngredient(Ingredient);

                if (RecipeId == 0)
                {
                    return Redirect("./Index");
                }

                List<int> ingredients = new List<int>() { Ingredient.Id };

                ingredientsInRecipeRepository.AddNewIngredientsInRecipe(ingredients, RecipeId);

                return RedirectToPage("./Index", new { recipeId = RecipeId });
            }

            return Page();
        }
    }
}