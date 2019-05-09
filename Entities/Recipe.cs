using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class Recipe
    {
        private string name;
        private string description;
        private int id;
        private List<Ingredient> ingredients = new List<Ingredient>();

        public List<Ingredient> Ingredients
        {
            get { return ingredients; }
            set { ingredients = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [Required(ErrorMessage = "The description can't be empty")]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        [Required(ErrorMessage = "The name can't be empty")]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int NumberOfIngredients
        {
            get
            {
                if (Ingredients is null)
                {
                    return 0;
                }

                return Ingredients.Count;
            }
        }
    }
}
