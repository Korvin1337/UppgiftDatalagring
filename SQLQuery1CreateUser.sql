CREATE LOGIN user2 WITH PASSWORD = 'pass';
CREATE USER user2 FOR LOGIN user2;
ALTER ROLE db_owner ADD MEMBER user2;
USE master;
GO


-- Attach the database
CREATE DATABASE [LocalDatabase3]
GO

USE LocalDatabase3;
GO

SELECT name
FROM sys.databases;
GO

