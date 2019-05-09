﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class Ingredient
    {
        private int id;
        private int recipeId;
        private string name;
        private int amount;
        private IngredientType type;
        private Unit unit;

        public Unit Unit
        {
            get { return unit; }
            set { unit = value; }
        }

        [Required]
        public IngredientType Type
        {
            get { return type; }
            set { type = value; }
        }

        [Range(1, int.MaxValue, ErrorMessage = "The amount can't be less than 1")]
        public int Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        [Required]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int RecipeId
        {
            get { return recipeId; }
            set { recipeId = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

    }
}
