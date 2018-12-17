SELECT *
FROM (SELECT EmployeeID, COUNT(*) AS Amount
	FROM Northwind.Orders
	GROUP BY EmployeeID) AS O
WHERE O.Amount > 150