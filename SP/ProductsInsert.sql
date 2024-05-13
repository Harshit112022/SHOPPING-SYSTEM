CREATE OR ALTER PROCEDURE ProductsInsert

@ProductsId INT OUTPUT,
@Name VARCHAR (MAX),
@ProductCategoriesId INT,
@ProductPrice INT
/*
***********************************************************************************************
	Date   			Modified By   	Purpose of Modification
1	1Jan2020		Anuja Bhatkar	Insert Tags
***********************************************************************************************
*/

AS
BEGIN


	INSERT INTO Products
	(
		[Name],
		ProductCategoriesId,
		IsActive,
		CreatedBy,
		CreatedOn
	)
	VALUES
	(
		@Name,
		@ProductCategoriesId,
		1,
		'admin',
		GETDATE()
		
	)

	SET @ProductsId = @@IDENTITY;
END

GO

EXECUTE ProductsInsert