﻿SELECT ContactName, Country
FROM Northwind.Customers
WHERE Country IN ('USA', 'Canada')
ORDER BY Country, ContactName