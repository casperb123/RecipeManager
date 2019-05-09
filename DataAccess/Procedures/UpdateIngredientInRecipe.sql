CREATE PROCEDURE UpdateIngredientInRecipe
@IngredientId INTEGER,
@RecipeId INTEGER,
@Amount INTEGER,
@Unit INTEGER
AS
BEGIN
UPDATE IngredientsInRecipe SET
	Amount = @Amount,
	Unit = @Unit
WHERE IngredientId = @IngredientId AND RecipeId = @RecipeId
SET NOCOUNT ON
END