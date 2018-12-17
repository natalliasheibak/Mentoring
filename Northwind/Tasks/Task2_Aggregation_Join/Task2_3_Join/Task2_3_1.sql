SELECT ET.EmployeeID
FROM Northwind.EmployeeTerritories AS ET
	JOIN Northwind.Territories AS T ON ET.TerritoryID = T.TerritoryID
	JOIN Northwind.Region AS R ON T.RegionID = R.RegionID
WHERE R.RegionDescription = 'Western'