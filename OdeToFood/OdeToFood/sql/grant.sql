--CREATE LOGIN [IIS APPPOOL\DefaultAppPool] FROM WINDOWS
GO
--USE OdeToFoodDB
GO
--CREATE USER [IIS APPPOOL\DefaultAppPool] FOR LOGIN [IIS APPPOOL\DefaultAppPool]
GO
--EXEC sp_addrolemember 'db_datareader', 'IIS APPPOOL\DefaultAppPool'
GO
--EXEC sp_addrolemember 'db_datawriter', 'IIS APPPOOL\DefaultAppPool'
GO
