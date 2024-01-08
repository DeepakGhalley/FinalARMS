﻿/*
Deployment script for tt_db

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "tt_db"
:setvar DefaultFilePrefix "tt_db"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
/*
The type for column standardConsumption in table [dbo].[tblWaterMeterReading] is currently  INT NULL but is being changed to  DECIMAL (18, 2) NULL. Data loss could occur and deployment may fail if the column contains data that is incompatible with type  DECIMAL (18, 2) NULL.
*/

IF EXISTS (select top 1 1 from [dbo].[tblWaterMeterReading])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
PRINT N'Altering [dbo].[tblWaterMeterReading]...';


GO
ALTER TABLE [dbo].[tblWaterMeterReading] ALTER COLUMN [standardConsumption] DECIMAL (18, 2) NULL;


GO
PRINT N'Creating [dbo].[FK_tblWaterMeterReading_ToTable]...';


GO
ALTER TABLE [dbo].[tblWaterMeterReading] WITH NOCHECK
    ADD CONSTRAINT [FK_tblWaterMeterReading_ToTable] FOREIGN KEY ([waterConnectionId]) REFERENCES [dbo].[mstWaterConnection] ([waterConnectionId]);


GO
PRINT N'Checking existing data against newly created constraints';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[tblWaterMeterReading] WITH CHECK CHECK CONSTRAINT [FK_tblWaterMeterReading_ToTable];


GO
PRINT N'Update complete.';


GO
