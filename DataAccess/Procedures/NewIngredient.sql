CREATE PROCEDURE NewIngredient
@Name VARCHAR(100),
@Type INTEGER
AS
BEGIN
INSERT INTO Ingredients
	([Name], [Type])
OUTPUT Inserted.Id
VALUES
	(@Name, @Type)
SET NOCOUNT ON
END