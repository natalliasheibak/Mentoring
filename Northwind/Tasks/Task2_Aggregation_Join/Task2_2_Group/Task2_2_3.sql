SELECT EmployeeID, CustomerID, COUNT(*) AS Amount
FROM Northwind.Orders
WHERE YEAR(OrderDate) = 1998
GROUP BY EmployeeID, CustomerID
