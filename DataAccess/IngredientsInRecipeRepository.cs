using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DataAccess
{
    public class IngredientsInRecipeRepository : CommonRepository
    {
        /// <summary>
        /// Adds a new ingredient to a recipe
        /// </summary>
        /// <param name="ingredient"></param>
        /// <returns>Rows affected</returns>
        public int AddNewIngredientInRecipe(Ingredient ingredient)
        {
            string sql = $"EXEC AddNewIngredientInRecipe {ingredient.Id}, {ingredient.RecipeId}, {ingredient.Amount}, {(int)ingredient.Unit};";

            return ExecuteNonQuery(sql);
        }

        /// <summary>
        /// Removes a ingredient from a recipe
        /// </summary>
        /// <param name="ingredientId"></param>
        /// <param name="recipeId"></param>
        /// <returns>Rows affected</returns>
        public int RemoveIngredientFromRecipe(int ingredientId, int recipeId)
        {
            string sql = $"EXEC RemoveIngredientFromRecipe {ingredientId}, {recipeId};";

            return ExecuteNonQuery(sql);
        }

        /// <summary>
        /// Updates a ingredient in a recipe
        /// </summary>
        /// <param name="ingredient"></param>
        /// <returns>Rows affected</returns>
        public int UpdateIngredientInRecipe(Ingredient ingredient)
        {
            string sql = $"EXEC UpdateIngredientInRecipe {ingredient.Id}, {ingredient.RecipeId}, {ingredient.Amount}, {(int)ingredient.Unit};";

            return ExecuteNonQuery(sql);
        }
    }
}
