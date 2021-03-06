USE [master]
GO

--CONFIGURING SQL INSTANCE TO ACCEPT ADVANCED OPTIONS
EXEC sp_configure 'show advanced options', 1
RECONFIGURE
GO

--ENABLING USE OF DISTRIBUTED QUERIES
EXEC sp_configure 'Ad Hoc Distributed Queries', 1
RECONFIGURE
GO

USE [master]
GO
--ADD DRIVERS IN SQL INSTANCE
EXEC master.dbo.sp_MSset_oledb_prop N'Microsoft.ACE.OLEDB.12.0', N'AllowInProcess', 1
GO

EXEC master.dbo.sp_MSset_oledb_prop N'Microsoft.ACE.OLEDB.12.0', N'DynamicParameters', 1
GO

