using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DataAccess
{
    public class IngredientsInRecipeRepository : CommonRepository
    {
        public int AddNewIngredientInRecipe(Ingredient ingredient)
        {
            string sql = $"EXEC AddNewIngredientInRecipe {ingredient.Id}, {ingredient.RecipeId}, {ingredient.Amount}, {(int)ingredient.Unit};";

            return ExecuteNonQuery(sql);
        }

        public int RemoveIngredientFromRecipe(int ingredientId, int recipeId)
        {
            string sql = $"EXEC RemoveIngredientFromRecipe {ingredientId}, {recipeId};";

            return ExecuteNonQuery(sql);
        }

        public int UpdateIngredientInRecipe(Ingredient ingredient)
        {
            string sql = $"EXEC UpdateIngredientInRecipe {ingredient.Id}, {ingredient.RecipeId}, {ingredient.Amount}, {(int)ingredient.Unit};";

            return ExecuteNonQuery(sql);
        }
    }
}
