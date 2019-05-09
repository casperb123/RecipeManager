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
        [BindProperty]
        public Ingredient Ingredient { get; set; }
        private IngredientRepository ingredientRepository;

        public EditModel()
        {
            ingredientRepository = new IngredientRepository();
        }

        public void OnGet()
        {
            Ingredient = ingredientRepository.GetIngredient(Id);
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                ingredientRepository.UpdateIngredient(Ingredient);

                return Redirect("./Index");
            }

            return Page();
        }
    }
}