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
        private List<Ingredient> ingredients;

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

        [Required]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        [Required]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

    }
}
