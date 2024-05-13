CREATE  PROCEDURE CustomersUpdate
	@CustomerId INT,
	@Name VARCHAR(MAX) = NULL,
	@PhoneNumber VARCHAR(MAX) = NULL,	
	@ModifyBy VARCHAR(MAX) 
AS
/*
***********************************************************************************************
	Date   			Modified By   		Purpose of Modification
1	1ARP2024		Harshit Chilvirwar		Update from Customers
***********************************************************************************************
*/
BEGIN
	IF @Name IS NOT NULL
	BEGIN
	UPDATE Customers
	SET [Name] = @Name
	WHERE CustomerId = @CustomerId;
	END
 
	IF @PhoneNumber IS NOT NULL 
	BEGIN
	UPDATE Customers
	SET PhoneNumber = @PhoneNumber
	WHERE CustomerId = @CustomerId;
	END
 
	UPDATE Customers
	SET LastModifiedBy = @ModifyBy
	WHERE CustomerID = @CustomerID;

	
	UPDATE Customers
	SET  LastModifiedOn = GETDATE()
	WHERE CustomerID = @CustomerID;


END
 

