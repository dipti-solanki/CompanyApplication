USE tempdb;

CREATE FUNCTION dbo.fnEndOfPreviousMonth (@DateToTest date)
RETURNS date
AS BEGIN
  RETURN DATEADD(day, 0 - DAY(@DateToTest), @DateToTest);
END;

select dbo.fnEndofPreviousMonth(SYSDATETIME())
select dbo.fnEndOfPreviousMonth('2018-02-08')

SELECT OBJECTPROPERTY(OBJECT_ID('dbo.fnEndOfPreviousMonth'),'IsDeterministic');
DROP FUNCTION dbo.fnEndOfPreviousMonth;

CREATE FUNCTION dbo.fnEndOfPreviousMonth (@DateToTest date)
RETURNS date
AS BEGIN
  RETURN EOMONTH ( dateadd(month, -1, @DateToTest ));
END;

select dbo.fnEndofPreviousMonth(SYSDATETIME())
select dbo.fnEndOfPreviousMonth('2018-02-08')
DROP FUNCTION dbo.fnEndOfPreviousMonth;


USE AdventureWorks;


CREATE FUNCTION Sales.fnGetLastOrdersForCustomer 
(@CustomerID int, @NumberOfOrders int)
RETURNS TABLE
AS
RETURN (SELECT TOP(@NumberOfOrders) soh.SalesOrderID,soh.OrderDate,soh.PurchaseOrderNumber FROM Sales.SalesOrderHeader AS soh
WHERE soh.CustomerID = @CustomerID
ORDER BY soh.OrderDate DESC);
	
SELECT * FROM Sales.fnGetLastOrdersForCustomer(18754,3);

SELECT c.CustomerID,
             c.AccountNumber,
             glofc.SalesOrderID,
             glofc.OrderDate 
FROM Sales.Customer AS c
CROSS APPLY Sales.fnGetLastOrdersForCustomer(c.CustomerID,2) AS glofc
ORDER BY c.CustomerID,glofc.SalesOrderID;

drop function Sales.fnGetLastOrdersForCustomer