CREATE PROC GetIngredient
@Id INTEGER
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
WHERE Ingredients.Id = @Id
SET NOCOUNT ON
END