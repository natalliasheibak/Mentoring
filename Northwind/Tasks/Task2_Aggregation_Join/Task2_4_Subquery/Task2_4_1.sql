SELECT CompanyName
FROM Northwind.Suppliers
WHERE SupplierID IN (SELECT SupplierID
					FROM Northwind.Products
					WHERE UnitsInStock = 0)