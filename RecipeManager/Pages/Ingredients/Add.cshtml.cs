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
        public int Amount { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "You need to pick a unit type")]
        public Unit Unit { get; set; }
        //[BindProperty]
        //[Required(ErrorMessage = "You need to choose one or more ingredients")]
        //public IEnumerable<string> IngredientId { get; set; }
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
                //List<string> idsTxt = Request.Form["IngredientId"].ToList();
                //IngredientId = IngredientId.ToList();

                //List<int> Ids = new List<int>();

                //foreach (string idTxt in IngredientId)
                //{
                //    Ids.Add(int.Parse(idTxt));
                //}

                Ingredient ingredient = ingredientRepository.GetIngredient(IngredientId);

                ingredient.RecipeId = RecipeId;
                ingredient.Amount = Amount;
                ingredient.Unit = Unit;

                ingredientsInRecipeRepository.AddNewIngredientInRecipe(ingredient);

                //ingredientsInRecipeRepository.AddNewIngredientsInRecipe(ids, RecipeId);

                return RedirectToPage("./Index", new { recipeId = RecipeId });
            }

            return Page();
        }
    }
}