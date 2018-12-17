SELECT * 
FROM Northwind.Customers AS C
WHERE NOT EXISTS (SELECT *
					FROM Northwind.Orders AS O
					WHERE C.CustomerID = O.CustomerID)
