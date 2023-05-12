USE [master]
GO

/* For security reasons the login is created disabled and with a random password. */
/****** Object:  Login [usersa]    Script Date: 11/05/2023 23:00:50 ******/
CREATE LOGIN [usersa] WITH PASSWORD=N'usersa', DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO

ALTER LOGIN [usersa] DISABLE
GO

ALTER SERVER ROLE [sysadmin] ADD MEMBER [usersa]
GO

ALTER SERVER ROLE [securityadmin] ADD MEMBER [usersa]
GO

ALTER SERVER ROLE [serveradmin] ADD MEMBER [usersa]
GO

ALTER SERVER ROLE [setupadmin] ADD MEMBER [usersa]
GO

ALTER SERVER ROLE [processadmin] ADD MEMBER [usersa]
GO

ALTER SERVER ROLE [diskadmin] ADD MEMBER [usersa]
GO

ALTER SERVER ROLE [dbcreator] ADD MEMBER [usersa]
GO

ALTER SERVER ROLE [bulkadmin] ADD MEMBER [usersa]
GO


