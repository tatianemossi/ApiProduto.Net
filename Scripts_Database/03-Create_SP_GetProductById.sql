﻿SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetProductById]
(@ID INT)
AS
BEGIN
SET NOCOUNT ON
SELECT Id, CreatedAt, Name, Price, Brand, UpdateAt 
FROM Product
WHERE Id = @ID
 
END
GO