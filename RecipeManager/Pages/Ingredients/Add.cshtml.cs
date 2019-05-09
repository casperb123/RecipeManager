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
    public class AddModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "You need to choose a ingredient")]
        public int IngredientId { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "You need to write an amount")]
        [Range(1, int.MaxValue, ErrorMessage = "The amount can't be less than 1")]
        public int Amount { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "You need to pick a unit type")]
        public Unit Unit { get; set; }
        public List<Ingredient> IngredientsInRecipe { get; set; }
        public List<Ingredient> IngredientsNotInRecipe { get; set; }
        private IngredientRepository ingredientRepository;
        private RecipeRepository recipeRepository;
        private IngredientsInRecipeRepository ingredientsInRecipeRepository;

        public AddModel()
        {
            ingredientRepository = new IngredientRepository();
            recipeRepository = new RecipeRepository();
            ingredientsInRecipeRepository = new IngredientsInRecipeRepository();
        }

        public void OnGet()
        {
            Recipe = recipeRepository.GetRecipe(RecipeId);
            IngredientsNotInRecipe = ingredientRepository.GetAllIngredients();
            IngredientsInRecipe = ingredientRepository.GetIngredientsInRecipe(RecipeId);

            var idsInRecipe = IngredientsInRecipe.Select(x => x.Id);
            IngredientsNotInRecipe.RemoveAll(x => idsInRecipe.Contains(x.Id));
        }
        
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                Recipe = new Recipe();
                IngredientsNotInRecipe = new List<Ingredient>();

                Ingredient ingredient = ingredientRepository.GetIngredient(IngredientId);

                ingredient.RecipeId = RecipeId;
                ingredient.Amount = Amount;
                ingredient.Unit = Unit;

                ingredientsInRecipeRepository.AddNewIngredientInRecipe(ingredient);

                return Redirect("/Recipes/Index");
            }

            Recipe = recipeRepository.GetRecipe(RecipeId);
            IngredientsNotInRecipe = ingredientRepository.GetAllIngredients();
            IngredientsInRecipe = ingredientRepository.GetIngredientsInRecipe(RecipeId);

            var idsInRecipe = IngredientsInRecipe.Select(x => x.Id);
            IngredientsNotInRecipe.RemoveAll(x => idsInRecipe.Contains(x.Id));

            return Page();
        }
    }
}