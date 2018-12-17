SELECT CustomerId, Country 
FROM Northwind.Customers 
WHERE Country BETWEEN 'B%' AND 'H' 
ORDER BY Country