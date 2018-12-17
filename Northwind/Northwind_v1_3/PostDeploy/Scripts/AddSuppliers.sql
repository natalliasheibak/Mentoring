IF NOT EXISTS (SELECT SupplierID FROM Northwind.Suppliers WHERE SupplierID = 21)
BEGIN
INSERT "Suppliers"("SupplierID","CompanyName","ContactName","ContactTitle","Address","City","Region","PostalCode","Country","Phone","Fax","HomePage") VALUES(21,'Lyngbysild','Niels Petersen','Sales Manager','Lyngbysild Fiskebakken 10','Lyngby',NULL,'2800','Denmark','43844108','43844115',NULL)
END
IF NOT EXISTS (SELECT SupplierID FROM Northwind.Suppliers WHERE SupplierID = 22)
BEGIN
INSERT "Suppliers"("SupplierID","CompanyName","ContactName","ContactTitle","Address","City","Region","PostalCode","Country","Phone","Fax","HomePage") VALUES(22,'Zaanse Snoepfabriek','Dirk Luchte','Accounting Manager','Verkoop Rijnweg 22','Zaandam',NULL,'9999 ZZ','Netherlands','(12345) 1212','(12345) 1210',NULL)
END
IF NOT EXISTS (SELECT SupplierID FROM Northwind.Suppliers WHERE SupplierID = 23)
BEGIN
INSERT "Suppliers"("SupplierID","CompanyName","ContactName","ContactTitle","Address","City","Region","PostalCode","Country","Phone","Fax","HomePage") VALUES(23,'Karkki Oy','Anne Heikkonen','Product Manager','Valtakatu 12','Lappeenranta',NULL,'53120','Finland','(953) 10956',NULL,NULL)
END
IF NOT EXISTS (SELECT SupplierID FROM Northwind.Suppliers WHERE SupplierID = 24)
BEGIN
INSERT "Suppliers"("SupplierID","CompanyName","ContactName","ContactTitle","Address","City","Region","PostalCode","Country","Phone","Fax","HomePage") VALUES(24,'G''day, Mate','Wendy Mackenzie','Sales Representative','170 Prince Edward Parade Hunter''s Hill','Sydney','NSW','2042','Australia','(02) 555-5914','(02) 555-4873','G''day Mate (on the World Wide Web)#http://www.microsoft.com/accessdev/sampleapps/gdaymate.htm#')
END
IF NOT EXISTS (SELECT SupplierID FROM Northwind.Suppliers WHERE SupplierID = 25)
BEGIN
INSERT "Suppliers"("SupplierID","CompanyName","ContactName","ContactTitle","Address","City","Region","PostalCode","Country","Phone","Fax","HomePage") VALUES(25,'Ma Maison','Jean-Guy Lauzon','Marketing Manager','2960 Rue St. Laurent','Montréal','Québec','H1J 1C3','Canada','(514) 555-9022',NULL,NULL)
END
IF NOT EXISTS (SELECT SupplierID FROM Northwind.Suppliers WHERE SupplierID = 26)
BEGIN
INSERT "Suppliers"("SupplierID","CompanyName","ContactName","ContactTitle","Address","City","Region","PostalCode","Country","Phone","Fax","HomePage") VALUES(26,'Pasta Buttini s.r.l.','Giovanni Giudici','Order Administrator','Via dei Gelsomini, 153','Salerno',NULL,'84100','Italy','(089) 6547665','(089) 6547667',NULL)
END
IF NOT EXISTS (SELECT SupplierID FROM Northwind.Suppliers WHERE SupplierID = 27)
BEGIN
INSERT "Suppliers"("SupplierID","CompanyName","ContactName","ContactTitle","Address","City","Region","PostalCode","Country","Phone","Fax","HomePage") VALUES(27,'Escargots Nouveaux','Marie Delamare','Sales Manager','22, rue H. Voiron','Montceau',NULL,'71300','France','85.57.00.07',NULL,NULL)
END
IF NOT EXISTS (SELECT SupplierID FROM Northwind.Suppliers WHERE SupplierID = 28)
BEGIN
INSERT "Suppliers"("SupplierID","CompanyName","ContactName","ContactTitle","Address","City","Region","PostalCode","Country","Phone","Fax","HomePage") VALUES(28,'Gai pâturage','Eliane Noz','Sales Representative','Bat. B 3, rue des Alpes','Annecy',NULL,'74000','France','38.76.98.06','38.76.98.58',NULL)
END
IF NOT EXISTS (SELECT SupplierID FROM Northwind.Suppliers WHERE SupplierID = 29)
BEGIN
INSERT "Suppliers"("SupplierID","CompanyName","ContactName","ContactTitle","Address","City","Region","PostalCode","Country","Phone","Fax","HomePage") VALUES(29,'Forêts d''érables','Chantal Goulet','Accounting Manager','148 rue Chasseur','Ste-Hyacinthe','Québec','J2S 7S8','Canada','(514) 555-2955','(514) 555-2921',NULL)
END