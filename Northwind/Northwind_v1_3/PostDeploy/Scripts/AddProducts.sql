IF NOT EXISTS (SELECT ProductID FROM Northwind.Products WHERE ProductID = 61)
BEGIN
INSERT "Products"("ProductID","ProductName","SupplierID","CategoryID","QuantityPerUnit","UnitPrice","UnitsInStock","UnitsOnOrder","ReorderLevel","Discontinued") VALUES(61,'Sirop d''érable',29,2,'24 - 500 ml bottles',28.5,113,0,25,0)
END
IF NOT EXISTS (SELECT ProductID FROM Northwind.Products WHERE ProductID = 62)
BEGIN
INSERT "Products"("ProductID","ProductName","SupplierID","CategoryID","QuantityPerUnit","UnitPrice","UnitsInStock","UnitsOnOrder","ReorderLevel","Discontinued") VALUES(62,'Tarte au sucre',29,3,'48 pies',49.3,17,0,0,0)
IF NOT EXISTS (SELECT ProductID FROM Northwind.Products WHERE ProductID = 63)
BEGIN
INSERT "Products"("ProductID","ProductName","SupplierID","CategoryID","QuantityPerUnit","UnitPrice","UnitsInStock","UnitsOnOrder","ReorderLevel","Discontinued") VALUES(63,'Vegie-spread',7,2,'15 - 625 g jars',43.9,24,0,5,0)
IF NOT EXISTS (SELECT ProductID FROM Northwind.Products WHERE ProductID = 64)
BEGIN
INSERT "Products"("ProductID","ProductName","SupplierID","CategoryID","QuantityPerUnit","UnitPrice","UnitsInStock","UnitsOnOrder","ReorderLevel","Discontinued") VALUES(64,'Wimmers gute Semmelknödel',12,5,'20 bags x 4 pieces',33.25,22,80,30,0)
IF NOT EXISTS (SELECT ProductID FROM Northwind.Products WHERE ProductID = 65)
BEGIN
INSERT "Products"("ProductID","ProductName","SupplierID","CategoryID","QuantityPerUnit","UnitPrice","UnitsInStock","UnitsOnOrder","ReorderLevel","Discontinued") VALUES(65,'Louisiana Fiery Hot Pepper Sauce',2,2,'32 - 8 oz bottles',21.05,76,0,0,0)
IF NOT EXISTS (SELECT ProductID FROM Northwind.Products WHERE ProductID = 66)
BEGIN
INSERT "Products"("ProductID","ProductName","SupplierID","CategoryID","QuantityPerUnit","UnitPrice","UnitsInStock","UnitsOnOrder","ReorderLevel","Discontinued") VALUES(66,'Louisiana Hot Spiced Okra',2,2,'24 - 8 oz jars',17,4,100,20,0)
IF NOT EXISTS (SELECT ProductID FROM Northwind.Products WHERE ProductID = 67)
BEGIN
INSERT "Products"("ProductID","ProductName","SupplierID","CategoryID","QuantityPerUnit","UnitPrice","UnitsInStock","UnitsOnOrder","ReorderLevel","Discontinued") VALUES(67,'Laughing Lumberjack Lager',16,1,'24 - 12 oz bottles',14,52,0,10,0)
IF NOT EXISTS (SELECT ProductID FROM Northwind.Products WHERE ProductID = 68)
BEGIN
INSERT "Products"("ProductID","ProductName","SupplierID","CategoryID","QuantityPerUnit","UnitPrice","UnitsInStock","UnitsOnOrder","ReorderLevel","Discontinued") VALUES(68,'Scottish Longbreads',8,3,'10 boxes x 8 pieces',12.5,6,10,15,0)
IF NOT EXISTS (SELECT ProductID FROM Northwind.Products WHERE ProductID = 69)
BEGIN
INSERT "Products"("ProductID","ProductName","SupplierID","CategoryID","QuantityPerUnit","UnitPrice","UnitsInStock","UnitsOnOrder","ReorderLevel","Discontinued") VALUES(69,'Gudbrandsdalsost',15,4,'10 kg pkg.',36,26,0,15,0)
IF NOT EXISTS (SELECT ProductID FROM Northwind.Products WHERE ProductID = 70)
BEGIN
INSERT "Products"("ProductID","ProductName","SupplierID","CategoryID","QuantityPerUnit","UnitPrice","UnitsInStock","UnitsOnOrder","ReorderLevel","Discontinued") VALUES(70,'Outback Lager',7,1,'24 - 355 ml bottles',15,15,10,30,0)
END