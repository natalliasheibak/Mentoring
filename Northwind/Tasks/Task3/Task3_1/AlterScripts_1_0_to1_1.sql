IF NOT EXISTS (SELECT * FROM sys.objects
	WHERE OBJECT_ID = OBJECT_ID(N'[dbo].[CreditCard]') AND type IN (N'U'))
BEGIN
CREATE TABLE "CreditCard" (
	"CreditCardNumber" "int" IDENTITY (1, 1) NOT NULL ,
	"EmployeeID" nvarchar (40) NOT NULL ,
	"ExpireDate" datetime NOT NULL ,
	CONSTRAINT "PK_CreditCardNumber" PRIMARY KEY  CLUSTERED 
	(
		"CreditCardNumber"
	),
	CONSTRAINT "FK_CreditCard_Employees" FOREIGN KEY 
	(
		"EmployeeID"
	) 
	REFERENCES "dbo"."Employees" (
		"EmployeeID"
	),
)
END