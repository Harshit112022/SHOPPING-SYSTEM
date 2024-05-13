CREATE PROCEDURE CustomersDelete
@CustomerId INT

/*
***********************************************************************************************
	Date   			Modified By   		Purpose of Modification
1	1Jan2020		Anuja Bhatkar		Delete record from Tags
***********************************************************************************************
TagsDelete 1

*/

	
AS
BEGIN

	UPDATE Customers
	SET IsActive = 0 
	WHERE
	CustomerId = @CustomerId

END

GO