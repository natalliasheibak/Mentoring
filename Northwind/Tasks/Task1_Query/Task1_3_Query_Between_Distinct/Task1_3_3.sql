SELECT CustomerId, Country 
FROM Northwind.Customers 
WHERE Country >= 'B%' AND Country < 'H' 
ORDER BY Country