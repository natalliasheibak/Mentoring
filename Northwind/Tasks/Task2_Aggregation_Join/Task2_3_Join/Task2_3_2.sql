SELECT C.CustomerID, Count(O.OrderID) AS Amount
FROM Northwind.Customers AS C LEFT JOIN Northwind.Orders AS O 
ON C.CustomerID = O.CustomerID
GROUP BY C.CustomerID
ORDER BY Amount