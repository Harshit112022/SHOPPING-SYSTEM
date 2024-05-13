CREATE PROCEDURE CustomersGetDetails

@CustomerId INT

/*
***********************************************************************************************
	Date   			Modified By   			Purpose of Modification
1	1ARP2024	Harshit Chilvirwar			Get List from Customers
***********************************************************************************************

CustomersGetDetails 1 

*/


AS
BEGIN


	SELECT
			ISNULL([Name], '') AS Name,
		ISNULL([Address], '') AS [Address],
		ISNULL(PhoneNumber, '') AS PhoneNumber		
	FROM
		Customers
	WHERE
		CustomerId = @CustomerId


END


GO