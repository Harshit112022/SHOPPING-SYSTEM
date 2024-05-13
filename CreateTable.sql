CREATE TABLE ProductCategories
(
	ProductCategoriesId INT PRIMARY KEY IDENTITY(1,1),
	[Name] VARCHAR (MAX),
	IsActive BIT,
	CreatedBy VARCHAR (MAX),
	CreatedOn DATETIME,
	LastModifiedBy VARCHAR (MAX),
	LastModifiedOn DATETIME
)

Go


CREATE TABLE Products
(
	ProductId INT PRIMARY KEY IDENTITY(1,1),
	[Name] VARCHAR (MAX),
	ProductCategoriesId INT FOREIGN KEY REFERENCES ProductCategories(ProductCategoriesId),
	IsActive BIT,
	CreatedBy VARCHAR (MAX),
	CreatedOn DATETIME,
	LastModifiedBy VARCHAR (MAX),
	LastModifiedOn DATETIME
)
 ALTER TABLE Products
ADD ProductPrice INT;


GO


CREATE TABLE Customers
(
	CustomerId INT PRIMARY KEY IDENTITY(1,1),
	[Name] VARCHAR (MAX),
	[Address] VARCHAR(MAX),
	[PhoneNumber] VARCHAR(MAX),
	IsActive BIT,
	CreatedBy VARCHAR (MAX),
	CreatedOn DATETIME,
	LastModifiedBy VARCHAR (MAX),
	LastModifiedOn DATETIME
)
GO

CREATE TABLE SaleOrders
(
	SaleOrderId INT PRIMARY KEY IDENTITY(1,1),
	CustomersId INT FOREIGN KEY REFERENCES Customers(CustomerId),
	[DateSaleOrders] DATE,	
	IsActive BIT,
	CreatedBy VARCHAR (MAX),
	CreatedOn DATETIME,
	LastModifiedBy VARCHAR (MAX),
	LastModifiedOn DATETIME
)
GO

CREATE TABLE SaleOrdersDetails
(
	SaleOrdersDetailsId INT PRIMARY KEY IDENTITY(1,1),
	SaleOrdersId INT FOREIGN KEY REFERENCES SaleOrders(SaleOrderId),
	ProductId INT FOREIGN KEY REFERENCES Products(ProductId),
	Quantity INT,
	IsActive BIT,
	CreatedBy VARCHAR (MAX),
	CreatedOn DATETIME,
	LastModifiedBy VARCHAR (MAX),
	LastModifiedOn DATETIME
)
GO

CREATE TABLE Venders
(
	VenderId INT PRIMARY KEY IDENTITY(1,1),
	VendersName VARCHAR(MAX),
	VendersPhone VARCHAR(MAX),
	IsActive BIT,
	CreatedBy VARCHAR (MAX),
	CreatedOn DATETIME,
	LastModifiedBy VARCHAR (MAX),
	LastModifiedOn DATETIME
)
GO

CREATE TABLE VenderProducts
(
	VenderProductId INT PRIMARY KEY IDENTITY(1,1),
	VendersProductPrice VARCHAR(MAX),
	ProductId INT FOREIGN KEY REFERENCES Products(ProductId), 	
IsActive BIT,
	CreatedBy VARCHAR (MAX),
	CreatedOn DATETIME,
	LastModifiedBy VARCHAR (MAX),
	LastModifiedOn DATETIME
)
GO

CREATE TABLE PurchesOrders
(
	PurchesOrderId INT PRIMARY KEY IDENTITY(1,1),
	PurchesOrderDate VARCHAR(MAX),	
	VenderId INT FOREIGN KEY REFERENCES Venders(VenderId), 
	VenderProductId INT FOREIGN KEY REFERENCES VenderProducts(VenderProductId), 
	IsActive BIT,
	CreatedBy VARCHAR (MAX),
	CreatedOn DATETIME,
	LastModifiedBy VARCHAR (MAX),
	LastModifiedOn DATETIME
)
GO

CREATE TABLE PurchesDetails
(
	PurchesDetailId INT PRIMARY KEY IDENTITY(1,1),
	PurchesOrderId INT FOREIGN KEY REFERENCES Venders(VenderId),
	ProductId  INT FOREIGN KEY REFERENCES Products(ProductId),
	Quantity INT,
	IsActive BIT,
	CreatedBy VARCHAR (MAX),
	CreatedOn DATETIME,
	LastModifiedBy VARCHAR (MAX),
	LastModifiedOn DATETIME
)
GO








