using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DataAccess
{
    public class IngredientRepository : CommonRepository
    {
        /// <summary>
        /// Returns a list with all the ingredients including the recipe details
        /// </summary>
        /// <returns>List of ingredients</returns>
        public List<Ingredient> GetAllIngredientsFull()
        {
            List<Ingredient> ingredients = new List<Ingredient>();

            string sql = "EXEC GetAllIngredientsFull;";

            DataTable dataTable = ExecuteQuery(sql);

            foreach (DataRow row in dataTable.Rows)
            {
                if (int.TryParse(row["Amount"].ToString(), out int amount))
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
                else
                {
                    Ingredient ingredient = new Ingredient()
                    {
                        Id = (int)row["Id"],
                        Name = (string)row["Name"],
                        Type = (IngredientType)(int)row["Type"]
                    };

                    ingredients.Add(ingredient);
                }
            }

            return ingredients;
        }

        /// <summary>
        /// Returns a list with all the ingredients
        /// </summary>
        /// <returns>List of ingredients</returns>
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

        /// <summary>
        /// Returns a ingredient with the given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Ingredient</returns>
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

        /// <summary>
        /// Returns a ingredient including the recipe details with the given id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="recipeId"></param>
        /// <returns>Ingredient</returns>
        public Ingredient GetIngredientFull(int id, int recipeId)
        {
            string sql = $"EXEC GetIngredientFull {id}, {recipeId};";

            DataTable dataTable = ExecuteQuery(sql);

            foreach (DataRow row in dataTable.Rows)
            {
                Ingredient ingredient = new Ingredient()
                {
                    Id = (int)row["Id"],
                    Name = (string)row["Name"],
                    Type = (IngredientType)(int)row["Type"],
                    RecipeId = (int)row["RecipeId"],
                    Amount = (int)row["Amount"],
                    Unit = (Unit)(int)row["Unit"]
                };

                return ingredient;
            }

            return null;
        }

        /// <summary>
        /// Deletes a ingredient with the given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Rows affected</returns>
        public int DeleteIngredient(int id)
        {
            string sql = $"EXEC DeleteIngredient {id};";

            return ExecuteNonQuery(sql);
        }

        /// <summary>
        /// Inserts a ingredient
        /// </summary>
        /// <param name="ingredient"></param>
        /// <returns>Rows affected</returns>
        public int NewIngredient(Ingredient ingredient)
        {
            string sql = $"EXEC NewIngredient {ingredient.Name}, {(int)ingredient.Type};";

            return ExecuteNonQueryScalar(sql);
        }

        /// <summary>
        /// Updates a ingredient
        /// </summary>
        /// <param name="ingredient"></param>
        /// <returns>Rows affected</returns>
        public int UpdateIngredient(Ingredient ingredient)
        {
            string sql = $"EXEC UpdateIngredient {ingredient.Id}, '{ingredient.Name}', {(int)ingredient.Type}";

            return ExecuteNonQuery(sql);
        }

        /// <summary>
        /// Returns a list with all the ingredients in a recipe
        /// </summary>
        /// <param name="id"></param>
        /// <returns>List of ingredients</returns>
        public List<Ingredient> GetIngredientsInRecipe(int id)
        {
            string sql = $"EXEC GetIngredientsInRecipe {id};";

            List<Ingredient> ingredients = new List<Ingredient>();
            DataTable dataTable = ExecuteQuery(sql);

            foreach (DataRow row in dataTable.Rows)
            {
                if (int.TryParse(row["Amount"].ToString(), out int amount))
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
                else
                {
                    Ingredient ingredient = new Ingredient()
                    {
                        Id = (int)row["Id"],
                        Name = (string)row["Name"],
                        Type = (IngredientType)(int)row["Type"]
                    };

                    ingredients.Add(ingredient);
                }
            }

            return ingredients;
        }
    }
}
