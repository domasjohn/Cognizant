CREATE DATABASE Cognizant
GO

CREATE TABLE Warehouse(
	ID varchar(255),
	Name varchar(255),
	Location varchar(255),
	Make varchar(255),
	Model varchar(255),
	Year_Model varchar(255),
	Price varchar(255),
	Licensed varchar(255),
	Date_Added varchar(255)
);
GO

Declare @JSON varchar(max)
SELECT @JSON=BulkColumn
FROM OPENROWSET (BULK 'C:\Users\domas\Desktop\warehouses.json', SINGLE_CLOB) import
INSERT INTO Warehouse
SELECT 
	C._id AS 'ID',
	A.name AS 'Name',
	B.location AS 'Location',
	C.make AS 'Make',
	C.model AS 'Model',
	C.year_model AS 'Year_Model',
	C.price AS 'Price',
	C.licensed AS 'Licensed',
	C.date_added AS 'Date_Added'
FROM OPENJSON (@JSON)
	WITH (
		_id			varchar(255),
		name		varchar(255),
		[location]	nvarchar(MAX) as JSON,
		[cars]		nvarchar(MAX) as JSON
	) as A
CROSS APPLY OPENJSON(A.location)
	WITH (
		lat			varchar(255),
		long		varchar(255)
	)
CROSS APPLY OPENJSON(A.cars)
	WITH (
		location	varchar(255),
		[vehicles]	nvarchar(MAX) as JSON
	) as B
CROSS APPLY OPENJSON(B.vehicles)
	WITH (
		_id			varchar(255),
		make		varchar(255),
		model		varchar(255),
		year_model	varchar(255),
		price		varchar(255),
		licensed	varchar(255),
		date_added	varchar(255)
	) as C