CREATE PROCEDURE RemoveIngredientFromRecipe
@IngredientId INTEGER,
@RecipeId INTEGER
AS
BEGIN
DELETE FROM IngredientsInRecipe WHERE IngredientId = @IngredientId AND RecipeId = @RecipeId
SET NOCOUNT ON
END