use AdventureWorks

SELECT ProductModelID, Name FROM Production.ProductModel 
WHERE ProductModelID=122 or ProductModelID=119 FOR XML RAW

SELECT ProductModelID, Name
FROM Production.ProductModel
WHERE ProductModelID=122 or ProductModelID=119
FOR XML RAW('Model');

SELECT ProductModelID, Name
FROM Production.ProductModel
WHERE ProductModelID=122 or ProductModelID=119
FOR XML RAW('Model'), ROOT('Models');

SELECT pm.ProductModelID, pm.Name AS ProductModel,
       p.Name AS ProductName
FROM Production.ProductModel AS pm
INNER JOIN Production.Product AS p
ON pm.ProductModelID = p.ProductModelID 
WHERE pm.ProductModelID=122 or pm.ProductModelID=119
FOR XML AUTO;

SELECT 1 AS Tag, NULL AS Parent,
       ProductID AS [Product!1!ProductID],
       Color AS [Product!1!Color!Element]
FROM Production.Product 
ORDER BY ProductID
FOR XML EXPLICIT;

SELECT ProductModelID,
       Name
FROM Production.ProductModel
WHERE ProductModelID IN (119,122)
FOR XML PATH ('ProductModel');
GO
SELECT ProductModelID AS "@ProductModelID",
       Name
FROM Production.ProductModel
WHERE ProductModelID IN (119,122)
FOR XML PATH ('ProductModel');
GO

SELECT Customer.CustomerID, Customer.TerritoryID, 
       (SELECT SalesOrderID, [Status]
        FROM Sales.SalesOrderHeader AS soh
        WHERE Customer.CustomerID = soh.CustomerID
        FOR XML AUTO, TYPE) as Orders
FROM Sales.Customer as Customer
WHERE EXISTS
  (SELECT 1 FROM Sales.SalesOrderHeader AS soh
   WHERE soh.CustomerID = Customer.CustomerID)				
ORDER BY Customer.CustomerID;

----demonstration 5 

CREATE TRIGGER TR_DATABASE_DDL_TRACKING
ON DATABASE FOR DDL_DATABASE_LEVEL_EVENTS
AS
  DECLARE @PostTime datetime2 = EVENTDATA().value('(/EVENT_INSTANCE/PostTime)[1]','datetime2');
  DECLARE @LoginName sysname = EVENTDATA().value('(/EVENT_INSTANCE/LoginName)[1]','sysname');
  DECLARE @TSQLCommand nvarchar(max) = EVENTDATA().value('(/EVENT_INSTANCE/TSQLCommand/CommandText)[1]','nvarchar(max)');
  
  PRINT 'DDL Event Occurred';
  PRINT @LoginName;
  PRINT 'executed';
  PRINT @TSQLCommand;
  PRINT 'at';
  PRINT @PostTime;

CREATE TABLE TestTable (TestTableID int);
GO
DROP TABLE TestTable;
GO

DROP TRIGGER TR_DATABASE_DDL_TRACKING ON DATABASE;

CREATE TRIGGER TR_DDL_ProcNamingConvention
ON DATABASE
FOR CREATE_PROCEDURE
AS 
BEGIN
  SET NOCOUNT ON;

  DECLARE @EventData xml;
  DECLARE @ObjectName sysname;
	
  SET @EventData = EVENTDATA();
  SET @ObjectName = @EventData.value('(/EVENT_INSTANCE/ObjectName)[1]','sysname');
	
  IF @ObjectName LIKE 'sp%'
  BEGIN
	PRINT '--------------- Database Coding Standards -----------------';
	PRINT CONCAT(' Stored Procedure Name: ', @ObjectName);
    PRINT ' Stored Procedure names are not permitted to start with sp';
	PRINT '-----------------------------------------------------------';
    ROLLBACK TRAN;
  END;
END;


CREATE PROC GetVersion AS SELECT @@VERSION;

--not created bcz in sp name starts with sp prefix not create
CREATE PROC sp_GetVersion AS SELECT @@VERSION;

DROP PROC GetVersion;


CREATE TRIGGER TR_DDL_CREATE_TABLE_PK
ON DATABASE
FOR CREATE_TABLE,ALTER_TABLE 
AS BEGIN
  SET NOCOUNT ON;

  DECLARE @EventData xml;
  DECLARE @SchemaName sysname;
  DECLARE @ObjectName sysname;
  DECLARE @FullName nvarchar(max);

  SET @EventData = EVENTDATA();
  SET @SchemaName = @EventData.value('(/EVENT_INSTANCE/SchemaName)[1]','sysname');
  SET @ObjectName = @EventData.value('(/EVENT_INSTANCE/ObjectName)[1]','sysname') ;
  SET @FullName = QUOTENAME(@SchemaName)+'.'+QUOTENAME(@ObjectName);

  IF OBJECTPROPERTY(OBJECT_ID(@FullName),'TableHasPrimaryKey') <> 1
  BEGIN
	PRINT '--------------- Database Coding Standards -----------------';
	PRINT CONCAT(' HasPrimaryKey: ', OBJECTPROPERTY(OBJECT_ID(@FullName),'TableHasPrimaryKey'));
    PRINT ' Table needs to be created with at least a Primary Key';
	PRINT '-----------------------------------------------------------';
    ROLLBACK TRAN;
  END;
END;

--not created with primary key trigger is fired
CREATE TABLE dbo.ValueList
( ValueListID int IDENTITY(1,1),
  Value decimal(18,2)
);

DROP TRIGGER TR_DDL_ProcNamingConvention
ON DATABASE;
GO

DROP TRIGGER TR_DDL_CREATE_TABLE_PK
ON DATABASE;

--demonstration 6 
USE AdventureWorks;

SELECT * FROM dbo.DatabaseLog;

SELECT EventDetail.value('PostTime[1]','datetime2') AS PostTime,
       EventDetail.value('SPID[1]', 'int') AS SPID,
       EventDetail.value('ObjectType[1]','sysname') AS ObjectType,
       EventDetail.value('ObjectName[1]','sysname') AS ObjectName
FROM dbo.DatabaseLog AS dl
CROSS APPLY dl.XmlEvent.nodes('/EVENT_INSTANCE') AS EventInfo(EventDetail)
ORDER BY PostTime;

SELECT dl.DatabaseLogID,
       EventDetail.value('PostTime[1]','datetime2') AS PostTime,
       EventDetail.value('SPID[1]', 'int') AS SPID,
       EventDetail.value('ObjectType[1]','sysname') AS ObjectType,
       EventDetail.value('ObjectName[1]','sysname') AS ObjectName,
       dl.TSQL 
FROM dbo.DatabaseLog AS dl
CROSS APPLY dl.XmlEvent.nodes('/EVENT_INSTANCE') AS EventInfo(EventDetail)
ORDER BY PostTime;

DECLARE @xmldoc AS int, @xml AS xml;
SELECT @xml=XmlEvent FROM dbo.DatabaseLog;
SELECT @xml;

EXEC sp_xml_preparedocument @xmldoc OUTPUT, @xml; 
 
SELECT * FROM OPENXML(@xmldoc, '/EVENT_INSTANCE', 2)
WITH (
  [PostTime] datetime2
, [SPID] int 
, [ObjectType] sysname
, [ObjectName] sysname
); 
 
EXEC sp_xml_removedocument @xmldoc;
