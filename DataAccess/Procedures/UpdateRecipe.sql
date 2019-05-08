CREATE PROCEDURE UpdateRecipe
@Id INTEGER,
@Name VARCHAR(100),
@Description VARCHAR(500)
AS
BEGIN
UPDATE Recipes SET
	[Name] = @Name,
	[Description] = @Description 
WHERE Id = @Id
SET NOCOUNT ON
END