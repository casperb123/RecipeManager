CREATE PROCEDURE UpdateIngredient
@Id INTEGER,
@Name VARCHAR(100),
@Type INTEGER
AS
BEGIN
UPDATE Ingredients SET 
	[Name] = @Name, [Type] = @Type
WHERE Id = @Id
SET NOCOUNT ON
END