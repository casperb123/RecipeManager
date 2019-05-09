CREATE PROCEDURE GetAllIngredientsFull
AS
BEGIN
SELECT
	Ingredients.Id,
	Ingredients.[Name],
	Ingredients.[Type],
	IngredientsInRecipe.RecipeId,
	IngredientsInRecipe.Amount,
	IngredientsInRecipe.Unit
FROM IngredientsInRecipe
LEFT JOIN Ingredients ON IngredientsInRecipe.IngredientId = Ingredients.Id
SET NOCOUNT ON
END