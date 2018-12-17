IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Northwind.Regions')
BEGIN
USE Northwind;   
EXEC sp_rename 'Northwind.Region', 'Northwind.Regions'; 
END

IF NOT EXISTS (SELECT * 
				FROM sys.columns as c, sys.tables as t 
				WHERE c.name = 'FoundationDate' 
				AND c.object_id = t.object_id 
				AND t.name = 'Customers')
BEGIN
ALTER TABLE Northwind.Customers
	ADD "FoundationYear" DATETIME NULL
END
