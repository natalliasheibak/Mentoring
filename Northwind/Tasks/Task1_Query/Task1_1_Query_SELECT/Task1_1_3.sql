DECLARE @Date date = datefromparts (1998, 05, 06)
SELECT OrderID AS [Order Number],
	CASE WHEN ShippedDate IS NULL THEN 'Not Shipped' 
	ELSE CONVERT(NVARCHAR, ShippedDate) END AS [Shipped Date]
FROM Northwind.Orders 
WHERE ShippedDate >= @Date OR ShippedDate IS NULL
