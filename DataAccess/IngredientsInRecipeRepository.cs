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

        public int RemoveIngredientFromRecipe(int ingredientId, int recipeId)
        {
            string sql = $"EXEC RemoveIngredientFromRecipe {ingredientId}, {recipeId};";

            return ExecuteNonQuery(sql);
        }
    }
}
