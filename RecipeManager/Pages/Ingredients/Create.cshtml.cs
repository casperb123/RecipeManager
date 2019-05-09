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
        [BindProperty]
        public Ingredient Ingredient { get; set; }
        private IngredientRepository ingredientRepository;

        public CreateModel()
        {
            ingredientRepository = new IngredientRepository();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                ingredientRepository.NewIngredient(Ingredient);

                return Redirect("./Index");
            }

            return Page();
        }
    }
}