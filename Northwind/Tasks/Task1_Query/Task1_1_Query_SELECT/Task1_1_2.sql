SELECT OrderId, 
	CASE WHEN ShippedDate IS NULL THEN 'Not Shipped' 
	ELSE CONVERT(NVARCHAR, ShippedDate) END AS Shipped 
FROM Northwind.Orders WHERE ShippedDate IS NULL