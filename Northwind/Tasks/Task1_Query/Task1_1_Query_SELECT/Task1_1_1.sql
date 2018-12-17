DECLARE @Date date = datefromparts (1998, 05, 06)
SELECT OrderID, ShippedDate, ShipVia FROM Northwind.Orders WHERE ShippedDate >= @Date and ShipVia >= 2