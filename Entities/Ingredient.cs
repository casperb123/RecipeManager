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

        [Required(ErrorMessage = "You need to choose a ingredient type")]
        public IngredientType Type
        {
            get { return type; }
            set { type = value; }
        }

        public int Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        [Required(ErrorMessage = "The name can't be empty")]
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
