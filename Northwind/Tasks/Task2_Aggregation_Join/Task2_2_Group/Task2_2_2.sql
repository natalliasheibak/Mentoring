SELECT EmployeeID,
	(SELECT CONCAT(LastName, ' ', FirstName)
	FROM Northwind.Employees AS E
	WHERE E.EmployeeID = O.EmployeeID) AS Seller, Count(*) AS Amount
FROM Northwind.Orders AS O
GROUP BY EmployeeID
ORDER BY Amount
