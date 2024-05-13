CREATE or	ALTER PROCEDURE ProductCategoriesInsert
@ProductCategorieId INT OUTPUT,
@Name VARCHAR (MAX)
/*
***********************************************************************************************
	Date   			Modified By			   	Purpose of Modification
1	4ARP2024		Harshit Chilvirwar		Insert ProductCategories
***********************************************************************************************
*/

AS
BEGIN


	INSERT INTO ProductCategories
	(
		[Name],
		IsActive,
		CreatedBy,
		CreatedOn
		
	)
	VALUES
	(
		@Name,
		1,
		'admin',
		GETDATE()		
	)

	SET @ProductCategorieId = @@IDENTITY;
END

GO


DECLARE @VAR INT
Execute ProductCategoriesInsert @VAR output ,'shirt'
print @VAR
