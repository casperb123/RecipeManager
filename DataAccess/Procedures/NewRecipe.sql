CREATE PROCEDURE NewRecipe
@Name VARCHAR(100),
@Description VARCHAR(500)
AS
BEGIN
INSERT INTO Recipes
	([Name], [Description])
OUTPUT Inserted.Id
VALUES
	(@Name, @Description)
SET NOCOUNT ON
END