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
	) REFERENCES "dbo"."Employees" (
		"EmployeeID"
	),
)
GO