using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DataAccess
{
    public class IngredientsInRecipeRepository : CommonRepository
    {
        public void AddNewIngredientsInRecipe(List<int> ids, int recipeId)
        {
            DataTable dataTable = new DataTable("IngredientsInRecipe");

            dataTable.Columns.Add(new DataColumn("IngredientId", typeof(int)));
            dataTable.Columns.Add(new DataColumn("RecipeId", typeof(int)));

            foreach (int id in ids)
            {
                dataTable.Rows.Add(id, recipeId);
            }

            BulkInsert(dataTable);
        }

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
    }
}
