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
    public class EditModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        [BindProperty(SupportsGet = true)]
        public int ExistingId { get; set; }
        [BindProperty]
        public Ingredient Ingredient { get; set; }
        public Unit Unit { get; set; }
        public int Amount { get; set; }
        private IngredientRepository ingredientRepository;
        private IngredientsInRecipeRepository ingredientsInRecipeRepository;

        public EditModel()
        {
            ingredientRepository = new IngredientRepository();
            ingredientsInRecipeRepository = new IngredientsInRecipeRepository();
        }

        public void OnGet()
        {
            if (ExistingId > 0)
            {
                Ingredient = ingredientRepository.GetIngredient(ExistingId);
            }
            else
            {
                Ingredient = ingredientRepository.GetIngredient(Id);
            }
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Ingredient.Amount > 0)
                {
                    ingredientsInRecipeRepository.UpdateIngredientInRecipe(Ingredient);

                    return RedirectToPage("./Index", new { recipeId = ExistingId });
                }

                ingredientRepository.UpdateIngredient(Ingredient);

                return Redirect("./Index");
            }

            if (ExistingId > 0)
            {
                Ingredient = ingredientRepository.GetIngredient(ExistingId);
            }
            else
            {
                Ingredient = ingredientRepository.GetIngredient(Id);
            }

            return Page();
        }
    }
}