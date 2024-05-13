CREATE PROCEDURE CustomersInsert

@CustomersId INT OUTPUT,
@Name VARCHAR (MAX),
@Address VARCHAR(MAX),
@PhoneNumber VARCHAR(MAX)


/*
***********************************************************************************************
	Date   			Modified By   	Purpose of Modification
1	1Jan2020		Anuja Bhatkar	Insert Tags
***********************************************************************************************
*/

AS
BEGIN


	INSERT INTO Customers
	(
	
		[Name],
		[Address],
		PhoneNumber,
		IsActive,
		CreatedBy,
		CreatedOn
		
	)
	VALUES
	(
		@Name,
		@Address,
		@PhoneNumber,
		1,
		'admin',
		GETDATE()
		
	)

	SET @CustomersId = @@IDENTITY;
END

GO
