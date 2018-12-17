SELECT E.EmployeeID, C.CustomerID, C.City
FROM Northwind.Employees AS E, Northwind.Customers AS C
WHERE E.City = C.City