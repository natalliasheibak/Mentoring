SELECT YEAR(OrderDate) AS Year, COUNT(*) AS OrderCount
FROM Northwind.Orders
GROUP BY YEAR(OrderDate)


SELECT Count(*) AS TotalCount
FROM Northwind.Orders