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
        [Required(ErrorMessage = "You need to choose one or more ingredients")]
        public int IngredientId { get; set; }
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
            IngredientsInRecipe = ingredientRepository.GetIngredientsInRecipe(RecipeId);
            IngredientsNotInRecipe = ingredientRepository.GetAllIngredientsFull();

            var idsInRecipe = IngredientsInRecipe.Select(x => x.Id);
            IngredientsNotInRecipe.RemoveAll(x => idsInRecipe.Contains(x.Id));
        }
        
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                List<string> idsTxt = Request.Form["Id"].ToList();
                List<int> ids = new List<int>();

                foreach (string idTxt in idsTxt)
                {
                    ids.Add(int.Parse(idTxt));
                }

                ingredientsInRecipeRepository.AddNewIngredientsInRecipe(ids, RecipeId);

                return Redirect("./Index");
            }

            return Page();
        }
    }
}