CREATE or alter PROCEDURE CustomersGetList

/*
***********************************************************************************************
	Date   			Modified By   		Purpose of Modification
1	4ARP2024		Harshit Chilvirwar		Get List for Customers
***********************************************************************************************
CustomersGetList

*/

AS
BEGIN

	SELECT 
	
		ISNULL([Name], '') AS Name,
		ISNULL([Address], '') AS [Address],
		ISNULL(PhoneNumber, '') AS PhoneNumber		
	FROM
		Customers
	

	
END


GO
select * from Customers