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
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Recipe Recipe { get; set; }
        private RecipeRepository recipeRepository;

        public CreateModel()
        {
            recipeRepository = new RecipeRepository();
        }

        public void OnGet()
        {

        }
    }
}