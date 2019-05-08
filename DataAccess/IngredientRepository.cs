using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DataAccess
{
    public class IngredientRepository : CommonRepository
    {
        public List<Ingredient> GetAllIngredientsFull()
        {
            List<Ingredient> ingredients = new List<Ingredient>();

            string sql = "EXEC GetAllIngredientsFull;";

            DataTable dataTable = ExecuteQuery(sql);

            foreach (DataRow row in dataTable.Rows)
            {
                Ingredient ingredient = new Ingredient()
                {
                    Id = (int)row["Id"],
                    RecipeId = (int)row["RecipeId"],
                    Name = (string)row["Name"],
                    Amount = (int)row["Amount"],
                    Type = (IngredientType)(int)row["Type"],
                    Unit = (Unit)(int)row["Unit"]
                };

                ingredients.Add(ingredient);
            }

            return ingredients;
        }

        public List<Ingredient> GetAllIngredients()
        {
            List<Ingredient> ingredients = new List<Ingredient>();

            string sql = "EXEC GetAllIngredients;";

            DataTable dataTable = ExecuteQuery(sql);

            foreach (DataRow row in dataTable.Rows)
            {
                Ingredient ingredient = new Ingredient()
                {
                    Id = (int)row["Id"],
                    Name = (string)row["Name"],
                    Type = (IngredientType)(int)row["Type"]
                };

                ingredients.Add(ingredient);
            }

            return ingredients;
        }

        public Ingredient GetIngredient(int id)
        {
            string sql = $"EXEC GetIngredient {id};";

            DataTable dataTable = ExecuteQuery(sql);

            foreach (DataRow row in dataTable.Rows)
            {
                Ingredient ingredient = new Ingredient()
                {
                    Id = (int)row["Id"],
                    Name = (string)row["Name"],
                    Type = (IngredientType)(int)row["Type"]
                };

                return ingredient;
            }

            return null;
        }

        public int DeleteIngredient(int id)
        {
            string sql = $"EXEC DeleteIngredient {id};";

            return ExecuteNonQuery(sql);
        }

        public int NewIngredient(Ingredient ingredient)
        {
            string sql = $"EXEC NewIngredient {ingredient.Name}, {ingredient.Type};";

            return ExecuteNonQueryScalar(sql);
        }

        public int UpdateIngredient(Ingredient ingredient)
        {
            string sql = $"EXEC UpdateIngredient {ingredient.Id}, '{ingredient.Name}', {ingredient.Type}";

            return ExecuteNonQuery(sql);
        }

        public List<Ingredient> GetIngredientsInRecipe(int id)
        {
            string sql = $"EXEC GetIngredientsInRecipe {id};";

            List<Ingredient> ingredients = new List<Ingredient>();
            DataTable dataTable = ExecuteQuery(sql);

            foreach (DataRow row in dataTable.Rows)
            {
                Ingredient ingredient = new Ingredient()
                {
                    Id = (int)row["Id"],
                    RecipeId = (int)row["RecipeId"],
                    Name = (string)row["Name"],
                    Amount = (int)row["Amount"],
                    Type = (IngredientType)(int)row["Type"],
                    Unit = (Unit)(int)row["Unit"]
                };

                ingredients.Add(ingredient);
            }

            return ingredients;
        }
    }
}
