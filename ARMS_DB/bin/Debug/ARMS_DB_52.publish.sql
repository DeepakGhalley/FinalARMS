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
The column titleId on table [dbo].[mstTaxPayerProfile] must be changed from NULL to NOT NULL. If the table contains data, the ALTER script may not work. To avoid this issue, you must add values to this column for all rows or mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.
*/

IF EXISTS (select top 1 1 from [dbo].[mstTaxPayerProfile])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
PRINT N'Dropping [dbo].[FK_mstTaxPayer_ToTable_6]...';


GO
ALTER TABLE [dbo].[mstTaxPayerProfile] DROP CONSTRAINT [FK_mstTaxPayer_ToTable_6];


GO
PRINT N'Altering [dbo].[mstTaxPayerProfile]...';


GO
ALTER TABLE [dbo].[mstTaxPayerProfile] ALTER COLUMN [titleId] INT NOT NULL;


GO
PRINT N'Creating [dbo].[FK_mstTaxPayer_ToTable_6]...';


GO
ALTER TABLE [dbo].[mstTaxPayerProfile] WITH NOCHECK
    ADD CONSTRAINT [FK_mstTaxPayer_ToTable_6] FOREIGN KEY ([titleId]) REFERENCES [dbo].[enumTitle] ([titleId]);


GO
PRINT N'Checking existing data against newly created constraints';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[mstTaxPayerProfile] WITH CHECK CHECK CONSTRAINT [FK_mstTaxPayer_ToTable_6];


GO
PRINT N'Update complete.';


GO
