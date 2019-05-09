CREATE PROCEDURE [AddNewIngredientInRecipe]
@IngredientId INTEGER,
@RecipeId INTEGER,
@Amount INTEGER,
@Unit INTEGER
AS
BEGIN
INSERT INTO IngredientsInRecipe
	(IngredientId, RecipeId, Amount, Unit)
VALUES
	(@IngredientId, @RecipeId, @Amount, @Unit)
SET NOCOUNT ON
END