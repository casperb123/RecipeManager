﻿CREATE PROCEDURE DeleteRecipe
@Id INTEGER
AS
BEGIN
DELETE FROM Recipes WHERE Id = @Id
SET NOCOUNT ON
END