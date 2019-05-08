using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DataAccess
{
    public class IngredientsInRecipeRepository : CommonRepository
    {
        public void AddNewIngredientsInRecipe(List<Ingredient> ingredients, int recipeId)
        {
            DataTable dataTable = new DataTable("IngredientsInRecipe");

            dataTable.Columns.Add(new DataColumn("IngredientId", typeof(int)));
            dataTable.Columns.Add(new DataColumn("RecipeId", typeof(int)));

            foreach (Ingredient ingredient in ingredients)
            {
                dataTable.Rows.Add(ingredient.Id, recipeId);
            }

            BulkInsert(dataTable);
        }

        public int RemoveIngredientFromRecipe(int ingredientId, int recipeId)
        {
            string sql = $"EXEC RemoveIngredientFromRecipe {ingredientId}, {recipeId};";

            return ExecuteNonQuery(sql);
        }
    }
}
