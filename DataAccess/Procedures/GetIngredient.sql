﻿CREATE PROCEDURE GetIngredient
@Id INTEGER
AS
BEGIN
SELECT * FROM Ingredients WHERE Id = @Id
SET NOCOUNT ON
END