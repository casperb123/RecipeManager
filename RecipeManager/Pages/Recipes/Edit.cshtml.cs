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
    public class EditModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int RecipeId { get; set; }
        [BindProperty]
        public Recipe Recipe { get; set; }
        private RecipeRepository recipeRepository;

        public EditModel()
        {
            recipeRepository = new RecipeRepository();
        }

        public void OnGet()
        {
            Recipe = recipeRepository.GetRecipe(RecipeId);
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                recipeRepository.UpdateRecipe(Recipe);

                return Redirect("./Index");
            }

            return Page();
        }
    }
}