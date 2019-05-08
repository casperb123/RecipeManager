CREATE PROCEDURE GetIngredientsInRecipe
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
INNER JOIN Ingredients ON IngredientsInRecipe.IngredientId = Ingredients.Id
WHERE RecipeId = @Id
SET NOCOUNT ON
END