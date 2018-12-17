SELECT E1.EmployeeID AS Employee, CONCAT(E1.FirstName, ' ', E2.LastName) AS EmployeeName, E2.EmployeeID AS Employer, CONCAT(E2.FirstName, ' ', E2.LastName) AS EmployerName
FROM Northwind.Employees AS E1, Northwind.Employees AS E2
WHERE E1.ReportsTo = E2.EmployeeID
