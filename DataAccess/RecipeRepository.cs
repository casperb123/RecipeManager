using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DataAccess
{
    public class RecipeRepository : CommonRepository
    {
        public List<Recipe> GetAllRecipesWithIngredients()
        {
            IngredientRepository ingredientRepository = new IngredientRepository();

            List<Ingredient> ingredients = ingredientRepository.GetAllIngredientsFull();
            List<Recipe> recipes = GetAllRecipes();

            foreach (Recipe recipe in recipes)
            {
                foreach (Ingredient ingredient in ingredients)
                {
                    if (ingredient.RecipeId == recipe.Id)
                    {
                        recipe.Ingredients.Add(ingredient);
                    }
                }
            }

            return recipes;
        }

        public int DeleteRecipe(int id)
        {
            string sql = $"EXEC DeleteRecipe {id};";

            return ExecuteNonQuery(sql);
        }

        public Recipe GetRecipe(int id)
        {
            string sql = $"EXEC GetRecipe {id};";

            DataTable dataTable = ExecuteQuery(sql);

            foreach (DataRow row in dataTable.Rows)
            {
                Recipe recipe = new Recipe()
                {
                    Id = (int)row["Id"],
                    Name = (string)row["Name"],
                    Description = (string)row["Description"]
                };

                return recipe;
            }

            return null;
        }

        public List<Recipe> GetAllRecipes()
        {
            List<Recipe> recipes = new List<Recipe>();

            string sql = "EXEC GetAllRecipes;";

            DataTable dataTable = ExecuteQuery(sql);

            foreach (DataRow row in dataTable.Rows)
            {
                Recipe recipe = new Recipe()
                {
                    Id = (int)row["Id"],
                    Name = (string)row["Name"],
                    Description = (string)row["Description"]
                };

                recipes.Add(recipe);
            }

            return recipes;
        }

        public int NewRecipe(Recipe recipe)
        {
            string sql = $"EXEC NewRecipe '{recipe.Name}', '{recipe.Description}';";

            return ExecuteNonQueryScalar(sql);
        }

        public int UpdateRecipe(Recipe recipe)
        {
            string sql = $"EXEC UpdateRecipe {recipe.Id}, '{recipe.Name}', '{recipe.Description}';";

            return ExecuteNonQuery(sql);
        }
    }
}
