IF NOT EXISTS (SELECT CustomerID FROM Northwind.Customers WHERE CustomerID = 'TRADH')
BEGIN
INSERT "Customers" VALUES('TRADH','Tradição Hipermercados','Anabela Domingues','Sales Representative','Av. Inês de Castro, 414','Sao Paulo','SP','05634-030','Brazil','(11) 555-2167','(11) 555-2168')
END
IF NOT EXISTS (SELECT CustomerID FROM Northwind.Customers WHERE CustomerID = 'TRAIH')
BEGIN
INSERT "Customers" VALUES('TRAIH','Trail''s Head Gourmet Provisioners','Helvetius Nagy','Sales Associate','722 DaVinci Blvd.','Kirkland','WA','98034','USA','(206) 555-8257','(206) 555-2174')
END
IF NOT EXISTS (SELECT CustomerID FROM Northwind.Customers WHERE CustomerID = 'VAFFE')
BEGIN
INSERT "Customers" VALUES('VAFFE','Vaffeljernet','Palle Ibsen','Sales Manager','Smagsloget 45','Århus',NULL,'8200','Denmark','86 21 32 43','86 22 33 44')
END
IF NOT EXISTS (SELECT CustomerID FROM Northwind.Customers WHERE CustomerID = 'VICTE')
BEGIN
INSERT "Customers" VALUES('VICTE','Victuailles en stock','Mary Saveley','Sales Agent','2, rue du Commerce','Lyon',NULL,'69004','France','78.32.54.86','78.32.54.87')
END
IF NOT EXISTS (SELECT CustomerID FROM Northwind.Customers WHERE CustomerID = 'VINET')
BEGIN
INSERT "Customers" VALUES('VINET','Vins et alcools Chevalier','Paul Henriot','Accounting Manager','59 rue de l''Abbaye','Reims',NULL,'51100','France','26.47.15.10','26.47.15.11')
END
IF NOT EXISTS (SELECT CustomerID FROM Northwind.Customers WHERE CustomerID = 'WANDK')
BEGIN
INSERT "Customers" VALUES('WANDK','Die Wandernde Kuh','Rita Müller','Sales Representative','Adenauerallee 900','Stuttgart',NULL,'70563','Germany','0711-020361','0711-035428')
END
IF NOT EXISTS (SELECT CustomerID FROM Northwind.Customers WHERE CustomerID = 'WARTH')
BEGIN
INSERT "Customers" VALUES('WARTH','Wartian Herkku','Pirkko Koskitalo','Accounting Manager','Torikatu 38','Oulu',NULL,'90110','Finland','981-443655','981-443655')
END
IF NOT EXISTS (SELECT CustomerID FROM Northwind.Customers WHERE CustomerID = 'WELLI')
BEGIN
INSERT "Customers" VALUES('WELLI','Wellington Importadora','Paula Parente','Sales Manager','Rua do Mercado, 12','Resende','SP','08737-363','Brazil','(14) 555-8122',NULL)
END
IF NOT EXISTS (SELECT CustomerID FROM Northwind.Customers WHERE CustomerID = 'WHITC')
BEGIN
INSERT "Customers" VALUES('WHITC','White Clover Markets','Karl Jablonski','Owner','305 - 14th Ave. S. Suite 3B','Seattle','WA','98128','USA','(206) 555-4112','(206) 555-4115')
END
IF NOT EXISTS (SELECT CustomerID FROM Northwind.Customers WHERE CustomerID = 'WILMK')
BEGIN
INSERT "Customers" VALUES('WILMK','Wilman Kala','Matti Karttunen','Owner/Marketing Assistant','Keskuskatu 45','Helsinki',NULL,'21240','Finland','90-224 8858','90-224 8858')
END